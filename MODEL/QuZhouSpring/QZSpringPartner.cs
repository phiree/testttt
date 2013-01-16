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
       public Guid Id { get; set; }
       //合作商代码
       public string FriendlyId{get;set;}
       //名称
       public string Name { get; set; }
       /// <summary>
       /// 请求源IP
       /// </summary>
       public string RequestSource { get; set; }
       //是否启用
       public bool Enable { get; set; }
    }
}
