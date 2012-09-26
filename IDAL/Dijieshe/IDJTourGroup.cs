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
    }
}
