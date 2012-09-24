using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
/// <summary>
/// 编辑路线点
/// </summary>
public partial class LocalTravelAgent_RouteList : System.Web.UI.Page
{

    
    protected void Page_Load(object sender, EventArgs e)
    {
        string stParam = Request["pid"];
        Guid productid;
        if (!Guid.TryParse(stParam, out productid))
        {
            ErrHandler.Redirect(ErrType.ParamIllegal);
        }
        routeList.ProductId = productid;
    }
}