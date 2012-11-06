using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
public partial class LocalTravelAgent_Groups_GroupEditRoute : basepageDjsGroupEdit
{

    BLL.BLLDJTourGroup bllGroup = new BLL.BLLDJTourGroup();
    BLL.BLLDJEnterprise bllEnter = new BLLDJEnterprise();
    BLLDJRoute bllRoute = new BLLDJRoute();
    //一天之中最多的景区数量,宾馆数量
    int ScenicAmountOneDay = 10;
    int HotelAmountOneDay = 5;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
        }
    }

    private void LoadData()
    {
        LoadTab1Data();
        LoadTab2Data();
    }

    private void LoadTab1Data()
    {
        IList<UIRoute> uiRoutes = RouteConverter.ConvertToUI(CurrentGroup.Routes);

        rptRoutes.DataSource = uiRoutes;
        rptRoutes.DataBind();
    }
    protected void rptRoutes_ItemDataBound(object o, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Repeater rptScenics = e.Item.FindControl("rptScenics") as Repeater;
            rptScenics.ItemDataBound += new RepeaterItemEventHandler(rptScenics_ItemDataBound);
            Repeater rptHotels = e.Item.FindControl("rptHotels") as Repeater;
            rptHotels.ItemDataBound += new RepeaterItemEventHandler(rptHotels_ItemDataBound);
            UIRoute uiRoute = e.Item.DataItem as UIRoute;
            rptHotels.DataSource = uiRoute.Hotels;
            rptHotels.DataBind();
            rptScenics.DataSource = uiRoute.Scenics;
            rptScenics.DataBind();

        }
    }

    void rptHotels_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        // throw new NotImplementedException();
    }

    void rptScenics_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        //  throw new NotImplementedException();
    }
    protected void rptRoutes_ItemCommand(object o, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.ToLower() == "edit")
        {
            pnlEditRoute.Visible = true;
            rblDayNo.Enabled = false;
            int dayNo = (int)e.CommandArgument;
            IList<DJ_Route> routes = CurrentGroup.Routes.Where(x => x.DayNo == dayNo).ToList();
            IList<string> scenicNames = routes.Where(x => x.Enterprise.Type == EnterpriseType.景点).Select(x => x.Enterprise.Name).ToList();
            IList<string> hotelNames = routes.Where(x => x.Enterprise.Type == EnterpriseType.宾馆).Select(x => x.Enterprise.Name).ToList();

            scenicNames = CommonLibrary.ListHelper.ExtendStringList(scenicNames, ScenicAmountOneDay);
            hotelNames = CommonLibrary.ListHelper.ExtendStringList(hotelNames, HotelAmountOneDay);

            rptEditScenics.DataSource = scenicNames;
            rptEditScenics.DataBind();
            rptEditHotels.DataSource = hotelNames;
            rptEditHotels.DataBind();
        }
    }
    protected void btnSaveRoute_Click(object sender, EventArgs e)
    {
        int dayNo =Convert.ToInt32( rblDayNo.Text);
        List<string> entNames = new List<string>();
        foreach (RepeaterItem item in rptEditScenics.Items)
        {
            TextBox tbxScenic= item.FindControl("tbxScenicName") as TextBox;
            string scenicName = CommonLibrary.StringHelper.TrimAll(tbxScenic.Text);
            entNames.Add(scenicName);
        }
        foreach (RepeaterItem itemHotel in rptEditHotels.Items)
        {
            TextBox tbxHotel = itemHotel.FindControl("tbxHotelName") as TextBox;
            string hotelName = CommonLibrary.StringHelper.TrimAll(tbxHotel.Text);
            entNames.Add(hotelName);
        }
        string errMsg;
        bllRoute.SaveFromNameList(CurrentGroup, dayNo, entNames,out errMsg);
        lblMsg_SaveRoute.Text = errMsg;
    }

    protected void btnAddRoute_Click(object sender, EventArgs e)
    {
        pnlEditRoute.Visible = true;
    }

    /// <summary>
    ///  创建最大数量的 textbox
    /// </summary>
    /// <param name="entNames"></param>
    /// <returns></returns>

    private void LoadTab2Data()
    {
        string sb = string.Empty;
        foreach (var routes in CurrentGroup.Routes.OrderBy(x => x.DayNo).GroupBy(x => x.DayNo))
        {
            sb += routes.Key.ToString();
            sb += ",";
            foreach (var item in routes.Where(x => x.Description.StartsWith("景点")))
            {
                sb += item.Enterprise.Name;
                sb += "-";
            }
            sb = routes.Where(x => x.Description.StartsWith("景点")).Count() > 0 ? sb.Substring(0, sb.Length - 1) : sb;
            sb += ",";
            foreach (var item in routes.Where(x => x.Description.StartsWith("住宿")))
            {
                sb += item.Enterprise.Name;
                sb += "-";
            }
            sb = routes.Where(x => x.Description.StartsWith("住宿")).Count() > 0 ? sb.Substring(0, sb.Length - 1) : sb;
            sb += "\n";
        }
        tbxSimple.Text = sb.ToString();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        UpdateSimple(tbxSimple);
        LoadTab1Data();
        Response.Redirect("/localtravelagent/Groups/GroupList.aspx");
    }

    private void UpdateSimple(TextBox tbx)
    {
        ///删除所有行程先--首先要做提醒
        foreach (Model.DJ_Route route in CurrentGroup.Routes)
        {
            bllRoute.Delete(route);
        }
        //保存新的成员
        string[] arrStrMember = tbx.Text.Split(Environment.NewLine.ToCharArray());

        string errMsg = string.Empty;
        foreach (string s in arrStrMember)
        {
            if (string.IsNullOrEmpty(s)) continue;
            IList<Model.DJ_Route> routelist = Convert2Route(s, out errMsg);
            if (!string.IsNullOrEmpty(errMsg))
            {
                lblSimpleMsg.ForeColor = System.Drawing.Color.Red;
                lblSimpleMsg.Text = errMsg;
                break;
            }
            foreach (var item in routelist)
            {
                bllRoute.Save(item);
            }
        }
        if (string.IsNullOrEmpty(errMsg))
        {
            lblSimpleMsg.ForeColor = System.Drawing.Color.Green;
            lblSimpleMsg.Text = "保存成功";
        }
    }
    private IList<Model.DJ_Route> Convert2Route(string strRoute, out string errMsg)
    {
        errMsg = "";
        IList<Model.DJ_Route> routeList = new List<Model.DJ_Route>();
        string[] strArrMember = strRoute.Split(',');
        if (strArrMember.Length != 3)
        {
            errMsg = "格式有误.源:" + strRoute + ".";
            return null;
        }
        var temp_split1 = strArrMember[1].Split(new char[] { '-', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (var item in temp_split1)
        {
            routeList.Add(new Model.DJ_Route()
            {
                DayNo = int.Parse(strArrMember[0]),
                Description = "景点",
                Enterprise = bllEnter.GetDJS8name(item)[0],
                DJ_TourGroup = CurrentGroup
            });
        }
        var temp_split2 = strArrMember[2].Split(new char[] { '-', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (var item in temp_split2)
        {
            routeList.Add(new Model.DJ_Route()
            {
                DayNo = int.Parse(strArrMember[0]),
                Description = "住宿",
                Enterprise = bllEnter.GetDJS8name(item).Count > 0 ? bllEnter.GetDJS8name(item)[0] : null,
                DJ_TourGroup = CurrentGroup
            });
        }
        return routeList;
    }

    enum FillType
    {
        宾馆,
        景区
    }
}