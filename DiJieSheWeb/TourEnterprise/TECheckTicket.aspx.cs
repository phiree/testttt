using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

public partial class TourEnterprise_TECheckTicket : System.Web.UI.Page
{
    //前台绑定数据
    public string GuideName;
    public string GroupName;
    public string EnterpriceName;
    public string AdultAmount;
    public string ChildrenAmount;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private void bind()
    {
        string[] strinfos= txtTE_info.Text.Trim().Split('/');
        string idcard = strinfos[0];
        string name = strinfos[1];
        string mobile = strinfos[2];

    }
}