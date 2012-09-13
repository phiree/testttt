using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 游客信息
    /// </summary>
    public class TS_VisitorInfo 
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        //身份证号码
        public virtual string CardNo { get; set; }

    }
}
