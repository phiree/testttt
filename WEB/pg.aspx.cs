using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;

public partial class pg : System.Web.UI.Page
{
    private static readonly ILog log = LogManager.GetLogger("PaymentLogger");

    string responseText = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        log.Info(Request.Params);
        string returnurl = Request["return_url"];

        GO("TRADE_SUCCESS");

        string target = returnurl + "?" + responseText.TrimEnd(new char[] {'&'});

        Response.Redirect(target);
    }
    /// <summary>
    /// TRADE_FINISHED
    /// TRADE_SUCCESS
    /// </summary>
    /// <param name="status"></param>
    public void GO(string status)
    {

        BuildRequest("trade_no", "TradeNo_"+Guid.NewGuid());
        BuildRequest("out_trade_no", Request["out_trade_no"]);


        BuildRequest("total_fee", Request["total_fee"]);
        BuildRequest("subject", Request["subject"]);
        BuildRequest("body", Request["body"]);
        BuildRequest("buyer_email", Request["buyer_email"]);
        BuildRequest("trade_status", status);
     
    }

    public void  BuildRequest(string key, string value)
    { 
        responseText+=key+"="+value+"&";
    }
}