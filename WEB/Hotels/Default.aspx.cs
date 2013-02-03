using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using HotelModel.HotelSDKModel;

public partial class Hotels_Default : System.Web.UI.Page
{
    public BLL.BLLArea bllarea = new BLL.BLLArea();
    public BLL.BLLHotelList hotelListService = new BLL.BLLHotelList();

    #region Elong
    string CityID = null;
    string checkInDate = null;
    string checkOutDate = null;
    string hotelName = null;
    string Geo = "-1";
    string Star = "";
    string Price = "-1";
    string Page = "1";
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindArea();
            BindHotels();
        }
    }

    private void BindHotels()
    {
        CityID = Request["area"]==null ? "1272":Request["area"];
        checkInDate = Request["cin"] == null ? null : Request["cin"];
        checkOutDate = Request["cout"] == null ? null : Request["cout"];

        SearchHotelListRequestCondition SearchHotelListRequestCondition = new SearchHotelListRequestCondition();
        SearchHotelListRequestCondition.CityId = CityID;
        SearchHotelListRequestCondition.CheckInDate = string.IsNullOrEmpty(checkInDate) ? DateTime.Now.Date : DateTime.Parse(checkInDate);
        SearchHotelListRequestCondition.CheckOutDate = string.IsNullOrEmpty(checkOutDate) ? DateTime.Now.AddDays(1).Date : DateTime.Parse(checkOutDate);
        SearchHotelListRequestCondition.HotelName = hotelName;
        SearchHotelListRequestCondition.MaxRows = 10;//这里先给个默认值
        SearchHotelListRequestCondition.PageIndex = int.Parse(Page);
        if (Star != "-1")
            SearchHotelListRequestCondition.StarCode = Star;
        if (Geo != "-1")
            SearchHotelListRequestCondition.CommercialLocationId = Geo;
        if (Price != "-1")
        {
            if (Price == "0")
            {
                SearchHotelListRequestCondition.LowestRate = 0;
                SearchHotelListRequestCondition.HighestRate = 150;

            }
            else if (Price == "1")
            {
                SearchHotelListRequestCondition.LowestRate = 150;
                SearchHotelListRequestCondition.HighestRate = 300;
            }
            else if (Price == "2")
            {
                SearchHotelListRequestCondition.LowestRate = 300;
                SearchHotelListRequestCondition.HighestRate = 600;
            }
            else if (Price == "3")
            {
                SearchHotelListRequestCondition.LowestRate = 600;
                SearchHotelListRequestCondition.HighestRate = 1000;
            }
            else if (Price == "4")
            {
                SearchHotelListRequestCondition.LowestRate = 1000;
                SearchHotelListRequestCondition.HighestRate = 10000;
            }
        }
        SearchHotelListRequestCondition.Price = Price;
        SearchHotelListResponseResult SearchHotelListResponseResult = hotelListService.GetHotelList(SearchHotelListRequestCondition);

        IList<HotelModel.HotelDB.nbapisdk_Hotel> hotels = hotelListService.GetHotelListLocal(SearchHotelListRequestCondition);

        rpthotel.DataSource = hotels;
        rpthotel.DataBind();
    }

    #region 数据绑定

    private void BindArea()
    {
        //rptAreas.DataSource = bllarea.GetSubArea("330000");
        //rptAreas.DataBind();
    }

    protected void rptArea_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
    }

    protected void rptTopic_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

    }

    protected void rpthotel_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

    }

    protected void rptCounty_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

    }
    #endregion

    #region 方法

    #endregion
}