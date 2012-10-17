using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

public partial class TourManagerDpt_RewordEnt : System.Web.UI.Page
{
    BLLDJEnterprise bllent = new BLLDJEnterprise();
    BLLDJConsumRecord bllrecord = new BLLDJConsumRecord();
    string entid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindReword();
        }
    }

    protected void rbolistSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindReword();
    }


    private void BindReword()
    {
        entid = Request.QueryString["entid"];
        string type = rbolistSelect.SelectedValue;
        switch (type)
        {
            case "type_1": bindRptGroup(90); break;
            case "type_2": bindRptGroup(180); break;
            case "type_3": bindRptGroup(365); break;
            case "type_4": bindRptGroup(5000); break;
        }
    }

    private void bindRptGroup(int day)
    {
        int groupcount,peocount;
        bllent.GetDJSRewordEnt(entid, day, out groupcount, out peocount);
        DJ_TourEnterprise enterprise = bllent.GetDJS8id(entid.ToString())[0];
        laType.Text = enterprise.Type.ToString();
        laName.Text = enterprise.Name;
        laGroupCount.Text = groupcount.ToString();
        laPeoCount.Text = peocount.ToString();
    }
}