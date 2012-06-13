using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
public partial class Payment_PaySuccess : System.Web.UI.Page
{
    public string OrderId;
    protected void Page_Load(object sender, EventArgs e)
    {
        Uri reffer = Request.UrlReferrer;

        //if (reffer == null )
        //{
        //    ErrHandler.Redirect(ErrType.SourceIllegal);
        //}

        OrderId = Request["orderid"];

        
    }
}