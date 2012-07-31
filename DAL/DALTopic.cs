using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

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
    }
}
