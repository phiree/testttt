using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class UserCenter_UpdateCommonUser : basepage
{
    BLLCommonUser bllcommonuser = new BLLCommonUser();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["cuid"] != null)
            {
                CommonUser cu= bllcommonuser.GetCommonUserByid(int.Parse(Request.QueryString["cuid"]));
                txtName.Text = cu.Name;
                txtIdcard.Text = cu.IdCard;
            }
        }
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["cuid"] != null)
        {
            CommonUser cu = bllcommonuser.GetCommonUserByid(int.Parse(Request.QueryString["cuid"]));
            cu.Name = txtName.Text.Trim();
            cu.IdCard = txtIdcard.Text.Trim();
            bllcommonuser.updatecu(cu);
            Response.Redirect("CommonUserInfo.aspx");
        }
        else
        {
            CommonUser cu = new CommonUser();
            cu.Name = txtName.Text.Trim();
            cu.IdCard = txtIdcard.Text.Trim();
            cu.User = CurrentMember;
            string msg;
            bllcommonuser.SaveCommonUser(cu, out msg);
        }
    }
}