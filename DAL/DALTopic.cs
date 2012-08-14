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
            string sql = "select t from Topic t where t.seoname='" + seoname + "'";
            IQuery query = session.CreateQuery(sql);
            return query.FutureValue<Topic>().Value;
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


        public void SaveTopic(string topicname)
        {
            Topic t = new Topic() { Name = topicname };
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
                    SaveTopic(item);
                }
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
