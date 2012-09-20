using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using IDAL;
using Model;

namespace BLL
{
    public class BLLScenicImg
    {
        IScenicImg Isi = new DALScenicImg();

        public void SaveOrUpdate(Model.ScenicImg si)
        {
            Isi.SaveOrUpdate(si);
        }

        public IList<Model.ScenicImg> GetSiByType(Model.Scenic scenic, int type)
        {
            return Isi.GetSiByType(scenic, type);
        }

        public ScenicImg GetSiBySiid(int siid)
        {
            return Isi.GetSiBySiid(siid);
        }
    }
}
