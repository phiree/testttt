
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
        public virtual int BeginTime { get; set; }

        public virtual int EndTime { get; set; }

        public virtual DJ_TourEnterprise Enterprise { get; set; }

        public virtual string Description { get; set; }

        public virtual DJ_TourGroup TourGroup { get; set; }
    /// <summary>
    /// 在目标地点干嘛: 用餐/游览/集合/购物
    /// </summary>
        public virtual string Behavior { get; set; }

        public virtual DJ_Product DJ_Product { get; set; }

        
    }
}
