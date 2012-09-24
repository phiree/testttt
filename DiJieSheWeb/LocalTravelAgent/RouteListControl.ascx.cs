using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
/// <summary>
/// 产品的行程列表
/// </summary>
public partial class LocalTravelAgent_RouteListControl : System.Web.UI.UserControl
{
    public Guid ProductId
    {
        get;
        set;
    }
    public bool DisplayEditColumn
    {
        get;
        set;
    }
    DJ_Product CurrentProduct;
    BLLDJProduct bllPro = new BLLDJProduct();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (ProductId == null)
        {
            Response.Write("请提供有效的ProductId");
        }
        CurrentProduct = bllPro.GetById(ProductId);
    }
    private void BindList()
    {
        rptRoute.DataSource = CurrentProduct.Routes;
        rptRoute.DataBind();
    }
   
}