using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BLL;
using System.Data;
/// <summary>
///WebService 的摘要说明
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
//若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。 
// [System.Web.Script.Services.ScriptService]
public class TicketService : System.Web.Services.WebService
{

    BLL.QuZhouSpring.BLLTicketSeller seller = new BLL.QuZhouSpring.BLLTicketSeller();
    public TicketService()
    {

        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }
    [WebMethod]
    public string buyProduct(string PartnerCode , string CardNumber, string ProductCode,int Number,out string errMsg)
    {
        errMsg = string.Empty;
        string result = string.Empty;
      //  seller.SellTicket(clientFriendlyId, idcardno, ticketId);
        return result;
    }
    /// <summary>
    /// 接入方
    /// </summary>
    /// <param name="PartnerCode"></param>
    /// <param name="productCode"></param>
    /// <param name="dt"></param>
    /// <returns></returns>
    [WebMethod]
    public string ProductInfo(string PartnerCode, string productCode, DateTime dt)
    {

        return string.Empty;
    }
    [WebMethod]
    public DataSet UserProductInfo(string idcardno)
    {
        DataSet dt = new DataSet();

        return dt;
    }
}
