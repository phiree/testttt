using System;
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

        public virtual DateTime BeginTime { get; set; }

        public virtual DateTime EndTime { get; set; }

        public virtual DJ_TourEnterprise Enterprice { get; set; }

        public virtual string Description { get; set; }
    }
}
