using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;

namespace BLL
{
    public class BLLDJ_Recommand:BLLBase<DJ_Recommand>
    {
        DALDJ_Recommand recommand = new DALDJ_Recommand();

        public DJ_Recommand GetByGovId(DJ_GovManageDepartment gov)
        {
            return recommand.GetByGovId(gov);
        }
    }
}
