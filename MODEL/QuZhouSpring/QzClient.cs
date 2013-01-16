using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 请求接口的网站
    /// </summary>
   public class QzClient
    {
       public Guid Id { get; set; }
       public string FriendlyId{get;set;}
       public string Name { get; set; }
       /// <summary>
       /// 请求源IP
       /// </summary>
       public string RequestSource { get; set; }
       public bool Enable { get; set; }
    }
}
