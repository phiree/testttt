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
public partial class LocalTravelAgent_ProductDetail : basepageDJS
{

    public Guid ProductId;
    bool IsNew = false;
    DJ_Product Product;
    BLLDJProduct bllProduct = new BLLDJProduct();
    BLLDJRoute bllRoute = new BLLDJRoute();
    protected override void OnInit(EventArgs e)
    {
        ucRouteEditor.RoutesChanged += new EventHandler(ucEditor_RoutesChangedEvent);
        base.OnInit(e);
    }
    protected   void Page_Load(object sender, EventArgs e)
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
            if (!IsNew)
            {
                LoadForm();
            }

        }
    }

    private void LoadForm()
    {
        ucRouteEditor.DayAmount = Product.DaysAmount;
        ucRouteEditor.Routes = Product.Routes;

        tbxName.Text = Product.Name;
        tbxDayAmount.Text = Product.DaysAmount.ToString();

    }
    private void UpdateForm()
    {
        Product.Name = tbxName.Text;
        Product.DJ_DijiesheInfo = CurrentDJS;
        Product.DaysAmount = Convert.ToInt32(tbxDayAmount.Text.Trim());
    }

    protected void rptRoute_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

        Guid routeId = Guid.Parse(e.CommandArgument.ToString());
        DJ_Route route = bllRoute.GetById(routeId);

    }

    protected void btnSaveProduct_Click(object sender, EventArgs e)
    {
        UpdateForm();
        bllProduct.Save(Product);
        if (IsNew)
        {
            Response.Redirect("ProductEdit.aspx?productid=" + Product.Id);
        }
        ShowNotification("产品保存成功");
    }

    /// <summary>
    /// 路线保存
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void ucEditor_RoutesChangedEvent(object sender,EventArgs e) {

        IList<DJ_ProductRoute> productRoutes = ((RoutesChangedEventArgs)e).ProductRoutes;
        Product.Routes.Clear();
        foreach (DJ_ProductRoute pr in productRoutes)
        {
            Product.Routes.Add(pr);
        }
        bllProduct.Save(Product);
        LoadForm();


        ShowNotification("路线保存成功");
    }
}