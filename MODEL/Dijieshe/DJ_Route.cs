
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 行程信息
    /// </summary>
    public class DJ_Route
    {
        public virtual Guid Id { get; set; }

        /// <summary>
        /// 第几天.
        /// </summary>
        public virtual int DayNo { get; set; }

        public virtual DJ_TourEnterprise Enterprise { get; set; }

        public virtual string Description { get; set; }

        public virtual DJ_TourGroup DJ_TourGroup { get; set; }
        public virtual void CopyTo(DJ_Route newRoute)
        {
            newRoute.DayNo = DayNo;
            newRoute.Enterprise = Enterprise;
            newRoute.Description = Description;

        }

    }
}
