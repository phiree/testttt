using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
namespace BLL
{
    public class BLLDijiesheInfo
    {
        IDAL.IDijieshe daldjs = new DAL.DALDijieshe();

        #region DJS

        public Guid AddDjs()
        { 
            
        }

        public IList<DJ_DijiesheInfo> GetDjs8all()
        {
            return daldjs.GetDJS8All();
        }
        #endregion

        #region group

        /// <summary>
        /// 添加团队基本信息
        /// </summary>
        public Guid AddBasicinfo(DJ_DijiesheInfo djs, string gname, DateTime gbdate, DateTime gedate, int gdays, int adults, int children)
        {
            DJ_TourGroup tg = new DJ_TourGroup();
            tg.Dijieshe = djs;
            tg.Name = gname;
            tg.BeginDate = gbdate;
            tg.EndDate = gedate;
            tg.DaysAmount = gdays;
            tg.AdultsAmount = adults;
            tg.ChildrenAmount = children;
            return daldjs.AddGroup(tg);
        }

        #endregion
    }
}
