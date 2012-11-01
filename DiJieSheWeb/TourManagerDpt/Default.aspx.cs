using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
public partial class TourManagerDpt_Default : basepageMgrDpt
{
    BLLDJEnterprise BllEnt = new BLLDJEnterprise();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           // Response.Redirect("EnterpriseMgr/?entType=1");
        }
    }

   
   
}