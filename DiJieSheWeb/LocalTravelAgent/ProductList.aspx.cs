using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
public partial class LocalTravelAgent_ProductList : System.Web.UI.Page
{
    BLLDJProduct bllProduct = new BLLDJProduct();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    private void BindList()
    { 
      //  bllProduct.get
    }
}