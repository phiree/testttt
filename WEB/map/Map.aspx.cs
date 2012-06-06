using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Text;

public partial class BaiduMap : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    //private void bind()
    //{
    //    IList<Model.Scenic> list=null;
    //    string scname = HttpUtility.UrlDecode(Request.Cookies["scname"].Value, Encoding.GetEncoding("UTF-8"));
    //    string level = HttpUtility.UrlDecode(Request.Cookies["level"].Value, Encoding.GetEncoding("UTF-8"));
    //    if(level!="全部")
    //         list = new BLLScenic().GetScenicByScenicName(scname,level);
    //    else if(scname!="")
    //        list = new BLLScenic().GetScenicByScenicName(scname, "");
    //    rptScenic.DataSource = list;
    //    rptScenic.DataBind();
    //}
    protected void Button2_Click(object sender, EventArgs e)
    {
       // bind();
    }
}