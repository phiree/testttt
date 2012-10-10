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
        if (groupall.gb == null ||
            groupall.gmlist == null || groupall.gmlist.Count < 1 ||
            groupall.grlist == null || groupall.grlist.Count < 1)
        {
            return;
        }

        html += @"{""Name"":""" +  groupall.gb.Name 
            + @""",""Bedate"":""" +  groupall.gb.Bedate 
            + @""",""Days"":""" +  groupall.gb.Days
            + @""",""PeopleTotal"":""" + groupall.gb.PeopleTotal
            + @""",""PeopleAdult"":""" + groupall.gb.PeopleAdult
            + @""",""PeopleChild"":""" + groupall.gb.PeopleChild
            + @""",""StartPlace"":""" + groupall.gb.StartPlace
            + @""",""EndPlace"":""" + groupall.gb.EndPlace ;

        html += @""",""Member"":""";
        foreach (ExcelOplib.Entity.GroupMember item in groupall.gmlist)
        {
            html += @"<tr><td>" + item.Memtype +
                "</td><td>" + item.Memname +
                "</td><td>" + item.Memid +
                "</td><td>" + item.Memphone +
                "</td><td>" + item.Cardno + @"</td></tr>";
        }

        html += @""",""Route"":""";
        foreach (ExcelOplib.Entity.GroupRoute item in groupall.grlist)
        {
            html += @"<tr><td>" + item.RouteDate +
                "</td><td>" + item.Breakfast +
                "</td><td>" + item.Lunch +
                "</td><td>" + item.Dinner +
                "</td><td>" + item.Hotel +
                "</td><td>" + item.Scenic +
                "</td><td>" + item.ShoppingPoint + "</td></tr>";
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