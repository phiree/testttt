using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDAL
{
    public interface IDJRoute
    {
        //预报时间
        IList<Model.DJ_Product> GetPdByTimeandTEId(DateTime time,Guid teid);
    }
}
