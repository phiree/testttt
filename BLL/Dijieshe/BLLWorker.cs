using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace BLL
{
    public class BLLWorker
    {
        public DAL.DALWorkers dalworkers = new DAL.DALWorkers();

        /// <summary>
        /// 对worker列表的多重查询
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        /// <param name="idcard"></param>
        /// <param name="specificidcard"></param>
        /// <param name="memtype"></param>
        /// <param name="djsid"></param>
        /// <returns></returns>
        public IList<Model.DJ_Workers> GetWorkers8Multi(string id, string name, string phone, string idcard,
            string specificidcard, object memtype, string djsid)
        {
            return dalworkers.Get8Multi(id, name, phone, idcard, specificidcard, memtype, djsid);
        }

        public void Save(Model.DJ_Workers worker)
        {
            dalworkers.Save(worker);
        }
        public bool Save(string name, string phone, string idcardno,
            string specialidcard, string belong,
            DJ_GroupWorkerType workertype,DJ_DijiesheInfo currentDjs, out string errMsg)
        {
            bool result = true ;
            errMsg = string.Empty;
            var workers = GetWorkers8Multi(string.Empty, name, phone, idcardno, string.Empty, workertype, currentDjs.Id.ToString());
            if (workers.Count > 0)
            {
                result = false;
                errMsg = "此工作人员已录入，不能重复添加";
            }
            else
            {
                DJ_Workers worker = new DJ_Workers();
                worker.CompanyBelong = belong;
                worker.DJ_Dijiesheinfo = currentDjs;
                worker.IDCard = idcardno;
                worker.Name = name;
                worker.Phone = phone;
                worker.SpecificIdCard = specialidcard;
               worker.WorkerType= workertype;
               Save(worker);
            }
            return result;
        }
        public DJ_Workers GetOne(Guid id)
        {
            return dalworkers.GetOne(id);
        }

        /// <summary>
        /// 更新worker
        /// </summary>
        /// <param name="worker"></param>
        public void UpdateWorkers(Model.DJ_Workers worker)
        {
            dalworkers.Update(worker);
        }
        public void Delete(Model.DJ_Workers worker)
        {
            dalworkers.Delete(worker);
        }
        public void DeleteDjsWorks(string dijiesheId)
        {
            IList<DJ_Workers> workers = dalworkers.Get8Multi(string.Empty, string.Empty, string.Empty, string.Empty,
                string.Empty, null, dijiesheId);
            foreach (DJ_Workers worker in workers)
            {
                Delete(worker);
            }
        }
    }
}
