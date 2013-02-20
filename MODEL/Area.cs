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
        public virtual string Zipcode { get; set; }

        /// <summary>
        ///行政级别:省,市,区
        /// </summary>
        public virtual AreaLevel Level
        {
            get
            {
                AreaLevel level;
                if (Code.EndsWith("0000"))
                    {
                        level = AreaLevel.省;
                    }
                    else if (Code.EndsWith("00"))
                    {
                        level = AreaLevel.市;
                    }
                    else
                    {
                        level = AreaLevel.区县;
                    }
                
                return level;
            }
        }
     
    }
    public enum AreaLevel
    {
        省,
        市,
        区县
    }
}
