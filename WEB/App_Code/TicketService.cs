using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BLL;
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
    public string GetTicket(string clientFriendlyId, string idcardno, int ticketId)
    {
        
        string result = string.Empty;
        seller.SellTicket(clientFriendlyId, idcardno, ticketId);
        return result;
    }

}
