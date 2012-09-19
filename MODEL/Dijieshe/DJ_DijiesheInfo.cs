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
        }
       
        /// <summary>
        /// 该地接社登记过的旅游团
        /// </summary>
        public virtual IList<DJ_TourGroup> Groups { get; set; }
    }
}
