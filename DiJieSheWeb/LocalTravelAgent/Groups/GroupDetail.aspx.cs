using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Groups_GroupDetail : System.Web.UI.Page
{
    BLL.BLLDJTourGroup blltg = new BLL.BLLDJTourGroup();
    BLL.BLLDJConsumRecord bllRecord = new BLL.BLLDJConsumRecord();

    protected void Page_Load(object sender, EventArgs e)
    {
        string guid = Request.QueryString[0];
        BindData(guid);
    }

    private void BindData(string guid)
    {
        Model.DJ_TourGroup tg = blltg.GetOne(Guid.Parse(guid));
      
        lblName.Text = tg.Name;
        lblDate.Text = tg.BeginDate.ToShortDateString() + "-" + tg.EndDate.ToShortDateString();
        lblDays.Text = tg.DaysAmount.ToString();
        lblPnum.Text = (tg.AdultsAmount + tg.ChildrenAmount).ToString();
        lblPadult.Text = tg.AdultsAmount.ToString();
        lblPchild.Text = tg.ChildrenAmount.ToString();
        lblForeigners.Text = tg.ForeignersAmount.ToString();
        lblGangaotais.Text = tg.GangaotaisAmount.ToString();
        lblGether.Text = tg.Gether;
        lblBack.Text = tg.BackPlace;

        rptMem.DataSource = tg.Members;
        rptMem.DataBind();

        rptWorkers.DataSource = tg.Workers;
        rptWorkers.DataBind();

        #region v.2012/10/9

        IList<ExcelOplib.Entity.GroupRouteNew> grlist = new List<ExcelOplib.Entity.GroupRouteNew>();
        foreach (var item in tg.Routes.GroupBy(x => x.DayNo))
        {
            grlist.Add(new ExcelOplib.Entity.GroupRouteNew()
            {
                RouteDate = item.First().DayNo.ToString(),
                Hotel = item.Where(x => x.Enterprise.Type == Model.EnterpriseType.宾馆).Count() > 0 ? item.Where(x => x.Enterprise.Type == Model.EnterpriseType.宾馆).ToList<Model.DJ_Route>() : null,
                Scenic = item.Where(x => x.Enterprise.Type == Model.EnterpriseType.景点).Count() > 0 ? item.Where(x => x.Enterprise.Type == Model.EnterpriseType.景点).ToList<Model.DJ_Route>() : null
            });
        }
        rptRoute.DataSource = grlist.OrderBy(x => x.RouteDate);
        rptRoute.DataBind();
        #endregion
    }

    protected void rptRoute_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Repeater rptRouteHotel = (Repeater)e.Item.FindControl("rptRouteHotel");
            //找到分类Repeater关联的数据项 
            ExcelOplib.Entity.GroupRouteNew grnrptRouteHotel = (ExcelOplib.Entity.GroupRouteNew)e.Item.DataItem;
            //根据分类ID查询该分类下的产品，并绑定产品Repeater 
            rptRouteHotel.DataSource = grnrptRouteHotel.Hotel;
            rptRouteHotel.DataBind();

            Repeater rptRouteScenic = (Repeater)e.Item.FindControl("rptRouteScenic");
            //找到分类Repeater关联的数据项 
            ExcelOplib.Entity.GroupRouteNew grnrptRouteScenic = (ExcelOplib.Entity.GroupRouteNew)e.Item.DataItem;
            //根据分类ID查询该分类下的产品，并绑定产品Repeater 
            rptRouteScenic.DataSource = grnrptRouteScenic.Scenic;
            rptRouteScenic.DataBind();

            Repeater rptRouteShopping = (Repeater)e.Item.FindControl("rptRouteShopping");
            //找到分类Repeater关联的数据项 
            ExcelOplib.Entity.GroupRouteNew grnrptRouteShopping = (ExcelOplib.Entity.GroupRouteNew)e.Item.DataItem;
            //根据分类ID查询该分类下的产品，并绑定产品Repeater 
            //rptRouteShopping.DataSource = grnrptRouteShopping.ShoppingPoint;
            //rptRouteShopping.DataBind();

            Label lblBreakfast = (Label)e.Item.FindControl("lblBreakfast");
            Label lblLunch = (Label)e.Item.FindControl("lblLunch");
            Label lblDinner = (Label)e.Item.FindControl("lblDinner");
            //找到分类Repeater关联的数据项 
            ExcelOplib.Entity.GroupRouteNew group = (ExcelOplib.Entity.GroupRouteNew)e.Item.DataItem;
        }
    }

    protected void rptRouteSub_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label label = (Label)e.Item.FindControl("lblName");
            //找到分类Repeater关联的数据项 
            Model.DJ_Route route = (Model.DJ_Route)e.Item.DataItem;
            //根据查询, 显示是否已经刷卡
            Model.DJ_GroupConsumRecord gcrecord = bllRecord.GetGroupConsumRecordByRouteId(route.Id);
            if (null != gcrecord)
            {
             //   label.BackColor = System.Drawing.Color.Aqua;
             //   label.Text += "【"+gcrecord.ConsumeTime+"】";
            }
            else
            {
               // label.BackColor = System.Drawing.Color.Yellow;
            }
        }
    }
}