using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class DJ_Workers
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Phone { get; set; }
        public virtual string IDCard { get; set; }
        public virtual string SpecificIdCard { get; set; }
        public virtual DJ_GroupWorkerType WorkerType { get; set; }
        public virtual DJ_DijiesheInfo DJ_Dijiesheinfo { get; set; }
        public virtual string CompanyBelong { get; set; }
    }
    public enum DJ_GroupWorkerType
    {
        导游 = 1,
        司机
    }
}
