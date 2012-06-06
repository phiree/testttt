using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace IDAL
{
    public interface IScenicImg
    {
        void SaveOrUpdate(ScenicImg si);
        IList<ScenicImg> GetSiByType(Scenic scenic, int type);
        ScenicImg GetSiBySiid(int siid);
    }
}
