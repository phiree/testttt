using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using CommonLibrary;
public partial class ScenticManager_Default : bpScenicManager
{

    BLLScenic bllscenic = new BLLScenic();
    BLLTicketPrice bllticketprice = new BLLTicketPrice();
    BLLMembership bllMember = new BLLMembership();
    public string RoleNames = string.Empty;
    public string ScenicName = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        //ScenicName = this.CurrentScenic.Name;

        ScenicAdmin scenicAdmin = bllMember.GetScenicAdmin((Guid)CurrentMember.Id);
        ScenicName = scenicAdmin.Scenic.Name;
        switch ((int)scenicAdmin.AdminType)
        {
            case 1:
                RoleNames = scenicAdmin.AdminType.ToString();
                dvEditor.Visible = true;

                break;
            case 2:
                RoleNames = scenicAdmin.AdminType.ToString();
                dvChecker.Visible = true;
                break;
            case 4:
                RoleNames = scenicAdmin.AdminType.ToString();
                dvFinance.Visible = true;
                break;
            case 3:
                RoleNames = ScenicAdminType.景区资料员.ToString() + "," + ScenicAdminType.检票员.ToString();
                dvEditor.Visible = dvChecker.Visible = true;
                break;
            case 5:
                RoleNames = ScenicAdminType.景区资料员.ToString() + "," + ScenicAdminType.景区财务.ToString();
                dvEditor.Visible = dvAccountManager.Visible = true;

                break;
            case 6:
             
                 RoleNames = ScenicAdminType.检票员.ToString() + "," + ScenicAdminType.景区财务.ToString();
                dvChecker.Visible = dvAccountManager.Visible = true;
                break;
            case 7:
                RoleNames = "超级管理员";
                dvChecker.Visible = dvAccountManager.Visible = dvEditor.Visible = dvFinance.Visible = true;
                break;
            default:
                break;
        }

    }
}