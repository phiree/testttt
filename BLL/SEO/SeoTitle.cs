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
        /// <summary>
        /// 页面主题,用h1标签
        /// </summary>
        public string H1Text { get; set; }
    }
    /// <summary>
    /// 景区列表页面title的seo优化
    /// </summary>
    public class SeoHandler
    {
        //DALArea dalArea = new DALArea();

        //区域area, 主题topic, 等级level 与 title,keyword的组合
        const string AreaTitleFormat = @"{0}景点门票_{0}景点门票价格_{0}旅游景点门票 - 中国旅游在线";
        const string AreaKeywordFormat = @"{0}景点门票，{0}景点门票价格，{0}旅游景点门票";
        const string Area_CountyTitleFormat = @"{0}{1}景区门票_{0}{1}景区门票价格_{0}{1}旅游景区门票-中国旅游在线";
        const string Area_CountyKeywordFormat = @"{0}{1}景区门票_{0}{1}景区门票价格_{0}{1}旅游景区门票";
        const string LevelTitleFormat = "浙江{0}景区门票_浙江{0}级景区_浙江{0}及旅游景区 - 中国旅游在线";
        const string LevelKeywordFormat = "{0}景区门票，浙江{0}景区，浙江{0}级旅游景区";
        const string LevelDescriptionFormat = "中国旅游在线提供浙江{0}A景区门票预订服务，众多风景名胜区吸引无数游客观光，浙江{0}A级景区全力打造一流的休闲度假环境，可方便的在线预订浙江{0}A级旅游景区门票.";
        const string AreaAndLEvelTitleFormat = "{0}{1}景区门票_{0}{1}景点门票_{0}{1}景点门票价格 - 中国旅游在线  ";
        const string AreaAndLEvelKeywordFormat = "{0}{1}景区门票,{0}{1}景点门票,{0}{1}景点门票价格";
        const string Area_CountyAndLEvelTitleFormat = "{0}{1}{2}景区门票_{0}{1}{2}景点门票_{0}{1}{2}景点门票价格 - 中国旅游在线  ";
        const string Area_CountyAndLEvelKeywordFormat = "{0}{1}{2}景区门票,{0}{1}{2}景点门票,{0}{1}{2}景点门票价格";
        const string TopicTitleFormat = "浙江{0}风景区_浙江{0}景点门票预订 - 中国旅游在线";
        const string AreaAndTopicTitleFormat = "{0}{1}风景区_{0}{1}景点门票预订 - 中国旅游在线";
        const string Area_CountyAndTopicTitleFormat = "{0}{1}{2}风景区_{0}{1}{2}景点门票预订 - 中国旅游在线";
        const string HomeTitle = "中国旅游在线_浙江旅游景点门票预订官网";
        const string HomeKeyword = "景点门票，门票预订，门票价格，旅游景点门票推荐";

       
        //区域--级别页面
        public static BatchSeoData GetSeoData_Home(Area area, Area countyarea, int level, Topic topic, int pageIndex)
        {
            BLL.BLLArea bllarea = new BLLArea();
            int areaId = area == null ? 0 : area.Id;
            int countyareaId = countyarea == null ? 0 : countyarea.Id;
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
            int xorcounty = countyareaId > 0 ? 8 : 0;
            int xoresult = xorarea ^ xortopic ^ xorlevel^xorcounty;
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
                case 13:
                    tt = TemplateType.Area_CountyAndLevel;
                    break;
                case 12:
                    tt = TemplateType.OnlyArea_County;
                    break;
                case 14:
                    tt = TemplateType.Area_CountyAndTopic;
                    break;
                case 15:
                    tt = TemplateType.Area_CountyAndTopic;
                    break;
            }


            string title = string.Empty;
            string keyword = string.Empty;
            string description = string.Empty;
            string h1text = string.Empty;


            switch (tt)
            {
                /*
                    城市+景区级别的页面title按照下列规则统一生成，省略keyword和description，如：                                                                                  
                    http://www.tourol.cn/hangzhou/5a/                                                                                                       
                    Title：杭州5a景区门票_杭州5a景点门票_杭州5a景点门票价格 - 中国旅游在线     
                 */
                case TemplateType.AreaAndLevel:
                    title = string.Format(AreaAndLEvelKeywordFormat, area.Name, level + "A");
                    //keyword = string.Format(AreaAndLEvelKeywordFormat, area.Name, level + "A");
                    //description = bllarea.GetAreaByAreaid(area.Id).MetaDescription;
                    h1text = string.Format("{0}{1}景点门票",area.Name,level+"A级");
                    break;
                case TemplateType.AreaAndTopic:
                    title = string.Format(AreaAndTopicTitleFormat, area.Name, topic.Name);
                    //keyword = string.Format(AreaAndTopicTitleFormat, area.Name, topic.Name);
                    //description = bllarea.GetAreaByAreaid(area.Id).MetaDescription;
                    h1text = string.Format("{0}{1}景点门票", area.Name, topic.Name );
                    break;
                case TemplateType.OnlyArea:
                    title = string.Format(AreaTitleFormat, area.Name);
                    keyword = string.Format(AreaKeywordFormat, area.Name);
                    description = bllarea.GetAreaByAreaid(area.Id).MetaDescription;
                    h1text = string.Format("{0}景点门票", area.Name);
                
                    break;
                case TemplateType.OnlyTopic:
                    title = string.Format(TopicTitleFormat, topic.Name);
                    keyword = string.Format(TopicTitleFormat, topic.Name);
                    description = "中国旅游在线官网提供浙江省内各旅游景点门票在线预订服务，是本省最权威的旅游景点门票授权机构，全面塑造“诗画江南，山水浙江”的旅游总体形象，全面推动本省旅游业的发展";
                    h1text = string.Format("浙江{0}景点门票", topic.Name);
                
                    break;
                case TemplateType.OnlyLevel:
                    title = string.Format(LevelTitleFormat, level + "A");
                    keyword = string.Format(LevelKeywordFormat, level + "A");
                    description = string.Format(LevelDescriptionFormat,level);
                    h1text = string.Format("浙江{0}景点门票", level+"A级");
                
                    break;
                case TemplateType.Area_CountyAndLevel:
                    title = string.Format(Area_CountyAndLEvelTitleFormat, area.Name, countyarea.Name, level + "A");
                    keyword = string.Format(Area_CountyAndLEvelKeywordFormat, area.Name, countyarea.Name, level + "A");
                    description = bllarea.GetAreaByAreaid(countyarea.Id).MetaDescription;
                    h1text = string.Format("{0}{1}景点门票", countyarea.Name, level + "A级");
                    break;
                case TemplateType.OnlyArea_County:
                    title = string.Format(Area_CountyTitleFormat, area.Name, countyarea.Name);
                    keyword = string.Format(Area_CountyKeywordFormat, area.Name, countyarea.Name);
                    description = bllarea.GetAreaByAreaid(countyarea.Id).MetaDescription;
                    h1text = string.Format("{0}景点门票", countyarea.Name);
                    break;
                case TemplateType.Area_CountyAndTopic:
                    title = string.Format(Area_CountyAndTopicTitleFormat, area.Name, countyarea.Name, topic.Name);
                    h1text = string.Format("{0}{1}景点门票",countyarea.Name,topic.Name);
                    break;
                default:
                    title = HomeTitle;
                    keyword = HomeKeyword;
                    description = "中国旅游在线官网提供浙江省内各旅游景点门票在线预订服务，是本省最权威的旅游景点门票授权机构，全面塑造“诗画江南，山水浙江”的旅游总体形象，全面推动本省旅游业的发展";
                    h1text = "浙江旅游景点门票";
                
                    break;
            }

            if (pageIndex > 0)
            {
                title += string.Format("(第{0}页)", pageIndex);
            }
           
            seoData.KeyWord = keyword;
            seoData.Title = title;
            seoData.Description = description;
            seoData.H1Text = h1text;
            return seoData;
        }
        //页面应该使用的seo模板
        enum TemplateType
        {
            Home,
            OnlyArea,
            OnlyArea_County,
            OnlyLevel,
            OnlyTopic,
            AreaAndLevel,
            Area_CountyAndLevel,
            AreaAndTopic,
            Area_CountyAndTopic
        }
    }
}
