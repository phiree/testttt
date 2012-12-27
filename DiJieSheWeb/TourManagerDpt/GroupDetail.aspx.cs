using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class TourManagerDpt_GroupDetail : basepageMgrDpt
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
        lblPnum.Text = (tg.AdultsAmount + tg.ChildrenAmount + tg.ForeignersAmount + tg.GangaotaisAmount).ToString();
        lblPadult.Text = tg.AdultsAmount.ToString();
        lblPchild.Text = tg.ChildrenAmount.ToString();
        lblForeigners.Text = tg.ForeignersAmount.ToString();
        lblGangaotais.Text = tg.GangaotaisAmount.ToString();

        rptMem.DataSource = tg.Members;
        rptMem.DataBind();

        rptWorkers.DataSource = tg.Workers;
        rptWorkers.DataBind();

        IList<ExcelOplib.Entity.GroupRouteNew> grlist = new List<ExcelOplib.Entity.GroupRouteNew>();
        var route_source = tg.Routes.OrderBy(x => x.DayNo).GroupBy(x => x.DayNo).ToList();
        foreach (var item in route_source)
        {
            grlist.Add(new ExcelOplib.Entity.GroupRouteNew()
            {
                RouteDate = item.First().DayNo.ToString(),
                Hotel = item.Where(x => x.Enterprise.Type == Model.EnterpriseType.宾馆).Count() > 0 ? item.Where(x => x.Enterprise.Type == Model.EnterpriseType.宾馆).ToList<Model.DJ_Route>() : null,
                Scenic = item.Where(x => x.Enterprise.Type == Model.EnterpriseType.景点).Count() > 0 ? item.Where(x => x.Enterprise.Type == Model.EnterpriseType.景点).ToList<Model.DJ_Route>() : null
            });
        }
        rptRoute.DataSource = grlist;
        rptRoute.DataBind();

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
                label.BackColor = System.Drawing.Color.Aqua;
                label.Text += "【" + gcrecord.ConsumeTime + "】";
            }
            else
            {
                label.BackColor = System.Drawing.Color.Yellow;
            }
        }
    }

    protected void btnOutput_Click(object sender, EventArgs e)
    {
        if (Request.QueryString.Count == 0) return;
        string guid = Request.QueryString[0];
        Model.DJ_TourGroup tg = blltg.GetOne(Guid.Parse(guid));
        //拼接datatable
        DataTable tblDatas = new DataTable("Datas");
        tblDatas.Columns.Add("groupname", Type.GetType("System.String"));
        tblDatas.Columns.Add("begintime", Type.GetType("System.String"));
        tblDatas.Columns.Add("days", Type.GetType("System.String"));
        tblDatas.Columns.Add();
        tblDatas.Columns.Add("guidename", Type.GetType("System.String"));
        tblDatas.Columns.Add("guideid", Type.GetType("System.String"));
        tblDatas.Columns.Add("guidephone", Type.GetType("System.String"));
        tblDatas.Columns.Add("guideno", Type.GetType("System.String"));
        tblDatas.Columns.Add();
        tblDatas.Columns.Add("drivername", Type.GetType("System.String"));
        tblDatas.Columns.Add("driverid", Type.GetType("System.String"));
        tblDatas.Columns.Add("driverphone", Type.GetType("System.String"));
        tblDatas.Columns.Add("driverno", Type.GetType("System.String"));
        tblDatas.Columns.Add();
        tblDatas.Columns.Add("yktype", Type.GetType("System.String"));
        tblDatas.Columns.Add("ykname", Type.GetType("System.String"));
        tblDatas.Columns.Add("ykid", Type.GetType("System.String"));
        tblDatas.Columns.Add("ykphone", Type.GetType("System.String"));
        tblDatas.Columns.Add();
        tblDatas.Columns.Add("day", Type.GetType("System.String"));
        tblDatas.Columns.Add("scenic", Type.GetType("System.String"));
        tblDatas.Columns.Add("hotel", Type.GetType("System.String"));

        var totalrow = Math.Max(Math.Max(tg.Workers.Count, tg.Members.Count), tg.Routes.GroupBy(x => x.DayNo).Count());
        var guides = tg.Workers
            .Where<Model.DJ_Group_Worker>(x => x.DJ_Workers.WorkerType == Model.DJ_GroupWorkerType.导游)
            .ToList();
        var drivers = tg.Workers
            .Where<Model.DJ_Group_Worker>(x => x.DJ_Workers.WorkerType == Model.DJ_GroupWorkerType.司机)
            .ToList();
        var members = tg.Members;
        var routes = tg.Routes.GroupBy(x => x.DayNo).Count();

        for (int i = 0; i < totalrow; i++)
        {
            var routes1 = string.Empty;
            var routes2 = string.Empty;
            if (routes > i)
            {
                var sceniclist = tg.Routes.Where(x => x.DayNo == (i + 1) && x.Enterprise.Type == Model.EnterpriseType.景点)
                        .ToList();
                foreach (var item in sceniclist)
                {
                    routes1 += item.Enterprise.Name + "-";
                    routes1 = routes1.TrimEnd('-');
                }
                var hotellist = tg.Routes.Where(x => x.DayNo == (i + 1) && x.Enterprise.Type == Model.EnterpriseType.宾馆)
                        .ToList();
                foreach (var item in hotellist)
                {
                    routes2 += item.Enterprise.Name + "-";
                    routes2 = routes2.TrimEnd('-');
                }
            }
            tblDatas.Rows.Add(new object[] { 
                    i==0?tg.Name:null,
                     i==0?tg.BeginDate.ToString():null,  
                      i==0?tg.DaysAmount.ToString():null,
                      null,
                    guides.Count>i?guides[i].DJ_Workers.Name:null,
                    guides.Count>i?guides[i].DJ_Workers.IDCard:null,
                    guides.Count>i?guides[i].DJ_Workers.Phone:null,
                    guides.Count>i?guides[i].DJ_Workers.SpecificIdCard:null,
                      null,
                    drivers.Count>i?drivers[i].DJ_Workers.Name:null,
                    drivers.Count>i?drivers[i].DJ_Workers.IDCard:null,
                    drivers.Count>i?drivers[i].DJ_Workers.Phone:null,
                    drivers.Count>i?drivers[i].DJ_Workers.SpecificIdCard:null,
                      null,
                    members.Count>i?members[i].MemberType.ToString():null,
                    members.Count>i?members[i].RealName:null,
                    members.Count>i?members[i].IdCardNo:null,
                    members.Count>i?members[i].PhoneNum:null,
                      null,
                    routes>i?(i+1).ToString():null,
                    routes>i?routes1:null,
                    routes>i?routes2:null
            });
        }
        new ExcelOplib.ExcelOutput().Download2Excel(tblDatas, this.Page, new List<string>() { 
            "团队名称","开始时间","天数","","导游姓名","导游身份证号","导游电话号码","导游证号","",
            "司机姓名","司机身份证号","司机电话号码","司机证号","","类型","游客姓名","游客证件号码","游客电话号码","",
            "日程","景点","住宿"},
            tg.Name + "[" + DateTime.Today.ToString("yyyy-MM-dd") + "]" + "团队信息");
    }
}