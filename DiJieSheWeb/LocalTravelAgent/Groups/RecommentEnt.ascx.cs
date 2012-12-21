using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using System.Web.UI.HtmlControls;
using System.Data;
using CommonLibrary;
public partial class LocalTravelAgent_Groups_RecommentEnt : System.Web.UI.UserControl
{
    public string AreaCode { get; set; }
    public string redirtRecEntList { get; set; }
    BLLDJ_GovManageDepartment BllGov = new BLLDJ_GovManageDepartment();
    BLLArea bllArea = new BLLArea();
    BLLDJ_Recommand bllRec = new BLLDJ_Recommand();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindArea(3);
            ddlProvince.SelectedValue = "330000";
            ddlProvince_SelectedIndexChanged(null, null);
            BindRecommendEnt();
        }
    }
    private void BindRecommendEnt()
    {
        rptRecomEnt.DataSource = BllGov.GetSubDptByCode(GetCode());
        rptRecomEnt.DataBind();
        //rptRecomEnt.DataSource = ListGov;
        //rptRecomEnt.DataBind();
    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        BindRecommendEnt();
    }
    protected void rptRecomEnt_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            DJ_GovManageDepartment Gov = e.Item.DataItem as DJ_GovManageDepartment;
            HtmlAnchor redirtLink = e.Item.FindControl("redirtLink") as HtmlAnchor;
            Literal laPolicy=e.Item.FindControl("laPolicy") as Literal;
            Button btnUpload = e.Item.FindControl("btnUpload") as Button;
            redirtLink.HRef = redirtRecEntList + "?dptid=" + Gov.Id;
            DJ_Recommand rec=bllRec.GetByGovId(Gov);
            if (rec != null)
            {
                laPolicy.Text = rec.RewardPolicy;
                if (!string.IsNullOrEmpty(rec.UploadFile))
                {
                    btnUpload.CommandArgument = rec.UploadFile;
                    btnUpload.Visible = true;
                }
            }
            else if (laPolicy.Text == "" || btnUpload.CommandArgument=="")
            {
                e.Item.Visible = false;
            }
        }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        var collection = BllGov.GetSubDptByCode(GetCode());
        DataTable dt = new DataTable();
        DataColumn dc = new DataColumn("col1");
        dt.Columns.Add(dc);
        dc = new DataColumn("col2");
        dt.Columns.Add(dc);
        foreach (var item in collection)
        {
            DataRow dr = dt.NewRow();
            dr[0] = item.Name;
            dr[1] = "奖励政策";
            dt.Rows.Add(dr);
        }
        new ExcelOplib.ExcelOutput().Download2Excel(dt, this.Page, new List<string>() { "名称", "奖励政策" }, "奖励企业"+"[" + DateTime.Today.ToString("yyyy-MM-dd") + "]");
    }

    protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlProvince.SelectedValue != "全部")
        {
            bindArea(2);
            foreach (ListItem item in ddlCity.Items)
            {
                if(item.Text!="全部")
                    item.Text = item.Text.Substring(3);
            }
            foreach (ListItem item in ddlCountry.Items)
            {
                if (item.Text != "全部")
                    item.Text = item.Text.Substring(3);
            }
        }
    }
    protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCity.SelectedValue != "全部")
        {
            bindArea(1);
            foreach (ListItem item in ddlCountry.Items)
            {
                if (item.Text != "全部")
                    item.Text = item.Text.Substring(3);
            }
        }
        else
        {
            ddlCountry.Items.Clear();
            ddlCountry.Items.Insert(0, new ListItem("全部", "全部"));
        }
    }

    private void bindArea(int AreaLevel)
    {
        if (AreaLevel >= 3)
        {
            ddlProvince.DataTextField = "Name";
            ddlProvince.DataValueField = "Code";
            ddlProvince.DataSource = bllArea.GetAreaProvince();
            ddlProvince.DataBind();
        }
        if (AreaLevel >= 2)
        {
            ddlCity.DataTextField = "Name";
            ddlCity.DataValueField = "Code";
            ddlCity.DataSource = bllArea.GetSubArea(ddlProvince.SelectedValue);
            ddlCity.DataBind();
            ddlCity.Items.Insert(0, new ListItem("全部", "全部"));
        }
        if (AreaLevel >= 1)
        {
            ddlCountry.DataTextField = "Name";
            ddlCountry.DataValueField = "Code";
            ddlCountry.Items.Clear();
            if (ddlCity.SelectedValue != "全部")
            {
                ddlCountry.DataSource = bllArea.GetSubArea(ddlCity.SelectedValue);
                ddlCountry.DataBind();
            }
            ddlCountry.Items.Insert(0, new ListItem("全部", "全部"));
        }
    }

    private string GetCode()
    {
        if (ddlCity.SelectedValue == "全部")
        {
            return ddlProvince.SelectedValue;
        }
        else if (ddlCountry.SelectedValue == "全部")
        {
            return ddlCity.SelectedValue;
        }
        else
        {
            return ddlCountry.SelectedValue;
        }
    }
    protected void rptRecomEnt_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "upload")
        {
            downloadFile df = new downloadFile();
            string filename = "/PolicyFile/" + e.CommandArgument;
            df.download(e.CommandArgument.ToString(),filename, Page);
        }
    }
}