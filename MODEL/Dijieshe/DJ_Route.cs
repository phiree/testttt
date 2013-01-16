
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 行程信息
    /// </summary>
    public class DJ_Route:DJ_ProductRoute
    {

        public virtual DJ_TourGroup DJ_TourGroup { get; set; }
        public virtual void CopyTo(DJ_Route newRoute)
        {
            newRoute.DayNo = DayNo;
            newRoute.Enterprise = Enterprise;
            newRoute.Description = Description;
            newRoute.RD_EnterpriseName = RD_EnterpriseName;

        }

    }
}
