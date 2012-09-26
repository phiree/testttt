using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDAL;
using DAL;

namespace BLL
{
    public class BLLDJTourGroup
    {
        IDJTourGroup Idjtourgroup = new DALDJTourGroup();

        public IList<Model.DJ_TourGroup> GetTourGroupByGuideIdcard(string idcard)
        {
            return Idjtourgroup.GetTourGroupByGuideIdcard(idcard);
        }

        public Model.DJ_TourGroup GetTourGroupById(Guid id)
        {
            return Idjtourgroup.GetTourGroupById(id);
        }

        public IList<Model.DJ_TourGroup> GetTourGroupByTEId(Guid id)
        {
            return Idjtourgroup.GetTourGroupByTEId(id);
        }
        public Model.DJ_TourGroup GetTgByproductid(Guid proid)
        {
            return Idjtourgroup.GetTgByproductid(proid);
        }
    }
}
