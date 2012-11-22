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

        public IList<Model.DJ_Workers> GetWorkers8Multy(string id, string name, string idcard, string SpecificIdCard,
            int WorkerType, DJ_DijiesheInfo DJ_DijiesheInfo, string CompanyBelong)
        {
            return dalworkers.GetWorkers8Multy(id, name, idcard, SpecificIdCard, WorkerType, DJ_DijiesheInfo, CompanyBelong);
        }
    }
}
