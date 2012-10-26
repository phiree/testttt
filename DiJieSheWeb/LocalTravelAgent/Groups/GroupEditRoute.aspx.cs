using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
public partial class LocalTravelAgent_Groups_GroupEditRoute :basepageDjsGroupEdit
{
    public string RouteJsonList = string.Empty;
    BLL.BLLDJTourGroup bllGroup = new BLL.BLLDJTourGroup();
    BLL.BLLDJEnterprise bllEnter = new BLLDJEnterprise();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
        }
    }

    private void LoadData()
    {
        LoadTab1Data();
        LoadTab2Data();
    }

    private void LoadTab1Data()
    {
        RouteJsonList = BLL.BLLDJTourGroup.BuildJsonForRouteList(CurrentGroup.Routes);
    }

    private void LoadTab2Data()
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        foreach (var routes in CurrentGroup.Routes.GroupBy(x=>x.DayNo))
        {
            sb.Append(routes.Key.ToString());
            sb.Append(",");
            foreach (var item in routes.Where(x=>x.Description.StartsWith("景点")))
            {
                sb.Append(item.Enterprise.Name);
                sb.Append("-");
            }
            sb=new System.Text.StringBuilder(sb.ToString().Substring(0, sb.Length - 1));
            sb.Append(",");
            foreach (var item in routes.Where(x => x.Description.StartsWith("住宿")))
            {
                sb.Append(item.Enterprise.Name);
                sb.Append("-");
            }
            sb = new System.Text.StringBuilder(sb.ToString().Substring(0, sb.Length - 1));
            sb.AppendLine();
        }
        tbxSimple.Text = sb.ToString();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        UpdateSimple(tbxSimple);
        LoadTab1Data();
        Response.Redirect("/localtravelagent/Groups/GroupList.aspx");
    }

    private void UpdateSimple(TextBox tbx)
    {
        ///删除所有成员先--首先要做提醒
        foreach (Model.DJ_Route route in CurrentGroup.Routes)
        {
            bllGroup.Delete(route);
        }
        //保存新的成员
        string[] arrStrMember = tbx.Text.Split(Environment.NewLine.ToCharArray());

        string errMsg = string.Empty;
        foreach (string s in arrStrMember)
        {
            if (string.IsNullOrEmpty(s)) continue;
            IList<Model.DJ_Route> routelist = Convert2Route(s, out errMsg);
            if (!string.IsNullOrEmpty(errMsg))
            {
                lblSimpleMsg.ForeColor = System.Drawing.Color.Red;
                lblSimpleMsg.Text = errMsg;
                break;
            }
            foreach (var item in routelist)
            {
                bllGroup.Save(item);
            }
        }
        if (string.IsNullOrEmpty(errMsg))
        {
            lblSimpleMsg.ForeColor = System.Drawing.Color.Green;
            lblSimpleMsg.Text = "保存成功";
        }
    }
    private IList<Model.DJ_Route> Convert2Route(string strRoute, out string errMsg)
    {
        errMsg = "";
        IList<Model.DJ_Route> routeList=new List<Model.DJ_Route>();
        string[] strArrMember = strRoute.Split(',');
        if (strArrMember.Length != 5)
        {
            errMsg = "格式有误.源:" + strRoute + ".";
            return null;
        }
        var temp_split1=strArrMember[1].Split(new char[]{'-',' '},StringSplitOptions.RemoveEmptyEntries);
        foreach (var item in temp_split1)
        {
            routeList.Add(new Model.DJ_Route(){
                DayNo=int.Parse(strArrMember[0]),
                Description="景点",
                Enterprise=bllEnter.GetDJS8name(item)[0],
                DJ_TourGroup=CurrentGroup
            });
        }
        var temp_split2 = strArrMember[2].Split(new char[] { '-', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (var item in temp_split2)
        {
            routeList.Add(new Model.DJ_Route(){
                DayNo=int.Parse(strArrMember[0]),
                Description="住宿",
                Enterprise=bllEnter.GetDJS8name(item)[0],
                DJ_TourGroup=CurrentGroup
            });
        }

        return routeList;
    }
}