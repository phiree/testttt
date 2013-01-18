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

    BLL.BLLQZTicketSeller seller = new BLL.BLLQZTicketSeller();
    public TicketService()
    {

        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }
    /// <summary>
    /// 合作方请求门票资源
    /// </summary>
    /// <param name="PartnerCode">合作方ID</param>
    /// <param name="CardNumber">抢票者身份证号码</param>
    /// <param name="ProductCode">门票代码</param>
    /// <param name="Number">购买数量</param>
    /// <param name="errMsg">如果返回值为F,则是错误消息,若是T则为空</param>
    /// <returns>"T"(请票成功)或"F"(失败)</returns>
    [WebMethod]
    public string buyProduct(string PartnerCode , string CardNumber, string ProductCode,int Number,out string errMsg)
    {
        errMsg = string.Empty;
        string result = string.Empty;
      //  seller.SellTicket(clientFriendlyId, idcardno, ticketId);
        return result;
    }
    /// <summary>
    /// 合作方查询剩某日期的剩余门票数量
    /// </summary>
    /// <param name="PartnerCode">合作方ID</param>
    /// <param name="productCode">门票代码</param>
    /// <param name="dt">日期</param>
    /// <returns>剩余数量</returns>
    [WebMethod]
    public int ProductInfo(string PartnerCode, string productCode, DateTime dt)
    {

        int leftAmount = 0;
        return leftAmount;
    }
    /// <summary>
    /// 游客查询自己抢订到的门票
    /// </summary>
    /// <param name="idcardno">用户</param>
    /// <returns></returns>
    [WebMethod]
    public DataSet UserProductInfo(string idcardno)
    {
        DataSet dt = new DataSet();

        return dt;
    }
}
