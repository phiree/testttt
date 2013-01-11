using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
public partial class LocalTravelAgent_RouteEditControl : System.Web.UI.UserControl
{
    bool IsNew = false;
  
   public DJ_Product CurrentProduct
    { get; set; }
   public DJ_Route CurrentRoute { get; set; }
   BLLDJRoute bllDJRoute = new BLLDJRoute();
    BLLDJEnterprise bllDJS = new BLLDJEnterprise();
    BLLDJProduct bllProduct = new BLLDJProduct();

    private void LoadTab1Data()
    {

        //todo 
        //IList<UIRoute> uiRoutes = RouteConverter.ConvertToUI(CurrentGroup);

        //if (uiRoutes.Count == CurrentGroup.DaysAmount)
        //{
        //    //  btnAddRoute.Visible = false;
        //}


       // rptRoutes.DataSource = uiRoutes;
        rptRoutes.DataBind();
    }
    public Guid RouteId { get; set; }
    protected override void OnPreRender(EventArgs e)
    {
        if (CurrentProduct == null)
        {
            ErrHandler.Redirect(ErrType.ParamIllegal);
        }
        if (CurrentRoute == null)
        {
            IsNew = true;

        }

       
            if (!IsNew)
            {
                LoadForm();
            }
        
        base.OnPreRender(e);
    }
    protected void Page_Load(object sender, EventArgs e)
    {


     
    }

    private void LoadForm()
    {
       


    }
    protected string UpdateMsg = string.Empty;
    private bool UpdateForm()
    {
        //CurrentRoute.BeginTime = Convert.ToInt32(tbxBeginTime.Text);
        //CurrentRoute.EndTime = Convert.ToInt32(tbxEndTime.Text);
        //CurrentRoute.Behavior = rblBehavior.SelectedValue;

     

        return true;
    }
    private void Save()
    {
        

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Save();
    }
    protected void rptRoutes_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }
    protected void rptRoutes_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

    }
    protected void rptEditEnt_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

    }
    protected void btnSaveRoute_Click(object sender, EventArgs e)
    { }
}