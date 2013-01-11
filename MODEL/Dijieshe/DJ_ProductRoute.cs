
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    ///  线路产品.
    /// </summary>
    public class DJ_ProductRoute
    {
        public virtual Guid Id { get; set; }

        /// <summary>
        /// 第几天.
        /// </summary>
        public virtual int DayNo { get; set; }

        public virtual DJ_TourEnterprise Enterprise { get; set; }
        //冗余字段
        public virtual string RD_EnterpriseName { get; set; }

        public virtual string Description { get; set; }

        

    }
}
