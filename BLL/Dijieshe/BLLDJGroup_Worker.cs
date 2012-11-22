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
            DalWorker.Save(worker);
        }

        public void UpdateData(Model.DJ_Group_Worker worker)
        {
            DalWorker.Update(worker);
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

        public Model.DJ_Group_Worker Get(Guid id)
        {
            return DalWorker.GetById(id);
        }
        #endregion

        #region workers list
        public IList<Model.DJ_Workers> GetWorkers8Multi(string id, string name, string phone, string idcard,
            string specificidcard, object memtype, string djsid)
        {
            return DalWorker.Get8Multi(id, name, phone, idcard, specificidcard, memtype, djsid);
        }
        public void UpdateWorkers(Model.DJ_Workers worker)
        {
            DalWorker.Update(worker);
        }
        #endregion
    }
}
