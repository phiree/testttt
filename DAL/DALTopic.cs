using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using Model;

namespace DAL
{
    public class DALTopic : DalBase, IDAL.ITopic
    {
        public IList<Model.ScenicTopic> GetScenictopic(string areacode)
        {
            string sql = "select st from ScenicTopic st where st.Scenic.Area.Code=" + areacode + "";
            IQuery query = session.CreateQuery(sql);
            return query.Future<Model.ScenicTopic>().ToList<Model.ScenicTopic>();
        }


        public IList<Model.ScenicTopic> GetStByscid(int scid)
        {
            string sql = "select st from ScenicTopic st where st.Scenic.Id=" + scid + "";
            IQuery query = session.CreateQuery(sql);
            return query.Future<Model.ScenicTopic>().ToList<Model.ScenicTopic>();
        }


        public IList<Topic> GetTopicByscid(int scid)
        {
            string sql = "select st.Topic from ScenicTopic st where st.Scenic.Id=" + scid;
            IQuery query = session.CreateQuery(sql);
            return query.Future<Topic>().ToList<Model.Topic>();
        }

        public IList<Model.Topic> GetAllTopics()
        {
            string sql = "select t from Topic t ";
            IQuery query = session.CreateQuery(sql);
            return query.Future<Topic>().ToList<Model.Topic>();
        }


        public Topic GetTopicByName(string name)
        {
            string sql = "select t from Topic t where t.Name='" + name + "'";
            IQuery query = session.CreateQuery(sql);
            return query.FutureValue<Topic>().Value;
        }

        public Topic GetTopicBySeoname(string seoname)
        {
            //string sql = "select t from Topic t where t.seoname='" + seoname + "'";
            //IQuery query = session.CreateQuery(sql);
            //return query.FutureValue<Topic>().Value;
            string sql = "select top 1 id,name,seoname from Topic t where t.seoname=:seoname";
            IQuery query = session.CreateSQLQuery(sql)
                .SetParameter("seoname", seoname);
            var result=query.UniqueResult<object[]>();
            if (result != null)
            {
                return new Topic()
                {
                    Id = Guid.Parse(result[0].ToString()),
                    Name = result[1].ToString(),
                    seoname = result[2].ToString()
                };
            }
            else
            {
                return null;
            }
        }

        public void SaveScenictopic(IList<string> topicname, Scenic scenic)
        {
            IList<Topic> tlist = GetAllTopics();
            IList<ScenicTopic> stlist = GetStByscid(scenic.Id);
            if (stlist.Count > 0)
            {
                foreach (var item in stlist)
                {
                    session.Delete(item);
                }
            }
            ScenicTopic st;
            foreach (string item in topicname)
            {
                var tmp = tlist.Where(x => x.Name == item.Trim()).First();
                st = new ScenicTopic()
                {
                    Scenic = scenic,
                    Topic = tmp
                };
                using (var t = session.BeginTransaction())
                {
                    session.SaveOrUpdate(st);
                    t.Commit();
                }
            }
        }


        public IList<ScenicTopic> GetStByTopicid(Guid topid)
        {
            string sql = "select st from ScenicTopic st where st.Topic.Id='" + topid + "'";
            IQuery query = session.CreateQuery(sql);
            return query.Future<ScenicTopic>().ToList<ScenicTopic>();
        }


        public void SaveTopic(string topicname, string topicseo)
        {
            Topic t;
            if (string.IsNullOrWhiteSpace(topicseo))
            {
                t = new Topic() { Name = topicname };
            }
            else
            {
                t = new Topic() { Name = topicname, seoname = topicseo };
            }
            using (var tr = session.BeginTransaction())
            {
                session.Save(t);
                tr.Commit();
            }
        }

        public void SaveTopic(List<string> topicnames)
        {
            foreach (var item in topicnames)
            {
                if (GetTopicByName(item) == null)
                {
                    SaveTopic(item, null);
                }
            }
        }

        public void SaveTopic(List<string> topicnames, List<string> topicseos)
        {
            Topic topic;
            try
            {
                for (int i = 0; i < topicnames.Count; i++)
                {
                    topic = GetTopicByName(topicnames[i]);
                    if (topic == null)
                    {
                        SaveTopic(topicnames[i], topicseos[i]);
                    }
                    else
                    {
                        topic.seoname = topicseos[i];
                        UpdateTopic(topic);
                    }
                }
            }
            catch (Exception e)
            {
                e = new Exception("景区表格式.xls中景区主题和topicseo对应不完整，请检查！");
                throw e;
            }
        }

        public void UpdateTopic(Topic topic)
        {
            using (var t = session.BeginTransaction())
            {
                session.Update(topic);
                t.Commit();
            }
        }

        public void DelTopic(Topic topic)
        {
            using (var trans = session.BeginTransaction())
            {
                string sql = "delete ScenicTopic st where st.Topic.Id=:topicid";
                IQuery query = session.CreateQuery(sql);
                query.SetParameter("topicid", topic.Id);
                query.ExecuteUpdate();
                session.Delete(topic);
                trans.Commit();
            }
        }

    }
}
