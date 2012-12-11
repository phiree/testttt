using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using Model;

namespace DAL
{
    public class DALDJ_Recommand:DalBase<DJ_Recommand>
    {
        public DJ_Recommand GetByGovId(DJ_GovManageDepartment gov)
        {
            string sql = "select re from DJ_Recommand re where re.DJ_GovManageDepartment.Id='" + gov.Id + "'";
            return GetOneByQuery(sql);
        }
    }
}
