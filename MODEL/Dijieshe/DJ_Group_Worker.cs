using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 团队工作人员:导游 和 司机
    /// </summary>
    public class DJ_Group_Worker
    {
        
        public virtual Guid Id { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public virtual string Name { get; set; }

        public virtual string Phone { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        public virtual string IDCard { get; set; }

        /// <summary>
        /// 工作证件号码: 导游证号,驾驶证号
        /// </summary>
        public virtual string SpecificIdCard { get; set; }

        public virtual DJ_GroupWorkerType WorkerType { get; set; }

        /// <summary>
        /// 所属团队. 简单起见,做成多对一的关系.
        /// </summary>
        public virtual DJ_TourGroup DJ_TourGroup { get; set; }
        public virtual DJ_DijiesheInfo DJ_Dijiesheinfo { get; set; }
        public virtual string CompanyBelong { get; set; }
       
    }
    public enum DJ_GroupWorkerType
    { 
        导游=1,
        司机
    }
}
