using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Model;
using BLL;
using System.Configuration;
public partial class search_Default : System.Web.UI.Page
{
    BLLTicketPrice bllticketprice = new BLLTicketPrice();
    BLLScenic bllscenic = new BLLScenic();
    BLLTicket bllTicket = new BLLTicket();
    BLLArea bllArea = new BLLArea();
    BLLScenicImg bllSI = new BLLScenicImg();
    BLLDJEnterprise bllEnt = new BLLDJEnterprise();
    public string q;
    protected void Page_Load(object sender, EventArgs e)
    {
        BindTicketList();
    }
    private void BindTicketList()
    {
        q = Request["q"];
        int pageIndex = GetPageIndex();
        int pageSize = pagerGot.PageSize;
        int totalRecord;

        IList<Model.DJ_TourEnterprise> ticketList = bllEnt.Search(q, pageIndex, pageSize, out totalRecord);
        if (ticketList.Count > 0)
        {
            rptItems.DataSource = ticketList;
            rptItems.DataBind();
            pagerGot.RecordCount = totalRecord;
            lblTotalRecord.Text = totalRecord.ToString();
            searchbody.Visible = true;
            nosearch.Visible = false;
            sceniccount.Visible = true;
            nosceniccount.Visible = false;
        }
        else
        {
            searchbody.Visible = false;
            nosearch.Visible = true;
            sceniccount.Visible = false;
            nosceniccount.Visible = true;
            string ids = ConfigurationManager.AppSettings["ScenicFocusIds"];
            List<Scenic> list = new List<Scenic>();
            foreach (string id in ids.Split(','))
            {
                list.Add(bllscenic.GetScenicById(int.Parse(id)));
            }
            rptrmsc.DataSource = list;
            rptrmsc.DataBind();
        }
    }
    protected void rptscenic_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Model.Scenic s = e.Item.DataItem as Model.Scenic;
            foreach (Ticket item in s.Tickets.Where(x => x.IsMain == true))
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

            IList<ScenicImg> mainImg = bllSI.GetSiByType(s, 1);
            string targetImageUrl = string.Empty;
            if (mainImg.Count > 0)
            {
                targetImageUrl = mainImg[0].Name;
                string extention = bllSI.GetSiByType(s, 1)[0].Name.Split('.')[1];
                img.ImageUrl = "/ScenicImg/small/" + bllSI.GetSiByType(s, 1)[0].Name.Split('.')[0] + "_s." + extention;
            }
            else
            { //如果没有主图 则选择副图第一章
                IList<ScenicImg> viceImg = bllSI.GetSiByType(s, 2);
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
            string ahref = "/Tickets/" + bllArea.GetAreaByCode(s.Area.Code.Substring(0, 4) + "00").SeoName + "_" + s.Area.SeoName + "/" + s.SeoName + ".html";
            HtmlAnchor ha = e.Item.FindControl("schref") as HtmlAnchor;
            ha.HRef = ahref;
            HtmlAnchor ha2 = e.Item.FindControl("schref2") as HtmlAnchor;
            ha2.HRef = ahref;
            HtmlAnchor ha3 = e.Item.FindControl("schref3") as HtmlAnchor;
            ha3.HRef = ahref;
        }
    }
    private int GetPageIndex()
    {
        string paramPageIndex = Request[pagerGot.UrlPageIndexName];
        int pageIndex;
        int.TryParse(paramPageIndex, out pageIndex);
        return pageIndex;
    }
    protected void rptrmsc_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Model.Scenic s = e.Item.DataItem as Model.Scenic;
            foreach (Ticket item in s.Tickets.Where(x => x.IsMain == true))
            {
                HtmlContainerControl hc = e.Item.FindControl("nsinfosc_price") as HtmlContainerControl;
                hc.InnerHtml = item.TicketPrice[2].Price.ToString("0");
            }
            HtmlAnchor ha = e.Item.FindControl("ahref") as HtmlAnchor;
            ha.HRef = "/Tickets/" + bllArea.GetAreaByCode(s.Area.Code.Substring(0, 4) + "00").SeoName + "_" + s.Area.SeoName + "/" + s.SeoName + ".html";
        }
    }
}