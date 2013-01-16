using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Model;
using BLL;
using System.Web.UI.HtmlControls;
public partial class MasterPage2 : System.Web.UI.MasterPage
{
   BLLMembership bllMember = new BLLMembership();
   public string iconUrl = "";
   public string iconAlt = "";
   public string inlineTip = "输入景区或景点名称";
   BLLArea bllArea = new BLLArea();
    protected void Page_Load(object sender, EventArgs e)
    {
        form1.Action = Request.RawUrl;
        
        if (Page.User.Identity.IsAuthenticated)
        {
           TourMembership member= bllMember.GetMember(Page.User.Identity.Name);
         
           switch (member.Opentype)
           {
               case Opentype.TencentWeibo:
                   iconAlt = "腾讯微博登录";
                   iconUrl = "/img/weiboicon16.png";
                   break;
               case Opentype.Sina: break;
           }
          
        }
        BindCart();
        

    }

    protected void BindCart()
    {
      IList<Ticket> ts=  new BLLTicket().GetTicketsFromCart();
      if (ts.Count == 0)
      {
          rptPopCart.Visible = false;
          pnlEmpty.Visible = true;
      }
      else

      {
          rptPopCart.Visible = true;
          pnlEmpty.Visible = false;
      }
        rptPopCart.DataSource = new BLLTicket().GetTicketsFromCart();
        rptPopCart.DataBind();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string q=tbxKeywords.Text;
        if (!(string.IsNullOrWhiteSpace(q)||q.Contains(inlineTip))) {
            Response.Redirect("/search/default.aspx?q=" + q,true);
        }

    }
    protected void rptPopCart_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Ticket t = e.Item.DataItem as Ticket;
            HtmlAnchor haa = e.Item.FindControl("ahref") as HtmlAnchor;
            haa.HRef = "/Tickets/" + bllArea.GetAreaByCode(t.Scenic.Area.Code.Substring(0, 4) + "00").SeoName + "_" + t.Scenic.Area.SeoName + "/" + t.Scenic.SeoName + ".html";
        }
    }

    protected void btnScLogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("/ScenicManager/Login.aspx");
    }
}
