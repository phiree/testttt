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

        public IList<Model.Scenic> GetScenic()
        {
            return IScenic.GetScenic();
        }
        public Scenic GetScenicBySeoName(string seoName)
        {
            return IScenic.GetScenicBySeoName(seoName);
        }
        public IList<Model.Ticket> GetScenicByScenicPosition(string position)
        {
            return IScenic.GetScenicByScenicPosition(position);
        }

        public IList<Model.Ticket> GetScenicByScenicName(string scenicname, string level, int areaid)
        {
            return IScenic.GetScenicByScenicName(scenicname, level, areaid);
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
                list = new BLLTicket().GetTicketByAreaId(areaid);
            }
            else
                list = new BLLTicket().GetTicketByscId(scid);
            foreach (Ticket item in list)
            {
                Model.ScenicTicket s = new ScenicTicket();
                s.Scenic = item.Scenic;
                s.Ticket = item;
                IList<TicketPrice> tp = new BLLTicketPrice().GetTicketPriceByScenicId(item.Scenic.Id);
                foreach (TicketPrice items in tp)
                {
                    switch (items.PriceType)
                    {
                        case PriceType.Normal:
                            s.Price1 = items.Price;
                            break;

                        case PriceType.PayOnline: s.Price2 = items.Price; break;

                        case PriceType.PreOrder: s.Price3 = items.Price; break;
                        case PriceType.PostCardDiscount: s.Price4 = items.Price; break;
                        case PriceType.DigitalPostCardDiscount: s.Price5 = items.Price; break;
                    }

                }
                ScenicTicket.Add(s);
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
