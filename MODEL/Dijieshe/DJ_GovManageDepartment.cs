using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 旅游管理部门
    /// </summary>
   public class DJ_GovManageDepartment
    {
       public DJ_GovManageDepartment()
       { }
       public virtual Guid Id { get; set; }
       public virtual string Name { get; set; }
       public virtual string Address { get; set; }
       public virtual Area Area { get; set; }
       public virtual string Phone { get; set; }

    }
}
