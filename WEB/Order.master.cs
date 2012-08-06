using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

public partial class OrderMaster: System.Web.UI.MasterPage
{
    BLLScenic bllscenic = new BLLScenic();
    protected void Page_Load(object sender, EventArgs e)
    {
        BindVisited();
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
    }
}
