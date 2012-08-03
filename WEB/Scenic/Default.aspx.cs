using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using BLL;
using Model;

public partial class Scenic_Default : System.Web.UI.Page
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
    protected void Page_Load(object sender, EventArgs e)
    {

        string paramSname = Request["sname"];

        if (!string.IsNullOrEmpty(paramSname))
        {
            Ticket t = new BLLTicket().GetTicketByScenicSeoName(paramSname);
            if (t.Lock == true)
            {
                Response.Redirect("/Default.aspx");
            }
            if (t == null)
            {
                ErrHandler.Redirect(ErrType.UnknownError);
            }
            TicketId = t.Id;
            bind(t);
        }
        else
        {
            ErrHandler.Redirect(ErrType.ParamIllegal);
        }



    }

    private void bind(Ticket t)
    {
        Scenic scenic = t.Scenic;
        maintitlett.InnerHtml = scenic.Name;
        scpoint = scenic.Position;
        scbindname = scenic.Name;
        int scid = scenic.Id;
        areaname.HRef = "/" + scenic.Area.SeoName + ".html";
        areaname.InnerHtml = scenic.Area.Name.Substring(3, scenic.Area.Name.Length - 3);
        scenicname.HRef = "/" + scenic.Area.SeoName + "/" + scenic.SeoName + ".html";
        scenicname.InnerHtml = scenic.Name;
        scaddress = scenic.Address;
        booknote = scenic.BookNote;
        sclevel = scenic.Level;
        scdesc = scenic.Desec;
        transguid = scenic.TransGuid;
        if (!string.IsNullOrEmpty(scenic.Desec))
            scshortdesc = scenic.Desec.Substring(0, 30) + "...";
        IList<ScenicImg> listsi = bllscenicimg.GetSiByType(scenic, 1);
        if (listsi.Count > 0)
            ImgMainScenic.Src = "/ScenicImg/" + listsi[0].Name;
        if (scenic.Desec != null)
        {
            scdescription.InnerHtml = scenic.Desec;
        }
        //添加辅图
        //IList<ScenicImg> ilist=bllscenicimg.GetSiByType(scenic, 2);
        //if (ilist.Count <= 6)
        //{
        //    imgcount = ilist.Count;
        //    rptft.DataSource = ilist;
        //    rptft.DataBind();
        //}
        //else
        //{
        //    List<ScenicImg> ftlist = new List<ScenicImg>();
        //    for (int i = 0; i < 6; i++)
        //    {
        //        ftlist.Add(ilist[i]);
        //    }
            
        //    imgcount = 6;
        //    rptft.DataSource = ftlist;
        //    rptft.DataBind();
        //}


        ydhtprice.InnerHtml = bllticketprice.GetTicketPriceByScenicandtypeid(scid, 2).Price.ToString("0");
        yjhtprice.InnerHtml = bllticketprice.GetTicketPriceByScenicandtypeid(scid, 1).Price.ToString("0");
        zfhtprice.InnerHtml = bllticketprice.GetTicketPriceByScenicandtypeid(scid, 3).Price.ToString("0");

        IList<Scenic> list = bllscenic.GetScenic();
        Dictionary<Scenic, double> places = new Dictionary<Scenic, double>();
        List<double> listdistance = new List<double>();
        bindimg(list, scenic);
        searchbigmap.HRef = "/map/Default.aspx?scenicid=" + scenic.Id;
        foreach (ScenicImg item in scdiction.Keys)
        {
            bindimglist += item.Scenic.Position + ":";
            searchbigmap.HRef += ","+item.Scenic.Id;
        }
        rptzbsc.DataSource = scdiction.Keys;
        rptzbsc.DataBind();
        
        //绑定主题
        rpttopic.DataSource = blltopic.GetStByscid(scenic.Id);
        rpttopic.DataBind();

        //绑定套票
        List<Ticket> listticket= bllticket.GetTp(scenic.Id).ToList();
        var result = from pair in listticket orderby pair.TicketPrice[0] descending select pair;
        List<Ticket> listtp = new List<Ticket>();
        List<Ticket> listcom = new List<Ticket>();
        foreach (Ticket item in listticket)
        {
            if (item.IsMain)
            {
                listtp.Add(item);
            }
            else
            {
                listcom.Add(item);
            }
        }
        rpttp.DataSource = listtp;
        rpttp.DataBind();
        rptcom.DataSource = listcom;
        rptcom.DataBind();
    }
    List<ScenicImg> sclist = new List<ScenicImg>();    //绑定周边景区
    Dictionary<ScenicImg, double> scdiction = new Dictionary<ScenicImg, double>();
    public void bindimg(IList<Scenic> list, Scenic scenic)
    {
        foreach (Scenic item in list)
        {
            if (!string.IsNullOrEmpty(item.Position))
            {
                string[] str = scenic.Position.Split(',');
                string[] str2 = item.Position.Split(',');
                double distance = CaculateDistance(double.Parse(str[0]), double.Parse(str[1]), double.Parse(str2[0]), double.Parse(str2[1]));
                if (distance != 0)
                {
                    if (scdiction.Count < 6)
                    {
                        if (bllscenicimg.GetSiByType(item, 1).Count > 0)
                        {
                            scdiction.Add(bllscenicimg.GetSiByType(item, 1)[0], distance);
                        }
                    }
                    else
                    {
                        foreach (KeyValuePair<ScenicImg, double> kvp in scdiction)
                        {
                            if (distance < kvp.Value)
                            {
                                if (bllscenicimg.GetSiByType(item, 1).Count > 0)
                                {
                                    scdiction.Remove(kvp.Key);
                                    scdiction.Add(bllscenicimg.GetSiByType(item, 1)[0], distance);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
        //if (k < 6 && dd < 500)
        //{
        //    dd = dd + 20;
        //    bindimg(list, scenic);
        //}

    }


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
}