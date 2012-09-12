using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 联票 
    /// </summary>
    public class TicketUnion:Ticket
    {
        public TicketUnion()
        {
            Scenics = new List<Scenic>();
        }
        /// <summary>
        /// 包含的景区
        /// </summary>

        public virtual IList<Scenic> Scenics { get; set; }
        
        public override IList<Scenic> GetScenics()
        {
            if (Scenics.Count <= 1)
            {
                throw new Exception("联票对应景区数要大于1");
            }

            return Scenics;
        }
    }
}
