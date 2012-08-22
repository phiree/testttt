using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommonLibrary;

public partial class Scenic_EditHTMLInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }
    }

    private void bind()
    {
        string type = Request.QueryString["type"];
        string scname = Request.QueryString["scname"];
        string scfunctype = Request.QueryString["scfunctype"];
        CKHTML.Text = new HTMLInfo().GetHTMLInfo(type, scname, scfunctype);
    }
}