using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    //活动规则
    public interface IActivityRule
    {
        //1 某天 某门票 某合作商  是否有足够票数
         bool HasEnoughAmount(int ticketId,string partnerCode,DateTime date, int requestAmount);
        /// <summary>
        /// 某身份证号码已经购买了某门票足够的数量
        ///<param name="amount">本次请求的数量</param>
        bool CheckIdCardAmountPerTicket(IList<TicketAssign> ticketAssigns, string idcard, string ticketCode, int amount);
        /// <summary>
        /// 身份证号是否已购买了足够的门票总数
        /// </summary>
        /// <param name="idcard"></param>
        /// <returns></returns>
        bool CheckIdCardAmountPerActivity(IList<TicketAssign> ticketAssigns, string idcard, int amount);

        /// <summary>
        /// 是否是在规定的时间范围内买票
        /// </summary>
        /// <returns></returns>
         bool CheckBuyTime();
        /// <summary>
        /// 是否属于规则内的地理位置
        /// </summary>
        /// <param name="userArea"></param>
        /// <returns></returns>
         bool CheckUserAreas(string userArea);
    }
}
