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
    protected void Page_Load(object sender, EventArgs e)
    {
        ChooseScenic();
        BindVisited();
    }

    //判断该页面是否是景区详情页面，同时选出该景区
    private void ChooseScenic()
    {
        string url = Request.Url.AbsoluteUri;
        string[] keys = url.Split('/');
        string key1 = keys[keys.Length - 2];
        string key2 = keys[keys.Length - 1].Split('.')[0];
        scenic= bllscenic.GetScenicBySeoName(key1, key2);
        
    }



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
    }
}
