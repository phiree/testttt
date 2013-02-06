using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FluentNHibernate.Data;
using System.IO;
using System.Text;

public partial class Manager_QuZhouSpring_AgentExcellist : System.Web.UI.Page
{
    private readonly string mappath = HttpContext.Current.Server.MapPath("/manager/d");
    //private BLL.BLLQZTicketSeller bllqzseller = new BLL.BLLQZTicketSeller();
    private BLL.BLLTicket bllticket = new BLL.BLLTicket();
    private BLL.BLLActivityServiceImpl bllactivity = new BLL.BLLActivityServiceImpl();

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
            string result = bllactivity.buyProduct("quzhouspring",false,null,zhejiangTourPartnerId, 
              lblIdCardNo.Text.Trim(),lblName.Text.Trim(),lblPhone.Text.Trim(), lblProductCode.Text.Trim(), 1);
            Button btn = e.Item.FindControl("btn") as Button;
            btn.Text = result;
            //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "alert('"+result+"');", true);
        }
    }
    private void getTicketslist()
    {
        var ds = new DataSet();
        var dt = new DataTable();
        string result = string.Empty;
        if (dt.Rows.Count == 0)
        {
            var conn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " + mappath + "/衢州门票客户信息.xls;Extended Properties=Excel 8.0";
            const string sql = "select 景区名称,姓名,身份证号码,手机号码,ticketcode from [Sheet1$] order by 身份证号码 desc";
            var cmd = new OleDbCommand(sql, new OleDbConnection(conn));
            var ad = new OleDbDataAdapter(cmd);
            ad.Fill(dt);
        }
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        System.Text.StringBuilder sb_result = new StringBuilder();

        for (var i = 0; i < dt.Rows.Count; i++)
        {
            result = bllactivity.buyProduct("quzhouspring", false, null, zhejiangTourPartnerId,
                                      dt.Rows[i][2].ToString().Replace("\n", "").Trim(),//身份证号码
                                      dt.Rows[i][1].ToString().Replace("\n", "").Trim(),//姓名
                                      dt.Rows[i][3].ToString().Replace("\n", "").Trim(),//手机号码
                                      dt.Rows[i][4].ToString().Replace("\n", "").Trim(),//ticketcode
                                      1);
            if (result != "T")
            {
                sb.AppendLine("<br/>" + dt.Rows[i][0].ToString() + "    " + dt.Rows[i][1].ToString() + "    " + dt.Rows[i][2].ToString() + "    ");
                sb.AppendLine(result);
                sb_result.AppendLine(dt.Rows[i][0].ToString() + "    " + dt.Rows[i][1].ToString() + "    " + dt.Rows[i][2].ToString() + "    " + result);
            }
        }
        FileStream fs = new FileStream(mappath + "/导入结果.txt", FileMode.OpenOrCreate);
        //获得字节数组
        byte[] data = new UTF8Encoding().GetBytes(sb_result.ToString());
        //开始写入
        fs.Write(data, 0, data.Length);
        //清空缓冲区、关闭流
        fs.Flush();
        fs.Close();
        lblresult.Text = sb.ToString();
    }
}