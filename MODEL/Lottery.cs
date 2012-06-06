using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 抽奖机
    /// </summary>
    public class Lottery
    {
        public virtual int Id { get; set; }
        public virtual string IdCard { get; set; }
    }
}
