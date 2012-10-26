using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TourManagerDpt_StaticsList : System.Web.UI.Page
{
    BLL.BLLDJConsumRecord bllCustomRecord = new BLL.BLLDJConsumRecord();
    BLL.BLLDJTourGroup blltg = new BLL.BLLDJTourGroup();
    public int xuhao_orig = 1;
    public int xuhao_1 = 1;
    public int xuhao_2 = 1;
    public int xuhao_3 = 1;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    private void BindData()
    {
        //原数据
        rptOrigin.DataSource = bllCustomRecord.GetGCR8Multi(null, null, null, null, null);
        rptOrigin.DataBind();

        //整理后数据Gov1
        BindGov1();

        //整理后数据Gov2
        BindGov2();

        //整理后数据Gov2
        BindGov3();
    }

    protected void BindGov1()
    {
        IList<Model.DJ_GroupConsumRecord> gcrlist = bllCustomRecord.GetGCR8Multi(null, null, null, null, null);
        IList<Model.DJ_GroupConsumRecord> gcrlist_month;
        IList<Model.DJ_GroupConsumRecord> gcrlist_year;
        IList<statics_model> sm1 = new List<statics_model>();
        string[] temp = txt_yijiedai.Text.Split(new char[] { '-', '/' });
        if (!string.IsNullOrEmpty(txt_yijiedai.Text) && temp.Length >= 2)
        {
            var begin_month = new DateTime(int.Parse(temp[0]), int.Parse(temp[1]), 1);
            var end_month = begin_month.AddMonths(1);
            var begin_year = new DateTime(int.Parse(temp[0]), 1, 1);
            var end_year = begin_year.AddYears(1);
            gcrlist_month = gcrlist.Where(x => x.ConsumeTime >= begin_month && x.ConsumeTime < end_month).ToList();
            gcrlist_year = gcrlist.Where(x => x.ConsumeTime >= begin_year && x.ConsumeTime < end_year).ToList();
        }
        else
        {
            var begin_month = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            var end_month = begin_month.AddMonths(1);
            var begin_year = new DateTime(DateTime.Today.Year, 1 ,1);
            var end_year = begin_month.AddYears(1);
            gcrlist_month = gcrlist.Where(x => x.ConsumeTime >= begin_month && x.ConsumeTime < end_month).ToList();
            gcrlist_year = gcrlist.Where(x => x.ConsumeTime >= begin_year && x.ConsumeTime < end_year).ToList();
        }
        foreach (var item in gcrlist_month.GroupBy(x => x.Route.DJ_TourGroup.DJ_DijiesheInfo.Name))
        {
            sm1.Add(new statics_model()
            {
                Name = item.Key,
                AdultsAmount = item.Sum(x => x.AdultsAmount),
                ChildrenAmount = item.Sum(x => x.ChildrenAmount),
                LiveDays = item.Sum(x => (x.AdultsAmount + x.ChildrenAmount) * x.LiveDay),
                Playnums = item.Sum(x => x.AdultsAmount + x.ChildrenAmount)
            });
        }
        foreach (var item in gcrlist_year.GroupBy(x => x.Route.DJ_TourGroup.DJ_DijiesheInfo.Name))
        {
            var static_m=sm1.Where(x => x.Name == item.Key);
            if(static_m.Count()>0)
            { 
                static_m.First().y_AdultsAmount=item.Sum(x => x.AdultsAmount);
                static_m.First().y_ChildrenAmount = item.Sum(x => x.ChildrenAmount);
                static_m.First().y_LiveDays = item.Sum(x => (x.AdultsAmount + x.ChildrenAmount) * x.LiveDay);
                static_m.First().y_Playnums = item.Sum(x => x.AdultsAmount + x.ChildrenAmount);
            }
        }
        rptGov1.DataSource = sm1;
        rptGov1.DataBind();
    }

    protected void BindGov2()
    {
        IList<Model.DJ_GroupConsumRecord> gcrlist = bllCustomRecord.GetGCR8Multi(null, null, null, null, null);
        IList<statics_model> sm1 = new List<statics_model>();
        string[] temp = txt_yijiedai2.Text.Split(new char[] { '-', '/' });
        if (!string.IsNullOrEmpty(txt_yijiedai2.Text) && temp.Length >= 2)
        {
            var begin_date = new DateTime(int.Parse(temp[0]), int.Parse(temp[1]), 1);
            var end_date = begin_date.AddMonths(1).AddDays(-1);
            gcrlist = gcrlist.Where(x => x.ConsumeTime >= begin_date && x.ConsumeTime < end_date).ToList();
        }
        else
        {
            var begin_date = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            var end_date = begin_date.AddMonths(1).AddDays(-1);
            gcrlist = gcrlist.Where(x => x.ConsumeTime >= begin_date && x.ConsumeTime < end_date).ToList();
        }
        //整理后数据Gov2
        IList<statics_Gov2> sm2 = new List<statics_Gov2>();
        foreach (var item2 in gcrlist.GroupBy(x => x.Route.DJ_TourGroup.DJ_DijiesheInfo.Name))
        {
            sm2.Add(new statics_Gov2()
            {
                Name = item2.Key,
                AdultsAmount_pre = item2.Sum(x => x.Route.DJ_TourGroup.AdultsAmount),
                ChildrenAmount_pre = item2.Sum(x => x.Route.DJ_TourGroup.ChildrenAmount),
                AdultsAmount_act = item2.Sum(x => x.AdultsAmount),
                ChildrenAmount_act = item2.Sum(x => x.ChildrenAmount)

            });
        }
        rptGov2.DataSource = sm2;
        rptGov2.DataBind();
    }

    protected void BindGov3()
    {
        //整理后数据Gov3
        IList<Model.DJ_TourGroup> tglist = blltg.GetTourGroupByAll();
        IList<statics_Gov3> sm3 = new List<statics_Gov3>();
        foreach (var item3 in tglist.Where(x=>x.DJ_DijiesheInfo!=null))
        {
            sm3.Add(new statics_Gov3()
            {
                Name = item3.DJ_DijiesheInfo.Name,
                Gname = item3.Name,
                GId = item3.Id.ToString()
            });
        }
        rptGov3.DataSource = sm3;
        rptGov3.DataBind();
    }

    protected void btn_yijiedai_Click(object sender, EventArgs e)
    {
        BindGov1();
    }

    protected void btn_yijiedai2_Click(object sender, EventArgs e)
    {
        BindGov2();
    }
}

class statics_model
{
    public string Name { get; set; }
    public int AdultsAmount { get; set; }
    public int ChildrenAmount { get; set; }
    public int LiveDays { get; set; }
    public int Playnums { get; set; }
    public int y_AdultsAmount { get; set; }
    public int y_ChildrenAmount { get; set; }
    public int y_LiveDays { get; set; }
    public int y_Playnums { get; set; }
}

class statics_Gov2
{
    public string Name { get; set; }
    public int AdultsAmount_pre { get; set; }
    public int ChildrenAmount_pre { get; set; }
    public int AdultsAmount_act { get; set; }
    public int ChildrenAmount_act { get; set; }
}

class statics_Gov3
{
    public string Name { get; set; }//地接社名称
    public string GId { get; set; }
    public string Gname { get; set; }//团队名称
    public string Playinfo { get; set; }
}