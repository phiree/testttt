using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FluentNHibernate.Data;

public partial class Manager_QuZhouSpring_AgentExcellist : System.Web.UI.Page
{
    private readonly string mappath = HttpContext.Current.Server.MapPath("/manager/d");
    private BLL.BLLQZTicketSeller bllqzseller = new BLL.BLLQZTicketSeller();
    private BLL.BLLTicket bllticket = new BLL.BLLTicket();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Bind();
        }
    }

    protected void btnInput_Click(object sender, EventArgs e)
    {
        getTicketslist();
        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "alert('ok');", true);
    }

    private void Bind()
    {
        var ds = new DataSet();
        var dt = new DataTable();
        #region 03
        if (dt.Rows.Count == 0)
        {
            var conn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " + mappath + "/衢州门票客户信息.xls;Extended Properties=Excel 8.0";
            const string sql = "select 景区名称,姓名,身份证号码,手机号码,ticketcode from [Sheet1$] order by 身份证号码 desc";
            var cmd = new OleDbCommand(sql, new OleDbConnection(conn));
            var ad = new OleDbDataAdapter(cmd);
            ad.Fill(dt);
        }
        #endregion

        rptTaList.DataSource = dt;
        rptTaList.DataBind();

    }

    //const string zhejiangTourPartnerId = "9c815efa-402a-40ce-860b-c0fa37f707eb";
    const string zhejiangTourPartnerId = "taizhou";
    protected void rptTaList_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "add")
        {

            Label lblName = e.Item.FindControl("lblName") as Label;
            Label lblIdCardNo = e.Item.FindControl("lblIdCardNo") as Label;
            Label lblProductCode = e.Item.FindControl("lblProductCode") as Label;
            Label lblPhone = e.Item.FindControl("lblPhone") as Label;
            /*
  bool ismedia, string clientFriendlyId, TourMembership member, string assignName, string idcardno, string phone, string ticketCode, int amount)
        {
             */
            string result = bllqzseller.SellTicket(true, zhejiangTourPartnerId
              , null,
              lblName.Text.Trim(), lblIdCardNo.Text.Trim(), lblPhone.Text.Trim(), lblProductCode.Text.Trim(), 1);
            Button btn = e.Item.FindControl("btn") as Button;
            btn.Text = result;
            //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "alert('"+result+"');", true);
        }
    }

    //老版本，活动导入方法
    //private void getTicketslist()
    //{
    //    var ds = new DataSet();
    //    var dt = new DataTable();
    //    if (dt.Rows.Count == 0)
    //    {
    //        var conn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " + mappath + "/衢州门票客户信息.xls;Extended Properties=Excel 8.0";
    //        const string sql = "select 景区名称,姓名,身份证号码,手机号码,ticketcode from [Sheet1$] order by 身份证号码 desc";
    //        var cmd = new OleDbCommand(sql, new OleDbConnection(conn));
    //        var ad = new OleDbDataAdapter(cmd);
    //        ad.Fill(dt);
    //    }
    //    System.Text.StringBuilder sb = new System.Text.StringBuilder();

    //    for (var i = 0; i < dt.Rows.Count; i++)
    //    {
    //        sb.AppendLine("<br/>" + dt.Rows[i][0].ToString()+"    "+ dt.Rows[i][1].ToString() +"    "+ dt.Rows[i][2].ToString()+"    ");
    //        string result = bllqzseller.SellTicket(true, zhejiangTourPartnerId, null,
    //                                  dt.Rows[i][1].ToString().Replace("\n", "").Trim(),//姓名
    //                                  dt.Rows[i][2].ToString().Replace("\n", "").Trim(),//身份证号码
    //                                  dt.Rows[i][3].ToString().Replace("\n", "").Trim(),//手机号码
    //                                  dt.Rows[i][4].ToString().Replace("\n", "").Trim(),//ticketcode
    //                                  1);
    //        sb.AppendLine(result);
    //    }
    //    lblresult.Text = sb.ToString();
    //}

    //新版本，正常票导入方式
    private void getTicketslist()
    {
        var ds = new DataSet();
        var dt = new DataTable();
        if (dt.Rows.Count == 0)
        {
            var conn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " + mappath + "/衢州门票客户信息.xls;Extended Properties=Excel 8.0";
            const string sql = "select 景区名称,姓名,身份证号码,手机号码,ticketcode from [Sheet1$] order by 身份证号码 desc";
            var cmd = new OleDbCommand(sql, new OleDbConnection(conn));
            var ad = new OleDbDataAdapter(cmd);
            ad.Fill(dt);
        }
        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        for (var i = 0; i < dt.Rows.Count; i++)
        {
            sb.AppendLine("<br/>" + dt.Rows[i][2].ToString() + "    ");

            string result = bllticket.BuyTicket(null, 1093, string.Empty, dt.Rows[i][2].ToString().Replace("\n", "").Trim(), string.Empty, 1);
            result += bllticket.BuyTicket(null, 1096, string.Empty, dt.Rows[i][2].ToString().Replace("\n", "").Trim(), string.Empty, 1);
            result += bllticket.BuyTicket(null, 1099, string.Empty, dt.Rows[i][2].ToString().Replace("\n", "").Trim(), string.Empty, 1);
            result += bllticket.BuyTicket(null, 1102, string.Empty, dt.Rows[i][2].ToString().Replace("\n", "").Trim(), string.Empty, 1);
            result += bllticket.BuyTicket(null, 1105, string.Empty, dt.Rows[i][2].ToString().Replace("\n", "").Trim(), string.Empty, 1);
            result += bllticket.BuyTicket(null, 1108, string.Empty, dt.Rows[i][2].ToString().Replace("\n", "").Trim(), string.Empty, 1);
            result += bllticket.BuyTicket(null, 1111, string.Empty, dt.Rows[i][2].ToString().Replace("\n", "").Trim(), string.Empty, 1);
            result += bllticket.BuyTicket(null, 1114, string.Empty, dt.Rows[i][2].ToString().Replace("\n", "").Trim(), string.Empty, 1);
            sb.AppendLine(result);
        }
        lblresult.Text = sb.ToString();
    }
}