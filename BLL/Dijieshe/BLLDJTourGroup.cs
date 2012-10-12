using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDAL;
using DAL;

namespace BLL
{
    public class BLLDJTourGroup
    {
        IDJTourGroup Idjtourgroup = new DALDJTourGroup();

        public IList<Model.DJ_TourGroup> GetTourGroupByGuideIdcard(string idcard)
        {
            return Idjtourgroup.GetTourGroupByGuideIdcard(idcard);
        }

        public Model.DJ_TourGroup GetTourGroupById(Guid id)
        {
            return Idjtourgroup.GetTourGroupById(id);
        }

        public IList<Model.DJ_Group_Worker> GetTourGroupByTEId(int id)
        {
            List<Model.DJ_TourGroup> listTg= Idjtourgroup.GetTourGroupByTEId(id).ToList();
            List<Model.DJ_Group_Worker> listGw = new List<Model.DJ_Group_Worker>();
            List<Model.DJ_Group_Worker> listGw2 = new List<Model.DJ_Group_Worker>();
            foreach (Model.DJ_TourGroup tg in listTg)
            {
                listGw.AddRange(tg.Workers.Where(x => x.WorkerType == Model.DJ_GroupWorkerType.导游).ToList<Model.DJ_Group_Worker>());
            }
            foreach (IGrouping<Guid, Model.DJ_Group_Worker> item in listGw.GroupBy(x => x.Id).ToDictionary(x => x.Key).Values)
	        {
                listGw2.Add(new DALDJ_Group_Worker().GetById(item.Key));
	        }
            return listGw2;
            
        }
        public Model.DJ_TourGroup GetTgByproductid(Guid proid)
        {
            return Idjtourgroup.GetTgByproductid(proid);
        }

        /// <summary>
        /// 查找当天的团队
        /// </summary>
        /// <param name="idcard">导游身份证号</param>
        /// <param name="TE">管理部门</param>
        /// <returns></returns>
        public IList<Model.DJ_TourGroup> GetTgByIdcardAndTE(string idcard, Model.DJ_TourEnterprise TE)
        {
            List<Model.DJ_TourGroup> ListTg= Idjtourgroup.GetTgByIdcardAndTE(idcard, TE).ToList();
            List<Model.DJ_TourGroup> ListTyTg = new List<Model.DJ_TourGroup>();
            foreach (Model.DJ_TourGroup Tg in ListTg)
            {
                DateTime dtBegin = Tg.BeginDate;
                foreach (Model.DJ_Route route in Tg.Routes)
                {
                    if (dtBegin.AddDays(route.DayNo).ToShortDateString() == DateTime.Now.ToShortDateString()&&route.Enterprise.Id==TE.Id)
                    {
                        ListTyTg.Add(Tg);
                    }
                }
            }
            return ListTyTg;
        }
        /// <summary>
        /// 查找当天该景区的导游信息
        /// </summary>
        /// <param name="TE"></param>
        /// <returns></returns>
        public IList<Model.DJ_Group_Worker> GetGuiderWorkerByTE(Model.DJ_TourEnterprise TE)
        {
            return Idjtourgroup.GetGuiderWorkerByTE(TE).Where(x => x.WorkerType == Model.DJ_GroupWorkerType.导游).ToList<Model.DJ_Group_Worker>();
        }

    }
}
