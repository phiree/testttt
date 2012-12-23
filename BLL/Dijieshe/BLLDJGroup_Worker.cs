using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using IDAL;

namespace BLL
{
    public class BLLDJGroup_Worker
    {
        BLLWorker bllWorker = new BLLWorker();
        #region field
        DAL.DALDJ_Group_Worker dalworker;

        public DALDJ_Group_Worker DalWorker
        {
            get
            {
                if (dalworker == null)
                    dalworker = new DALDJ_Group_Worker();
                return dalworker;
            }
            set { dalworker = value; }
        }
        #endregion

        #region worker relationship
        public void SaveData(string name, string phone, string idcard, string othercard
            , string companyBelong
            , Model.DJ_GroupWorkerType type, Model.DJ_DijiesheInfo djs, out string message)
        {
            message = string.Empty;
            var result = Get8Multi(null, name, null, idcard, null, type, null, null);
            if (result.Count > 0)
            {
                message = "该成员已存在!";
                return;
            }
            //Model.DJ_Group_Worker worker = new Model.DJ_Group_Worker() { 
            //    Name=name,
            //    Phone=phone,
            //    IDCard=idcard,
            //    SpecificIdCard=othercard,
            //    WorkerType=type,
            //    DJ_Dijiesheinfo=djs,
            //    CompanyBelong=companyBelong
            //};
            Model.DJ_Workers worker = new Model.DJ_Workers()
            {
                Name = name,
                Phone = phone,
                IDCard = idcard,
                SpecificIdCard = othercard,
                WorkerType = type,
                DJ_Dijiesheinfo = djs,
                CompanyBelong = companyBelong
            };
            bllWorker.Save(worker);
        }

        public void UpdateData(Model.DJ_Group_Worker worker)
        {
            DalWorker.Update(worker);
        }
        public void Save(Model.DJ_Group_Worker worker)
        {
            DalWorker.Save(worker);
        }

        public Model.DJ_Group_Worker GetByIdCard(string idcard)
        {
            return DalWorker.GetByIdCard(idcard);
        }

        public IList<Model.DJ_Group_Worker> Get8Multi(string id, string name, string phone, string idcard,
            string specificidcard, object memtype, string gid, string djsid)
        {
            return DalWorker.Get8Multi(id, name, phone, idcard, specificidcard, memtype, gid, djsid);
        }

        public IList<Model.DJ_Group_Worker> GetWorkersForGroup(Model.DJ_TourGroup group,Model.DJ_GroupWorkerType type)
        {
            return Get8Multi(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, type, group.Id.ToString(), string.Empty);
        }
        public Model.DJ_Group_Worker Get(Guid id)
        {
            return DalWorker.GetById(id);
        }
        public void DeleteFromGroup(Model.DJ_TourGroup group)
        {
            //团队里的worker关系
          IList<Model.DJ_Group_Worker> gws=  DalWorker.Get8Multi(string.Empty, 
                string.Empty, 
                string.Empty,
                string.Empty,
                string.Empty,
                null,
                group.Id.ToString(),
                string.Empty);
          //if (gws.Count >= 1)
          //{
          //    DalWorker.Delete(gws[0]);
          //}
          foreach (Model.DJ_Group_Worker gw in gws)
          {
              
            DalWorker.Delete(gw);
          }
        }
        #endregion
    }
}
