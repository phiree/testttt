using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using BLL;
using Model;
using System.Web.Security;

public partial class Scenic_Default : basepage
{
    BLLScenic bllscenic = new BLLScenic();
    BLLMembership bllMember = new BLLMembership();
    BLLTicketPrice bllticketprice = new BLLTicketPrice();
    BLLOrder bllorder = new BLLOrder();
    BLLScenicImg bllscenicimg = new BLLScenicImg();
    BLLTopic blltopic = new BLLTopic();
    BLLTicket bllticket = new BLLTicket();
    public int TicketId = 0;
    public string scpoint = "";
    public string scbindname = "";
    public string bindimglist = "";
    public int imgcount;
    public string scaddress = "";
    public string booknote = "";
    public string sclevel = "";
    public string transguid = "";
    public string scdesc = "";
    public string scshortdesc = "";
    public int scid;
    Scenic s;
    protected void Page_Load(object sender, EventArgs e)
    {

        string paramSname = Request["sname"];

        if (!string.IsNullOrEmpty(paramSname))
        {
             s = new BLLScenic().GetScenicBySeoName(paramSname);
            if (s == null)
            {
                ErrHandler.Redirect(ErrType.UnknownError);
            }
          
            bind(s);
        }
        else
        {
            ErrHandler.Redirect(ErrType.ParamIllegal);
        }

     decimal onlineprice=   s.Tickets.FirstOrDefault(x=>x.IsMain==true).GetPrice(PriceType.PayOnline);
     SetSeoTitle(s.Name, onlineprice); 
    }
    /*
     景点内容页的title公式：***门票预订_***门票价格/多少钱 – 中国旅游在线     
     */
    const string scenicTitleFormat = "{0}门票预订_{0}门票价格/{1}元 – 中国旅游在线";
    private void SetSeoTitle(string scenicName,decimal price)
    {
        this.Title = string.Format(scenicTitleFormat, scenicName, price.ToString("0"));
        this.MetaDescription = string.Empty;
        this.MetaKeywords = string.Empty;
    }
    private void bind(Scenic scenic)
    {
      
        maintitlett.InnerHtml = scenic.Name;
        scpoint = scenic.Position;
        scbindname = scenic.Name;
        scid = scenic.Id;
        areaname.HRef = "/Tickets/" + scenic.Area.SeoName;
        areaname.InnerHtml = scenic.Area.Name.Substring(3, scenic.Area.Name.Length - 3);
        scenicname.HRef = "/Tickets/" + scenic.Area.SeoName + "/" + scenic.SeoName + ".html";
        scenicname.InnerHtml = scenic.Name;
        scaddress = scenic.Address;
        booknote = scenic.BookNote;
        sclevel = scenic.Level;
        scdesc = scenic.ScenicDetail;
        transguid = scenic.Trafficintro;
        if (!string.IsNullOrEmpty(scenic.Desec))
        {
            if (scenic.Desec.Length>30)
                scshortdesc = scenic.Desec.Substring(0, 30) + "...";
            else
                scshortdesc = scenic.Desec + "...";
        }
        IList<ScenicImg> listsi = bllscenicimg.GetSiByType(scenic, 1);
        if (listsi.Count > 0)
            ImgMainScenic.Src = "/ScenicImg/mainimg/" + listsi[0].Name;


        IList<Scenic> list = bllscenic.GetScenic();
        Dictionary<Scenic, double> places = new Dictionary<Scenic, double>();
        List<double> listdistance = new List<double>();
        if (!string.IsNullOrEmpty(scenic.Position))
        {
            //bindimg(list, scenic);
            //foreach (ScenicImg item in scdiction.Keys)
            //{
                bindimglist += scenic.Position + ":";
           // }
        }

        
        //绑定主题
        rpttopic.DataSource = blltopic.GetStByscid(scenic.Id);
        rpttopic.DataBind();

        //绑定套票
        IList<Ticket> listticket= bllticket.GetTp(scenic.Id);
    
        rpttp.DataSource = listticket;
        rpttp.DataBind();
       //编辑
        EditRole();
        sc_dp.scname = scenic.Name;
        sc_dp.BaseData = booknote;
        plate2.scname = scenic.Name;
        plate2.BaseData = scenic.ScenicDetail;
        sc_jtzn.scname = scenic.Name;
        sc_jtzn.BaseData = scenic.Trafficintro;
    }
    List<ScenicImg> sclist = new List<ScenicImg>();    //绑定周边景区
    Dictionary<ScenicImg, double> scdiction = new Dictionary<ScenicImg, double>();
    const double PI = 3.1415926535;
    double CaculateDistance(double lat1, double lng1, double lat2, double lng2)
    {
        double EARTH_RADIUS = 6378.137;   // 地球半径
        double radLat1 = lat1 * PI / 180;     // 转化为弧度值
        double radLat2 = lat2 * PI / 180;
        double a = radLat1 - radLat2;
        double b = (lng1 - lng2) * PI / 180;
        double s = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2) + Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(b / 2), 2)));
        s = s * EARTH_RADIUS;
        return s;
    }


    public void SortInsert(List<double> list)
    {
        for (int i = 1; i < list.Count; i++)
        {
            double t = list[i];
            int j = i;
            while ((j > 0) && (list[j - 1] < t))
            {
                list[j] = list[j - 1];
                --j;
            }
            list[j] = t;
        }
    }

    protected void imgbtnPay_Click(object sender, ImageClickEventArgs e)
    {
        //  Response.Redirect("ScenicPay.aspx?scid=" + Request.QueryString["id"] + "&count=" + txtTicketCount.Value + "&type=1");

    }


    #region 网站编辑人员编辑权限（暂时设置为网站后台管理员）
    public void EditRole()
    {
        if (CurrentUser != null && Roles.IsUserInRole(CurrentUser.UserName, "SiteAdmin"))
        {
            sc_dp.CanEdit = true;
            plate2.CanEdit = true;
            sc_jtzn.CanEdit = true;
        }
    }
    #endregion
}