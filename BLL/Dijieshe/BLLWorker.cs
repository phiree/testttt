﻿using System;
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

        /// <summary>
        /// 更新worker
        /// </summary>
        /// <param name="worker"></param>
        public void UpdateWorkers(Model.DJ_Workers worker)
        {
            dalworkers.Update(worker);
        }
    }
}