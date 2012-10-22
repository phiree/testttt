<%@ WebHandler Language="C#" Class="ExcelHandler" %>

using System;
using System.Web;

public class ExcelHandler : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {

        #region 导入
        string filename=context.Request["filename"];
        
        //老版本
        //ExcelOplib.ExcelDjsOpr excel = new ExcelOplib.ExcelDjsOpr();
        //System.Collections.Generic.List<ExcelOplib.Entity.DJSEntity> djsresult = excel.getDJSlist(filename);
        //新版本2012-09-28
        //ExcelOplib.ExcelGroupOpr excel = new ExcelOplib.ExcelGroupOpr();
        //System.Collections.Generic.List<ExcelOplib.Entity.GroupMember> gmlist = excel.getMemberlist(filename);
        
        //string html = string.Empty;
        //if (gmlist==null || gmlist.Count < 1)
        //{
        //    return ;
        //}

        //foreach (ExcelOplib.Entity.GroupMember item in gmlist)
        //{
        //    html += "<tr><td><select><option value='成人游客'>成人游客</option><option value='儿童游客'>儿童游客</option>" +
        //        "<option value='导游'>导游</option><option value='司机'>司机</option></select></td>" +
        //        "<td><input type='text' value='" + item.Memname + "'/>" +
        //        "</td><td><input type='text' value='" + item.Memid + "'/></td>" +
        //        "<td><input type='text' value='" + item.Memphone + "'/></td>" +
        //        "<td><input type='hidden' /><input type='hidden' />" +
        //        "<input onclick='delrow(this)' class='delrow' type='button' style='width: 25px;' value='-' /></td></tr>";
        //}
        
        //新版本2012-10-09
        ExcelOplib.ExcelGroupOpr excel = new ExcelOplib.ExcelGroupOpr();
        ExcelOplib.Entity.GroupAll groupall = excel.getGroup(filename);

        string html = string.Empty;
        if (groupall.GroupBasic == null ||
            groupall.GroupMemberList == null || groupall.GroupMemberList.Count < 1 ||
            groupall.GroupRouteList == null || groupall.GroupRouteList.Count < 1)
        {
            return;
        }

        html += @"{""Name"":""" +  groupall.GroupBasic.Name
            + @""",""Bedate"":""" + DateTime.Parse(groupall.GroupBasic.Begindate).ToShortDateString() + "-" + DateTime.Parse(groupall.GroupBasic.Enddate).ToShortDateString()
            + @""",""Days"":""" +  groupall.GroupBasic.Days
            + @""",""PeopleTotal"":""" + groupall.GroupBasic.PeopleTotal
            + @""",""PeopleAdult"":""" + groupall.GroupBasic.PeopleAdult
            + @""",""PeopleChild"":""" + groupall.GroupBasic.PeopleChild
            + @""",""StartPlace"":""" + groupall.GroupBasic.StartPlace
            + @""",""EndPlace"":""" + groupall.GroupBasic.EndPlace
            + @""",""Foreigners"":""" + groupall.GroupBasic.Foreigners
            + @""",""GroupNo"":""" + groupall.GroupBasic.GroupNo
            + @""",""Gangaotais"":""" + groupall.GroupBasic.Gangaotais;

        html += @""",""Member"":""";
        foreach (ExcelOplib.Entity.GroupMember item in groupall.GroupMemberList)
        {
            html += @"<tr><td>" + item.Memtype +
                "</td><td>" + item.Memname +
                "</td><td>" + item.Memid +
                "</td><td>" + item.Memphone +
                "</td><td>" + item.Cardno +
                "</td></tr>";
        }

        html += @""",""Route"":""";
        foreach (ExcelOplib.Entity.GroupRoute item in groupall.GroupRouteList)
        {
            html += @"<tr><td>" + item.RouteDate +
                "</td><td>" + item.City +
                "</td><td>" + item.Breakfast +
                "</td><td>" + item.Lunch +
                "</td><td>" + item.Dinner +
                "</td><td>" + item.Hotel1
                                         + (item.Hotel2 == string.Empty ? "" : "-" + item.Hotel2) +
                "</td><td>" + item.Scenic1 
                                         + (item.Scenic2 == string.Empty ? "" : "-" + item.Scenic2)
                                         + (item.Scenic3 == string.Empty ? "" : "-" + item.Scenic3)
                                         + (item.Scenic4 == string.Empty ? "" : "-" + item.Scenic4)
                                         + (item.Scenic5 == string.Empty ? "" : "-" + item.Scenic5)
                                         + (item.Scenic6 == string.Empty ? "" : "-" + item.Scenic6)
                                         + (item.Scenic7 == string.Empty ? "" : "-" + item.Scenic7)
                                         + (item.Scenic8 == string.Empty ? "" : "-" + item.Scenic8)
                                         + (item.Scenic9 == string.Empty ? "" : "-" + item.Scenic9)
                                         + (item.Scenic10 == string.Empty ? "" : "-" + item.Scenic10) +
                "</td><td>" + item.ShoppingPoint1
                                         + (item.ShoppingPoint2 == string.Empty ? "" : "-" + item.ShoppingPoint2)
                                         + (item.ShoppingPoint3 == string.Empty ? "" : "-" + item.ShoppingPoint3)+ "</td></tr>";
        }
        html += @"""}";
        #endregion
        context.Response.Write(html);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}