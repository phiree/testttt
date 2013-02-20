using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserCenter_HotelOrder : basepage
{
    BLL.BLLHotelOrder bllho = new BLL.BLLHotelOrder();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            rptHotel_Bind();
        }
    }

    protected void rptHotel_ItemDataBound(object sender, RepeaterItemEventArgs e)
    { 
    
    }

    protected void rptHotel_Bind()
    {
        var result = bllho.GetOrderList(CurrentMember.Id.ToString());
        rptHotel.DataSource = result;
        rptHotel.DataBind();
    }
}