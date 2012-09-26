using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
/// <summary>
/// 编辑产品信息
/// </summary>
public partial class LocalTravelAgent_ProductDetail : System.Web.UI.Page
{

    public Guid ProductId;
    bool IsNew = false;
    DJ_Product Product;
    BLLDJProduct bllProduct = new BLLDJProduct();
    BLLDJ_Route bllRoute = new BLLDJ_Route();
    protected void Page_Load(object sender, EventArgs e)
    {

        string paramstr = Request["productId"];
        if (!Guid.TryParse(paramstr, out ProductId))
        {
            IsNew = true;
            Product = new DJ_Product();

        }
        else
        {
            Product = bllProduct.GetById(ProductId);
        }
        ucRouteEditor.ProductId = Product.Id;
        
        if (!IsPostBack)
        {
            LoadForm();
            LoadList();
            
        }
    }

    private void LoadForm()
    {
        tbxName.Text = Product.Name;

    }
    private void LoadList()
    {
        rptRoute.DataSource = Product.Routes;
        rptRoute.DataBind();
    }
    private void UpdateForm()
    {
        Product.Name = tbxName.Text;
    }

    protected void rptRoute_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        DJ_Route route= e.Item.DataItem as DJ_Route;

        switch (e.CommandName.ToLower())
        {
            case "edit":
                ucRouteEditor.RouteId = route.Id;
                ucRouteEditor.Visible = true;
                break;
            case "delete":
                bllRoute.Delete(route);
                break;
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ucRouteEditor.Visible = true;
        //ucRouteEditor
    }
}