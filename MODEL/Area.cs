using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Area
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string SeoName { get; set; }
        public virtual string Code { get; set; }
        public virtual int AreaOrder { get; set; }
        public virtual string MetaDescription { get; set; }
    }
}
