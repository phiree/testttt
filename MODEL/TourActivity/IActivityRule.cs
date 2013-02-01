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
         bool HasEnoughAmount();
        /// <summary>
        /// 某身份证号码是否已经
        /// </summary>
        /// <returns></returns>
         bool CheckIdCardAmountPerTicket();
    }
}
