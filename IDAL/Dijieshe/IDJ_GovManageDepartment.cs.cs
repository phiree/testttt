using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace IDAL
{
    public interface IDJ_GovManageDepartment
    {
        IList<DJ_GovManageDepartment> GetGovDptByName(string name);
    }
}
