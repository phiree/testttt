<%@ WebHandler Language="C#" Class="ImportDataHander" %>

using System;
using System.Web;
using DAL.ado;
using BLL;
using System.Data;
public class ImportDataHander : IHttpHandler {
    
    BLLActivityServiceImpl bllService = new BLLActivityServiceImpl();
    string connectionstringforSync = "Server=60.191.70.234,98;database=TourzjWeiboManage;uid=sa;pwd=zmmisateacher";
    BLLTourActivity bllAct = new BLLTourActivity();
    BLLActivityPartner bllPartner = new BLLActivityPartner();
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
        
        
         
         string realName = "活动参与者";
                string activitycode = typeid == 1 ? "quzhouspring" : "suichang2013";
                string activityId = bllAct.GetOneByActivityCode(activitycode).Id.ToString();
                string partnerId = bllPartner.GetByPartnerCode(activitycode, partnerCode).Id.ToString();
                string log = Environment.NewLine + Environment.NewLine + "Begin" + DateTime.Now;
                log += string.Format(@"记录:[ userticketid:{0},身份证号:{1},购买时间:{2},
                                            活动类型:{3},活动ID:{4},合作商ID:{5},
                                            门票代码:{6},同步状态:{7},电话号码:{8} ]", id, idcardno, buyTime, typeid,activityId,partnerId, ticketCode, syncstate, phone)
                    + Environment.NewLine;
              
                string result = string.Empty ;
                try
                {
                    //调用存储过程
                    /*
                     [usp_TicketRequest]
(
  @IDCard Varchar(50),		--身份证
  @RealName VarChar(50),	--姓名
  @Phone Varchar(50),		--电话
  @ActivityID uniqueidentifier,--活动代码
  @PartnerID  uniqueidentifier, --合作商代码
  @ProductCode VarChar(100),    --门票代码
  @ReqAmount int,				--请求门票的数量
  @Remark VarChar(255)			--备注(订单详情)
                     */
                  
                    if (SiteConfig.ImportUsingProc)
                    {
                        DateTime beginProc = DateTime.Now;
                        log += "存储过程执行开始:" + beginProc.ToString("MMdd hh-mm-ss fff") + Environment.NewLine;
                        DAL.ado.NativeSqlUtiliity nativeSql = new NativeSqlUtiliity
                            (System.Configuration.ConfigurationManager.ConnectionStrings["TourOnlineConn"].ConnectionString);
                        nativeSql.ExecuteDataSetProc("usp_TicketRequest", new string[] { 
                    idcardno,realName,phone,activityId,partnerId,ticketCode,"1",""
                    }, out result);
                        DateTime endProc = DateTime.Now;
                        log += "存储过程执行结束:" + endProc.ToString("MMdd hh-mm-ss fff") + Environment.NewLine;
                        log += "存储过程执行耗时:" + (endProc - beginProc).TotalMilliseconds + Environment.NewLine;
                    }
                    else
                    {
                        DateTime beginBLL = DateTime.Now;
                        log += "业务逻辑执行开始:" + beginBLL.ToString("MMdd hh-mm-ss fff") + Environment.NewLine;

                        result = bllService.buyProduct(false, activitycode, null, partnerCode, idcardno, realName, phone, ticketCode, 1, buyTime);
                        DateTime endBLL = DateTime.Now;
                        log += "业务逻辑执行结束:" + endBLL.ToString("MMdd hh-mm-ss fff") + Environment.NewLine;
                        log += "业务逻辑执行耗时:" + (endBLL - beginBLL).TotalMilliseconds + Environment.NewLine;

                    }
                }
                catch (Exception ex)
                {
                    result = ex.Message;
                    HttpContext.Current.Server.ClearError();
                }
                if (result == "T")
                {
                    DAL.ado.NativeSqlUtiliity nativsql = new NativeSqlUtiliity(SiteConfig.SyncServerConnection);
                    nativsql.ExecuteNonResult("update "+SiteConfig.SyncTableName+" set syncstate=1 where id= " + id);
                }
                else
                {
                    DAL.ado.NativeSqlUtiliity nativsql = new NativeSqlUtiliity(SiteConfig.SyncServerConnection);
                    nativsql.ExecuteNonResult("update " + SiteConfig.SyncTableName + " set syncstate=3 where id= " + id);
                }
                log = result+"_" + log;
                CommonLibrary.IOHelper.WriteContentToFile(
                    context.Server.MapPath(@"/tourolAdminLog/importData/AjaxResult"+DateTime.Now.ToString("yyyyMMddHH")+".txt"), log+Environment.NewLine);
                context.Response.Write(result);
              
    }

  
    public bool IsReusable {
        get {
            return false;
        }
    }

}