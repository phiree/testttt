using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 抽奖结果
    /// </summary>
    public class LottryResult
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual Lottery Lottery { get; set; }
        public virtual string IdCard { get; set; }
        public virtual DateTime Time { get; set; }
        public virtual bool IsGet { get; set; }
    }
}
