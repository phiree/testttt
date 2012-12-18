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
       

        IList<UIRoute> uiRoutes = RouteConverter.ConvertToUI(CurrentGroup);

        if (uiRoutes.Count == CurrentGroup.DaysAmount)
        {
          //  btnAddRoute.Visible = false;
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
            Button btnModifyRoute = e.Item.FindControl("btnModifyRoute") as Button;
            Button btnClear = e.Item.FindControl("btnClear") as Button;
            if (uiRoute.Hotels.Count == 0 && uiRoute.Scenics.Count == 0)
            {
                btnModifyRoute.Text = "添加行程";
                btnClear.Visible = false;
            }
            else {
                btnModifyRoute.Text = "修改";
                btnClear.Visible = true;
            }
          


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
                    tbx.CssClass += " rewardbg";
                }
            }
        }
    }
    protected void rptRoutes_ItemCommand(object o, RepeaterCommandEventArgs e)
    {
        string commandName=e.CommandName.ToLower();
        if (commandName== "edit")
        {
          //  btnAddRoute.Visible = true;
            pnlEditRoute.Visible = true;
            rblDayNo.Enabled = false;
            int dayNo = Convert.ToInt32(e.CommandArgument);
            IList<DJ_Route> routes = CurrentGroup.Routes.Where(x => x.DayNo == dayNo).ToList();
            IList<string> scenicNames = routes.Where(x => x.Enterprise.Type == EnterpriseType.景点).Select(x => x.Enterprise.Name).ToList();
            IList<string> hotelNames = routes.Where(x => x.Enterprise.Type == EnterpriseType.宾馆).Select(x => x.Enterprise.Name).ToList();
            rblDayNo.SelectedValue = dayNo.ToString();
            lblDayNo.Text = dayNo.ToString();
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
            //   btnAddRoute.Visible = true;
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
        bllRoute.SaveFromNameList(CurrentGroup, dayNo, entDictionary, out errMsg);
        bllGroup.Save(CurrentGroup);
      
        LoadData();
        pnlEditRoute.Visible = false;
        
     
        if (string.IsNullOrEmpty(errMsg))
        {
            errMsg = "操作成功";
        }
        ShowNotification(errMsg);
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('" + lblMsg_SaveRoute.Text + "')", true);
       // btnAddRoute.Visible = true;
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        pnlEditRoute.Visible = false;
      //  btnAddRoute.Visible = true;
    }
    protected void btnAddRoute_Click(object sender, EventArgs e)
    {
        rblDayNo.Enabled = true;
        pnlEditRoute.Visible = true;
     //   btnAddRoute.Visible = false;
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
       // btnAddRoute.Visible = true;
     //   Response.Redirect("/localtravelagent/Groups/GroupList.aspx");
    }

    private void UpdateSimple()
    {
       
        //保存新的成员
      string errMsg;
     
      bllRoute.CreateRouteFromMultiLineString(CurrentGroup, tbxSimple.Text.Trim(), out errMsg);
      bllGroup.Save(CurrentGroup);
      if (string.IsNullOrEmpty(errMsg))
      {
         
          errMsg = "保存成功";
      }
      else
      {
        
        
      }
      ShowNotification(errMsg);
       
    }
  
    enum FillType
    {
        宾馆,
        景区
    }
}