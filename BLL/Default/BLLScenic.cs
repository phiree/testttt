using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDAL;
using Model;

namespace BLL
{
    public class BLLScenic:DAL.DalBase
    {
        DAL.DALScenic iscenic;
        public DAL.DALScenic IScenic
        {
            get
            {
                if (iscenic == null)
                {
                    iscenic = new DAL.DALScenic();
                }
                return iscenic;
            }
            set
            {
                iscenic = value;
            }
        }
        DAL.DALTicket iticket;
        public DAL.DALTicket ITicket
        {
            get
            {
                if (iticket == null)
                {
                    iticket = new DAL.DALTicket();
                }
                return iticket;
            }
            set
            {
                iticket = value;
            }
        }
       DAL.DALTicketPrice iticketprice;
       public DAL.DALTicketPrice ITicketprice
        {
            get
            {
                if (iticket == null)
                {
                    iticketprice = new DAL.DALTicketPrice();
                }
                return iticketprice;
            }
            set
            {
                iticketprice = value;
            }
        }
       BLLArea bllArea = new BLLArea();

        public IList<Model.Scenic> GetScenic()
        {
            return IScenic.GetScenic();
        }
        public Scenic GetScenicBySeoName(string seoName)
        {
            return IScenic.GetScenicBySeoName(seoName);
        }
        public IList<Model.Scenic> GetScenicByScenicPosition(string position)
        {
            return IScenic.GetScenicByScenicPosition(position);
        }

        public IList<Model.Scenic> GetScenicByScenicName(string scenicname, string level, int areaid, string topic)
        {
            return IScenic.GetScenicByScenicName(scenicname, level, areaid, topic);
        }

        public IList<ScenicMap> GetScenicMapByCondition(string scenicname, string level, int areaid, string topic)
        {
            return IScenic.GetScenicMapByCondition(scenicname, level, areaid, topic);
        }
        public Scenic GetScenicById(int scid)
        {
            return IScenic.GetScenicById(scid);
        }

        public bool IsSeoExist(string seoname)
        {
            bool result = false;
            return result;
        }

        public IList<Model.Scenic> GetScenicByAreacode(string areacode)
        {
            return IScenic.GetScenicByAreacode(areacode);
        }

        public Scenic GetScrnicByUserName(string username)
        {
            return IScenic.GetScrnicByUserName(username);
        }

        public void UpdateScenicInfo(Scenic scenic)
        {
            IScenic.UpdateScenicInfo(scenic);
        }

        public void UpdateScenicInfo(List<Scenic> slist)
        {
            IScenic.UpdateScenicInfo(slist);
        }


        public ScenicCheckProgress GetStatus(int scenicId, ScenicModule module)
        {
            return IScenic.GetStatus(scenicId, module);
        }

        public IList<ScenicCheckProgress> GetStatus(int scenicID)
        {
            return IScenic.GetStatus(scenicID);
        }

        /// <summary>
        /// 申请开通某个功能
        /// </summary>
        /// <param name="scenic"></param>
        /// <param name="module"></param>
        public void Apply(Scenic scenic, TourMembership applier, ScenicModule module)
        {
            ScenicCheckProgress scp = new ScenicCheckProgress();
            var cplist = scenic.CheckProgress.ToList();
            if (cplist.Count != 0)
            {
                foreach (ScenicCheckProgress item in cplist)
                {
                    if (item.Module == module)
                    {
                        scp = item;
                        continue;
                    }
                }
            }
            scp.Applier = applier;
            scp.CheckStatus = CheckStatus.Applied;
            scp.CheckTime = DateTime.Now;
            scp.Module = module;
            scp.Scenic = scenic;
            IScenic.SaveCheckProgress(scp);
        }
        public void Apply(Scenic scenic, TourMembership applier, ScenicModule module, Guid id)
        {
            ScenicCheckProgress scp = new ScenicCheckProgress();
            var cplist = scenic.CheckProgress.ToList();
            if (cplist.Count != 0)
            {
                foreach (ScenicCheckProgress item in cplist)
                {
                    if (item.Module == module)
                    {
                        scp = item;
                        continue;
                    }
                }
            }
            scp.Applier = applier;
            scp.CheckStatus = CheckStatus.Applied;
            scp.CheckTime = DateTime.Now;
            scp.Module = module;
            scp.Scenic = scenic;
            scp.Id = id;
            IScenic.SaveCheckProgress(scp);
        }
        /// <summary>
        /// 批准某个功能的申请.
        /// </summary>
        /// <param name="scenic"></param>
        /// <param name="checker"></param>
        /// <param name="module"></param>
        public void ChangeCheckStatus(Scenic scenic, TourMembership checker, ScenicModule module, CheckStatus cs)
        {
            ScenicCheckProgress scp = GetStatus(scenic.Id, module);
            if (scp.CheckStatus != CheckStatus.Applied)
            {
                ErrHandler.Redirect(ErrType.UnknownError,"187行");
            }
            scp.CheckStatus = cs;
            IScenic.SaveCheckProgress(scp);
            if (module == ScenicModule.SellOnLine)
            {
                IList<Ticket> tickets = ITicket.GetTicketByscId(scenic.Id);
                foreach (var item in tickets)
                {
                    item.Lock = false;
                }
                ITicket.SaveOrUpdateTicket(tickets);
            }
        }

        public Scenic GetScenicBySeoName(string aseoname, string sseoname)
        {
            return IScenic.GetScenicBySeoName(aseoname, sseoname);
        }
        public IList<Scenic> GetList_Mipang()
        {
            string where = " s.MipangId>0";
            return GetListByConditions(where);
        }
        private IList<Scenic> GetListByConditions(string where)
        {
            List<Scenic> scenicList = new List<Scenic>();

            string sql = "select s from Scenic s where "+where;
            var query = session.CreateQuery(sql);
             scenicList=  query.Future<Scenic>().ToList();

            return scenicList;
        }
        public Scenic GetByMipangId(int mipangId)
        {
            string sql = "select s from Scenic s where s.MipangId=" + mipangId; 
            var query = session.CreateQuery(sql);
            NHibernate.IFutureValue<Scenic> fScenic = query.FutureValue<Scenic>();
            if (fScenic == null) return null;
            else return fScenic.Value;

        }

        public IList<Scenic> BuildScenicListFromIds(string[] ids)
        {
            string strIds = string.Empty;
            foreach (string s in ids)
            {
                strIds += s + ",";
            }
            strIds.TrimEnd(',');
            return IScenic.BuildScenicListFromIds(strIds);

        }
        /// <summary>
        ///构造 景区链接
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string BuildScenicLink(DJ_TourEnterprise s)
        {
          return "/Tickets/" + bllArea.GetAreaByCode(s.Area.Code.Substring(0, 4) + "00").SeoName 
              + "_" + s.Area.SeoName + "/" + s.SeoName + ".html";

        }

        #region Contract

        public void UploadContractImg(ContractImg contractimg)
        {
            IScenic.UploadContractImg(contractimg);
        }

        public ContractImg GetContractImg(int scenicid)
        {
            return IScenic.GetContractImg(scenicid);
        }

        public ScenicCheckProgress GetCheckProgressByscidandmouid(int scid, int module)
        {
            return IScenic.GetCheckProgressByscidandmouid(scid, module);
        }

        public void UpdateCheckState(ScenicCheckProgress scp)
        {
            IScenic.UpdateCheckState(scp);
        }
        #endregion

        #region ScenicImg
        public void SaveScenicimg(List<ScenicImg> silist)
        {
            IScenic.SaveScenicimg(silist);
        }
        public void DeleteScenicimg()
        {
            IScenic.DeleteScenicimg();
        }
        #endregion
    }
}
