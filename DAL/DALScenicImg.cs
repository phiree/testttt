using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDAL;
using NHibernate;
using Model;

namespace DAL
{
    public class DALScenicImg:DalBase,IScenicImg
    {

        public void SaveOrUpdate(Model.ScenicImg si)
        {
            using (var x=session.Transaction)
            {
                x.Begin();
                session.SaveOrUpdate(si);
                x.Commit();
            }
        }


        public IList<Model.ScenicImg> GetSiByType(Model.Scenic scenic, int type)
        {
            string sql = "select si from ScenicImg si where si.Scenic.Id=" + scenic.Id + " and ImgType=" + type + "";
            IQuery query = session.CreateQuery(sql);
            return query.Future<ScenicImg>().ToList<ScenicImg>();
        }


        public ScenicImg GetSiBySiid(int siid)
        {
            string sql = "select si from ScenicImg si where si.Id=" + siid + "";
            IQuery query = session.CreateQuery(sql);
            return query.FutureValue<ScenicImg>().Value;
        }
    }
}
