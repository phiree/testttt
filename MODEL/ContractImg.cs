using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ContractImg
    {
        public virtual int Id { get; set; }
        public virtual Scenic Scenic { get; set; }
        public virtual string Imgloc { get; set; }
        public virtual ScenicModule ScenicModule { get; set; }
    }
}
