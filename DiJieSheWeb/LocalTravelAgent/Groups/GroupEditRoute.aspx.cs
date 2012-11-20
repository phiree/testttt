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
            InitDaysAmount();
            LoadData();

        }
    }

    private void LoadData()
    {
        //绑定链接
        a_link_1.HRef = "/LocalTravelAgent/Groups/GroupEditBasicInfo.aspx?groupid=" + Request["groupid"];
        a_link_2.HRef = "/LocalTravelAgent/Groups/GroupEditMember.aspx?groupid=" + Request["groupid"];
        a_link_3.HRef = "/LocalTravelAgent/Groups/GroupEditRoute.aspx?groupid=" + Request["groupid"];
        LoadTab1Data();
        LoadTab2Data();
    }
    private void InitDaysAmount()
    {
        rblDayNo.Items.Clear();
        for (int i = 1; i <= CurrentGroup.DaysAmount; i++)
        {

            ListItem li = new ListItem();
            
            if (i == 1) li.Selected = true;
            li.Text = li.Value = i.ToString();
            rblDayNo.Items.Add(li);
        }
    }
    private void LoadTab1Data()
    {
       

        IList<UIRoute> uiRoutes = RouteConverter.ConvertToUI(CurrentGroup.Routes);

        if (uiRoutes.Count == CurrentGroup.DaysAmount)
        {
            btnAddRoute.Visible = false;
        }


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
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            TextBox tbxEntEdit = e.Item.FindControl("tbxEntEdit") as TextBox;
            object ent = e.Item.DataItem;
            if (ent!= null)
            { 
             
            }

        }
    }

    void rptScenics_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        //  throw new NotImplementedException();
    }
 protected  void rptEditEnt_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            TextBox tbx= e.Item.FindControl("tbxEntEdit") as TextBox;
            string entName = tbx.Text.Trim();
            if (!string.IsNullOrEmpty(entName))
            {
                DJ_TourEnterprise ent = bllEnter.GetEntByName(entName);
                if (ent != null && ent.IsVerified)
                {
                    tbx.CssClass = "rewardbb";
                    tbx.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }
    protected void rptRoutes_ItemCommand(object o, RepeaterCommandEventArgs e)
    {
        string commandName=e.CommandName.ToLower();
        if (commandName== "edit")
        {
            btnAddRoute.Visible = true;
            pnlEditRoute.Visible = true;
            rblDayNo.Enabled = false;
            int dayNo = Convert.ToInt32(e.CommandArgument);
            IList<DJ_Route> routes = CurrentGroup.Routes.Where(x => x.DayNo == dayNo).ToList();
            IList<string> scenicNames = routes.Where(x => x.Enterprise.Type == EnterpriseType.景点).Select(x => x.Enterprise.Name).ToList();
            IList<string> hotelNames = routes.Where(x => x.Enterprise.Type == EnterpriseType.宾馆).Select(x => x.Enterprise.Name).ToList();
            rblDayNo.SelectedValue = dayNo.ToString();
            LoadEditRepeater(scenicNames, hotelNames);
        }
        else if (commandName == "delete")
        { 
               int dayNo = Convert.ToInt32(e.CommandArgument);
          //     CurrentGroup.Routes = CurrentGroup.Routes.Where(x => x.DayNo != dayNo).ToList();
               IList<DJ_Route> routeToBeDeleted = CurrentGroup.Routes.Where(x => x.DayNo == dayNo).ToList();
               foreach (DJ_Route r in routeToBeDeleted)
               {
                   CurrentGroup.Routes.Remove(r);
               }
               bllGroup.Save(CurrentGroup);
               LoadData();
               pnlEditRoute.Visible = false;
               btnAddRoute.Visible = true;
        }
    }
    private void LoadEditRepeater(IList<string> scenicNames,IList<string> hotelNames)
    {
    
            scenicNames = CommonLibrary.ListHelper.ExtendStringList(scenicNames, ScenicAmountOneDay);
            hotelNames = CommonLibrary.ListHelper.ExtendStringList(hotelNames, HotelAmountOneDay);
        rptEditScenics.DataSource = scenicNames;
        rptEditScenics.DataBind();
        rptEditHotels.DataSource = hotelNames;
        rptEditHotels.DataBind();
        
    }
    protected void btnSaveRoute_Click(object sender, EventArgs e)
    {
        int dayNo =Convert.ToInt32( rblDayNo.Text);
        List<string> entNames = new List<string>();
        foreach (RepeaterItem item in rptEditScenics.Items)
        {
            TextBox tbxScenic = item.FindControl("tbxEntEdit") as TextBox;
            string scenicName = CommonLibrary.StringHelper.TrimAll(tbxScenic.Text);
            entNames.Add(scenicName);
        }
        foreach (RepeaterItem itemHotel in rptEditHotels.Items)
        {
            TextBox tbxHotel = itemHotel.FindControl("tbxEntEdit") as TextBox;
            string hotelName = CommonLibrary.StringHelper.TrimAll(tbxHotel.Text);
            entNames.Add(hotelName);
        }
        string errMsg;
        bllRoute.SaveFromNameList(CurrentGroup, dayNo, entNames,out errMsg);
        bllGroup.Save(CurrentGroup);
      
        LoadData();
        pnlEditRoute.Visible = false;
        lblMsg_SaveRoute.Text = errMsg;
        if (string.IsNullOrEmpty(errMsg))
        {
            lblMsg_SaveRoute.Text = "操作成功";
        }
        btnAddRoute.Visible = true;
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        pnlEditRoute.Visible = false;
        btnAddRoute.Visible = true;
    }
    protected void btnAddRoute_Click(object sender, EventArgs e)
    {
        rblDayNo.Enabled = true;
        pnlEditRoute.Visible = true;
        btnAddRoute.Visible = false;
        IList<int> daynos = CurrentGroup.Routes.Select(x => x.DayNo).Distinct().ToList();


        LoadEditRepeater(new List<string>(), new List<string>());
    }

    /// <summary>
    ///  创建最大数量的 textbox
    /// </summary>
    /// <param name="entNames"></param>
    /// <returns></returns>

    private void LoadTab2Data()
    {
      string simpleText=  bllRoute.GenerateFormatingStringForRoutes(CurrentGroup.Routes);
      tbxSimple.Text = simpleText;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        UpdateSimple();
        LoadData();
        pnlEditRoute.Visible = false;
        btnAddRoute.Visible = true;
     //   Response.Redirect("/localtravelagent/Groups/GroupList.aspx");
    }

    private void UpdateSimple()
    {
       
        //保存新的成员
      string errMsg;
      CurrentGroup.Routes = bllRoute.CreateRouteFromMultiLineString(tbxSimple.Text.Trim(), out errMsg);
      bllGroup.Save(CurrentGroup);
      if (string.IsNullOrEmpty(errMsg))
      {
          lblSimpleMsg.ForeColor = System.Drawing.Color.Green;
          lblSimpleMsg.Text = "保存成功";
      }
      else
      {
          lblSimpleMsg.ForeColor = System.Drawing.Color.Red;
          lblSimpleMsg.Text = errMsg;
      }
       
    }
  
    enum FillType
    {
        宾馆,
        景区
    }
}