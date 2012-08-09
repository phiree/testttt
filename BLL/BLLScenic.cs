using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDAL;
using Model;

namespace BLL
{
    public class BLLScenic
    {
        IDAL.IScenic iscenic;
        public IScenic IScenic
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
        IDAL.ITicket iticket;
        public IDAL.ITicket ITicket
        {
            get {
                if (iticket == null)
                {
                    iticket = new DAL.DALTicket();
                }
                return iticket;
            }
            set {
                iticket = value;
            }
        }
        IDAL.ITicketPrice iticketprice;
        public IDAL.ITicketPrice ITicketprice
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

        public IList<Model.Scenic> GetScenicByScenicName(string scenicname, string level, int areaid,string topic)
        {
            return IScenic.GetScenicByScenicName(scenicname, level, areaid,topic);
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

        public List<Model.ScenicTicket> GetScenicTicket(int areaid, int scid)
        {
            List<Model.ScenicTicket> ScenicTicket = new List<ScenicTicket>();
            IList<Ticket> list;
            if (scid == 0)
            {
                list = iticket.GetTicketByAreaId(areaid);
            }
            else
                list = iticket.GetTicketByscId(scid);
            foreach (Ticket item in list)
            {
                Model.ScenicTicket st = new ScenicTicket();
                st.Scenic = item.Scenic;
                st.Ticket = item;
                IList<TicketPrice> tp = ITicketprice.GetTicketPriceByScenicId(item.Scenic.Id);
                foreach (TicketPrice items in tp)
                {
                    switch (items.PriceType)
                    {
                        case PriceType.Normal:
                            st.Price1 = items.Price;
                            break;

                        case PriceType.PayOnline: st.Price2 = items.Price; break;

                        case PriceType.PreOrder: st.Price3 = items.Price; break;
                        case PriceType.PostCardDiscount: st.Price4 = items.Price; break;
                        case PriceType.DigitalPostCardDiscount: st.Price5 = items.Price; break;
                    }

                }
                ScenicTicket.Add(st);
            }
            return ScenicTicket;
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
            ScenicCheckProgress scp=new ScenicCheckProgress();
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
        public void ChangeCheckStatus(Scenic scenic, TourMembership checker, ScenicModule module,CheckStatus cs)
        {
            ScenicCheckProgress scp = GetStatus(scenic.Id, module);
            if (scp.CheckStatus != CheckStatus.Applied)
            {
                ErrHandler.Redirect(ErrType.UnknownError);
            }
            scp.CheckStatus = cs;
            IScenic.SaveCheckProgress(scp);
            if (module == ScenicModule.SellOnLine)
            {
                IList<Ticket> tickets=ITicket.GetTicketByscId(scenic.Id);
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
