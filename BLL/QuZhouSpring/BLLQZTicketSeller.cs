using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    //被抢一张票
   public class BLLQZTicketSeller
    {
       public void SellTicket(string clientFriendlyId, string idcardno, int ticketId)
       { 
        //验证这个分发商还有没有足够的门票

           //验证这个身份证号码是否已经抢到一定数量的门票,无法继续抢订.

           //验证通过
           //1 为身份证号创建一个用户名
           //2 为该用户购买id为ticketid的门票 把门票分配额给该身份证号码.
           //3 该接入商该景区的已售门票+1
       }
    }
}
