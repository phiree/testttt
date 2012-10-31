using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

public partial class TourManagerDpt_RewordInfol : System.Web.UI.Page
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
        RptGroupReword.DataSource = bllent.GetDJSRewordGroup(entid, day);
        RptGroupReword.DataBind();
    }
    int OnlyScenicCount = 0, OnlyGuesthouseCount = 0, BothsCount = 0;
    protected void RptGroupReword_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            DJ_TourGroup group = e.Item.DataItem as DJ_TourGroup;
            Literal laOnlyScenic = e.Item.FindControl("laOnlyScenic") as Literal;
            Literal laOnlyGuesthouse = e.Item.FindControl("laOnlyGuesthouse") as Literal;
            Literal Both = e.Item.FindControl("Both") as Literal;
            //人数算法，取行程中景点人数最多的一个，去宾馆中人数最多的一个，然后取他们的交集
            int MaxScenic=0, MaxGuesthouse=0, Boths=0;
            foreach (DJ_Route route in group.Routes)
            {
                DJ_GroupConsumRecord record = bllrecord.GetGroupConsumRecordByRouteId(route.Id);
                if ( record!= null)
                {
                    //if (record.Enterprise.Type == EnterpriseType.景点 && record.Enterprise.IsVeryfied)
                    //{
                    //    if ((record.AdultsAmount + record.ChildrenAmount) > MaxScenic)
                    //    {
                    //        MaxScenic = record.AdultsAmount + record.ChildrenAmount;
                    //    }
                    //}
                    //if (record.Enterprise.Type == EnterpriseType.宾馆 && record.Enterprise.IsVeryfied)
                    //{
                    //    if ((record.AdultsAmount + record.ChildrenAmount) > MaxGuesthouse)
                    //    {
                    //        MaxGuesthouse = record.AdultsAmount + record.ChildrenAmount;
                    //    }
                    //}
                    Boths = MaxScenic < MaxGuesthouse ? MaxScenic : MaxGuesthouse;
                }
            }
            laOnlyScenic.Text = MaxScenic.ToString();
            laOnlyGuesthouse.Text = MaxGuesthouse.ToString();
            Both.Text = Boths.ToString();
            OnlyScenicCount += MaxScenic;
            OnlyGuesthouseCount += MaxGuesthouse;
            BothsCount += Boths;
        }
        if (e.Item.ItemType == ListItemType.Footer)
        {
            Literal laOnlyScenicCount = e.Item.FindControl("laOnlyScenicCount") as Literal;
            Literal laOnlyGuesthouseCount = e.Item.FindControl("laOnlyGuesthouseCount") as Literal;
            Literal BothCount = e.Item.FindControl("BothCount") as Literal;
            laOnlyScenicCount.Text = OnlyScenicCount.ToString();
            laOnlyGuesthouseCount.Text = OnlyGuesthouseCount.ToString();
            BothCount.Text = BothsCount.ToString();
        }
    }
}