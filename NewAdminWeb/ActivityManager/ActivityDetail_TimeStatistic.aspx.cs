using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using System.Data;

public partial class ActivityManager_ActivityDetail_TimeStatistic : System.Web.UI.Page
{
    TourActivity ta;
    BLLTourActivity bllTa = new BLLTourActivity();
    BLLActivityTicketAssign bllAta = new BLLActivityTicketAssign();
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
        gridCheckTicketStatistic.Hidden = true;
        gridTimeStatistic.DataSource = bllAta.GetDTbyLvTicket(ta.Id);
        gridTimeStatistic.DataBind();
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        InitGrid();
    }

    private void InitGrid()
    {
        ta = bllTa.GetOne(Guid.Parse(Request.QueryString["actId"]));
        DataTable dt = bllAta.GetDTbyLvTicket(ta.Id);
        FineUI.BoundField bf;
        
        for (int i = 0; i < dt.Columns.Count; i++)
        {
            bf = new FineUI.BoundField();
            bf.DataField = dt.Columns[i].ColumnName;
            bf.HeaderText = dt.Columns[i].ColumnName;
            gridTimeStatistic.Columns.Add(bf);
        }
        dt = bllAta.GetDtBycheckTicket(ta.Id);

        for (int i = 0; i < dt.Columns.Count; i++)
        {
            bf = new FineUI.BoundField();
            bf.DataField = dt.Columns[i].ColumnName;
            bf.HeaderText = dt.Columns[i].ColumnName;
            gridCheckTicketStatistic.Columns.Add(bf);
        }

    }

    protected void rblType_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (rblType.SelectedIndex)
        {
            case 0:
                {
                    gridTimeStatistic.Hidden = false; gridCheckTicketStatistic.Hidden = true;
                    gridTimeStatistic.DataSource = bllAta.GetDTbyLvTicket(ta.Id);
                    gridTimeStatistic.DataBind();
                    break;
                }
            case 1:
                {
                    gridTimeStatistic.Hidden = true; gridCheckTicketStatistic.Hidden = false;
                    gridCheckTicketStatistic.DataSource = bllAta.GetDtBycheckTicket(ta.Id);
                    gridCheckTicketStatistic.DataBind();
                    break;
                 }
        }
    }
}