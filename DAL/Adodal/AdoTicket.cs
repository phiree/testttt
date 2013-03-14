using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DB.Helper;

namespace DAL.Adodal
{
    public class AdoTicket
    {
        public IList<Model.Scenic> GetTicketByAreaIdAndLevel(Model.Area area, int level, string topic, int pageIndex, int pageSize, out int totalRecord)
        {
            totalRecord = 1;
            return null;
            
            //string where = " where IsHide<>true ";
            //if (area != null)
            //{
            //    if (area.Code.Substring(4, 2) == "00")
            //        where += " and  s.Area.Code like '%" + area.Code.Substring(0, 4) + "%'";
            //    else
            //        where += " and s.Area.Id=" + area.Id;
            //}
            //else
            //{
            //    where += " and s.Area.Code like '33%' ";
            //}
            //if (level > 0)
            //{
            //    where += " and s.Level='" + level + "A'";
            //}
            //string order = " order by s.ScenicOrder asc";


            //string fromwhere = " from Scenic s " + where;
            //string strQuery = "select s " + fromwhere + order;
            //string strQueryCount = "select count(*) " + fromwhere;
            //if (topic == null)
            //{
            //    return Search(strQuery, strQueryCount, pageIndex, pageSize, out totalRecord);
            //}
            //else
            //{
            //    string topicsql = "select st from ScenicTopic st where st.Topic.seoname='" + topic + "'";
            //    IQuery query = session.CreateQuery(topicsql);
            //    List<Model.ScenicTopic> listtopic = query.Future<Model.ScenicTopic>().ToList<Model.ScenicTopic>();
            //    query = session.CreateQuery(strQuery);
            //    List<Model.Scenic> list = query.Future<Model.Scenic>().ToList<Model.Scenic>();
            //    var result = from t in listtopic join l in list on t.Scenic.Id equals l.Id select l;
            //    totalRecord = result.ToList<Model.Scenic>().Count;
            //    return result.ToList<Model.Scenic>().Skip(pageIndex * pageSize).Take(pageSize).ToList();
            //}
        }

        private IList<Model.Scenic> Search(string strQuery, string strQueryCount, int pageIndex, int pageSize, out int totalRecord)
        {
            totalRecord=int.Parse(DBHelper.ReturnDataSet(strQueryCount).Tables[0].Rows[0][0].ToString());
            var dt=DBHelper.ReturnDataSet(strQuery).Tables[0];
            List<Model.Scenic> ticketList = new List<Model.Scenic>();
            for (int i = pageIndex * pageSize; i < pageIndex * pageSize+pageSize; i++)
            {
                ticketList.Add(new Model.Scenic() { 
                    Id=int.Parse(dt.Rows[i][""].ToString()),

                });
            }

            return ticketList;
        }
    }
}
