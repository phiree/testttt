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
    DJ_Route CurrentRoute;
    DJ_Product CurrentProduct;
    BLLDJ_Route bllDJRoute = new BLLDJ_Route();
    BLLDijiesheInfo bllDJS = new BLLDijiesheInfo();
    BLLDJProduct bllProduct = new BLLDJProduct();

    public Guid RouteId { get; set; }
    public Guid ProductId { get; set; }


    protected void Page_Load(object sender, EventArgs e)
    {


        if (ProductId == null)
        {
            ErrHandler.Redirect(ErrType.ParamIllegal);
        }
        if (RouteId != null)
        {
            CurrentRoute = bllDJRoute.GetById(RouteId);
            CurrentProduct = bllProduct.GetById(ProductId);
        }
        else
        {
            IsNew = true;
        }
        if (!IsPostBack)
        {
            if (!IsNew)
            {
                LoadForm();
            }
        }
    }

    private void LoadForm()
    {
        tbxBeginTime.Text = CurrentRoute.BeginTime.ToString();
        tbxEndTime.Text = CurrentRoute.EndTime.ToString();
        tbxDayNo.Text = CurrentRoute.DayNo.ToString();
        tbxEnterprise.Text = CurrentRoute.Enterprise.Name;
        rblBehavior.SelectedValue = CurrentRoute.Behavior;


    }
    protected string UpdateMsg = string.Empty;
    private bool UpdateForm()
    {
        CurrentRoute.BeginTime = Convert.ToDateTime(tbxBeginTime.Text);
        CurrentRoute.EndTime = Convert.ToDateTime(tbxEndTime.Text);
        CurrentRoute.Behavior = rblBehavior.SelectedValue;

        CurrentRoute.DayNo = Convert.ToInt16(tbxDayNo.Text);
        IList<DJ_TourEnterprise> djs = bllDJS.GetDJS8name(tbxEnterprise.Text);
        if (djs.Count != 1)
        {
            UpdateMsg = "请输入正确的企业名称";
            return false;
        }
        CurrentRoute.Enterprise = djs[0];
        CurrentRoute.DJ_Product = CurrentProduct;

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
}