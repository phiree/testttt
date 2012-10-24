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

        public Model.DJ_Group_Worker GetByIdCard(string idcard)
        {
            return Idj_group_worker.GetByIdCard(idcard);
        }
    }
}
