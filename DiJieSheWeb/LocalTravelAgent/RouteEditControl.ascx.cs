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
    BLLDJ_Route bllDJRoute = new BLLDJ_Route();
    BLLDJEnterprise bllDJS = new BLLDJEnterprise();
    BLLDJProduct bllProduct = new BLLDJProduct();
    

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
        //tbxBeginTime.Text = CurrentRoute.BeginTime.ToString();
        //tbxEndTime.Text = CurrentRoute.EndTime.ToString();
        tbxDayNo.Text = CurrentRoute.DayNo.ToString();
        tbxEnterprise.Text = CurrentRoute.Enterprise.Name;
        rblBehavior.SelectedValue = CurrentRoute.Behavior;


    }
    protected string UpdateMsg = string.Empty;
    private bool UpdateForm()
    {
        //CurrentRoute.BeginTime = Convert.ToInt32(tbxBeginTime.Text);
        //CurrentRoute.EndTime = Convert.ToInt32(tbxEndTime.Text);
        CurrentRoute.Behavior = rblBehavior.SelectedValue;

        CurrentRoute.DayNo = Convert.ToInt16(tbxDayNo.Text);
        IList<DJ_TourEnterprise> djs = bllDJS.GetDJS8name(tbxEnterprise.Text);
        if (djs.Count != 1)
        {
            UpdateMsg = "请输入正确的企业名称";
            return false;
        }
        CurrentRoute.Enterprise = djs[0];
        //CurrentRoute.DJ_Product = CurrentProduct;

        return true;
    }
    private void Save()
    {
        bool updateRst = UpdateForm();
        if (updateRst)
        {
            bllDJRoute.SaveOrUpdate(CurrentRoute);
            UpdateMsg = "保存成功";
            if (IsNew)
            {
                tbxBeginTime.Text = tbxDayNo.Text = tbxEndTime.Text = tbxEnterprise.Text = string.Empty;
            }

            this.Visible = false;

        }


    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Save();
    }
}