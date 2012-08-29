using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDAL;
using NHibernate;

namespace DAL
{
    public class DALArea : DalBase, IArea
    {
        public IList<Model.Area> GetArea(int areaid)
        {
            string sqlstr = "select a from Area a where a.Code like '" + areaid + "__00'";
            IQuery query = session.CreateQuery(sqlstr);

            return query.Future<Model.Area>().ToList<Model.Area>();
        }
        public Model.Area GetAreaByAreaid(int areaid)
        {
            IQuery query = session.CreateQuery("select a from Area a where a.Id=" + areaid + "");
            return query.FutureValue<Model.Area>().Value;
        }

        public Model.Area GetAreaByAreaname(string areaname)
        {
            IQuery query = session.CreateQuery("select a from Area a where a.Name='" + areaname + "'");
            return query.FutureValue<Model.Area>().Value;
        }

        public Model.Area GetAreaBySeoName(string seoName)
        {
            IQuery query = session.CreateQuery("select a from Area a where a.SeoName='" + seoName + "'");
            return query.FutureValue<Model.Area>().Value;
        }

        public IList<Model.Area> GetSubArea(string areacode)
        {
            string sql = "";
            //开始2位编号
            string bCode = areacode.Substring(0, 2);
            //中间2位编号
            string mCode = areacode.Substring(2, 2);
            //最后2位编号
            string lCode = areacode.Substring(4, 2);
            //查询编号
            string searchCode;
            if (mCode == "00")
            {
                //查找市级区域单位
                searchCode = bCode + "__00";
                sql = "select a from Area a where a.Code like '" + searchCode
                    + "' and a.Code<>'" + bCode + "0000'";
            }
            //else if (lCode == "00")
            //{
            //    //查找市内区、县级区域单位(并排除市和辖区)
            //    searchCode = bCode + mCode + "__";
            //    sql = "select u from Unit u where u.Area.Code like '" + searchCode
            //        + "' AND u.Area.Code<>'" + bCode + mCode
            //        + "00' AND u.Area.Code<>'"
            //        + bCode + mCode + "01' ";
            //}
            if (string.IsNullOrEmpty(sql)) return null;
            IQuery query = session.CreateQuery(sql);
            return query.Future<Model.Area>().ToList<Model.Area>();
        }

        public IList<Model.Area> GetAreaProvince()
        {
            string strQuery = "select a from Area a where a.Code like '__0000'";
            IQuery query = session.CreateQuery(strQuery);
            return query.Future<Model.Area>().ToList<Model.Area>();
        }
    }
}
