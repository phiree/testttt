using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace IDAL
{
    public interface IScenicAdmin
    {
        ScenicAdmin GetScenicAdminByScidandtype(int scid, int type);
        void SaveOrUpdate(ScenicAdmin sa);
    }
}
