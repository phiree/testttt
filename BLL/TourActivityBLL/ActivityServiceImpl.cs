using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL;
using Model;
using System.Data;
namespace BLL
{
    /// <summary>
    /// 为接口服务
    /// </summary>
    public class BLLActivityServiceImpl
    {
        BLLMembership bllMembership = new BLLMembership();
        BLLTicketAssign bllTa = new BLLTicketAssign();
        BLLOrder bllOrder = new BLLOrder();
        BLLTicket bllTicket = new BLLTicket();
        BLLActivityPartner bllPartner = new BLLActivityPartner();
        BLLTourActivity bllActivity = new BLLTourActivity();
        BLLActivityTicketAssign bllActivityTicketAssign = new BLLActivityTicketAssign();

        /// <summary>
        /// 合作伙伴请求门票
        /// </summary>
        /// <param name="activityCode">活动代码</param>
        /// <param name="needValidatePerDay">是否每天验证</param>
        /// <param name="needCheckTime">是否限制购买时间</param>
        /// <param name="PartnerCode"></param>
        /// <param name="CardNumber"></param>
        /// <param name="RealName"></param>
        /// <param name="Phone"></param>
        /// <param name="ticketCodes"></param>
        /// <param name="Number"></param>
        /// <returns></returns>
        public string buyProduct(bool needValidation, string activityCode, TourMembership member
            , string PartnerCode, string CardNumber, string RealName, string Phone, string ticketCode, int Number,DateTime buyTime)
        {

            
           
            Guid requestGUID = Guid.NewGuid();
            TourLog.ErrorLog.Debug(string.Format("*********Begin********{5}出票请求:{6}_{0}_{1}_{2}_{3}_{4}", PartnerCode, CardNumber, ticketCode, Number, Phone, requestGUID,activityCode));
            string returnMsg = "T";
            TourActivity activity = bllActivity.GetOneByActivityCode(activityCode);//get from activitycode
            ActivityPartner currentPartner = activity.Partners.Where(x => x.PartnerCode == PartnerCode).First();//get from partnercode and actrivityCode
          
            string connString=System.Configuration.ConfigurationManager.ConnectionStrings["TourOnline"].ConnectionString;
            DAL.ado.NativeSqlUtiliity nativeSql = new DAL.ado.NativeSqlUtiliity(connString);

            if (false)//如果使用存储过程)
            {
                nativeSql.ExecuteDataSetProc("usp_TicketRequest", new string[] { 
                    CardNumber,RealName,Phone,activity.Id.ToString(),  currentPartner.Id.ToString(),ticketCode,"1",""
                    }, out returnMsg);
            }


           //todo
         
            // 下单前的验证 与用户无关
            int nowHour = DateTime.Now.Hour;
            string checkErrMsg;
            
                if (needValidation&& !activity.CheckBeforeOrder(currentPartner,ticketCode,Number, out checkErrMsg))
                {
                    returnMsg = string.Format("F|{0}", checkErrMsg);
                    goto LblReturn;
                }
            ///身份证号码格式验证
            string checkIdCardNoErrMsg;
            bool idcardnoValid = CommonLibrary.StringHelper.CheckIDCard(CardNumber, out checkIdCardNoErrMsg);
            if (!idcardnoValid)
            {
                returnMsg = "F|" + checkIdCardNoErrMsg;
                goto LblReturn;
            }


            if (string.IsNullOrEmpty(RealName))
            {
                RealName = activity.Name + "参与者";
            }
            ///开始生成订单,订单详情,门票分配
            //创建用户
            if (member == null)
            {
                member = bllMembership.GetMember(CardNumber);

                if (member == null)
                {
                    //创建用户
                    member = bllMembership.CreateUser2(RealName, Phone, string.Empty, CardNumber, CardNumber, "123456", string.Empty);
                }
            }
            ////自动创建订单(如果是联票, 则要为联票门票创建三个订单

            string createOrderErrMsg;
        
            Ticket ticket = bllTicket.GetByProductCode(ticketCode);
            
            

            bllOrder.CreateOrder( PartnerCode, member, ticket, CardNumber, RealName, Number,PriceType.PreOrder,buyTime, out createOrderErrMsg);
            if (!string.IsNullOrEmpty(createOrderErrMsg))
            {
                returnMsg = "F|"+createOrderErrMsg;
                goto LblReturn;
            }

            ////3 该接入商该景区的已售门票+1
          
                //ticketAssign.SoldAmount += Number;
                //bllActivityTicketAssign.SaveOrUpdate(ticketAssign);
           
        LblReturn:
            TourLog.ErrorLog.Info(returnMsg);
            TourLog.ErrorLog.Info(requestGUID + "*********END********" + requestGUID);
            return returnMsg;

        }

        public string buyProduct(string activityCode, TourMembership member
               , string PartnerCode, string CardNumber, string RealName, string Phone, string ticketCode, int Number)
        {
          return  buyProduct(true, activityCode, member, PartnerCode,
                CardNumber, RealName, Phone, ticketCode, Number,DateTime.Now.Date);
        }
   
       
        public int ProductLeftAmount(string activityCode, string PartnerCode, string productCode, DateTime dt)
        {
            ActivityTicketAssign ticketAssign = bllActivityTicketAssign.GetOneByQuery(activityCode, PartnerCode, productCode, dt);
            if (ticketAssign == null) return -1;
            int left = ticketAssign.AssignedAmount - ticketAssign.SoldAmount;
            left = left < 0 ? 0 : left;
            return left;
        }

        /// <summary>
        /// 获取所有门票的剩余票量
        /// </summary>
        /// <param name="activityCode"></param>
        /// <param name="PartnerCode"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public DataSet ProductLeftAmountAll(string activityCode, string PartnerCode, DateTime date)
        {
         
            IList<ActivityTicketAssign> assigns = bllActivityTicketAssign.GetList(activityCode, PartnerCode, date);


            DataSet ds = new DataSet();

            DataTable dt = new DataTable("ticketamounts");
            string colScenicName = "ScenicName";
            string colProductCode = "ProductCode";
            string colLastAmount = "LastAmount";
            string colAssignedAmount = "AssignedAmount";
            string colSoldAmount = "SoldAmount";
            dt.Columns.Add(colScenicName);
            dt.Columns.Add(colProductCode);
            dt.Columns.Add(colLastAmount);
            dt.Columns.Add(colAssignedAmount);
            dt.Columns.Add(colSoldAmount);
            foreach (ActivityTicketAssign ta in assigns)
            {

                DataRow dr = dt.NewRow();
                dr[colScenicName] = ta.Ticket.Scenic.Name;
                dr[colProductCode] = ta.Ticket.ProductCode;
                dr[colLastAmount] = ta.AssignedAmount - ta.SoldAmount;
                dr[colAssignedAmount] = ta.AssignedAmount;
                dr[colSoldAmount] = ta.SoldAmount;
                dt.Rows.Add(dr);
            }

            ds.Tables.Add(dt);

            return ds;

        }

        public string UpdateIdCardNo(string activityCode, string oldNo, string newNo)
        {
            string result = bllTa.UpdateIdCardNo(activityCode, oldNo, newNo);
            if (string.IsNullOrEmpty(result))
            {
                return "T";
            }
            else
            {
                return "F|" + result;
            }
        }
        public DataSet GetTicketsInActivity(string activityCode, string idcardno)
        {

            return bllTa.GetTicketsInActivity(activityCode, idcardno);
        }

        

    }
}
