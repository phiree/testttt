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

public partial class _Default : basepage
{
    /// <summary>   BLLTicketPrice bllticketprice = new BLLTicketPrice();
    BLLScenic bllscenic = new BLLScenic();
    BLLTicket bllTicket = new BLLTicket();
    BLLMembership bllMember = new BLLMembership();
    BLLArea bllArea = new BLLArea();
    /// 用于构建两个查询的链接
    /// </summary>
    string UrlQuery = string.Empty;
    int areaId = 0, level = 0;
    string areaSeoName,levelname;
    Area area;
    CommonLibrary.UrlParamHelper urlParamHelper;
    protected void Page_Load(object sender, EventArgs e)
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
        levelname = Request["level"];
        if (levelname != null)
        {
            int.TryParse(levelname.TrimEnd('a'), out level);
   
        }
        if (!IsPostBack)
        {
            GetAreaId();
            BindArea();
            BindBread();
            BindLevelLinks();
            BindTicketList();
            SetSeo();

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
       
    }

    /// <summary>
    /// 面包屑
    /// </summary>
    private void BindBread()
    {
        if (!string.IsNullOrEmpty(levelname))
        {
            lLevelBread.Text = levelname.ToUpper();
            lArrow.Visible = true;
        }
        if (areaId != 0)
        {
            Model.Area area = bllArea.GetAreaByAreaid(areaId);
            lAreabread.Text = area.Name;
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
         level=int.Parse(levelname.Substring(0,1));
        }
        IList<Model.Ticket> ticketList = bllTicket.GetTicketByAreaIdAndLevel(areaId, level, pageIndex, pageSize, out totalRecord);



        rptItems.DataSource = ticketList;
        rptItems.DataBind();
        pagerGot.RecordCount = totalRecord;
        if (totalRecord > 0)
        {
            lblTotal.Text = "共" + totalRecord + "个景区";
        }
    }



    protected void rptscenic_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Model.Ticket t = e.Item.DataItem as Model.Ticket;
            decimal priceNormal = t.GetPrice(Model.PriceType.Normal);
            decimal priceOnline = t.GetPrice(Model.PriceType.PayOnline);
            Literal liPriceNormal = e.Item.FindControl("liPriceNormal") as Literal;
            Literal liPriceOnline = e.Item.FindControl("liPriceOnline") as Literal;
            liPriceNormal.Text = priceNormal.ToString("0");
            liPriceOnline.Text = priceOnline.ToString("0");
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
    const string queryArea = "area";
    const string queryLevel = "level";
    protected void rptArea_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Model.Area area = e.Item.DataItem as Model.Area;

         
            HtmlAnchor hrefArea = e.Item.FindControl("hrefArea") as HtmlAnchor;
            hrefArea.HRef = BuildLink(queryArea, area.SeoName);
            if (string.IsNullOrEmpty(areaSeoName))
            {
                hrefAllArea.Attributes["class"] = "hla";
            }
            else if(areaSeoName==area.SeoName)
            {
                hrefArea.Attributes["class"] = "hla";
            }
           
        }
        //
    }


   /// <summary>
    /// 为 "全部"筛选条件 和 A级  构造符合seo的 链接(给链接添加锚点)
    /// </summary>
    /// <returns></returns>
    private void BindLevelLinks()
    {

        hrefAllArea.HRef = BuildLink(queryArea, "",true);
       hlLevelAll.HRef = BuildLink(queryLevel, "", true);
        hlLevel3.HRef = BuildLink(queryLevel, "3a");
        hlLevel4.HRef = BuildLink(queryLevel, "4a");
        hlLevel5.HRef = BuildLink(queryLevel, "5a");


        BuildHignLightItems();
        
    }
    /// <summary>
    /// 高亮显示当前菜单项
    /// </summary>
    private void BuildHignLightItems()
    {  if (string.IsNullOrEmpty(levelname))
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
        return BuildLink(type,value,false);
    }
    private string BuildLink(string type, string value, bool isAll)
    {
        return urlParamHelper.BuildLink2(type, value,isAll);

     }

    private void SetSeo()
    {
        
     BatchSeoData seodata = SeoHandler.GetSeoData_Home(area, level, pageIndex);
     this.Title = seodata.Title;
     this.MetaKeywords = seodata.KeyWord;
    }

}