using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;

namespace BLL
{
    public class BLLTicketAssign:BLLBase<TicketAssign>
    {
        DAL.DALTicketAssign Iticketassign = new DAL.DALTicketAssign();

        /// <summary>
        /// 保存更新
        /// </summary>
        /// <param name="ticketassign"></param>
        public void SaveOrUpdate(TicketAssign ticketassign)
        {
            Iticketassign.SaveOrUpdate(ticketassign);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assignID"></param>
        /// <returns></returns>
        public TicketAssign GetTicketAssignById(Guid assignID)
        {
            return Iticketassign.GetTicketAssignByID(assignID);
        }

        public IList<TicketAssign> GetTicketAssignByUserId(Guid userid)
        {
            return Iticketassign.GetTicketAssignByUserId(userid);
        }
        public IList<TicketAssign> GetTicketAssignByUserId(Guid userid,bool isUsed)
        {
            return Iticketassign.GetTicketAssignByUserId(userid, isUsed);
        }
        public IList<TicketAssign> GetIsUsedCountByAsodid(int odid)
        {
            return Iticketassign.GetIsUsedCountByAsodid(odid);
        }
        public IList<TicketAssign> GetByodid(int odid)
        {
            return Iticketassign.GetByodid(odid);
        }
        public IList<DataTable> GetTicketAssignBynameandidcard(string name, string idcard, Scenic scenic)
        {
            return Iticketassign.GetTicketAssignBynameandidcard(name, idcard, scenic);
        }
        public List<TicketAssign> GetIdcardandname(string name, string idcard, Scenic scenic)
        {
            return Iticketassign.GetIdcardandname(name, idcard, scenic);
        }
        public void GetTicketInfoByIdCard(string idcard, Ticket ticket, out int ydcount, out int usedcount,int type)
        {
            Iticketassign.GetTicketInfoByIdCard(idcard, ticket,out ydcount,out usedcount,type);
        }
        public IList<TicketAssign> GetNotUsedTicketAssign(string idcard, Ticket ticket,int type)
        {
            return Iticketassign.GetNotUsedTicketAssign(idcard, ticket,type);
        }
        public TicketAssign GetLasetRecordByidcard(string idcard, Ticket ticket,int type)
        {
            return Iticketassign.GetLasetRecordByidcard(idcard, ticket,type);
        }
        public void GetOlTicketInfoByIdcard(string idcard, Ticket ticket, out int olcount, out int usedolcount, int type)
        {
            Iticketassign.GetOlTicketInfoByIdcard(idcard, ticket, out olcount, out usedolcount, type);
        }
        public IList<TicketAssign> Getolnotusedticketassign(string idcard, int ticketid, int type)
        {
            return Iticketassign.Getolnotusedticketassign(idcard, ticketid, type);
        }
        public List<TicketAssign> GetUsedRecord(string idcard)
        {
            return Iticketassign.GetUsedRecord(idcard);
        }
        public int GetUsedCount(string idcard, DateTime dt)
        {
            return Iticketassign.GetUsedCount(idcard, dt);
        }

        public int GetUnusedCount(string idcard)
        {
            return Iticketassign.GetUnusedCount(idcard);
        }
        public int GetDdCount(string idcard)
        {
            return Iticketassign.GetDdCount(idcard);
        }
        public List<TicketAssign> GetYwCount(string idcard)
        {
            return Iticketassign.GetYwCount(idcard);
        }
        public IList<TicketAssign> GetTaByIdCard(string idcard)
        {
            return Iticketassign.GetTaByIdCard(idcard);
        }
        public IList<TicketAssign> GetTaByIdcardandscenic(string idcard, Scenic scenic)
        {
            return Iticketassign.GetTaByIdcardandscenic(idcard, scenic);
        }
        public IList<TicketAssign> GetTaByIdcardandTicketCode(string idcard,string ticketCode)
        {

            return Iticketassign.GetTaByIdcardandTicketCode(idcard, ticketCode);
        }
        public IList<Ticket> GetTicketTypeByIdCard(string idcard)
        {
            return Iticketassign.GetTicketTypeByIdCard(idcard);
        }
        /// <summary>
        /// 衢州抢票接口
        /// <dataset>
        ///    <datatable>
        ///     <dr>
        ///       <dt>ScenicName 景区名称</dt> 
        ///       <dt>OrderTime 抢票时间</dt> 
        ///       <dt>IsUsed 是否已使用("true"或者 "false"</dt> 
        ///        <dt>ValidPeriod 有效期限(2013-02-01~2013-02-29)</dt>
        ///     </dr>   
        /// </datatable>
        /// </dataset>
        /// </summary>
        /// <param name="idCardNo"></param>
        /// <returns></returns>
        public DataSet GetTicketsHasProductCode(string idCardNo)
        {
            DataSet ds = new DataSet();
            IList<TicketAssign> gotTotalTicketsOfThisType=
                GetTaByIdCard(idCardNo)
            .Where(x => !string.IsNullOrEmpty(x.OrderDetail.TicketPrice.Ticket.ProductCode))
            .ToList();
            DataTable dt = new DataTable("gotTickets");
            string colScenicName="ScenicName";
            string colProductCode = "ProductCode";
            string colOrderTime="OrderTime";
            string colIsUsed="IsUsed";
            string colValidPeriod="ValidPeriod";
            dt.Columns.Add(colScenicName);
            dt.Columns.Add(colProductCode);
            dt.Columns.Add(colOrderTime);
            dt.Columns.Add(colIsUsed);
            dt.Columns.Add(colValidPeriod);

            foreach (TicketAssign ta in gotTotalTicketsOfThisType)
            {

                DataRow dr = dt.NewRow();
                dr[colScenicName] = ta.OrderDetail.TicketPrice.Ticket.Scenic.Name;
                dr[colOrderTime] = ta.OrderDetail.Order.BuyTime;
                dr[colIsUsed] = ta.IsUsed;
                dr[colValidPeriod] = ta.OrderDetail.TicketPrice.Ticket.BeginDate.Date 
                                    + "~" + ta.OrderDetail.TicketPrice.Ticket.EndDate.Date;
                dr[colProductCode] = ta.OrderDetail.TicketPrice.Ticket.ProductCode;
                dt.Rows.Add(dr);
            
            }
            ds.Tables.Add(dt);
            return ds;
        }

        /// <summary>
        /// 批量修改身份证号码信息--衢州送票活动给信息中西提供的接口
        /// </summary>
        /// <param name="oldNo"></param>
        /// <param name="newNo"></param>
        /// <returns></returns>
        public string UpdateIdCardNo(string oldNo, string newNo)
        {
           
            //防止sql注入
            string idcardSimplePartern=@"^\d+[x|X]{0,1}$";
            if(!System.Text.RegularExpressions.Regex.IsMatch(oldNo,idcardSimplePartern))
            {
                return "更新失败.身份证号码不符合规范";
            }
            string errMsg;
            if (!CommonLibrary.StringHelper.CheckIDCard(newNo, out errMsg))
            {
                return  errMsg;
            }
            string result = string.Empty;
            try
            {
                Iticketassign.UpdateIdCardNo(oldNo, newNo);
            }
            catch(Exception ex) {
                result = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// 获取身份证号码列表
        /// </summary>
        /// <param name="areaCodeHead">行政区划代码(省:开头两位,市:开头四位,具体区县:全部六位</param>
        /// <param name="entId">具体的一个景区</param>
        /// <param name="dateBegin">订单开始日期</param>
        /// <param name="dateEnd">订单结束日期</param>
        /// <param name="dateEnd">是否已经游玩过</param>
        /// <returns></returns>
        public IList<IdCardInfo> GetIdcardList(string areaCodeHead, int? entId, 
            DateTime? dateBegin, DateTime? dateEnd,bool? isUsed)
        {
            IList<IdCardInfo> idcardInfoList = new List<IdCardInfo>();
            IList<string> idcardList = new List<string>();

            IList<TicketAssign> taList = Iticketassign.GetList(areaCodeHead, entId, dateBegin, dateEnd, isUsed);
            idcardList = taList.Select(x=>x.IdCard).ToList();
            string errMsg;
            foreach (string idcard in idcardList)
            {
                string parseErrmsg;
                IdCardInfo info = new IdCardInfo(idcard).Parse(out parseErrmsg);
                if (info != null)
                {
                    idcardInfoList.Add(info);
                }
            }

            return idcardInfoList;
        }

        public IList<TicketAssign> GetListByNameIdCardLike(string term, string scid)
        {
            return Iticketassign.GetListByNameIdCardLike(term, scid);
        }
    }
}
