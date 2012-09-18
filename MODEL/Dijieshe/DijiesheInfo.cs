using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 地接社信息
    /// </summary>
    public class DijiesheInfo
    {

        public DijiesheInfo()
        {
            Groups = new List<TourGroup>();
        }
        public virtual Guid Id { get; set; }
        public virtual DijiesheInfo Dijieshe { get; set; }
        public virtual string Name { get; set; }

        public virtual string Address { get; set; }
        /// <summary>
        /// 负责人姓名
        /// </summary>
        public virtual string ChargePersonName { get; set; }
        public virtual string ChargePersonPhone { get; set; }
        public virtual string Phone { get; set; }
        /// <summary>
        /// 该地接社登记过的旅游团
        /// </summary>
        public virtual IList<TourGroup> Groups { get; set; }
    }
}
