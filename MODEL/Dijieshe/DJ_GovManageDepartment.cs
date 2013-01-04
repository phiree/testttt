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
       public virtual string seoname { get; set; }
       public virtual string ChargeName { get; set; }
       public virtual string ChargeTel { get; set; }
       public virtual string ChargeEmail { get; set; }
    }
}
//为绑定报表作用
public class month
{
    public month(int monthindex)
    {
        MonthIndex = monthindex;
    }
    private int monthIndex;

    public int MonthIndex
    {
        get { return monthIndex; }
        set { monthIndex = value; }
    }
}