using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Vote
    {
        public virtual int Id { get; set; }
        public virtual string IdCard { get; set; }
        public virtual Scenic Scenic { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual int Num { get; set; }
        public virtual string Type { get; set; }
        public virtual DateTime Time { get; set; }
        public virtual string Note { get; set; }
        public virtual bool IsEffect { get; set; }
        public virtual Guid TourMembershipId { get; set; }
    }
}
