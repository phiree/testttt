using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace IDAL
{
    public interface IDJTourGroup
    {
        IList<DJ_TourGroup> GetTourGroupByGuideIdcard(string idcard);
        DJ_TourGroup GetTourGroupById(Guid id);
        IList<DJ_TourGroup> GetTourGroupByTEId(Guid id);
        Model.DJ_TourGroup GetTgByproductid(Guid proid);
    }
}
