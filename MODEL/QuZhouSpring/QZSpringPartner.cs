using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 合作方信息
    /// </summary>
   public class QZSpringPartner
    {
       public virtual Guid Id { get; set; }
       //合作商代码
       public virtual string FriendlyId { get; set; }
       //名称
       public virtual string Name { get; set; }
       /// <summary>
       /// 请求源IP
       /// </summary>
       public virtual string RequestSource { get; set; }
       //是否启用
       public virtual bool Enable { get; set; }
    }
}
