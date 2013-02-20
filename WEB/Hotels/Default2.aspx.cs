using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Hotels_Default2 : System.Web.UI.Page
{
    BLL.BLLHotelList bllhotel = new BLL.BLLHotelList();

    protected void Page_Load(object sender, EventArgs e)
    {
        rpt.DataSource = bllhotel.GetHotelListNearby(new HotelModel.HotelSDKModel.SearchHotelListRequestCondition() { zipCode = "310000" }, "30.260129000,120.127715000",3);
        rpt.DataBind();
    }
}