using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BLL;
using Model;
using System.Data;
/// <summary>
///WebService 的摘要说明
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
//若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。 
 [System.Web.Script.Services.ScriptService]
public class TicketService : System.Web.Services.WebService
{

    BLL.BLLQZTicketSeller seller = new BLL.BLLQZTicketSeller();
    BLL.BLLQZPartnerTicketAsign bllQzPartnerTicketAsign = new BLLQZPartnerTicketAsign();
    BLL.BLLTicketAssign bllTicketAssign = new BLLTicketAssign();
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
    ///  <param name="RealName">抢票者的姓名(如果不填,则传用户昵称</param>
    /// <param name="Phone">抢票者的电话号码</param>
    /// <param name="ProductCode">门票代码</param>
    /// <param name="Number">购买数量</param>

    /// <returns>"T"(请票成功)或"F|(失败原因)"</returns>
    [WebMethod]
    public string buyProduct(string PartnerCode, string CardNumber, string RealName, string Phone, string ProductCode, int Number)
    {

        string result = seller.SellTicket(PartnerCode, CardNumber, RealName, Phone, ProductCode, Number);
        //  seller.SellTicket(clientFriendlyId, idcardno, ticketId);
        return result;
    }
    /// <summary>
    /// 媒体请求门票资源
    /// </summary>
    /// <param name="PartnerCode">合作方ID</param>
    /// <param name="CardNumber">抢票者身份证号码</param>
    ///  <param name="RealName">抢票者的姓名(如果不填,则传用户昵称</param>
    /// <param name="Phone">抢票者的电话号码</param>
    /// <param name="ProductCode">门票代码</param>
    /// <param name="Number">购买数量</param>

    /// <returns>"T"(请票成功)或"F|(失败原因)"</returns>
    [WebMethod]
    public string buyProductForMedia(string PartnerCode, string CardNumber, string RealName, string Phone, string ProductCode, int Number)
    {

        string result = seller.SellTicket(true, PartnerCode,null,RealName, CardNumber, Phone, ProductCode, Number);
        //  seller.SellTicket(clientFriendlyId, idcardno, ticketId);
        return result;
    }
    /// <summary>
    /// 合作方查询剩某日期某门票的剩余门票数量
    /// </summary>
    /// <param name="PartnerCode">合作方ID</param>
    /// <param name="productCode">门票代码</param>
    /// <param name="dt">日期</param>
    /// <returns>剩余数量</returns>
    [WebMethod]
    public int ProductInfo(string PartnerCode, string productCode, DateTime dt)
    {

        Model.QZPartnerTicketAsign qzPartnerTicketAsign = bllQzPartnerTicketAsign.GetOne(dt.Date, PartnerCode, productCode);
        if (qzPartnerTicketAsign == null)
        {
            TourLog.LogInstance.Error("没有查到相应信息");
            return -1;

        }
        int leftAmount = qzPartnerTicketAsign.AsignedAmount - qzPartnerTicketAsign.SoldAmount;
        if (leftAmount < 0) leftAmount = 0;
        return leftAmount;
    }
    /// <summary>
    /// 游客查询自己抢订到的门票
    /// </summary>
    /// <param name="idcardno">用户</param>
    /// <returns>
    /// dataset结构:
    ///   <dataset>
    ///    <datatable>
    ///     <dr>
    ///       <dt>ScenicName 景区名称</dt> 
    ///       <dt>OrderTime 抢票时间</dt> 
    ///       <dt>IsUsed 是否已使用("true"或者 "false"</dt> 
    ///        <dt>ValidPeriod 有效期限(2013-02-01~2013-02-29)</dt>
    ///     </dr>   
    /// </datatable>
    /// </returns>
    [WebMethod]
    public DataSet UserProductInfo(string idcardno)
    {


        return bllTicketAssign.GetTicketsHasProductCode(idcardno);
    }
    /// <summary>
    /// 更新身份证信息
    /// </summary>
    /// <param name="oldNo">原有身份证号码</param>
    /// <param name="newNo">新身份证号码</param>
    /// <returns>T 或者 F|(详细错误信息)</returns>
    [WebMethod]
    public string UpdateIdCardNo(string oldNo, string newNo)
    {
        string result = bllTicketAssign.UpdateIdCardNo(oldNo, newNo);
        if (string.IsNullOrEmpty(result))
        {
            return "T";
        }
        else
        {
            return "F|" + result;
        }
    }

    /// <summary>
    /// 获取所有门票的剩余票量
    /// </summary>
    /// <param name="partnerCode"></param>
    /// <param name="date"></param>
    /// <returns></returns>
    [WebMethod]
    public DataSet ProductInfoAll(string partnerCode,DateTime date)
    {
        return bllQzPartnerTicketAsign.ProductInfoAll(partnerCode, date);
    }
}
