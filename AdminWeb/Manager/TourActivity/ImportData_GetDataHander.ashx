<%@ WebHandler Language="C#" Class="ImportDataHander" %>

using System;
using System.Web;
using DAL.ado;
using BLL;
using System.Data;
public class ImportDataHander : IHttpHandler {
    string connectionstringforSync = "Server=60.191.70.234,98;database=TourzjWeiboManage;uid=sa;pwd=zmmisateacher";
    BLLActivityServiceImpl bllService = new BLLActivityServiceImpl();
   
    public void ProcessRequest (HttpContext context) {

            DAL.ado.NativeSqlUtiliity nativsql = new NativeSqlUtiliity(connectionstringforSync);
            DataSet ds = nativsql.ExecuteDateSet("select top 1 * from UserTicket where syncstate=0");
            if (ds.Tables[0].Rows.Count == 0)
            {
                context.Response.Write("finished");
            }
          DataRow row=ds.Tables[0].Rows[0];
            
                string log = "Begin" + DateTime.Now;
                int id = Convert.ToInt32(row["id"]);
                string idcardno = row["postcode"].ToString();
                DateTime buyTime = Convert.ToDateTime(row["gDate"]);
                int typeid = Convert.ToInt32(row["typeid"]);
                string ticketCode = row["gid"].ToString();
                string partnerCode = row["orderfrom"].ToString();
                int syncstate = Convert.ToInt32(row["syncstate"]);
                string phone = row["mobile"].ToString();
                string returnResult = string.Format(
        "{0}$_${1}$_${2}$_${3}$_${4}$_${5}$_${6}$_${7}",
        id,idcardno,buyTime,typeid,ticketCode,partnerCode,syncstate,phone
                    );
                context.Response.Write(returnResult);
              
    }

   
   
    public bool IsReusable {
        get {
            return false;
        }
    }

}