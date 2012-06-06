using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ContractScenicPrice
    {
        public virtual int Id { get; set; }
        public virtual Scenic Scenic { get; set; }
        public virtual string PriceContract { get; set; }
    }
}
