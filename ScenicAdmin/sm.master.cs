using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Model;
using BLL;
public partial class ScenicManager_sm : System.Web.UI.MasterPage
{
    BLL.BLLMembership bllMember = new BLL.BLLMembership();
    BLLScenicImg bllscenicimg = new BLLScenicImg();
    private Scenic currentScenic;
    public Scenic Scenic
    {
        get;
        set;
    }

    protected override void OnInit(EventArgs e)
    {
        MembershipUser mu = Membership.GetUser();
        if (mu == null || mu.UserName == string.Empty || bllMember.GetScenicAdmin((Guid)mu.ProviderUserKey)==null)
        {
            Response.Redirect("/login.aspx");
        }
        ScenicAdmin scenicAdmin = bllMember.GetScenicAdmin((Guid)mu.ProviderUserKey);
        liScenicName.Text = scenicAdmin.Scenic.Name;
        if (scenicAdmin == null)
        {
            BLL.ErrHandler.Redirect(BLL.ErrType.AccessDenied);
        }
        try
        {
            
            liUserName.Text = mu.UserName;
            Scenic = scenicAdmin.Scenic;
            liScenicName.Text = Scenic.Name;
            IList<ScenicImg> list = bllscenicimg.GetSiByType(Scenic, 1);
            imgScenic.Src ="/"+ System.Web.Configuration.WebConfigurationManager.AppSettings["ScenicImagePath"]+"/mainimg/" + list[0].Name;
            if (!string.IsNullOrEmpty(Scenic.Position))
            {
                HttpCookie httpcookie = new HttpCookie("unitposition", Scenic.Position);
                Response.Cookies.Add(httpcookie);
            }
            else
            {
                HttpCookie httpcookie = new HttpCookie("unitposition", "120.159033,30.28376");
                Response.Cookies.Add(httpcookie);
            }
            //Response.Redirect("/ScenicManager/UpdateScenticInfo.aspx");
            switch ((int)scenicAdmin.AdminType)
            {
                case 1:
                    this.adminBlock.Style.Add("display", "block");
                    this.checkBlock.Style.Add("display", "none");
                    this.accountBlock.Style.Add("display", "none");
                    cancelTa.Visible = false;
                    break;
                case 2:
                    this.adminBlock.Style.Add("display", "none");
                    this.checkBlock.Style.Add("display", "block");
                    this.accountBlock.Style.Add("display", "none");
                    cancelTa.Visible = false;
                    break;
                case 4:
                    this.adminBlock.Style.Add("display", "none");
                    this.checkBlock.Style.Add("display", "none");
                    this.accountBlock.Style.Add("display", "block");
                    cancelTa.Visible = false;
                    break;
                case 3:
                    this.adminBlock.Style.Add("display", "block");
                    this.checkBlock.Style.Add("display", "block");
                    this.accountBlock.Style.Add("display", "none");
                    cancelTa.Visible = false;
                    break;
                case 5:
                    this.adminBlock.Style.Add("display", "block");
                    this.checkBlock.Style.Add("display", "none");
                    this.accountBlock.Style.Add("display", "block");
                    cancelTa.Visible = false;
                    break;
                case 6:
                    this.adminBlock.Style.Add("display", "none");
                    this.checkBlock.Style.Add("display", "block");
                    this.accountBlock.Style.Add("display", "block");
                    cancelTa.Visible = false;
                    break;
                case 7:
                    this.adminBlock.Style.Add("display", "block");
                    this.checkBlock.Style.Add("display", "block");
                    this.accountBlock.Style.Add("display", "block");
                    cancelTa.Visible = true;
                    break;
                default:
                    this.adminBlock.Style.Add("display", "none");
                    this.checkBlock.Style.Add("display", "none");
                    this.accountBlock.Style.Add("display", "none");
                    cancelTa.Visible = false;
                    break;
            }
        }
        catch (Exception)
        {

        }
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnexit_Click(object sender, EventArgs e)
    {
    }
}