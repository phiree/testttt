using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
public partial class LocalTravelAgent_ProductList : basepageDJS
{
    BLLDJProduct bllProduct = new BLLDJProduct();
    protected void Page_Load(object sender, EventArgs e)
    {
        BindList();
    }
    private void BindList()
    {
        rptProduct.DataSource = bllProduct.GetListByDjsID(CurrentDJS.Id);
        rptProduct.DataBind();
    }
}