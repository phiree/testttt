using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
/// <summary>
/// 路线编辑控件.
/// 编辑路线信息,返回路线列表
/// </summary>
public partial class LocalTravelAgent_RouteEditControl : System.Web.UI.UserControl
{

    public int DayAmount { get; set; }
    public IList<DJ_ProductRoute> Routes { get; set; }


   

    BLLDJRoute bllDJRoute = new BLLDJRoute();
    BLLDJEnterprise bllDJS = new BLLDJEnterprise();

    public event EventHandler RoutesChanged;
    protected void OnRoutesChanged(EventArgs ea)
    {
        var e = RoutesChanged;
        if (e != null)
            e(this, ea);
    }
   
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Routes == null)
        {
            Routes = new List<DJ_ProductRoute>();
        }
        if (!IsPostBack)
        {
           
            LoadData();
        }

    }
    /// <summary>
    /// 当前正在编辑的路线.
    /// </summary>
    private DJ_ProductRoute CurrentRoute;

    private void LoadData()
    {



        IList<UIRoute> uiRoutes = RouteConverter.ConvertToUI(Routes, DayAmount);
        rptRoutes.DataSource = uiRoutes;
        rptRoutes.DataBind();
    }

    protected void rptRoutes_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int dayNo = Convert.ToInt32(e.CommandArgument);
        switch (e.CommandName.ToLower())
        {
            case "edit":
                pnlEditRoute.Visible = true;

                IList<DJ_ProductRoute> routes = Routes.Where(x => x.DayNo == dayNo).ToList();
                IList<string> scenicNames = routes.Where(x => x.Enterprise.Type == EnterpriseType.景点).Select(x => x.Enterprise.Name).ToList();
                IList<string> hotelNames = routes.Where(x => x.Enterprise.Type == EnterpriseType.宾馆).Select(x => x.Enterprise.Name).ToList();
             
                lblDayNo.Text = dayNo.ToString();
                LoadEditRepeater(scenicNames, hotelNames);
                break;
            case "delete":
                IList<DJ_ProductRoute> routeToBeDeleted = Routes.Where(x => x.DayNo == dayNo).ToList();
                foreach (DJ_ProductRoute r in routeToBeDeleted)
                {
                    Routes.Remove(r);
                }
                LoadData();
                pnlEditRoute.Visible = false;
                break;
        }
    }
    int ScenicAmountOneDay = 10;
    int HotelAmountOneDay = 5;
    private void LoadEditRepeater(IList<string> scenicNames, IList<string> hotelNames)
    {

        scenicNames = CommonLibrary.ListHelper.ExtendStringList(scenicNames, ScenicAmountOneDay);
        hotelNames = CommonLibrary.ListHelper.ExtendStringList(hotelNames, HotelAmountOneDay);
        rptEditScenics.DataSource = scenicNames;
        rptEditScenics.DataBind();
        rptEditHotels.DataSource = hotelNames;
        rptEditHotels.DataBind();

    }
    protected void rptRoutes_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Repeater rptScenics = e.Item.FindControl("rptScenics") as Repeater;
           
            Repeater rptHotels = e.Item.FindControl("rptHotels") as Repeater;
         
            UIRoute uiRoute = e.Item.DataItem as UIRoute;
            Button btnModifyRoute = e.Item.FindControl("btnModifyRoute") as Button;
            Button btnClear = e.Item.FindControl("btnClear") as Button;
            if (uiRoute.Hotels.Count == 0 && uiRoute.Scenics.Count == 0)
            {
                btnModifyRoute.Text = "添加行程";
                btnClear.Visible = false;
            }
            else
            {
                btnModifyRoute.Text = "修改";
                btnClear.Visible = true;
            }



            rptHotels.DataSource = uiRoute.Hotels;
            rptHotels.DataBind();
            rptScenics.DataSource = uiRoute.Scenics;
            rptScenics.DataBind();

        }
    }
    protected void rptEditEnt_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            TextBox tbx = e.Item.FindControl("tbxEntEdit") as TextBox;
            string entName = tbx.Text.Trim();
            if (!string.IsNullOrEmpty(entName))
            {
                DJ_TourEnterprise ent = bllDJS.GetEntByName(entName);
                if (ent != null && ent.IsVerified)
                {
                    tbx.CssClass += " rewardbg";
                }
            }
        }
    }
    protected void btnSaveRoute_Click(object sender, EventArgs e)
    {
        Save();
        pnlEditRoute.Visible = false;
  
    }
    public IList<DJ_ProductRoute> Save()
    {
        int dayNo = Convert.ToInt32(lblDayNo.Text);
        Dictionary<EnterpriseType, IList<string>> entDictionary = new Dictionary<EnterpriseType, IList<string>>();
        List<string> entNames = new List<string>();
        foreach (RepeaterItem item in rptEditScenics.Items)
        {
            if (!entDictionary.ContainsKey(EnterpriseType.景点))
            {
                entDictionary.Add(EnterpriseType.景点, new List<string>());
            }
            TextBox tbxScenic = item.FindControl("tbxEntEdit") as TextBox;
            string scenicName = CommonLibrary.StringHelper.TrimAll(tbxScenic.Text);
            entDictionary[EnterpriseType.景点].Add(scenicName);
            entNames.Add(scenicName);
        }
        foreach (RepeaterItem itemHotel in rptEditHotels.Items)
        {
            if (!entDictionary.ContainsKey(EnterpriseType.宾馆))
            {
                entDictionary.Add(EnterpriseType.宾馆, new List<string>());
            }
            TextBox tbxHotel = itemHotel.FindControl("tbxEntEdit") as TextBox;
            string hotelName = CommonLibrary.StringHelper.TrimAll(tbxHotel.Text);
            entDictionary[EnterpriseType.宾馆].Add(hotelName);
            entNames.Add(hotelName);
        }
        string errMsg;
        Routes.Clear();
        IList<DJ_ProductRoute> routes = bllDJRoute.CreateRouteFromNameList(dayNo, entDictionary, out errMsg);
        foreach (DJ_ProductRoute pj in routes)
        {
            Routes.Add(pj);
        }

        RoutesChangedEventArgs args = new RoutesChangedEventArgs();
        args.ProductRoutes = Routes;
        OnRoutesChanged(args);

        LoadData();
        return Routes;

    }
}