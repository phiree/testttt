using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 地接社信息
    /// </summary>
    public class DJ_DijiesheInfo:DJ_TourEnterprise
    {

        public DJ_DijiesheInfo()
        {
            Groups = new List<DJ_TourGroup>();
            Works = new List<DJ_Workers>();
        }

        public virtual IList<DJ_Workers> Drivers { get {
            return Works.Where(x => x.WorkerType == DJ_GroupWorkerType.司机).ToList();
        } }
        public virtual IList<DJ_Workers> Guides
        {
            get
            {
                return Works.Where(x => x.WorkerType == DJ_GroupWorkerType.导游).ToList();
            }
        }
        public virtual IList<DJ_Workers> Works { get; set; }


       
        /// <summary>
        /// 该地接社登记过的旅游团
        /// </summary>
        public virtual IList<DJ_TourGroup> Groups { get; set; }
    }
}
