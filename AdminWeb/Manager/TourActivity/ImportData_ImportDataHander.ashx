<%@ WebHandler Language="C#" Class="ImportDataHander" %>

using System;
using System.Web;
using DAL.ado;
using BLL;
using System.Data;
public class ImportDataHander : IHttpHandler {
    
    BLLActivityServiceImpl bllService = new BLLActivityServiceImpl();
    string connectionstringforSync = "Server=60.191.70.234,98;database=TourzjWeiboManage;uid=sa;pwd=zmmisateacher";
  
    public void ProcessRequest (HttpContext context) {

            
                int id = Convert.ToInt32(context.Request["id"]);
                string idcardno = context.Request["idcardno"].ToString();
                DateTime buyTime = Convert.ToDateTime(context.Request["buyTime"]);
                int typeid = Convert.ToInt32(context.Request["typeid"]);
                string ticketCode = context.Request["ticketCode"].ToString();
                string partnerCode = context.Request["partnerCode"].ToString();
                int syncstate = Convert.ToInt32(context.Request["syncstate"]);
                string phone = context.Request["phone"].ToString();
                if (string.IsNullOrEmpty(partnerCode))
                {
                    partnerCode = "tourol.cn";
                }
        
           string log = "Begin" + DateTime.Now;
                log += string.Format("记录:[ {0},{1},{2},{3},{4},{5},{6},{7} ]", id, idcardno, buyTime, typeid, ticketCode, partnerCode, syncstate, phone);
              
         string realName = "活动参与者";
                string activitycode = typeid == 1 ? "quzhouspring" : "suichang2013";
                string result = string.Empty ;
                try
                {
                     result = bllService.buyProduct(false, activitycode, null, partnerCode, idcardno, realName, phone, ticketCode, 1);
                }
                catch (Exception ex)
                {
                    result = ex.Message;
                }
                if (result == "T")
                {
                    DAL.ado.NativeSqlUtiliity nativsql = new NativeSqlUtiliity(connectionstringforSync);
                    nativsql.ExecuteNonResult("update userticket set syncstate=2 where id= " + id);
                }
                else
                {
                    DAL.ado.NativeSqlUtiliity nativsql = new NativeSqlUtiliity(connectionstringforSync);
                    nativsql.ExecuteNonResult("update userticket set syncstate=3 where id= " + id);
                }
                log = result + log;
                CommonLibrary.IOHelper.WriteContentToFile("d:\\importData\\AjaxResult.txt", log+Environment.NewLine);
                context.Response.Write(result);
              
    }

  
    public bool IsReusable {
        get {
            return false;
        }
    }

}