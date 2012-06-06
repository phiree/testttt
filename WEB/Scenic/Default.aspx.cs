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
    public int TicketId = 0;
    public string scpoint = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        string paramSname = Request["sname"];
       
        if (!string.IsNullOrEmpty(paramSname))
        {
            Ticket t = new BLLTicket().GetTicketByScenicSeoName(paramSname);
            
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
        int scid = scenic.Id;
        areaname.HRef = "../Default.aspx?area=" + scenic.Area.Id;
        areaname.InnerHtml = scenic.Area.Name.Substring(3, scenic.Area.Name.Length - 3);
        scenicname.HRef = "Default.aspx?id=" + scenic.Id;
        scenicname.InnerHtml = scenic.Name;
        IList<ScenicImg> listsi= bllscenicimg.GetSiByType(scenic, 1);
        if(listsi.Count>0)
            ImgMainScenic.Src = "/ScenicImg/" + listsi[0].Name;
        if (scenic.Desec != null)
        {
            scdescription.InnerHtml = scenic.Desec;
        }
        //添加辅图
        IList<ScenicImg> listft = bllscenicimg.GetSiByType(scenic, 2);
        for (int i = 1; i <=listft.Count; i++)
        {
            switch (i)
            {
                case 1: Imgft1.ImageUrl = "/ScenicImg/" + listft[i - 1].Name; fttitle1.InnerHtml = listft[i - 1].Title; break;
                case 2: Imgft2.ImageUrl = "/ScenicImg/" + listft[i - 1].Name; fttitle2.InnerHtml = listft[i - 1].Title; break;
                case 3: Imgft3.ImageUrl = "/ScenicImg/" + listft[i - 1].Name; fttitle3.InnerHtml = listft[i - 1].Title; break;
                case 4: Imgft4.ImageUrl = "/ScenicImg/" + listft[i - 1].Name; fttitle4.InnerHtml = listft[i - 1].Title; break;
                case 5: Imgft5.ImageUrl = "/ScenicImg/" + listft[i - 1].Name; fttitle5.InnerHtml = listft[i - 1].Title; break;
                case 6: Imgft6.ImageUrl = "/ScenicImg/" + listft[i - 1].Name; fttitle6.InnerHtml = listft[i - 1].Title; break;
            }
        }
        ydhtprice.InnerHtml = bllticketprice.GetTicketPriceByScenicandtypeid(scid, 2).Price.ToString("0");
        yjhtprice.InnerHtml = bllticketprice.GetTicketPriceByScenicandtypeid(scid, 1).Price.ToString("0");
        zfhtprice.InnerHtml = bllticketprice.GetTicketPriceByScenicandtypeid(scid, 3).Price.ToString("0");

        IList<Scenic> list = bllscenic.GetScenic();
        Dictionary<Scenic, double> places = new Dictionary<Scenic, double>();
        List<double> listdistance = new List<double>();
        bindimg(list, scenic);



        List<ScenicImg> listsc = new List<ScenicImg>();
        if (Request.Cookies["visitedscenic"] != null)
        {
            string[] allkeys = Request.Cookies["visitedscenic"].Value.Split(',');
            foreach (string item in allkeys)
            {
                Scenic sss=bllscenic.GetScenicById(int.Parse(item));
                if(bllscenicimg.GetSiByType(sss,1).Count>0)
                listsc.Add(bllscenicimg.GetSiByType(sss,1)[0]);       
            }
            rptvisited.DataSource = listsc;
            rptvisited.DataBind();
        }
        






       //绑定最近浏览过的记录
        if (Request.Cookies["visitedscenic"] == null)//如果没有cookie，则生成该cookie,并且添加当前的景区
        {
            Response.Cookies.Add(new HttpCookie("visitedscenic", scenic.Id.ToString()));
        }
        else
        {
            string allvisited = Request.Cookies["visitedscenic"].Value;
            string[] allscenicids = allvisited.Split(',');
            int flag = 0;
            foreach (string item in allscenicids)
            {
                if (item == scenic.Id.ToString())
                    flag = 1;
            }
            if (flag == 0)
            {
                Request.Cookies["visitedscenic"].Value = Request.Cookies["visitedscenic"].Value + "," + scenic.Id.ToString();
                Response.Cookies["visitedscenic"].Value = Request.Cookies["visitedscenic"].Value;
            }
        }
    }
    int k = 0;
    int dd = 20;
    List<Scenic> sclist = new List<Scenic>();
    public void bindimg(IList<Scenic> list,Scenic scenic)
    {
        foreach (Scenic item in list)
        {
            if (!string.IsNullOrEmpty(item.Position))
            {
                string[] str = scenic.Position.Split(',');
                string[] str2 = item.Position.Split(',');
                double distance = CaculateDistance(double.Parse(str[0]), double.Parse(str[1]), double.Parse(str2[0]), double.Parse(str2[1]));
                if (distance < dd && distance != 0)
                {
                    int flag = 0;
                    foreach (Scenic ss in sclist)
                    {
                        if (ss == item)
                        {
                            flag = 1;
                            break;
                        }
                    }
                    //places.Add(item, distance);
                    //listdistance.Add(distance);
                    sclist.Add(item);
                    switch (k)
                    {
                        case 0: 
                            if (flag == 0) 
                            { 
                                IList<ScenicImg> listsi=bllscenicimg.GetSiByType(item,1);
                                if(listsi.Count>0)
                                    Imgzb1.ImageUrl = "/ScenicImg/" + listsi[0].Name;
                                zbname1.InnerHtml = item.Name;
                                aImgzb1.HRef = "/" + item.Area.SeoName + "/" + item.SeoName;
                                k++; 
                            }
                            break;
                        case 1:
                            if (flag == 0) 
                            {
                                IList<ScenicImg> listsi = bllscenicimg.GetSiByType(item, 1);
                                if (listsi.Count > 0)
                                    Imgzb2.ImageUrl = "/ScenicImg/" + listsi[0].Name;
                                zbname2.InnerHtml = item.Name;
                                aImgzb2.HRef = "/" + item.Area.SeoName + "/" + item.SeoName;
                                k++; 
                            } 
                            break;
                        case 2: 
                            if (flag == 0) 
                            {
                                IList<ScenicImg> listsi = bllscenicimg.GetSiByType(item, 1);
                                if (listsi.Count > 0)
                                    Imgzb3.ImageUrl = "/ScenicImg/" + listsi[0].Name;
                                zbname3.InnerHtml = item.Name;
                                aImgzb3.HRef = "/" + item.Area.SeoName + "/" + item.SeoName;
                                k++; 
                            }
                            break;
                        case 3: 
                            if (flag == 0) 
                            {
                                IList<ScenicImg> listsi = bllscenicimg.GetSiByType(item, 1);
                                if (listsi.Count > 0)
                                    Imgzb4.ImageUrl = "/ScenicImg/" + listsi[0].Name;
                                zbname4.InnerHtml = item.Name;
                                aImgzb4.HRef = "/" + item.Area.SeoName + "/" + item.SeoName;
                                k++; 
                            }
                            break;
                        case 4:
                            if (flag == 0) 
                            {
                                IList<ScenicImg> listsi = bllscenicimg.GetSiByType(item, 1);
                                if (listsi.Count > 0)
                                    Imgzb5.ImageUrl = "/ScenicImg/" + listsi[0].Name;
                                zbname5.InnerHtml = item.Name;
                                aImgzb5.HRef = "/" + item.Area.SeoName + "/" + item.SeoName;
                                k++; 
                            } 
                            break;
                        case 5:
                            if (flag == 0)
                            {
                                IList<ScenicImg> listsi = bllscenicimg.GetSiByType(item, 1);
                                if (listsi.Count > 0)
                                    Imgzb6.ImageUrl = "/ScenicImg/" + listsi[0].Name;
                                zbname6.InnerHtml = item.Name;
                                aImgzb6.HRef = "/" + item.Area.SeoName + "/" + item.SeoName;
                                k++;
                            }
                            break;
                        default: break;
                    }
                    
                }
            }
        }
        if (k < 6)
        {
            dd = dd + 20;
            bindimg(list, scenic);
        }
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