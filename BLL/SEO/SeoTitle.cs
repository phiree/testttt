using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;
namespace BLL.SEO
{

    public class SeoData
    {
        public string Title { get; set; }
        public string KeyWord { get; set; }
        public string Description { get; set; }
    }
    /// <summary>
    /// title的seo优化
    /// </summary>
    public class SeoHandler
    {
        DALArea dalArea = new DALArea();

        const string AreaTitleFormat = @"{0}景点门票_{0}景点门票价格_{0}旅游景点门票 - 中国旅游在线";
        const string AreaKeywordFormat = @"{0}景点门票，{0}景点门票价格，{0}旅游景点门票";
        const string LevelTitleFormat = "浙江{0}景区门票_浙江{0}级景区_浙江{0}及旅游景区 - 中国旅游在线";
        const string LevelKeywordFormat = "{0}景区门票，浙江{0}景区，浙江{0}级旅游景区";
        const string AreaAndLEvelTitleFormat = "{0}{1}景区门票_{0}{1}景点门票_{0}{1}景点门票价格 - 中国旅游在线  ";
        const string AreaAndLEvelKeywordFormat = "{0}{1}景区门票,{0}{1}景点门票,{0}{1}景点门票价格";

        const string HomeTitle = "中国旅游在线_浙江旅游景点门票预订官网";
        const string HomeKeyword = "景点门票，门票预订，门票价格，旅游景点门票推荐";
        //区域--级别页面
        public static SeoData GetSeoData_Home(Area area, int level, int pageIndex)
        {
            int areaId = area == null ? 0 : area.Id;
            SeoData seoData = new SeoData();
            TemplateType tt = TemplateType.Home;
            if (areaId > 0)
            {
                if (level > 0)
                {
                    tt = TemplateType.AreaAndLevel;
                }
                else
                {
                    tt = TemplateType.OnlyArea;
                }
            }
            else
            {
                if (level > 0) { tt = TemplateType.OnlyLevel; }
            }

            string title = string.Empty;
            string keyword = string.Empty;


            switch (tt)
            {
                case TemplateType.AreaAndLevel:
                    title = string.Format(AreaAndLEvelKeywordFormat, area.Name, level + "A");
                    keyword = string.Format(AreaAndLEvelKeywordFormat, area.Name, level + "A");
                    break;
                case TemplateType.OnlyArea:
                    title = string.Format(AreaTitleFormat, area.Name);
                    keyword = string.Format(AreaKeywordFormat, area.Name);
                    break;
                case TemplateType.OnlyLevel:
                    title = string.Format(LevelTitleFormat, level + "A");
                    keyword = string.Format(LevelKeywordFormat, level + "A");
                    break;
                default:
                    title = HomeTitle;
                    keyword = HomeKeyword;
                    break;
            }

            if (pageIndex > 0)
            {
                title += string.Format("(第{0}页)",pageIndex);
            }

            seoData.KeyWord = keyword;
            seoData.Title = title;

            return seoData;
        }
        //页面应该使用的seo模板
        enum TemplateType
        {
            Home,
            OnlyArea,
            OnlyLevel,
            AreaAndLevel

        }
    }
}
