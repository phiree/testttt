using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using Model;

namespace DAL
{
    public class DALTopic : DalBase,IDAL.ITopic
    {
        public IList<Model.ScenicTopic> GetScenictopic(string areacode)
        {
            string sql = "select st from ScenicTopic st where st.Scenic.Area.Code=" + areacode + "";
            IQuery query = session.CreateQuery(sql);
            return query.Future<Model.ScenicTopic>().ToList<Model.ScenicTopic>();
        }


        public Model.ScenicTopic GetStByscid(int scid)
        {
            string sql = "select st from ScenicTopic st where st.Scenic.Id=" + scid + "";
            IQuery query = session.CreateQuery(sql);
            return query.FutureValue<ScenicTopic>().Value;
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


        public IList<Topic> GetTopicByName(string name)
        {
            string sql = "select t from Topic t where t.Name='" + name + "'";
            IQuery query = session.CreateQuery(sql);
            return query.Future<Topic>().ToList<Topic>();
        }
    }
}
