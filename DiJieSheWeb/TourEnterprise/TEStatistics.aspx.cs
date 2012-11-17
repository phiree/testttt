using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using System.Linq.Expressions;
using System.IO;
using System.Data;

public partial class TourEnterprise_TEStatistics : System.Web.UI.Page
{
    BLLDJConsumRecord bllrecord = new BLLDJConsumRecord();
    BLLDJRoute BLLDJRoute = new BLLDJRoute();
    int Index = 1;
    List<DJ_GroupConsumRecord> ListRecord = new List<DJ_GroupConsumRecord>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtBeginTime.Text = DateTime.Now.ToString("yyyy-MM-dd"); txtEndTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
            bind();
        }
    }

    private void bind()
    {
        ListRecord = GetRecordList();
        //ListRecord= OrderByList(ListRecord);
        rptTgRecord.DataSource = ListRecord;
        rptTgRecord.DataBind();
    }

    private List<DJ_GroupConsumRecord> GetRecordList()
    {
        List<DJ_GroupConsumRecord> ListRec = new List<DJ_GroupConsumRecord>();
        if (ddlState.SelectedValue == "已验证")
            ListRec = bllrecord.GetRecordByAllCondition(txtGroupName.Text.Trim(), txtEntName.Text.Trim(), txtBeginTime.Text, txtEndTime.Text, Master.CurrentTE.Id);
        if (ddlState.SelectedValue == "未验证")
            ListRec.AddRange(BindForeast(txtGroupName.Text.Trim(), txtEntName.Text.Trim(), txtBeginTime.Text, txtEndTime.Text));
        if (ddlState.SelectedValue == "全部")
        {
            ListRec = bllrecord.GetRecordByAllCondition(txtGroupName.Text.Trim(), txtEntName.Text.Trim(), txtBeginTime.Text, txtEndTime.Text, Master.CurrentTE.Id);
            ListRec.AddRange(BindForeast(txtGroupName.Text.Trim(), txtEntName.Text.Trim(), txtBeginTime.Text, txtEndTime.Text));
        }
        return ListRec;
    }


    protected void rptTgRecord_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            DJ_GroupConsumRecord record = e.Item.DataItem as DJ_GroupConsumRecord;
            //Literal laNo = e.Item.FindControl("laNo") as Literal;
            Literal laIsChecked = e.Item.FindControl("laIsChecked") as Literal;
            if (record.Id.Equals(Guid.Empty))
            {
                laIsChecked.Text = "未验证";
            }
            else
                laIsChecked.Text = "已验证";
            //laNo.Text = Index++.ToString();
        }
        if (e.Item.ItemType == ListItemType.Footer)
        {
            Literal laGuiderCount = e.Item.FindControl("laGuiderCount") as Literal;
            Literal laAdultCount = e.Item.FindControl("laAdultCount") as Literal;
            Literal laChildrenCount = e.Item.FindControl("laChildrenCount") as Literal;
            int groupcount, adultcount, childrencount;
            bllrecord.GetCountInfoByETid(Master.CurrentTE.Id, out groupcount, out adultcount, out childrencount, ListRecord);
            laGuiderCount.Text = groupcount.ToString();
            laAdultCount.Text = adultcount.ToString();
            laChildrenCount.Text = childrencount.ToString();
        }
    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        DateTime BeginTime, EndTime;
        if (DateTime.TryParse(txtBeginTime.Text, out BeginTime) && DateTime.TryParse(txtEndTime.Text, out EndTime))
        {
            if (BeginTime > EndTime)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('起始时间大于终止时间')", true);
                txtBeginTime.Text = "";
                txtEndTime.Text = "";
            }
        }
        else
        {
            txtBeginTime.Text = "";
            txtEndTime.Text = "";
        }
        bind();
    }

    private List<DJ_GroupConsumRecord> BindForeast(string groupname, string EntName, string BeginTime, string EndTime)
    {
        List<DJ_Route> ListRoute = BLLDJRoute.GetRouteByAllCondition(groupname, EntName, BeginTime, EndTime, Master.CurrentTE.Id).ToList();
        List<DJ_GroupConsumRecord> ListRecord = new List<DJ_GroupConsumRecord>();
        foreach (DJ_Route route in ListRoute)
        {
            DJ_GroupConsumRecord record = new DJ_GroupConsumRecord();
            int MaxLiveDay;
            List<DJ_Route> listWroute = bllrecord.GetLiveRouteByDay(out MaxLiveDay, 1, Master.CurrentTE, route);
            record.LiveDay = MaxLiveDay;
            record.Route = route;
            record.AdultsAmount = route.DJ_TourGroup.AdultsAmount;
            record.ChildrenAmount = route.DJ_TourGroup.ChildrenAmount;
            record.Enterprise = Master.CurrentTE;
            record.ConsumeTime = route.DJ_TourGroup.BeginDate.AddDays(route.DayNo - 1);
            ListRecord.Add(record);
        }
        return ListRecord;
    }

    //#region 排序方法
    //private List<DJ_GroupConsumRecord> OrderByList(List<DJ_GroupConsumRecord> ListRecord)
    //{
    //    string[] orderbyStrs = Request.Cookies["orderstr"].Value.Split('_');
    //    int orderIndex = int.Parse(orderbyStrs[0]);
    //    string orderType = orderbyStrs[1];
    //    switch (orderIndex)
    //    {
    //        case 0:
    //            {
    //                ListRecord = orderType == "asc" ? ListRecord.OrderBy(x => x.ConsumeTime).ToList() : ListRecord.OrderByDescending(x => x.ConsumeTime).ToList();
    //                break;
    //            }
    //        case 1:
    //            {
    //                ListRecord = orderType == "asc" ? ListRecord.OrderBy(x => x.Route.DJ_TourGroup.Name).ToList() : ListRecord.OrderByDescending(x => x.Route.DJ_TourGroup.Name).ToList();
    //                break;
    //            }
    //        case 2:
    //            {
    //                ListRecord = orderType == "asc" ? ListRecord.OrderBy(x => x.Route.DJ_TourGroup.DJ_DijiesheInfo.Name).ToList() : ListRecord.OrderByDescending(x => x.Route.DJ_TourGroup.DJ_DijiesheInfo.Name).ToList();
    //                break;
    //            }
    //        case 3:
    //            {
    //                ListRecord = orderType == "asc" ? ListRecord.OrderBy(x => x.LiveDay).ToList() : ListRecord.OrderByDescending(x => x.LiveDay).ToList();
    //                break;
    //            }
    //        case 4:
    //            {
    //                ListRecord = orderType == "asc" ? ListRecord.OrderBy(x => x.AdultsAmount).OrderBy(x => x.ChildrenAmount).ToList() : ListRecord.OrderByDescending(x => x.AdultsAmount).OrderByDescending(x => x.ChildrenAmount).ToList();
    //                break;
    //            }
    //        default:
    //            break;
    //    }
    //    return ListRecord;

    //}
    //#endregion
    protected void BtnCreatexls_Click(object sender, EventArgs e)
    {
        List<DJ_GroupConsumRecord> WListRec = new List<DJ_GroupConsumRecord>();
        List<DJ_GroupConsumRecord> YListRec = new List<DJ_GroupConsumRecord>();
        if (ddlState.SelectedValue == "已验证")
        {
            YListRec = bllrecord.GetRecordByAllCondition(txtGroupName.Text.Trim(), txtEntName.Text.Trim(), txtBeginTime.Text, txtEndTime.Text, Master.CurrentTE.Id);
            WListRec = null;
        }
        if (ddlState.SelectedValue == "未验证")
        {
            WListRec.AddRange(BindForeast(txtGroupName.Text.Trim(), txtEntName.Text.Trim(), txtBeginTime.Text, txtEndTime.Text));
            YListRec = null;
        }
        if (ddlState.SelectedValue == "全部")
        {
            YListRec = bllrecord.GetRecordByAllCondition(txtGroupName.Text.Trim(), txtEntName.Text.Trim(), txtBeginTime.Text, txtEndTime.Text, Master.CurrentTE.Id);
            WListRec.AddRange(BindForeast(txtGroupName.Text.Trim(), txtEntName.Text.Trim(), txtBeginTime.Text, txtEndTime.Text));
        }
        CreateExcels(WListRec, YListRec, Master.CurrentTE.Name+"信息统计.xls");
    }



    public void CreateExcels(List<DJ_GroupConsumRecord> WListRecord, List<DJ_GroupConsumRecord> YListRecord, string FileName)
    {
        //HttpResponse resp;
        //resp = Page.Response;
        //resp.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
        //resp.AppendHeader("Content-Disposition", "attachment;filename=" + FileName);
        //// resp.ContentType = "application/vnd.ms-excel";
        //string colCaption = "",colContent="",colfooter="";
        //colCaption = "序号\t住宿时间\t团队名称\t旅行社名称\t住宿天数\t人数\t验证状态\n";
        //resp.Write(colCaption);
        //foreach (DJ_GroupConsumRecord record in WListRecord)
        //{
        //    colContent += Index++ + "\t";
        //    colContent += record.ConsumeTime + "\t";
        //    colContent += record.Route.DJ_TourGroup.Name + "\t";
        //    colContent += record.Route.DJ_TourGroup.DJ_DijiesheInfo.Name + "\t";
        //    colContent += record.LiveDay + "\t";
        //    colContent += "成人" + record.AdultsAmount + "儿童" + record.ChildrenAmount + "\t";
        //    colContent += "未验证\n";
        //}
        //foreach (DJ_GroupConsumRecord record in YListRecord)
        //{
        //    colContent += Index++ + "\t";
        //    colContent += record.ConsumeTime + "\t";
        //    colContent += record.Route.DJ_TourGroup.Name + "\t";
        //    colContent += record.Route.DJ_TourGroup.DJ_DijiesheInfo.Name + "\t";
        //    colContent += record.LiveDay + "\t";
        //    colContent += "成人" + record.AdultsAmount + "儿童" + record.ChildrenAmount + "\t";
        //    colContent += "已验证\n";
        //}
        //resp.Write(colContent);
        //int groupcount,adultcount,childrencount;
        //    bllrecord.GetCountInfoByETid(Master.CurrentTE.Id, out groupcount, out adultcount, out childrencount, ListRecord);
        //    colfooter = "共接待团对数" + groupcount + "其中包括成人" + adultcount + "儿童" + childrencount;
        //resp.Write(colfooter);
        ////写缓冲区中的数据到HTTP头文档中 
        //resp.End();

        List<string> titlelist = new List<string>() { "序号", "住宿时间", "团队名称", "旅行社名称", "住宿天数", "人数", "验证状态" };
        DataTable dt = new DataTable();
        for (int i = 0; i < titlelist.Count; i++)
        {
            dt.Columns.Add(new DataColumn());
        }
        foreach (DJ_GroupConsumRecord record in WListRecord)
        {
            DataRow dr = dt.NewRow();
            dr[0] = Index;
            dr[1] = record.ConsumeTime;
            dr[2] = record.Route.DJ_TourGroup.Name;
            dr[3] = record.Route.DJ_TourGroup.DJ_DijiesheInfo.Name;
            dr[4] = record.LiveDay;
            dr[5] = "成人" + record.AdultsAmount + "儿童" + record.ChildrenAmount;
            dr[6] = "未验证";
            dt.Rows.Add(dr);
            Index++;
        }
        foreach (DJ_GroupConsumRecord record in YListRecord)
        {
            DataRow dr = dt.NewRow();
            dr[0] = Index;
            dr[1] = record.ConsumeTime;
            dr[2] = record.Route.DJ_TourGroup.Name;
            dr[3] = record.Route.DJ_TourGroup.DJ_DijiesheInfo.Name;
            dr[4] = record.LiveDay;
            dr[5] = "成人" + record.AdultsAmount + "儿童" + record.ChildrenAmount;
            dr[6] = "已验证";
            dt.Rows.Add(dr);
            Index++;
        }
        int groupcount, adultcount, childrencount;
        bllrecord.GetCountInfoByETid(Master.CurrentTE.Id, out groupcount, out adultcount, out childrencount, ListRecord);
        DataRow drend = dt.NewRow();
        drend[0] = "共接待团对数" + groupcount + "其中包括成人" + adultcount + "儿童" + childrencount;
        dt.Rows.Add(drend);
        ExcelOplib.ExcelOutput.Download2Excel(dt, this.Page, titlelist);
    }
}