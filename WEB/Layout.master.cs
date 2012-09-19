using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

public partial class Layout : System.Web.UI.MasterPage
{
    BLLScenicImg bllscenicimg = new BLLScenicImg();
    BLLScenic bllscenic = new BLLScenic();
    Scenic scenic = new Scenic();
    BLLTopic blltopic = new BLLTopic();
    protected void Page_Load(object sender, EventArgs e)
    {
        ChooseScenic();
        IsShow();
        BindVisited();
        BindLikeScenic();
        bindzbsc();
    }

    //判断页面是否要显示的模块
    private void IsShow()
    {
        if (scenic == null)
        {
            likemod.Visible = false;
            zbmod.Visible = false;
        }
    }

    //判断该页面是否是景区详情页面，同时选出该景区
    private void ChooseScenic()
    {
        string url = Request.RawUrl;
        string[] keys = url.Split('/');
        string key1 = keys[keys.Length - 2];
        string key2 = keys[keys.Length - 1].Split('.')[0];
        scenic= bllscenic.GetScenicBySeoName(key1, key2);
    }


    //绑定最近浏览过的景区
    private void BindVisited()
    {
        List<Scenic> listsc = new List<Scenic>();
        if (Request.Cookies["visitedscenic"] != null)
        {
            string[] allkeys = Request.Cookies["visitedscenic"].Value.Split(',');
            foreach (string item in allkeys)
            {
                Scenic sss = bllscenic.GetScenicById(int.Parse(item));
                listsc.Add(sss);
            }
            rptvisited.DataSource = listsc;
            rptvisited.DataBind();
        }
       // 绑定最近浏览过的记录
        if (scenic != null)
        {
            if (Request.Cookies["visitedscenic"]==null)//如果没有cookie，则生成该cookie,并且添加当前的景区
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
                    if (Request.Cookies["visitedscenic"].Value.Split(',').Length < 10)
                    {
                        Request.Cookies["visitedscenic"].Value = Request.Cookies["visitedscenic"].Value + "," + scenic.Id.ToString();
                        Response.Cookies["visitedscenic"].Value = Request.Cookies["visitedscenic"].Value;
                    }
                }
            }
        }
      
    }

    //绑定相似景区
    private void BindLikeScenic()
    {
        if (scenic != null)
        {
            rptlikesc.DataSource = SearchLikeSc();
            rptlikesc.DataBind();
        }
    }

    //绑定周边景区
    private void bindzbsc()
    {
        if (scenic != null&&!string.IsNullOrEmpty(scenic.Position)&&scenic.Position!="null")
        {
            IList<Scenic> list = bllscenic.GetScenic();
            bindimg(list, scenic);
            rptzbsc.DataSource = scdiction.Keys;
            rptzbsc.DataBind();
        }
    }

    

    List<ScenicImg> sclist = new List<ScenicImg>();    //绑定周边景区
    Dictionary<Scenic, double> scdiction = new Dictionary<Scenic, double>();
    private void bindimg(IList<Scenic> list, Scenic scenic)
    {
        foreach (Scenic item in list)
        {
            if (!string.IsNullOrEmpty(item.Position) && item.Position!="null")
            {
                string[] str = scenic.Position.Split(',');
                string[] str2 = item.Position.Split(',');
                double distance = CaculateDistance(double.Parse(str[0]), double.Parse(str[1]), double.Parse(str2[0]), double.Parse(str2[1]));
                if (distance != 0)
                {
                    if (scdiction.Count < 6)
                    {
                            scdiction.Add(item, distance);
                    }
                    else
                    {
                        foreach (KeyValuePair<Scenic, double> kvp in scdiction)
                        {
                            if (distance < kvp.Value)
                            {
                                if (bllscenicimg.GetSiByType(item, 1).Count > 0)
                                {
                                    scdiction.Remove(kvp.Key);
                                    scdiction.Add(item, distance);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
    }



    #region 查找相似景区算法
    private List<Scenic> SearchLikeSc()
    {
        List<ScenicTopic> listst = blltopic.GetStByscid(scenic.Id).ToList();
        List<Scenic> listsc = new List<Scenic>(); //获取到的所有的景区，其中有重复项
        Dictionary<int, int> dic = new Dictionary<int, int>();
        List<Scenic> listresult = new List<Scenic>();
        foreach (ScenicTopic topic in listst)
        {
            List<ScenicTopic> Listtt = blltopic.GetStByTopicid(topic.Topic.Id).ToList();
            foreach (ScenicTopic t in Listtt)
            {
                listsc.Add(t.Scenic);
            }
        }
        foreach (Scenic item in listsc)
        {
            if (!dic.Keys.Contains(item.Id))
            {
                dic.Add(item.Id, 1);
            }
            else
            {
                dic[item.Id] = dic[item.Id] + 1;
            }
        }
        int k = 0;
        var result = from pair in dic orderby pair.Value descending select pair;

        foreach (KeyValuePair<int,int> item in result)
        {
            if (k == 10)
                break;
            if (item.Key != scenic.Id)
            {
                listresult.Add(bllscenic.GetScenicById(item.Key));
            }
        }
        return listresult;
    }
    #endregion

    #region 景区距离算法
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
    #endregion
}
