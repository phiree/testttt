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
        //新版本
        ExcelOplib.ExcelGroupOpr excel = new ExcelOplib.ExcelGroupOpr();
        System.Collections.Generic.List<ExcelOplib.Entity.GroupMember> gmlist = excel.getMemberlist(filename);
        
        string html = string.Empty;
        if (gmlist==null || gmlist.Count < 1)
        {
            return ;
        }

        foreach (ExcelOplib.Entity.GroupMember item in gmlist)
        {
            html += "<tr><td><select><option value='成人游客'>成人游客</option><option value='儿童游客'>儿童游客</option>" +
                "<option value='导游'>导游</option><option value='司机'>司机</option></select></td>" +
                "<td><input type='text' value='" + item.Memname + "'/>" +
                "</td><td><input type='text' value='" + item.Memid + "'/></td>" +
                "<td><input type='text' value='" + item.Memphone + "'/></td>" +
                "<td><input type='hidden' /><input type='hidden' />" +
                "<input onclick='delrow(this)' class='delrow' type='button' style='width: 25px;' value='-' /></td></tr>";
        }
        #endregion
        context.Response.Write(html);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}