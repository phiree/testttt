using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using IDAL;
using Model;

namespace DAL
{
    public class DALScenicAdmin:DalBase,IScenicAdmin
    {

        public Model.ScenicAdmin GetScenicAdminByScidandtype(int scid, int type)
        {
            string sql = "select sa from ScenicAdmin sa where sa.Scenic.Id=" + scid + " and AdminType=" + type + "";
            IQuery query = session.CreateQuery(sql);
            return query.FutureValue<ScenicAdmin>().Value;
        }


        public void SaveOrUpdate(ScenicAdmin sa)
        {
            using (var x=session.Transaction)
            {
                x.Begin();
                session.SaveOrUpdate(sa);
                x.Commit();
            }
        }
    }
}
