using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
namespace BLL
{
    //根据身份证号码提取的信息
    /// <summary>
    /// 需要的统计报表
    /// 后台:  
    ///   所有景区 & 个别景区
    ///      人员地理位置 省份,城市
    ///      人员性别
    ///      人员年龄
    ///   
    /// </summary>
   
    public class BLLIdcardReport
    {
       
        BLLTicketAssign bllTa = new BLLTicketAssign();

        public BLLIdcardReport()
        {
            
        }
        /// <summary>
        /// 景区相关报表--区别于 旅行社报表
        /// </summary>
        /// <param name="areaCodeHead"></param>
        /// <param name="entId"></param>
        /// <param name="dateBegin"></param>
        /// <param name="dateEnd"></param>
        /// <param name="isUsed"></param>
        /// <returns></returns>
        public    Dictionary<string,int> GetListForScenic(string areaCodeHead, int? entId, 
            DateTime? dateBegin, DateTime? dateEnd,bool? isUsed)
        {
            IList<IdCardInfo> idcardList = bllTa.GetIdcardList(areaCodeHead, entId, dateBegin, dateEnd, isUsed);

            Dictionary<string, int> chartSery = new Dictionary<string, int>();
           //省份
            var provinceReport=from idcardInfo in idcardList
                               group  idcardInfo.ProvinceCode by idcardInfo.ProvinceCode into g
             select new{ProvinceCode=g.Key,Amount=g};

         
            chartSery = idcardList.GroupBy(x => x.ProvinceCode).ToDictionary(g =>IdCardInfo.ProvinceDict[g.Key], g => g.ToList().Count);

           // bllTa.GetAll<TicketAssign>();


            return chartSery;
        }
       
    }
}
