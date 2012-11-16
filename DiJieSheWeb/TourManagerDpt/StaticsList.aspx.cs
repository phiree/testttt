using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

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
        #region 筛选省市
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
        #endregion
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
                m_AdultsAmount = item.Sum(x => x.AdultsAmount),
                m_ChildrenAmount = item.Sum(x => x.ChildrenAmount),
                m_LiveDays = item.Where(x => x.Enterprise.Type == Model.EnterpriseType.宾馆).Sum(x => (x.AdultsAmount + x.ChildrenAmount) * x.LiveDay),
                m_Playnums = item.Where(x => x.Enterprise.Type == Model.EnterpriseType.景点).Sum(x => x.AdultsAmount + x.ChildrenAmount)
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
        m_total = sm1.Sum(x => x.m_AdultsAmount + x.m_ChildrenAmount);
        m_play = sm1.Sum(x => x.m_Playnums);
        m_hotel = sm1.Sum(x => x.m_LiveDays);
        y_total = sm1.Sum(x => x.y_AdultsAmount + x.y_ChildrenAmount);
        y_play = sm1.Sum(x => x.y_Playnums);
        y_hotel = sm1.Sum(x => x.y_LiveDays);
        rptGov1.DataSource = sm1;
        rptGov1.DataBind();
    }

    protected void BindGov2()
    {
        if (string.IsNullOrEmpty(txt_name2.Text)) {
            return; 
        }

        IList<Model.DJ_GroupConsumRecord> gcrlist = bllCustomRecord.GetGCR8Multi(null, null, null, null, null);
        #region 筛选省市
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
        #endregion
        //V.2012.10.26
        #region 筛选时间
        string[] temp = txt_yijiedai2.Text.Split(new char[] { '年', '月' });
        if (temp.Length >= 2)
        {
            var begin_date = new DateTime(int.Parse(temp[0]), int.Parse(temp[1]), 1);
            var end_date = begin_date.AddMonths(1);
            gcrlist = gcrlist
                .Where(x => x.ConsumeTime >= begin_date && x.ConsumeTime < end_date)
                .ToList();
            //筛选企业
            if (!string.IsNullOrEmpty(txt_name2.Text))
            {
                gcrlist = gcrlist.Where(x => x.Enterprise.Name == txt_name2.Text).ToList();
            }
        }
        else
        {
            return;
        }
        #endregion

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

    //protected void BindGov3()
    //{
        ////整理后数据Gov3
        //IList<Model.DJ_TourGroup> tglist = blltg.();
        //#region 筛选省市
        //if (CurrentDpt.Area.Level == Model.AreaLevel.省)
        //{
        //    tglist = tglist
        //        .Where(x => x.DJ_DijiesheInfo.Area.Code.StartsWith(CurrentDpt.Area.Code.Substring(0, 2)))
        //        .ToList();
        //}
        //if (CurrentDpt.Area.Level == Model.AreaLevel.市)
        //{
        //    tglist = tglist
        //        .Where(x => x.DJ_DijiesheInfo.Area.Code.StartsWith(CurrentDpt.Area.Code.Substring(0, 4)))
        //        .ToList();
        //}
        //if (CurrentDpt.Area.Level == Model.AreaLevel.区县)
        //{
        //    tglist = tglist
        //        .Where(x => x.DJ_DijiesheInfo.Area.Code.StartsWith(CurrentDpt.Area.Code.Substring(0, 6)))
        //        .ToList();
        //}
        //#endregion
        ////筛选企业
        //if (!string.IsNullOrEmpty(txt_name3djs.Text))
        //{
        //    tglist = tglist.Where(x => x.Routes.Where(y => y.Enterprise.Name == txt_name3djs.Text.Trim()).Count() > 0).ToList();
        //}
        ////筛选日期
        //string[] temp = txt_yijiedai3.Text.Split(new char[] { '年', '月' });
        //if (!string.IsNullOrEmpty(txt_yijiedai3.Text) && temp.Length >= 2)
        //{
        //    var begin_date = new DateTime(int.Parse(temp[0]), int.Parse(temp[1]), 1);
        //    var end_date = begin_date.AddMonths(1);
        //    tglist = tglist.Where(x => x.BeginDate >= begin_date && x.EndDate.AddDays(x.DaysAmount) < end_date).ToList();
        //}
        //IList<statics_Gov3> sm3 = new List<statics_Gov3>();
        //foreach (var item3 in tglist.Where(x => x.DJ_DijiesheInfo != null))
        //{
        //    var temp = new statics_Gov3();
        //    temp.Name = item3.DJ_DijiesheInfo.Name;
        //    temp.Gname = item3.Name;
        //    temp.GId = item3.Id.ToString();
        //    temp.Bedate = item3.BeginDate.ToShortDateString() + "~" + item3.EndDate.ToShortDateString();

        //    var temp_y_hotel = item3.Routes
        //        .Where(x => x.Enterprise.Type == Model.EnterpriseType.宾馆)
        //        .Where(x => x.DayNo == ((DateTime.Parse(txt_yijiedai3.Text) - item3.BeginDate).Days));
        //    if (temp_y_hotel.Count() > 0)
        //    {
        //        foreach (var item in temp_y_hotel)
        //        {
        //            temp.y_hotel += item.Enterprise.Name + " ";
        //        }
        //    }
        //    else
        //    {
        //        temp.y_hotel = "无";
        //    }

        //    var temp_t_hotel = item3.Routes
        //        .Where(x => x.Enterprise.Type == Model.EnterpriseType.宾馆)
        //        .Where(x => x.DayNo == ((DateTime.Parse(txt_yijiedai3.Text) - item3.BeginDate).Days + 1));
        //    if (temp_t_hotel.Count() > 0)
        //    {
        //        foreach (var item in temp_t_hotel)
        //        {
        //            temp.t_hotel += item.Enterprise.Name + " ";
        //        }
        //    }
        //    else
        //    {
        //        temp.t_hotel = "无";
        //    }

        //    var temp_t_scenic = item3.Routes
        //        .Where(x => x.Enterprise.Type == Model.EnterpriseType.景点)
        //        .Where(x => x.DayNo == ((DateTime.Parse(txt_yijiedai3.Text) - item3.BeginDate).Days + 1));
        //    if (temp_t_scenic.Count() > 0)
        //    {
        //        foreach (var item in temp_t_hotel)
        //        {
        //            temp.t_scenic += item.Enterprise.Name + " ";
        //        }
        //    }
        //    else
        //    {
        //        temp.t_scenic = "无";
        //    }
        //    sm3.Add(temp);
        //}
        //////V.2012.10.27
        //////团队名字非空
        ////if (!string.IsNullOrEmpty(txt_name3.Text))
        ////{
        ////    //地接社名字非空
        ////    if (!string.IsNullOrEmpty(txt_name3djs.Text))
        ////    {
        ////        sm3 = sm3.Where(x => x.Name.Split(new string[] { txt_name3djs.Text }, StringSplitOptions.None).Count() > 1).ToList();
        ////        rptGov3.DataSource = sm3.Where(x => x.Name.Split(new string[] { txt_name3.Text }, StringSplitOptions.None).Count() > 1);
        ////    }
        ////    else
        ////    {
        ////        rptGov3.DataSource = sm3.Where(x => x.Name.Split(new string[] { txt_name3.Text }, StringSplitOptions.None).Count() > 1);
        ////    }
        ////}
        //////团队名字空
        ////else
        ////{
        ////if (!string.IsNullOrEmpty(txt_name3djs.Text))
        ////{
        ////    rptGov3.DataSource = sm3.Where(x => x.Name.Split(new string[] { txt_name3djs.Text }, StringSplitOptions.None).Count() > 1);
        ////}
        ////else
        ////{
        ////V.20120.10.30
        //rptGov3.DataSource = sm3;
        ////}
        ////}
        //rptGov3.DataBind();
    //}

    protected void BindGov3()
    {
        if (string.IsNullOrEmpty(txt_name3djs.Text))
        {
            return;
        }
        IList<Model.DJ_GroupConsumRecord> gcrlist = bllCustomRecord.GetGCR8Multi(null, null, null, null, null);
        #region 筛选省市
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
        #endregion
        #region 筛选时间
        string[] tempdate = txt_yijiedai3.Text.Split(new char[] { '年', '月' });
        if (tempdate.Length >= 2)
        {
            var begin_date = new DateTime(int.Parse(tempdate[0]), int.Parse(tempdate[1]), 1);
            var end_date = begin_date.AddMonths(1);
            gcrlist = gcrlist
                .Where(x => x.ConsumeTime >= begin_date && x.ConsumeTime < end_date)
                .ToList();
            //筛选企业
            if (!string.IsNullOrEmpty(txt_name2.Text))
            {
                gcrlist = gcrlist.Where(x => x.Enterprise.Name == txt_name3djs.Text).ToList();
            }
        }
        else
        {
            return;
        }
        #endregion
        #region 整理数据
        IList<statics_Gov3> sm3 = new List<statics_Gov3>();
        foreach (var item3 in gcrlist.Where(x => x.Route.DJ_TourGroup.DJ_DijiesheInfo != null))
        {
            var temp = new statics_Gov3();
            temp.Name = item3.Route.DJ_TourGroup.DJ_DijiesheInfo.Name;
            temp.Gname = item3.Route.DJ_TourGroup.Name;
            temp.GId = item3.Route.DJ_TourGroup.Id.ToString();
            temp.Bedate = item3.Route.DJ_TourGroup.BeginDate.ToShortDateString() + "~" + item3.Route.DJ_TourGroup.EndDate.ToShortDateString();

            #region 昨日住宿
            var temp_y_hotel = item3.Route.DJ_TourGroup.Routes
                .Where(x => x.Enterprise.Type == Model.EnterpriseType.宾馆)
                .Where(x => x.DayNo == ((DateTime.Parse(txt_yijiedai3.Text) - item3.Route.DJ_TourGroup.BeginDate).Days));
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
            #endregion

            #region 今日住宿
            var temp_t_hotel = item3.Route.DJ_TourGroup.Routes
                .Where(x => x.Enterprise.Type == Model.EnterpriseType.宾馆)
                .Where(x => x.DayNo == ((DateTime.Parse(txt_yijiedai3.Text) - item3.Route.DJ_TourGroup.BeginDate).Days + 1));
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
            #endregion

            #region 今日景区
            var temp_t_scenic = item3.Route.DJ_TourGroup.Routes
                .Where(x => x.Enterprise.Type == Model.EnterpriseType.景点)
                .Where(x => x.DayNo == ((DateTime.Parse(txt_yijiedai3.Text) - item3.Route.DJ_TourGroup.BeginDate).Days + 1));
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
            #endregion
            sm3.Add(temp);
        }
        #endregion
        rptGov3.DataSource = sm3;
        rptGov3.DataBind();
    }

    protected void btn_yijiedai_Click(object sender, EventArgs e)
    {
        BindGov1();
    }

    protected void btn_yijiedai2_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txt_name2.Text))
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "alert('请输入要查询的企业名称!')", true);
            return;
        }
        BindGov2();
    }

    protected void btn_yijiedai3_Click(object sender, EventArgs e)
    {
        BindGov3();
    }

    protected void btnOutput1_Click(object sender, EventArgs e)
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
        //V.2012.11.16
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
        //V.2012.11.16
        foreach (var item in gcrlist_month.GroupBy(x => x.Route.DJ_TourGroup.DJ_DijiesheInfo.Name))
        {
            sm1.Add(new statics_model()
            {
                Name = item.Key,
                m_AdultsAmount = item.Sum(x => x.AdultsAmount),
                m_ChildrenAmount = item.Sum(x => x.ChildrenAmount),
                m_LiveDays = item.Where(x => x.Enterprise.Type == Model.EnterpriseType.宾馆).Sum(x => (x.AdultsAmount + x.ChildrenAmount) * x.LiveDay),
                m_Playnums = item.Where(x => x.Enterprise.Type == Model.EnterpriseType.景点).Sum(x => x.AdultsAmount + x.ChildrenAmount)
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
        m_total = sm1.Sum(x => x.m_AdultsAmount + x.m_ChildrenAmount);
        m_play = sm1.Sum(x => x.m_Playnums);
        m_hotel = sm1.Sum(x => x.m_LiveDays);
        y_total = sm1.Sum(x => x.y_AdultsAmount + x.y_ChildrenAmount);
        y_play = sm1.Sum(x => x.y_Playnums);
        y_hotel = sm1.Sum(x => x.y_LiveDays);

        //创建datatable
        DataTable tblDatas = new DataTable("Datas");
        //tblDatas.Columns.Add("id", Type.GetType("System.Int32"));
        //tblDatas.Columns[0].AutoIncrement = true;
        //tblDatas.Columns[0].AutoIncrementSeed = 1;
        //tblDatas.Columns[0].AutoIncrementStep = 1;
        tblDatas.Columns.Add("id", Type.GetType("System.String"));
        tblDatas.Columns.Add("name", Type.GetType("System.String"));
        tblDatas.Columns.Add("m_total", Type.GetType("System.String"));
        tblDatas.Columns.Add("m_play", Type.GetType("System.String"));
        tblDatas.Columns.Add("m_hotel", Type.GetType("System.String"));
        tblDatas.Columns.Add("y_total", Type.GetType("System.String"));
        tblDatas.Columns.Add("y_play", Type.GetType("System.String"));
        tblDatas.Columns.Add("y_hotel", Type.GetType("System.String"));
        int i = 1;
        foreach (var item in sm1)
        {
            tblDatas.Rows.Add(new object[] { i++, item.Name,item.m_AdultsAmount+item.m_ChildrenAmount,
                item.m_Playnums,item.m_LiveDays,item.y_AdultsAmount+item.y_ChildrenAmount,y_play,y_hotel});
            i++;
        }
        tblDatas.Rows.Add(new object[] { "总计", "", m_total, m_play, m_hotel, y_total, y_play, y_hotel });
        ExcelOplib.ExcelOutput.Download2Excel(tblDatas, this.Page, new List<string>() { 
            "序号","地接社名称","本月总人数","本月游览人次","本月住宿人数","本年总人数","本年游览人数","本年住宿人数"
        });
    }

    protected void btnOutput2_Click(object sender, EventArgs e)
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
        //V.2012.11.16
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

        //创建datatable
        DataTable tblDatas = new DataTable("Datas");
        tblDatas.Columns.Add("id", Type.GetType("System.Int32"));
        tblDatas.Columns[0].AutoIncrement = true;
        tblDatas.Columns[0].AutoIncrementSeed = 1;
        tblDatas.Columns[0].AutoIncrementStep = 1;
        tblDatas.Columns.Add("name", Type.GetType("System.String"));
        tblDatas.Columns.Add("m_total", Type.GetType("System.String"));
        foreach (var item in sm2)
        {
            tblDatas.Rows.Add(new object[] { null, "共"+(item.AdultsAmount_pre+item.ChildrenAmount_pre)
                +"人： 成人"+item.AdultsAmount_pre+"人，儿童"+item.ChildrenAmount_pre+"人",
                "共"+(item.AdultsAmount_act+item.ChildrenAmount_act)
                +"人： 成人"+item.AdultsAmount_act+"人，儿童"+item.ChildrenAmount_act+"人",
            });
        }
        ExcelOplib.ExcelOutput.Download2Excel(tblDatas, this.Page, new List<string>() { 
            "序号","拟接待人数","实际接待人数"
        });
    }

    protected void btnOutput3_Click(object sender, EventArgs e) {

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
        //创建datatable
        DataTable tblDatas = new DataTable("Datas");
        tblDatas.Columns.Add("id", Type.GetType("System.String"));
        tblDatas.Columns.Add("djsname", Type.GetType("System.String"));
        tblDatas.Columns.Add("gname", Type.GetType("System.String"));
        tblDatas.Columns.Add("datetime", Type.GetType("System.String"));
        tblDatas.Columns.Add("situation", Type.GetType("System.String"));
        int i = 1;
        foreach (var item in sm3)
        {
            tblDatas.Rows.Add(new object[] { i++, item.Name, item.Gname, item.Bedate, 
                "上一日住宿："+item.y_hotel+"，准备入住："+item.t_hotel+"今日游览："+item.t_scenic });
            i++;
        }
        tblDatas.Rows.Add(new object[] { "总计", "", m_total, m_play, m_hotel, y_total, y_play, y_hotel });
        ExcelOplib.ExcelOutput.Download2Excel(tblDatas, this.Page, new List<string>() { 
            "序号","地接社名称","团队名称","时间","游览情况"
        });
    }
}

class statics_model
{
    public string Name { get; set; }
    public int m_AdultsAmount { get; set; }
    public int m_ChildrenAmount { get; set; }
    public int m_LiveDays { get; set; }
    public int m_Playnums { get; set; }
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