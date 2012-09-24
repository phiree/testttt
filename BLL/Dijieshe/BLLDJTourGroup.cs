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
    }
}
