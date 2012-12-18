using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 团队工作人员:导游 和 司机
    /// </summary>
    public class DJ_Group_Worker
    {
        
        public virtual Guid Id { get; set; }
        /// <summary>
        /// 员工
        /// </summary>
        public virtual DJ_Workers DJ_Workers { get; set; }

        /// <summary>
        /// 冗余字段
        /// </summary>
        public virtual string RD_WorkerName { get; set; }
        public virtual string RD_WorkerIdCard { get; set; }
        public virtual string RD_Phone { get; set; }
        /// <summary>
        /// 所属团队. 简单起见,做成多对一的关系.
        /// </summary>
        public virtual DJ_TourGroup DJ_TourGroup { get; set; }
        
    }

}
