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

    public enum enumGroupByType
    {
        ProvinceCode,
        CityCode,
        CountryCode,
        Age
    }
    public class BLLIdcardReport
    {

        BLLTicketAssign bllTa = new BLLTicketAssign();

        public BLLIdcardReport()
        {

        }
        /// <summary>
        /// 景区相关报表--区别于 旅行社报表
        /// </summary>
        /// <param name="areaCodeHead">区域编码(如浙江传"33"杭州市传"3301"</param>
        /// <param name="entId">景区ID</param>
        /// <param name="dateBegin">开始时间</param>
        /// <param name="dateEnd">结束时间</param>
        /// <param name="isUsed"></param>
        /// <returns></returns>
        public Dictionary<string, int> GetListForScenic(string areaCodeHead, int? entId,
            DateTime? dateBegin, DateTime? dateEnd, bool? isUsed, enumGroupByType groupByType, int groupByValue)
        {
            IList<IdCardInfo> idcardList = bllTa.GetIdcardList(areaCodeHead, entId, dateBegin, dateEnd, isUsed);


            Dictionary<string, int> chartSery = new Dictionary<string, int>();

            switch (groupByType)
            {
                case enumGroupByType.Age:
                    chartSery = idcardList.GroupBy(x => x.Age).OrderBy(x=>x.Key) .ToDictionary(g => g.Key.ToString(), g => g.ToList().Count);
                    break;
                case enumGroupByType.CityCode:
                    chartSery = idcardList.Where(x => x.ProvinceCode == groupByValue)
                      
                        .GroupBy(x => x.CityCode).OrderBy(x=>x.ToList().Count).ToDictionary(g => IdCardInfo.CityDict[g.Key], g => g.ToList().Count)
                        
                       ;
                    break;
                case enumGroupByType.ProvinceCode:
                    chartSery = idcardList.GroupBy(x => x.ProvinceCode).OrderBy(x => x.ToList().Count).ToDictionary(g => IdCardInfo.ProvinceDict[g.Key], g => g.ToList().Count);

                    break;
                case enumGroupByType.CountryCode:
                    chartSery = idcardList.Where(x => x.CityCode == groupByValue).GroupBy(x => x.CountryCode)
                        .OrderBy(x => x.ToList().Count).ToDictionary(g => IdCardInfo.CityDict[g.Key], g => g.ToList().Count);

                    break;
            }

            // bllTa.GetAll<TicketAssign>();


            return chartSery;
        }

    }
}
