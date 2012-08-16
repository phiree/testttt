using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;
namespace BLL.SEO
{
    /// <summary>
    /// 批量设置title 和 keyworld.
    /// (descriptiong需要单独设置.)
    /// </summary>
    public class BatchSeoData
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
        //DALArea dalArea = new DALArea();

        //区域area, 主题topic, 等级level 与 title,keyword的组合
        const string AreaTitleFormat = @"{0}景点门票_{0}景点门票价格_{0}旅游景点门票 - 中国旅游在线";
        const string AreaKeywordFormat = @"{0}景点门票，{0}景点门票价格，{0}旅游景点门票";
        const string LevelTitleFormat = "浙江{0}景区门票_浙江{0}级景区_浙江{0}及旅游景区 - 中国旅游在线";
        const string LevelKeywordFormat = "{0}景区门票，浙江{0}景区，浙江{0}级旅游景区";
        const string AreaAndLEvelTitleFormat = "{0}{1}景区门票_{0}{1}景点门票_{0}{1}景点门票价格 - 中国旅游在线  ";
        const string AreaAndLEvelKeywordFormat = "{0}{1}景区门票,{0}{1}景点门票,{0}{1}景点门票价格";
        const string TopicTitleFormat = "浙江{0}风景区_浙江{0}景点门票预订 - 中国旅游在线";
        const string AreaAndTopicTitleFormat = "{0}{1}风景区_{0}{1}景点门票预订 - 中国旅游在线";

        const string HomeTitle = "中国旅游在线_浙江旅游景点门票预订官网";
        const string HomeKeyword = "景点门票，门票预订，门票价格，旅游景点门票推荐";
        //区域--级别页面
        public static BatchSeoData GetSeoData_Home(Area area, int level, Topic topic, int pageIndex)
        {
            BLL.BLLArea bllarea = new BLLArea();
            int areaId = area == null ? 0 : area.Id;
            string topicid = topic == null ? string.Empty : topic.Id.ToString();
            BatchSeoData seoData = new BatchSeoData();
            TemplateType tt = TemplateType.Home;

            //改用异或的方式查询,种类太多,ifelse不清晰   SST.
            //if (areaId > 0)//含区域
            //{
            //    if (level > 0)//含区域&等级
            //    {
            //        tt = TemplateType.AreaAndLevel;
            //    }
            //    else//含区域 !等级
            //    {
            //        tt = TemplateType.OnlyArea;
            //    }
            //}
            //else//不含区域
            //{
            //    if (level > 0) { tt = TemplateType.OnlyLevel; }
            //}

            //将上述方法改用异或的方式查询,种类太多,ifelse不清晰   SST.
            //area=4(100), topic=2(10), level=1(1)
            int xorarea = areaId == 0 ? 0 : 4;
            int xortopic = topicid == string.Empty ? 0 : 2;
            int xorlevel = level > 0 ? 1 : 0;
            int xoresult = xorarea ^ xortopic ^ xorlevel;
            switch (xoresult)
            { 
                case 1:
                    tt = TemplateType.OnlyLevel;
                    break;
                case 2:
                    tt = TemplateType.OnlyTopic;
                    break;
                case 3:
                    tt = TemplateType.OnlyTopic;
                    break;
                case 4:
                    tt = TemplateType.OnlyArea;
                    break;
                case 5:
                    tt = TemplateType.AreaAndLevel;
                    break;
                case 6:
                    tt = TemplateType.AreaAndTopic;
                    break;
                case 7:
                    tt = TemplateType.AreaAndTopic;
                    break;
            }


            string title = string.Empty;
            string keyword = string.Empty;
            string description = string.Empty;


            switch (tt)
            {
                case TemplateType.AreaAndLevel:
                    title = string.Format(AreaAndLEvelKeywordFormat, area.Name, level + "A");
                    keyword = string.Format(AreaAndLEvelKeywordFormat, area.Name, level + "A");
                    description = bllarea.GetAreaByAreaid(area.Id).MetaDescription;
                    break;
                case TemplateType.AreaAndTopic:
                    title = string.Format(AreaAndTopicTitleFormat, area.Name, topic.Name);
                    keyword = string.Format(AreaAndTopicTitleFormat, area.Name, topic.Name);
                    description = bllarea.GetAreaByAreaid(area.Id).MetaDescription;
                    break;
                case TemplateType.OnlyArea:
                    title = string.Format(AreaTitleFormat, area.Name);
                    keyword = string.Format(AreaKeywordFormat, area.Name);
                    description = bllarea.GetAreaByAreaid(area.Id).MetaDescription;
                    break;
                case TemplateType.OnlyTopic:
                    title = string.Format(TopicTitleFormat, topic.Name);
                    keyword = string.Format(TopicTitleFormat, topic.Name);
                    description = "中国旅游在线官网提供浙江省内各旅游景点门票在线预订服务，是本省最权威的旅游景点门票授权机构，全面塑造“诗画江南，山水浙江”的旅游总体形象，全面推动本省旅游业的发展";
                    break;
                case TemplateType.OnlyLevel:
                    title = string.Format(LevelTitleFormat, level + "A");
                    keyword = string.Format(LevelKeywordFormat, level + "A");
                    description = "中国旅游在线官网提供浙江省内各旅游景点门票在线预订服务，是本省最权威的旅游景点门票授权机构，全面塑造“诗画江南，山水浙江”的旅游总体形象，全面推动本省旅游业的发展";
                    break;
                default:
                    title = HomeTitle;
                    keyword = HomeKeyword;
                    description = "中国旅游在线官网提供浙江省内各旅游景点门票在线预订服务，是本省最权威的旅游景点门票授权机构，全面塑造“诗画江南，山水浙江”的旅游总体形象，全面推动本省旅游业的发展";
                    break;
            }

            if (pageIndex > 0)
            {
                title += string.Format("(第{0}页)", pageIndex);
            }
            if (pageIndex > 0)
            {
                title += string.Format("(第{0}页)", pageIndex);
            }
            seoData.KeyWord = keyword;
            seoData.Title = title;
            seoData.Description = description;

            return seoData;
        }
        //页面应该使用的seo模板
        enum TemplateType
        {
            Home,
            OnlyArea,
            OnlyLevel,
            OnlyTopic,
            AreaAndLevel,
            AreaAndTopic
        }
    }
}
