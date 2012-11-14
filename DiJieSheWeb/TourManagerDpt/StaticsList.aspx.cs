using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TourManagerDpt_StaticsList : basepageMgrDpt
{
    BLL.BLLDJConsumRecord bllCustomRecord = new BLL.BLLDJConsumRecord();
    BLL.BLLDJTourGroup blltg = new BLL.BLLDJTourGroup();
    public int xuhao_orig = 1;
    public int xuhao_1 = 1;
    public int m_total = 0;
    public int m_hotel = 0;
    public int m_play = 0;
    public int y_total = 0;
    public int y_hotel = 0;
    public int y_play = 0;
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
        txt_yijiedai.Text = DateTime.Now.Year + "年" + DateTime.Now.Month + "月";
        txt_yijiedai2.Text = DateTime.Now.Year + "年" + DateTime.Now.Month + "月";
        txt_yijiedai3.Text = DateTime.Now.Year + "年" + DateTime.Now.Month + "月";

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
        if (CurrentDpt.Area.Level == Model.AreaLevel.省)
        {
            gcrlist = gcrlist.Where(x => x.Route.DJ_TourGroup.DJ_DijiesheInfo.Area.Code.StartsWith(CurrentDpt.Area.Code.Substring(0, 2))).ToList();
        }
        else if (CurrentDpt.Area.Level == Model.AreaLevel.市)
        {
            gcrlist = gcrlist.Where(x => x.Route.DJ_TourGroup.DJ_DijiesheInfo.Area.Code.StartsWith(CurrentDpt.Area.Code.Substring(0, 4))).ToList();
        }
        else if (CurrentDpt.Area.Level == Model.AreaLevel.区县)
        {
            gcrlist = gcrlist.Where(x => x.Route.DJ_TourGroup.DJ_DijiesheInfo.Area.Code.StartsWith(CurrentDpt.Area.Code.Substring(0, 6))).ToList();
        }
        IList<Model.DJ_GroupConsumRecord> gcrlist_month;
        IList<Model.DJ_GroupConsumRecord> gcrlist_year;
        IList<statics_model> sm1 = new List<statics_model>();
        //V.2012.10.26
        string[] temp = txt_yijiedai.Text.Split(new char[] { '年', '月' });
        if (!string.IsNullOrEmpty(txt_yijiedai.Text) && temp.Length >= 2)
        {
            var begin_month = new DateTime(int.Parse(temp[0]), int.Parse(temp[1]), 1);
            var end_month = begin_month.AddMonths(1);
            var begin_year = new DateTime(int.Parse(temp[0]), 1, 1);
            var end_year = begin_month.AddMonths(1);
            gcrlist_month = gcrlist.Where(x => x.ConsumeTime >= begin_month && x.ConsumeTime < end_month).ToList();
            gcrlist_year = gcrlist.Where(x => x.ConsumeTime >= begin_year && x.ConsumeTime < end_year).ToList();
        }
        else
        {
            var begin_month = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            var end_month = begin_month.AddMonths(1);
            var begin_year = new DateTime(DateTime.Today.Year, 1, 1);
            var end_year = begin_month.AddMonths(1);
            gcrlist_month = gcrlist.Where(x => x.ConsumeTime >= begin_month && x.ConsumeTime < end_month).ToList();
            gcrlist_year = gcrlist.Where(x => x.ConsumeTime >= begin_year && x.ConsumeTime < end_year).ToList();
        }
        //V.2012.10.26
        foreach (var item in gcrlist_month.GroupBy(x => x.Route.DJ_TourGroup.DJ_DijiesheInfo.Name))
        {
            sm1.Add(new statics_model()
            {
                Name = item.Key,
                AdultsAmount = item.Sum(x => x.AdultsAmount),
                ChildrenAmount = item.Sum(x => x.ChildrenAmount),
                LiveDays = item.Where(x => x.Enterprise.Type == Model.EnterpriseType.宾馆).Sum(x => (x.AdultsAmount + x.ChildrenAmount) * x.LiveDay),
                Playnums = item.Where(x => x.Enterprise.Type == Model.EnterpriseType.景点).Sum(x => x.AdultsAmount + x.ChildrenAmount)
            });
        }
        foreach (var item in gcrlist_year.GroupBy(x => x.Route.DJ_TourGroup.DJ_DijiesheInfo.Name))
        {
            var static_m = sm1.Where(x => x.Name == item.Key);
            if (static_m.Count() > 0)
            {
                static_m.First().y_AdultsAmount = item.Sum(x => x.AdultsAmount);
                static_m.First().y_ChildrenAmount = item.Sum(x => x.ChildrenAmount);
                static_m.First().y_LiveDays = item.Where(x => x.Enterprise.Type == Model.EnterpriseType.宾馆).Sum(x => (x.AdultsAmount + x.ChildrenAmount) * x.LiveDay);
                static_m.First().y_Playnums = item.Where(x => x.Enterprise.Type == Model.EnterpriseType.景点).Sum(x => x.AdultsAmount + x.ChildrenAmount);
            }
        }
        if (!string.IsNullOrEmpty(txt_name1.Text))
        {
            sm1 = sm1.Where(x => x.Name.Split(new string[] { txt_name1.Text }, StringSplitOptions.None).Count() > 1).ToList();
        }
        m_total = sm1.Sum(x => x.AdultsAmount) + sm1.Sum(x => x.ChildrenAmount);
        m_hotel = sm1.Sum(x => x.LiveDays);
        m_play = sm1.Sum(x => x.Playnums);
        y_total = sm1.Sum(x => x.y_AdultsAmount) + sm1.Sum(x => x.y_ChildrenAmount);
        y_hotel = sm1.Sum(x => x.y_LiveDays);
        y_play = sm1.Sum(x => x.y_Playnums);
        rptGov1.DataSource = sm1;
        rptGov1.DataBind();
    }

    protected void BindGov2()
    {
        IList<Model.DJ_GroupConsumRecord> gcrlist = bllCustomRecord.GetGCR8Multi(null, null, null, null, null);
        if (CurrentDpt.Area.Level == Model.AreaLevel.省)
        {
            gcrlist = gcrlist.Where(x => x.Route.DJ_TourGroup.DJ_DijiesheInfo.Area.Code.StartsWith(CurrentDpt.Area.Code.Substring(0, 2))).ToList();
        }
        else if (CurrentDpt.Area.Level == Model.AreaLevel.市)
        {
            gcrlist = gcrlist.Where(x => x.Route.DJ_TourGroup.DJ_DijiesheInfo.Area.Code.StartsWith(CurrentDpt.Area.Code.Substring(0, 4))).ToList();
        }
        else if (CurrentDpt.Area.Level == Model.AreaLevel.区县)
        {
            gcrlist = gcrlist.Where(x => x.Route.DJ_TourGroup.DJ_DijiesheInfo.Area.Code.StartsWith(CurrentDpt.Area.Code.Substring(0, 6))).ToList();
        }
        //V.2012.10.26
        string[] temp = txt_yijiedai2.Text.Split(new char[] { '年', '月' });
        if (!string.IsNullOrEmpty(txt_yijiedai2.Text) && temp.Length >= 2)
        {
            var begin_date = new DateTime(int.Parse(temp[0]), int.Parse(temp[1]), 1);
            var end_date = begin_date.AddMonths(1);
            gcrlist = gcrlist
                .Where(x => x.ConsumeTime >= begin_date && x.ConsumeTime < end_date)
                .ToList();
            if (!string.IsNullOrEmpty(txt_name2.Text))
            {
                gcrlist = gcrlist.Where(x => x.Enterprise.Name.IndexOf(txt_name2.Text) != -1).ToList();
            }
        }
        else
        {
            //var begin_date = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            //var end_date = begin_date.AddMonths(1).AddDays(-1);
            //gcrlist = gcrlist
            //    .Where(x => x.ConsumeTime >= begin_date && x.ConsumeTime < end_date)
            //    .ToList();
            return;
        }
        if (!string.IsNullOrEmpty(txt_name2.Text))
        {
            gcrlist = gcrlist.Where(x => x.Enterprise.Name.IndexOf(txt_name2.Text) >= 0).ToList();
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
        //筛选省市
        if (CurrentDpt.Area.Level == Model.AreaLevel.省)
        {
            tglist = tglist
                .Where(x => x.DJ_DijiesheInfo.Area.Code.StartsWith(CurrentDpt.Area.Code.Substring(0, 2)))
                .ToList();
        }
        if (CurrentDpt.Area.Level == Model.AreaLevel.市)
        {
            tglist = tglist
                .Where(x => x.DJ_DijiesheInfo.Area.Code.StartsWith(CurrentDpt.Area.Code.Substring(0, 4)))
                .ToList();
        }
        if (CurrentDpt.Area.Level == Model.AreaLevel.区县)
        {
            tglist = tglist
                .Where(x => x.DJ_DijiesheInfo.Area.Code.StartsWith(CurrentDpt.Area.Code.Substring(0, 6)))
                .ToList();
        }
        //筛选企业
        if (!string.IsNullOrEmpty(txt_name3djs.Text))
        {
            tglist = tglist.Where(x => x.Routes.Where(y => y.Enterprise.Name == txt_name3djs.Text.Trim()).Count() > 0).ToList();
        }
        //筛选日期
        if (!string.IsNullOrEmpty(txt_yijiedai3.Text))
        {
            tglist = tglist.Where(x => x.BeginDate <= DateTime.Parse(txt_yijiedai3.Text) && x.EndDate.AddDays(1) > DateTime.Parse(txt_yijiedai3.Text)).ToList();
        }
        IList<statics_Gov3> sm3 = new List<statics_Gov3>();
        foreach (var item3 in tglist.Where(x => x.DJ_DijiesheInfo != null))
        {
            var temp = new statics_Gov3();
            temp.Name = item3.DJ_DijiesheInfo.Name;
            temp.Gname = item3.Name;
            temp.GId = item3.Id.ToString();
            temp.Bedate = item3.BeginDate.ToShortDateString() + "~" + item3.EndDate.ToShortDateString();

            var temp_y_hotel = item3.Routes
                .Where(x => x.Enterprise.Type == Model.EnterpriseType.宾馆)
                .Where(x => x.DayNo == ((DateTime.Parse(txt_yijiedai3.Text) - item3.BeginDate).Days));
            if (temp_y_hotel.Count() > 0)
            {
                foreach (var item in temp_y_hotel)
                {
                    temp.y_hotel += item.Enterprise.Name + " ";
                }
            }
            else
            {
                temp.y_hotel = "无";
            }

            var temp_t_hotel = item3.Routes
                .Where(x => x.Enterprise.Type == Model.EnterpriseType.宾馆)
                .Where(x => x.DayNo == ((DateTime.Parse(txt_yijiedai3.Text) - item3.BeginDate).Days + 1));
            if (temp_t_hotel.Count() > 0)
            {
                foreach (var item in temp_t_hotel)
                {
                    temp.t_hotel += item.Enterprise.Name + " ";
                }
            }
            else
            {
                temp.t_hotel = "无";
            }

            var temp_t_scenic = item3.Routes
                .Where(x => x.Enterprise.Type == Model.EnterpriseType.景点)
                .Where(x => x.DayNo == ((DateTime.Parse(txt_yijiedai3.Text) - item3.BeginDate).Days + 1));
            if (temp_t_scenic.Count() > 0)
            {
                foreach (var item in temp_t_hotel)
                {
                    temp.t_scenic += item.Enterprise.Name + " ";
                }
            }
            else
            {
                temp.t_scenic = "无";
            }
            sm3.Add(temp);
        }
        ////V.2012.10.27
        ////团队名字非空
        //if (!string.IsNullOrEmpty(txt_name3.Text))
        //{
        //    //地接社名字非空
        //    if (!string.IsNullOrEmpty(txt_name3djs.Text))
        //    {
        //        sm3 = sm3.Where(x => x.Name.Split(new string[] { txt_name3djs.Text }, StringSplitOptions.None).Count() > 1).ToList();
        //        rptGov3.DataSource = sm3.Where(x => x.Name.Split(new string[] { txt_name3.Text }, StringSplitOptions.None).Count() > 1);
        //    }
        //    else
        //    {
        //        rptGov3.DataSource = sm3.Where(x => x.Name.Split(new string[] { txt_name3.Text }, StringSplitOptions.None).Count() > 1);
        //    }
        //}
        ////团队名字空
        //else
        //{
        //if (!string.IsNullOrEmpty(txt_name3djs.Text))
        //{
        //    rptGov3.DataSource = sm3.Where(x => x.Name.Split(new string[] { txt_name3djs.Text }, StringSplitOptions.None).Count() > 1);
        //}
        //else
        //{
        //V.20120.10.30
        rptGov3.DataSource = sm3;
        //}
        //}
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

    protected void btn_yijiedai3_Click(object sender, EventArgs e)
    {
        BindGov3();
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
    public string Bedate { get; set; }//起止时间
    public string y_hotel { get; set; }//昨天住宿
    public string t_hotel { get; set; }//今天住宿
    public string t_scenic { get; set; }//今天景区
}