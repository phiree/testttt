using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class TourManagerDpt_StaticsDetail : basepageMgrDpt
{
    string enterp_name = string.Empty;
    BLL.BLLDJConsumRecord bllrecord = new BLL.BLLDJConsumRecord();
    BLL.BLLDJEnterprise bllenterp = new BLL.BLLDJEnterprise();

    protected void Page_Load(object sender, EventArgs e)
    {
        enterp_name = Request.QueryString[0] == null ? string.Empty : Request.QueryString[0];
        BindData();
    }

    private void BindData()
    {
        IList<Model.DJ_GroupConsumRecord> recordList = bllrecord.GetGCR8Multi(null, null, null, null, enterp_name);
        IList<statics_detail> sdlist = new List<statics_detail>();
        statics_detail sd = null;
        IList<statics_enterpeople> hotellist = new List<statics_enterpeople>();
        IList<statics_enterpeople> sceniclist = new List<statics_enterpeople>();

        var resutl_list = recordList.GroupBy(x => (x.ConsumeTime.Year.ToString() + "-" +
            x.ConsumeTime.Month.ToString() + "-" +
            x.ConsumeTime.Day.ToString()));
        foreach (var item in resutl_list)
        {
            sd = new statics_detail();
            sd.ConsumeDate = item.Key;
            //添加宾馆
            foreach (var item2 in item
                .Where(x => (x.Enterprise.Type == Model.EnterpriseType.宾馆 || x.Enterprise.Type == Model.EnterpriseType.饭店))
                .GroupBy(y => y.Enterprise.Name))
            {
                var temp = new statics_enterpeople()
                {
                    Enterprice = bllenterp.GetDJS8name(item2.Key)[0],
                    Peoplenum = item2.Sum(x => x.AdultsAmount) + item2.Sum(x => x.ChildrenAmount)
                };
                sd.HotelList.Add(temp);
            }
            //添加景区
            foreach (var item2 in item
                .Where(x => x.Enterprise.Type == Model.EnterpriseType.景点)
                .GroupBy(y => y.Enterprise.Name))
            {
                var temp = new statics_enterpeople()
                {
                    Enterprice = bllenterp.GetDJS8name(item2.Key)[0],
                    Peoplenum = item2.Sum(x => x.AdultsAmount) + item2.Sum(x => x.ChildrenAmount)
                };
                sd.ScenicList.Add(temp);
            }
            sdlist.Add(sd);
        }
        //绑定数据
        rptStaticDetail.DataSource = sdlist;
        rptStaticDetail.DataBind();
    }

    protected void rptStaticDetail_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Repeater rptRouteHotel = (Repeater)e.Item.FindControl("rptHotels");
            //找到分类Repeater关联的数据项 
            statics_detail sd1 = (statics_detail)e.Item.DataItem;
            //根据分类ID查询该分类下的产品，并绑定产品Repeater 
            rptRouteHotel.DataSource = sd1.HotelList;
            rptRouteHotel.DataBind();

            Repeater rptRouteScenic = (Repeater)e.Item.FindControl("rptScenics");
            //找到分类Repeater关联的数据项 
            statics_detail sd2 = (statics_detail)e.Item.DataItem;
            //根据分类ID查询该分类下的产品，并绑定产品Repeater 
            rptRouteScenic.DataSource = sd2.ScenicList;
            rptRouteScenic.DataBind();
        }
    }

    protected void btnOutput1_Click(object sender, EventArgs e)
    {
        IList<Model.DJ_GroupConsumRecord> recordList = bllrecord.GetGCR8Multi(null, null, null, null, enterp_name);
        IList<statics_detail> sdlist = new List<statics_detail>();
        statics_detail sd = null;
        IList<statics_enterpeople> hotellist = new List<statics_enterpeople>();
        IList<statics_enterpeople> sceniclist = new List<statics_enterpeople>();

        var resutl_list = recordList.GroupBy(x => (x.ConsumeTime.Year.ToString() + "-" +
            x.ConsumeTime.Month.ToString() + "-" +
            x.ConsumeTime.Day.ToString()));
        foreach (var item in resutl_list)
        {
            sd = new statics_detail();
            sd.ConsumeDate = item.Key;
            //添加宾馆
            foreach (var item2 in item
                .Where(x => (x.Enterprise.Type == Model.EnterpriseType.宾馆 || x.Enterprise.Type == Model.EnterpriseType.饭店))
                .GroupBy(y => y.Enterprise.Name))
            {
                var temp = new statics_enterpeople()
                {
                    Enterprice = bllenterp.GetDJS8name(item2.Key)[0],
                    Peoplenum = item2.Sum(x => x.AdultsAmount) + item2.Sum(x => x.ChildrenAmount)
                };
                sd.HotelList.Add(temp);
            }
            //添加景区
            foreach (var item2 in item
                .Where(x => x.Enterprise.Type == Model.EnterpriseType.景点)
                .GroupBy(y => y.Enterprise.Name))
            {
                var temp = new statics_enterpeople()
                {
                    Enterprice = bllenterp.GetDJS8name(item2.Key)[0],
                    Peoplenum = item2.Sum(x => x.AdultsAmount) + item2.Sum(x => x.ChildrenAmount)
                };
                sd.ScenicList.Add(temp);
            }
            sdlist.Add(sd);
        }

        //拼接datatable
        DataTable tblDatas = new DataTable("Datas");
        tblDatas.Columns.Add("id", Type.GetType("System.Int32"));
        tblDatas.Columns[0].AutoIncrement = true;
        tblDatas.Columns[0].AutoIncrementSeed = 1;
        tblDatas.Columns[0].AutoIncrementStep = 1;
        tblDatas.Columns.Add("date", Type.GetType("System.String"));
        tblDatas.Columns.Add("pinfo", Type.GetType("System.String"));
        tblDatas.Columns.Add("hinfo", Type.GetType("System.String"));
        foreach (var sditem in sdlist)
        {
            var pinfo = string.Empty;
            var hinfo = string.Empty;
            foreach (var pitem in sditem.ScenicList)
            {
                pinfo += pitem.Enterprice.Name + ":" + pitem.Peoplenum + "    ";
            }
            foreach (var hitem in sditem.HotelList)
            {
                hinfo += hitem.Enterprice.Name + ":" + hitem.Peoplenum + "    ";
            }
            tblDatas.Rows.Add(new object[] { null, sditem.ConsumeDate, pinfo, hinfo });
        }
        new ExcelOplib.ExcelOutput().Download2Excel(tblDatas, this.Page, new List<string>() { 
            "序号","日期","浏览人数","住宿人数"}, CurrentDpt.Name + "[" + DateTime.Today.ToString("yyyy-MM-dd") + "]" + "已接待情况表");
    }
}

class statics_detail
{
    public string ConsumeDate { get; set; }
    public IList<statics_enterpeople> HotelList { get; set; }
    public IList<statics_enterpeople> ScenicList { get; set; }
    public statics_detail()
    {
        HotelList = new List<statics_enterpeople>();
        ScenicList = new List<statics_enterpeople>();
    }
}

class statics_enterpeople
{
    public Model.DJ_TourEnterprise Enterprice { get; set; }
    public int Peoplenum { get; set; }
}