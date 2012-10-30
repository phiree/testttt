using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace DAL
{
    public class DALDJ_Group_Worker:DalBase,IDAL.IDJ_Group_Worker
    {

        public IList<Model.DJ_TourGroup> GetTgListByIdcard(string idcard)
        {
            string sql = "select gw.DJ_TourGroup from DJ_TourGroupMember gw where gw.IdCardNo='" + idcard + "'";
            IQuery query = session.CreateQuery(sql);
            return query.Future<Model.DJ_TourGroup>().ToList<Model.DJ_TourGroup>();
        }




        public Model.DJ_Group_Worker GetById(Guid id)
        {
            return session.Get<Model.DJ_Group_Worker>(id);
        }


        public Model.DJ_Group_Worker GetByIdCard(string idcard)
        {
            string sql = "select gw from DJ_TourGroupMember gw where gw.IdCardNo='" + idcard + "'";
            IQuery query = session.CreateQuery(sql);
            return query.FutureValue<Model.DJ_Group_Worker>().Value;
        }
    }
}
