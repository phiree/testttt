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
        IDJ_Group_Worker Idj_group_worker = new DALDJ_Group_Worker();
        DAL.DALDJ_Group_Worker dalworker = new DALDJ_Group_Worker();

        public void SaveData(string name, string phone, string idcard, string othercard,
            Model.DJ_GroupWorkerType type,Model.DJ_DijiesheInfo djs,out string message)
        {
            message = string.Empty;
            var result = Get8Multi(null, name, null, idcard, null, type, null, null);
            if (result.Count > 0)
            {
                message = "该成员已存在!";
                return;
            }
            Model.DJ_Group_Worker worker = new Model.DJ_Group_Worker() { 
                Name=name,
                Phone=phone,
                IDCard=idcard,
                SpecificIdCard=othercard,
                WorkerType=type,
                DJ_Dijiesheinfo=djs
            };
            dalworker.Save(worker);
        }

        public void UpdateData(Model.DJ_Group_Worker worker)
        {
            dalworker.Update(worker);
        }

        public Model.DJ_Group_Worker GetByIdCard(string idcard)
        {
            return Idj_group_worker.GetByIdCard(idcard);
        }

        public IList<Model.DJ_Group_Worker> Get8Multi(string id, string name, string phone, string idcard, string specificidcard, object memtype, string gid,string djsid)
        {
            return Idj_group_worker.Get8Multi(id, name, phone, idcard, specificidcard, memtype, gid, djsid);
        }
    }
}
