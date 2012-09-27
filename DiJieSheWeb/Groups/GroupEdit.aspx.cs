using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class LocalTravelAgent_GroupEdit : basepage
{
    //VAR
    public const string GROUPID = "GROUPID";
    private string groupid;

    //
    BLL.BLLDJEnterprise blldjs = new BLL.BLLDJEnterprise();


    protected void Page_Load(object sender, EventArgs e)
    {
        groupid = Request.QueryString["id"];
        if (!string.IsNullOrEmpty(groupid))
        {
            HttpCookie cookie = new HttpCookie(GROUPID, groupid);
            Response.Cookies.Add(cookie);
            BindGroup();
        }
        BindDJS();
    }

    private void BindGroup()
    {
        Model.DJ_TourGroup tg=blldjs.GetGroup8gid(groupid);
        txtGroupname.Text = tg.Name;
        txtBegintime.Text = tg.BeginDate.ToShortDateString();
        txtEndtime.Text = tg.EndDate.ToShortDateString();
        txtAdultnum.Text = tg.AdultsAmount.ToString();
        txtChildnum.Text = tg.ChildrenAmount.ToString();
        txtDays.Text = tg.DaysAmount.ToString();
    }

    private void BindDJS()
    {
        //根据登陆用户的类型加载  ddl_enterprice
        IList<Model.DJ_TourEnterprise> djslist = new List<Model.DJ_TourEnterprise>();
        Model.DJ_User_Gov user_gov = CurrentMember as Model.DJ_User_Gov;
        Model.DJ_User_TourEnterprise user_entp = CurrentMember as Model.DJ_User_TourEnterprise;
        //1.如果是政府企业用户
        if (user_gov != null)
        {
            djslist = blldjs.GetDjs8all();
        }
        //2.如果是地接社用户
        if (user_entp != null)
        {
            djslist = blldjs.GetDJS8type(Model.EnterpriseType.旅行社.ToString());
        }
        //结束
        IList<Model.DJ_DijiesheInfo> djlist = new List<Model.DJ_DijiesheInfo>();
        foreach (var item in djslist)
        {
            Model.DJ_DijiesheInfo dj = item as Model.DJ_DijiesheInfo;
            if (dj != null)
            {
                djlist.Add(dj);
            }
        }
        ddlDJS.DataSource = djlist;
        ddlDJS.DataTextField = "Name";
        ddlDJS.DataValueField = "Id";
        ddlDJS.DataBind();
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        IList<Model.DJ_TourEnterprise> telist = blldjs.GetDJS8id(ddlDJS.Text);
        Model.DJ_TourGroup tg = blldjs.GetGroup8name(txtGroupname.Text.Trim());
        //if (tg != null)
        //{
        //    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('已存在该名称')", true);
        //}
        Guid djsid=blldjs.AddBasicinfo(telist[0] as Model.DJ_DijiesheInfo, txtGroupname.Text, Calendar1.SelectedDate,
            Calendar2.SelectedDate, int.Parse(txtDays.Text), int.Parse(txtAdultnum.Text), int.Parse(txtChildnum.Text));
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        btnOK_Click(null, null);
        Response.Redirect("/Groups/GroupMemberid.aspx");
    }

    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        txtBegintime.Text = Calendar1.SelectedDate.ToString("yyyy-MM-dd");
    }

    protected void Calendar2_SelectionChanged(object sender, EventArgs e)
    {
        txtEndtime.Text = Calendar2.SelectedDate.ToString("yyyy-MM-dd");
    }
}