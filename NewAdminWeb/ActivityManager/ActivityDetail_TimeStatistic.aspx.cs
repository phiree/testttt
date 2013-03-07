using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class ActivityManager_ActivityDetail_TimeStatistic : System.Web.UI.Page
{
    TourActivity ta;
    BLLTourActivity bllTa = new BLLTourActivity();
    protected void Page_Load(object sender, EventArgs e)
    {
        ta = bllTa.GetOne(Guid.Parse(Request.QueryString["actId"]));
        if (!IsPostBack)
        {
            bindData();
        }
    }

    private void bindData()
    {
        string dt = Request.QueryString["dt"];
        rblType.Label = dt + "详细信息";
        gridTimeStatistic.DataSource = ta.Tickets;
        gridTimeStatistic.DataBind();
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        InitGrid();
    }

    private void InitGrid()
    {
        FineUI.BoundField bf;

        bf = new FineUI.BoundField();
        bf.DataField = "Scenic.Name";
        bf.HeaderText = "景区名称";
        gridTimeStatistic.Columns.Add(bf);

        bf = new FineUI.BoundField();
        bf.DataField = "Name";
        bf.HeaderText = "票名";
        gridTimeStatistic.Columns.Add(bf);

        FineUI.TemplateField tf;

        //foreach (var partner in ta.Partners)
        //{
        //    tf = new FineUI.TemplateField();
        //    tf.HeaderText = partner.Name;
        //    Label lbltest=new Label();
        //    lbltest.Text="123";
        //    tf.ItemTemplate.InstantiateIn(lbltest);
        //}

    }
}