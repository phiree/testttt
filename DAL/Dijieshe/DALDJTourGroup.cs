using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDAL;
using NHibernate;

namespace DAL
{
    public class DALDJTourGroup:DalBase,IDJTourGroup
    {

        public IList<Model.DJ_TourGroup> GetTourGroupByGuideIdcard(string idcard)
        {
            string sql = "select tg from DJ_TourGroup tg where tg.GuideIdCardNo='" + idcard + "'";
            sql += " and '"+DateTime.Now.ToString()+"' between begindate and enddate";
            IQuery query = session.CreateQuery(sql);
            return query.Future<Model.DJ_TourGroup>().ToList<Model.DJ_TourGroup>();
        }


        public Model.DJ_TourGroup GetTourGroupById(Guid id)
        {
            string sql = "select tg from DJ_TourGroup tg where tg.Id='" + id + "'";
            IQuery query = session.CreateQuery(sql);
            return query.FutureValue<Model.DJ_TourGroup>().Value;
        }


        public IList<Model.DJ_TourGroup> GetTourGroupByTEId(int id)
        {
            List<Guid> listDJ_Product_Id = new DALDJProduct().GetListByTEId(id).ToList().GroupBy(x => x.Id).Select(x=>x.Key).ToList();
            List<Model.DJ_TourGroup> ListTg=new List<Model.DJ_TourGroup>();
            foreach (Guid product_id in listDJ_Product_Id)
            {
                Model.DJ_TourGroup tg = GetTgByproductid(product_id);
                if (tg != null)
                {
                    ListTg.Add(tg);
                }
            }
            return ListTg;
        }


        public Model.DJ_TourGroup GetTgByproductid(Guid proid)
        {
            string sql = "select tg from DJ_TourGroup tg where tg.DJ_Product.Id='" + proid + "'";
            sql += " and '" + DateTime.Now.ToString() + "' between begindate and enddate";
            IQuery query = session.CreateQuery(sql);
            return query.FutureValue<Model.DJ_TourGroup>().Value;
        }




        public IList<Model.DJ_TourGroup> GetTgByIdcardAndTE(string idcard, Model.DJ_TourEnterprise TE)
        {
            List<Model.DJ_TourGroup> ListTg = new DAL.DALDJ_Group_Worker().GetTgListByIdcard(idcard).ToList();
            List<Model.DJ_TourGroup> ListSelectTg = new List<Model.DJ_TourGroup>();
            foreach (Model.DJ_TourGroup Tgitem in ListTg)
            {
                if (Tgitem.Routes.Where(x => x.Enterprise.Id == TE.Id).Count() > 0)
                {
                    ListSelectTg.Add(Tgitem);
                }
            }
            return ListSelectTg;
        }
    }
}
