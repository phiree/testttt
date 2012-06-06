using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;
using IDAL;

namespace BLL
{
    public class BLLScenicAdmin
    {
        IScenicAdmin Iscenicadmin = new DALScenicAdmin();

        public Model.ScenicAdmin GetScenicAdminByScidandtype(int scid, int type)
        {
            return Iscenicadmin.GetScenicAdminByScidandtype(scid, type);
        }

        public void SaveOrUpdate(ScenicAdmin sa)
        {
            Iscenicadmin.SaveOrUpdate(sa);
        }
    }
}
