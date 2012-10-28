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
        IDAL.IDJ_GovManageDepartment Idepart = new DALDJ_GovManageDepartment();

        public IList<DJ_GovManageDepartment> GetGovDptByName(string name)
        {
            return Idepart.GetGovDptByName(name);
        }
    }
}
