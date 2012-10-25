using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using IDAL;
using DAL;

namespace BLL
{
    public class BLLDJ_GovManageDepartment
    {
        DALDJ_GovManageDepartment Idepart = new DALDJ_GovManageDepartment();

        public void Save(DJ_GovManageDepartment obj)
        {
            Idepart.Save(obj);
        }

        public IList<DJ_GovManageDepartment> GetGovDptByName(string name)
        {
            return Idepart.GetGovDptByName(name);
        }

        public DJ_GovManageDepartment GetById(Guid id)
        {
            return Idepart.GetById(id);
        }
    }
}
