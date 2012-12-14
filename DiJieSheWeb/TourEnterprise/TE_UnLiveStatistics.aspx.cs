using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using System.Data;

public partial class TourEnterprise_TE_UnLiveStatistics : System.Web.UI.Page
{
    BLLDJRoute BLLDJRoute = new BLLDJRoute();
    BLLDJConsumRecord bllrecord = new BLLDJConsumRecord();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindData();
        }
    }

    private void bindData()
    {

        rptTgRecord.DataSource = BindUnlive();
        rptTgRecord.DataBind();
    }

    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        bindData();
    }

    protected void BtnCreatexls_Click(object sender, EventArgs e)
    {
        List<UnLiveStatistics> List= BindUnlive();
        List<string> titlelist = new List<string>() { "序号", "预住时间", "旅行社名称", "住宿天数", "成人/儿童(儿童)", "导游","联系电话" };
        DataTable dt = new DataTable();
        for (int i = 0; i < titlelist.Count; i++)
        {
            dt.Columns.Add(new DataColumn());
        }
        foreach (var item in List)
        {
            DataRow dr = dt.NewRow();
            dr[0] = item.Index;
            dr[1] = item.Time;
            dr[2] = item.entName;
            dr[3] = item.LiveCount;
            dr[4] = item.PeopleCount;
            dr[5] = item.guidername;
            dr[6] = item.telephone;
            dt.Rows.Add(dr);
        }
        ExcelOplib.ExcelOutput.Download2Excel(dt, this.Page, titlelist, Master.CurrentTE.Name + "[" + DateTime.Today.ToString("yyyy-MM-dd") + "]" + "拟入住数据");
    }

    private List<UnLiveStatistics> BindUnlive()
    {
        DateTime dt;
        if (!DateTime.TryParse(txtTime.Text, out dt))
        {
            dt = DateTime.Now;
            txtTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }
        else
        {
            if (dt < DateTime.Now)
            {
                dt = DateTime.Now;
                txtTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }
        IList<DJ_Route> ListRoute = BLLDJRoute.GetRouteByAllCondition("", txtEntName.Text, txtTime.Text, "", Master.CurrentTE.Id).ToList();
        List<UnLiveStatistics> ListunliveStatistic = new List<UnLiveStatistics>();
        int Index = 1;
        foreach (DJ_Route route in ListRoute)
        {
            UnLiveStatistics u = new UnLiveStatistics();
            u.Index = Index++;
            u.Time = route.DJ_TourGroup.BeginDate.AddDays(route.DayNo - 1).ToString("yyyy-MM-dd");
            u.entName = route.DJ_TourGroup.DJ_DijiesheInfo.Name;
            int MaxLiveDay;
            List<DJ_Route> listWroute = bllrecord.GetLiveRouteByDay(out MaxLiveDay, 1, Master.CurrentTE, route);
            u.LiveCount = MaxLiveDay;
            u.PeopleCount = route.DJ_TourGroup.AdultsAmount + "/" + route.DJ_TourGroup.ChildrenAmount;
            List<DJ_Group_Worker> ListGW = route.DJ_TourGroup.Workers.Where(x => x.DJ_Workers.WorkerType == DJ_GroupWorkerType.导游).ToList();
            if (ListGW != null)
            {
                u.guidername = ListGW[0].DJ_Workers.Name;
                u.telephone = ListGW[0].DJ_Workers.Phone;
            }
            ListunliveStatistic.Add(u);
        }
        return ListunliveStatistic;
    }
}

public class UnLiveStatistics
{
    public int Index { get; set; }
    public string Time { get; set; }
    public string entName { get; set; }
    public int LiveCount { get; set; }
    public string PeopleCount { get; set; }
    public string guidername { get; set; }
    public string telephone { get; set; }
}