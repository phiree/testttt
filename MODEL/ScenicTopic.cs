using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ScenicTopic
    {
        public virtual Guid Id { get; set; }
        public virtual Topic Topic { get; set; }
        public virtual Scenic Scenic { get; set; }
    }
}
