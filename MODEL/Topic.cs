using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Topic
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
    }
}
