using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using System.Xml;
using System.Net;
using System.IO;
using System.Text;
using System.Net.Sockets;

public partial class Voting_Default : basepage
{
    BLL.BLLScenic bllScenic = new BLL.BLLScenic();
    BLL.BLLArea bllArea = new BLL.BLLArea();
    BLL.BLLVote bllVote = new BLL.BLLVote();
    public string MemberId {
        get {
            return CurrentUser.ProviderUserKey == null ? "" : CurrentUser.ProviderUserKey.ToString();
        }
        private set { }
    }
    public string Urlfrom {
        get {
            return Request.UrlReferrer == null ? "" : Request.UrlReferrer.Host;
        }
        private set { }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(Request.QueryString["promid"]))
        {
            Response.Cookies.Add(new HttpCookie("promid", Request.QueryString["promid"]));
        }
        if (!IsPostBack)
        {
            BindScenics(); 
            BindArea();
        }
    }

    private void BindScenics()
    {
        string areacode=Request.QueryString["areacode"];//获取传入的市级地区id
        if (string.IsNullOrWhiteSpace(areacode)) areacode = "330100";//如果没有传入,默认杭州.  -->扩展到其他省网站上获取盛会
        IList<Scenic> scenics = bllScenic.GetScenicByAreacode(areacode);
        rptSenic2Vote.DataSource = scenics;
        rptSenic2Vote.DataBind();
    }

    private void BindArea()
    {
        IList<Area> areas = bllArea.GetSubArea("330000");//传入浙江省areacode
        rptArea2Vote.DataSource = areas;
        rptArea2Vote.DataBind();
    }
    protected void rptSenic2Vote_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "detail")
        {
            int scenicid = int.Parse(e.CommandArgument.ToString());
            Response.Redirect("../Scenic/?id="+scenicid);
            return;
        }
        //本地用户 && QQ用户没有登录
        if (string.IsNullOrWhiteSpace(CurrentUser.UserName))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请先登录');", true);
            Response.Redirect("../Account/Login.aspx?ReturnUrl=%2fVoting%2fDefault.aspx%3fareacode%3d331000");
            return;
        }
        try
        {
            if (e.CommandName == "vote")
            {
                //判断是否还有投票权
                if (!isCanVote())
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('你的投票权已使用完，详情点击个人中心查看！');", true);
                    return;
                }
                int scenicid = int.Parse(e.CommandArgument.ToString());
                //QQ方式投票
                //Vote8QQ(scenicid);
                if (isOauthUser())
                {
                    //QQweibo方式投票
                    Vote8weibo(scenicid);
                }
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('投票成功！');", true);
            } 
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #region 判断是否还有投票权
    public bool isCanVote()
    {
        long totalAmount = bllVote.GetUserTotalAmount(new Guid(MemberId));
        long usedAmount = bllVote.GetUserVotedAmount(new Guid(MemberId));
        if (usedAmount < totalAmount)
            return true;
        else
            return false;
    }

    public bool isOauthUser()
    {
        bool result = false;
        Model.User user = (Model.User)CurrentMember;
        if (!string.IsNullOrWhiteSpace(user.Openid))
            result = true;
        return result;
    }
    #endregion

    #region QQweibo投票
    public void Vote8weibo(int scenicid)
    {
        new BLL.BLLVote().Vote(new Guid(CurrentUser.ProviderUserKey.ToString()), "", bllScenic.GetScenicById(scenicid), 1, "网站投票", DateTime.Now, "", true);
        QWeiboSDK.QWeiboRequest request = new QWeiboSDK.QWeiboRequest();
        System.Collections.Generic.List<QWeiboSDK.Parameter> paras = new System.Collections.Generic.List<QWeiboSDK.Parameter>();
        var url = "http://open.t.qq.com/api/t/add";
        var oauthkey = new QWeiboSDK.OauthKey()
        {
            customKey = Request.Cookies["appKey"].Value,
            customSecret = Request.Cookies["appSecret"].Value,
            tokenKey = Request.Cookies["oauthtokenkey"].Value,
            tokenSecret = Request.Cookies["oauthtokensecret"].Value,
            verify = Request.Cookies["oauthverify"].Value
        };
        paras.Add(new QWeiboSDK.Parameter("format", "json"));
        paras.Add(new QWeiboSDK.Parameter("content", "瞧一瞧,看一看 " + DateTime.Now.ToString()));
        paras.Add(new QWeiboSDK.Parameter("clientip", getReaderIpds()));
        paras.Add(new QWeiboSDK.Parameter("jing", ""));
        paras.Add(new QWeiboSDK.Parameter("wei", ""));
        paras.Add(new QWeiboSDK.Parameter("syncflag", "0"));
        var jsonResult = request.SyncRequest(url, "POST", oauthkey, paras, null);
        System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
        Model.Qweibo_tadd Qwt = jss.Deserialize<Model.Qweibo_tadd>(jsonResult);
        if (Qwt.ret == 0)
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('投票成功！');", true);
        else
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('未知错误！');", true);
    }
    #endregion

    #region QQ投票
    public void Vote8QQ(int scenicid)
    {
        new BLL.BLLVote().Vote(new Guid(CurrentUser.ProviderUserKey.ToString()), "", bllScenic.GetScenicById(scenicid),
            1, "网站投票", DateTime.Now, "", true);
        QConnectSDK.QOpenClient qzone = Session["QzoneOauth"] as QConnectSDK.QOpenClient;
        if (qzone != null)
        {
            qzone.AddWeibo("瞧一瞧,看一看 " + DateTime.Now.ToString());
        }
    }
    #endregion

    #region 获取外网IP
    //获取外网IP 
    public static string getReaderIpds()
    {
        string pubIP = "";
        string serviceUrl = "";
        Socket sk = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        sk.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, true);
        string req = "M-SEARCH * HTTP/1.1\r\n" +
        "HOST: 239.255.255.250:1900\r\n" +
        "ST:upnp:rootdevice\r\n" +
        "MAN:\"ssdp:discover\"\r\n" +
        "MX:3\r\n\r\n";
        byte[] data = System.Text.Encoding.ASCII.GetBytes(req);
        byte[] receive = new byte[0x1000];
        IPEndPoint ipe = new IPEndPoint(IPAddress.Broadcast, 1900);
        //发送数据，获取服务地址 
        sk.SendTo(data, ipe);
        int length = 0;
        length = sk.Receive(receive);
        string resp = Encoding.ASCII.GetString(receive, 0, receive.Length).ToLower();
        if (resp.Contains("upnp:rootdevice"))
        {
            resp = resp.Substring(resp.ToLower().IndexOf("location:") + 9);
            resp = resp.Substring(0, resp.IndexOf("\r")).Trim();
            serviceUrl = GetServiceUrl(resp);//解析获取地址 
        }
        //利用ssdp discover服务向serviceIP发送请求，存储返回结果，并在xml中解析出外网ip 
        string reqStr = "" +
        "" +
        "" +
        "" + "" +
        "" +
        "";
        byte[] b = Encoding.UTF8.GetBytes(reqStr);
        WebRequest wr = HttpWebRequest.Create(serviceUrl);
        wr.Method = "POST";
        wr.Headers.Add("SOAPACTION", "\"urn:schemas-upnp-org:service:WANIPConnection:1#" + "GetExternalIPAddress" + "\"");
        wr.ContentType = "text/xml; charset=\"utf-8\"";
        wr.ContentLength = b.Length;
        wr.GetRequestStream().Write(b, 0, b.Length);
        // 
        XmlDocument xml = new XmlDocument();
        WebResponse ws = wr.GetResponse();
        Stream ress = ws.GetResponseStream();
        xml.Load(ress);
        XmlNamespaceManager xmlMgr = new XmlNamespaceManager(xml.NameTable);
        xmlMgr.AddNamespace("tns", "urn:schemas-upnp-org:device-1-0");
        pubIP = xml.SelectSingleNode("//NewExternalIPAddress/text()", xmlMgr).Value;
        return pubIP;
    }
    /// 
    /// 剖析 
    /// 
    /// 
    /// 
    private static string GetServiceUrl(string resp)
    {
        try
        {
            XmlDocument desc = new XmlDocument();
            desc.Load(WebRequest.Create(resp).GetResponse().GetResponseStream());
            XmlNamespaceManager nsMgr = new XmlNamespaceManager(desc.NameTable);
            nsMgr.AddNamespace("tns", "urn:schemas-upnp-org:device-1-0");
            XmlNode typen = desc.SelectSingleNode("//tns:device/tns:deviceType/text()", nsMgr);
            if (!typen.Value.Contains("InternetGatewayDevice"))
                return null;
            XmlNode node = desc.SelectSingleNode("//tns:service[tns:serviceType=\"urn:schemas-upnp-org:service:WANIPConnection:1\"]/tns:controlURL/text()", nsMgr);
            if (node == null)
                return null;
            XmlNode eventnode = desc.SelectSingleNode("//tns:service[tns:serviceType=\"urn:schemas-upnp-org:service:WANIPConnection:1\"]/tns:eventSubURL/text()", nsMgr);
            int n = resp.IndexOf("://");
            n = resp.IndexOf('/', n + 3);
            string surl = resp.Substring(0, n) + eventnode.Value;
            return surl;
        }
        catch
        {
            return null;
        }
    }
    //获取外网IP 
    private static string GetExternalIP()
    {
        return "";
        //以下是通过外网页面读取的 
        //try 
        //{   
        //    System.Net.WebClient client = new System.Net.WebClient(); 
        //    client.Encoding = System.Text.Encoding.Default; 
        //    string reply = client.DownloadString("http://www.ip138.com/ip2city.asp"); 
        //    string[] ipStr = reply.Split(new char[] { '[', ']' }); 
        //    pubIP = ipStr[1]; 
        //} 
        //catch (Exception ex) 
        //{ 
        //    System.Windows.Forms.MessageBox.Show(ex.Message); 
        //} 
    }
    #endregion 

}
