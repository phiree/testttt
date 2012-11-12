using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using IDAL;
using DAL;

namespace BLL
{
    public class BLLDJ_GovManageDepartment:BLLBase<DJ_GovManageDepartment>
    {
        DALDJ_GovManageDepartment Idepart = new DALDJ_GovManageDepartment();

        public void Save(DJ_GovManageDepartment obj)
        {
            Idepart.Save(obj);
        }

        /// <summary>
        /// 获取管理部门
        /// </summary>
        /// <param name="name">部门名称</param>
        /// <returns></returns>
        public IList<DJ_GovManageDepartment> GetGovDptByName(string name)
        {
            return Idepart.GetGovDptByName(name);
        }

        public DJ_GovManageDepartment GetById(Guid id)
        {
            return Idepart.GetById(id);
        }

        /// <summary>
        /// 获取子管理部门
        /// </summary>
        /// <param name="code">区域编号</param>
        /// <returns>管理部门列表</returns>
        public IList<DJ_GovManageDepartment> GetSubDptByCode(string code)
        {
            return Idepart.GetSubDptByCode(code);
        }
    }
}
