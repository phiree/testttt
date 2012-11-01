using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 操作日志:
    /// 操作人,
    /// 操作时间
    /// 操作对象
    ///操作内容
    ///操作类型
    /// 
    /// </summary>
    public class OperationLog
    {
        public virtual int Id { get; set; }
        
        public virtual TourMembership Member { get; set; }
        public virtual DateTime OperationTime { get; set; }
        /// <summary>
        /// 操作内容
        /// </summary>
        public virtual string Content { get; set; }
        public virtual OperationType OprationType { get; set; }
        /// <summary>
        /// 被操作对象的主键
        /// </summary>
        public virtual string TargetId { get; set; }
    }
    public enum OperationType
    { 
      管理部门管理纳入企业=1
    }
    
}
