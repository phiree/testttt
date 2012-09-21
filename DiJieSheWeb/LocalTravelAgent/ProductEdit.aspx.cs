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
    bool IsNew=false;
    DJ_Product Product;
    BLLDJProduct bllProduct = new BLLDJProduct();
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
        if (!IsPostBack)
        {
            LoadForm();
        }
    }

    private void LoadForm()
    {
        tbxName.Text = Product.Name;
        
    }
    private void UpdateForm()
    {
        Product.Name = tbxName.Text;
    }


}