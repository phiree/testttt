using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.ado;
using BLL;
using System.Data;
public partial class Manager_TourActivity_ImportSyncTable : System.Web.UI.Page
{
    /*
     * 1 绑定未导入的数据
     * 2 测试数据有效性
     */
    BLLActivityServiceImpl bllService = new BLLActivityServiceImpl();
    public int TotalRecords = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        DAL.ado.NativeSqlUtiliity nativsql = new NativeSqlUtiliity(connectionstringforSync);
         
        DataSet ds = nativsql.ExecuteDateSet("select  * from UserTicket where syncstate=0");
        TotalRecords = ds.Tables[0].Rows.Count;
    }
    protected void btnImport_Click(object sender, EventArgs e)
    {

        ImportAllData();
    }
    string connectionstringforSync = "Server=60.191.70.234,98;database=TourzjWeiboManage;uid=sa;pwd=zmmisateacher";
    private void ImportAllData()
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        Guid importGuid = Guid.NewGuid();
        sb.AppendLine("导入开始,导入ID:"+importGuid);
        try
        {
            DAL.ado.NativeSqlUtiliity nativsql = new NativeSqlUtiliity(connectionstringforSync);
            DataSet ds = nativsql.ExecuteDateSet("select top 1 * from UserTicket where syncstate=0");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string log = "Begin" + DateTime.Now;
                int id = Convert.ToInt32(row["id"]);
                string idcardno = row["postcode"].ToString();
                DateTime buyTime = Convert.ToDateTime(row["gDate"]);
                int typeid = Convert.ToInt32(row["typeid"]);
                string ticketCode = row["gid"].ToString();
                string partnerCode = row["orderfrom"].ToString();
                int syncstate = Convert.ToInt32(row["syncstate"]);
                string phone = row["mobile"].ToString();
                log += string.Format("记录:[ {0},{1},{2},{3},{4},{5},{6},{7} ]", id, idcardno, buyTime, typeid, ticketCode, partnerCode, syncstate, phone);
                string realName = "活动参与者";
                string activitycode = typeid == 1 ? "quzhouspring" : "suichang2013";
                string result = bllService.buyProduct(false, activitycode, null, partnerCode, idcardno, realName, phone, ticketCode, 1,buyTime);
                log = result + log;
                if (result == "T")
                {
                    nativsql.ExecuteNonResult("update userticket set syncstate=1001 where id= " + id);
                }
                sb.AppendLine(log);

            }
        }
        catch (Exception ex)
        {
            sb.AppendLine(ex.ToString());
        }
        finally
        {
            sb.AppendLine("导入结束,导入ID:" + importGuid);

            string logFileName = "d:\\importsyncdata\\" + importGuid + ".txt";
            CommonLibrary.IOHelper.WriteContentToFile(logFileName, sb.ToString());
        }
    }

   
    private void BindData()
    {

    }
}