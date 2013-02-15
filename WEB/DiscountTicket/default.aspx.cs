using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using BLL.SEO;
using System.Configuration;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;


public partial class DiscountTicket_DiscountTicket : basepage
{
    #region 页面参数初始化
    BLLDJEnterprise bllEnt = new BLLDJEnterprise();
    BLLTicket bllTicket = new BLLTicket();
    BLLMembership bllMember = new BLLMembership();
    BLLTopic blltopic = new BLLTopic();
    BLLArea bllArea = new BLLArea();
    BLLScenicImg bllSI = new BLLScenicImg();
    #endregion

    #region seo链接设置
    /// <summary> 
    /// 用于构建两个查询的链接
    /// </summary>
    string UrlQuery = string.Empty;
    int areaId = 0, level = 0;
    public string areaSeoName, levelname, topicname, countyname;
    Area area;
    Area areacounty;
    Topic topic;
    CommonLibrary.UrlParamHelper urlParamHelper;
    //初始化关于url
    private void initurl()
    {
        //第三方登录的处理
        Uri from = Request.UrlReferrer;
        UrlQuery = Request.RawUrl;
        if (from != null)
        {
            if (from.Host == "open.t.qq.com")
            {
                new LoginRedirect();
            }

        }
        urlParamHelper = new CommonLibrary.UrlParamHelper(Request.Url.AbsoluteUri);
        areaSeoName = Request["area"];
        levelname = Request.QueryString["level"];
        topicname = Request.QueryString["topic"];
        countyname = Request.QueryString["county"];
        if (topicname != null)
        {
            topicname = topicname.TrimEnd('/');
            topicname = topicname.Substring(2);
            topic = blltopic.GetTopicBySeoname(topicname);
        }
        if (levelname != null)
        {
            int.TryParse(levelname.TrimEnd('a').TrimEnd('A'), out level);

        }
        if (string.IsNullOrEmpty(countyname))
        {
            pagerGot.UrlRewritePattern = "/Tickets/%area%/%level%/page_{0}.html";
        }
        else
        {
            pagerGot.UrlRewritePattern = "/Tickets/%area%_%county%/%level%/page_{0}.html";
        }
    }
    private void GetAreaId()
    {
        area = bllArea.GetAreaBySeoName(areaSeoName);
        if (area != null)
        {

            areaId = area.Id;
        }
        else
        {
            // ErrHandler.Redirect(ErrType.ParamIllegal);
        }
        if (countyname != null)
        {
            areacounty = bllArea.GetAreaBySeoName(countyname);
            areaId = areacounty.Id;
        }
    }
    /// <summary>
    /// 为两个筛选条件项 构建url
    /// </summary>
    /// <param name="queryParam"></param>
    /// <param name="id"></param>
    /// <param name="isRemove"></param>
    /// <returns></returns>


    private string BuildLink(string type, string value)
    {
        return BuildLink(type, value, false);
    }
    private string BuildLink(string type, string value, bool isAll)
    {
        return "/Tickets" + urlParamHelper.BuildLink2(type, value, isAll);

    }

    /// <summary>
    /// 设置seo
    /// </summary>
    private void SetSeo()
    {
        BatchSeoData seodata = SeoHandler.GetSeoData_Home(area, areacounty, level, topic, pageIndex);
        this.Title = seodata.Title;
        this.MetaKeywords = seodata.KeyWord;
        if (level == 0 && topic == null && area != null)
        { this.MetaDescription = area.MetaDescription; }
        else
        {
            this.MetaDescription = seodata.Description;
        }
        liH1.Text = seodata.H1Text;
    }
    private string BindHref(Area area, string countyname, int level, string themeseoname)
    {
        string url = "/Tickets";
        if (area != null)
            url += "/" + area.SeoName;
        if (countyname != null)
            url += "_" + countyname;
        if (level != 0)
            url += "/" + level + "A";
        if (themeseoname != null)
            url += "/t_" + themeseoname;
        return url;
    }
    #endregion

    #region Load
    protected void Page_Load(object sender, EventArgs e)
    {
        initurl();
        if (!IsPostBack)
        {
            GetAreaId();
            BindArea();
            BindCounty();
            BindBread();
            BindLevelLinks();
            BindTicketList();
            SetSeo();
            BindTopic();
        }

    }
    /// <summary>
    /// 面包屑
    /// </summary>
    private void BindBread()
    {

        string urlBase = "/Tickets/";

        if (areaId != 0)
        {

            breadareaurl.InnerText = area.Name.Substring(3, 2);
            urlBase = breadareaurl.HRef = urlBase + area.SeoName;
            if (countyname != null)
            {
                breadcountyurl.InnerText = areacounty.Name.Substring(3);
                if (breadcountyurl.InnerText.Trim().Length >= 6)
                    breadcountyurl.InnerText = breadcountyurl.InnerText.Trim().Substring(3);
                urlBase = breadcountyurl.HRef = urlBase + '_' + countyname + "/";
            }
            else
            {
                phCounty.Visible = false;
                urlBase = breadareaurl.HRef = urlBase + "/";
            }
        }
        else
        {
            phCounty.Visible = false;
            phArea.Visible = false;
        }
        if (!string.IsNullOrEmpty(levelname))
        {
            breadlevelurl.InnerText = levelname.ToUpper();
            //lArrow.Visible = true;
            urlBase = breadlevelurl.HRef = urlBase + levelname.ToLower() + "/";
        }
        else
        {
            phLevel.Visible = false;
        }
        if (!string.IsNullOrEmpty(topicname))
        {
            breadtopic.InnerText = topic.Name;
            //lArrow.Visible = true;
            urlBase = breadtopic.HRef = urlBase + "t_" + topicname + "/";
        }
        else
        {
            phTopic.Visible = false;
        }
    }
    int totalRecord;
    int pageIndex;
    private void BindTicketList()
    {
        pageIndex = GetPageIndex();
        int pageSize = pagerGot.PageSize;

        int level = 0;
        if (!string.IsNullOrEmpty(levelname))
        {
            level = int.Parse(levelname.Substring(0, 1));
        }
        IList<Model.DJ_TourEnterprise> ticketList;
        if (countyname == null)
            ticketList = bllEnt.GetTicketByAreaIdAndLevel(area, level, topicname, pageIndex, pageSize, out totalRecord);
        else
            ticketList = bllEnt.GetTicketByAreaIdAndLevel(areacounty, level, topicname, pageIndex, pageSize, out totalRecord);

        rptItems.DataSource = ticketList;
        rptItems.DataBind();
        pagerGot.RecordCount = totalRecord;
        if (totalRecord > 0)
        {
            lblTotal.Text = "共" + totalRecord + "个景区";
        }
    }


    private void BindTopic()
    {
        rptTopic.DataSource = blltopic.GetAllTopics();
        rptTopic.DataBind();
    }

    private void BindCounty()
    {
        if (area != null)
        {
            rptCounty.DataSource = new BLLArea().GetSubArea(area.Code);
            rptCounty.DataBind();
        }
        else
        {
            countydiv.Visible = false;
        }
    }
    private int GetPageIndex()
    {
        string paramPageIndex = Request[pagerGot.UrlPageIndexName];
        int pageIndex;
        int.TryParse(paramPageIndex, out pageIndex);
        return pageIndex;
    }

    private void BindArea()
    {
        rptAreas.DataSource = new BLLArea().GetSubArea("330000");
        rptAreas.DataBind();
    }
    /// <summary>
    /// 高亮显示当前菜单项
    /// </summary>
    private void BuildHignLightItems()
    {
        if (string.IsNullOrEmpty(levelname))
        {
            hlLevelAll.Attributes["class"] = "hlv";
            return;
        }
        if (levelname.ToLower() == "3a")
        {
            hlLevel3.Attributes["class"] = "hlv";
            return;
        }
        if (levelname.ToLower() == "4a")
        {
            hlLevel4.Attributes["class"] = "hlv";
            return;
        }

        if (levelname.ToLower() == "5a")
        {
            hlLevel5.Attributes["class"] = "hlv";
            return;
        }
        if (levelname.ToLower() == "2a")
        {
            hlLevel2.Attributes["class"] = "hlv";
            return;
        }
        if (levelname.ToLower() == "a")
        {
            hlLevel1.Attributes["class"] = "hlv";
            return;
        }

    }
    /// <summary>
    /// 为 "全部"筛选条件 和 A级  构造符合seo的 链接(给链接添加锚点)
    /// </summary>
    /// <returns></returns>
    private void BindLevelLinks()
    {

        hrefAllArea.HRef = BindHref(null, null, level, topicname);
        hrefTopicAll.HRef = BuildLink(queryTopic, "", true);
        hlLevelAll.HRef = BuildLink(queryLevel, "", true);
        hlLevel3.HRef = BuildLink(queryLevel, "3a");
        hlLevel4.HRef = BuildLink(queryLevel, "4a");
        hlLevel5.HRef = BuildLink(queryLevel, "5a");

        hlLevel2.HRef = BuildLink(queryLevel, "2a");
        hlLevel1.HRef = BuildLink(queryLevel, "1a");

        BuildHignLightItems();

    }
    #endregion

    #region event
    protected void rptscenic_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Model.Scenic t = e.Item.DataItem as Model.Scenic;
            foreach (Ticket item in t.Tickets.Where(x => x.IsMain == true))
            {
                decimal priceNormal = item.GetPrice(Model.PriceType.Normal);
                decimal priceOnline = item.GetPrice(Model.PriceType.PayOnline);
                Literal liPriceNormal = e.Item.FindControl("liPriceNormal") as Literal;
                Literal liPriceOnline = e.Item.FindControl("liPriceOnline") as Literal;
                liPriceNormal.Text = priceNormal.ToString("0");
                liPriceOnline.Text = priceOnline.ToString("0");
               
               
            }
            //设置图片
            Image img = e.Item.FindControl("Image1") as Image;

            IList<ScenicImg> mainImg = bllSI.GetSiByType(t, 1);
            string targetImageUrl = string.Empty;
            if (mainImg.Count > 0)
            {
                targetImageUrl = mainImg[0].Name;
                string extention = bllSI.GetSiByType(t, 1)[0].Name.Split('.')[1];
                img.ImageUrl = "/ScenicImg/small/" + bllSI.GetSiByType(t, 1)[0].Name.Split('.')[0] + "_s." + extention;
            }
            else { //如果没有主图 则选择副图第一章
                IList<ScenicImg> viceImg = bllSI.GetSiByType(t, 2);
                if (viceImg.Count > 0)
                {
                    targetImageUrl = viceImg[0].Name;
                }
            }
            if (!string.IsNullOrEmpty(targetImageUrl))
            {
              //  string extention = System.IO.Path.GetExtension(targetImageUrl);
                targetImageUrl = targetImageUrl.Insert(targetImageUrl.IndexOf("."), "_s");

                img.ImageUrl = "/ScenicImg/small/" + targetImageUrl;
            }
            string ahref="/Tickets/" + bllArea.GetAreaByCode(t.Area.Code.Substring(0, 4) + "00").SeoName + "_" + t.Area.SeoName + "/" + t.SeoName + ".html";
            HtmlAnchor ha = e.Item.FindControl("schref") as HtmlAnchor;
            ha.HRef = ahref;
            HtmlAnchor ha2 = e.Item.FindControl("schref2") as HtmlAnchor;
            ha2.HRef = ahref;
            HtmlAnchor ha3 = e.Item.FindControl("schref3") as HtmlAnchor;
            ha3.HRef = ahref;
        }
        if (e.Item.ItemType == ListItemType.Footer)
        {
            if (rptItems.Items.Count == 0)
            {
                Label lblNoResult = e.Item.FindControl("lblNoResult") as Label;
                lblNoResult.Visible = true;
            }
        }
        if (e.Item.ItemType == ListItemType.Header)
        {
            e.Item.Visible = totalRecord > 0;
            Label lblTotalRecord = e.Item.FindControl("lblTotalRecord") as Label;
            lblTotalRecord.Text = totalRecord.ToString();
        }
    }
    
    const string queryArea = "area";
    const string queryLevel = "level";
    const string queryTopic = "topic";
    protected void rptArea_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Model.Area area = e.Item.DataItem as Model.Area;


            HtmlAnchor hrefArea = e.Item.FindControl("hrefArea") as HtmlAnchor;
            hrefArea.HRef = BuildLink(queryArea, area.SeoName);
            hrefArea.HRef = Regex.Replace(hrefArea.HRef, @"(?<="+area.SeoName+@")_\D+?/|(?<="+area.SeoName+@")_\D+", "/");
            if (string.IsNullOrEmpty(areaSeoName))
            {
                hrefAllArea.Attributes["class"] = "hla";
            }
            else if (areaSeoName == area.SeoName)
            {
                hrefArea.Attributes["class"] = "hla";
            }

        }
        //
    }


  

   
    protected void rptTopic_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Model.Topic topic = e.Item.DataItem as Model.Topic;


            HtmlAnchor hreftopic = e.Item.FindControl("hltopic") as HtmlAnchor;
            hreftopic.HRef = BuildLink(queryTopic, "t_"+topic.seoname);
            if (string.IsNullOrEmpty(topicname))
            {
                hrefTopicAll.Attributes["class"] = "hlt";
            }
            else if (topicname == topic.seoname)
            {
                hreftopic.Attributes["class"] = "hlt";
            }

        }
    }
    protected void rptCounty_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Model.Area areacounty = e.Item.DataItem as Model.Area;
            HtmlAnchor hrefCounty = e.Item.FindControl("hlcounty") as HtmlAnchor;
            if (hrefCounty.InnerHtml.Trim().Length > 3)
            {
                hrefCounty.InnerHtml = hrefCounty.InnerHtml.Trim().Substring(3);
            }
            hrefCounty.HRef = BindHref(area, areacounty.SeoName, level, topicname);
            if(countyname==areacounty.SeoName)
                hrefCounty.Attributes["class"] = "hlc";
        }
    }

    #endregion
}