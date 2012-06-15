using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Model;
using BLL;
public partial class MasterPage2 : System.Web.UI.MasterPage
{
   BLLMembership bllMember = new BLLMembership();
   public string iconUrl = "";
   public string iconAlt = "";
   public string inlineTip = "输入景区或景点名称";
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
}
