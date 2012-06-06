using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class ScenicManager_ScenicPictureShow : System.Web.UI.Page
{
    BLLScenicImg bllscenicimg = new BLLScenicImg();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }
    }

    private void bind()
    {
        rptPicShow1.DataSource = bllscenicimg.GetSiByType(Master.Scenic, 1);
        rptPicShow1.DataBind();
        rptPicShow2.DataSource = bllscenicimg.GetSiByType(Master.Scenic, 2);
        rptPicShow2.DataBind();
        rptPicShow3.DataSource = bllscenicimg.GetSiByType(Master.Scenic, 3);
        rptPicShow3.DataBind();
    }
}