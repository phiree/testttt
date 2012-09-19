<%@ WebHandler Language="C#" Class="ExcelHandler" %>

using System;
using System.Web;

public class ExcelHandler : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {

        #region 导入
        string filename=context.Request["filename"];
        ExcelOplib.ExcelDjsOpr excel = new ExcelOplib.ExcelDjsOpr();
        System.Collections.Generic.List<ExcelOplib.Entity.DJSEntity> djsresult = excel.getDJSlist(@"d:\upload\" + filename);
        string html = string.Empty;

        foreach (ExcelOplib.Entity.DJSEntity item in djsresult)
        {
            html += "<tr><td><select><option value='成人游客'>成人游客</option><option value='儿童游客'>儿童游客</option>" +
                "<option value='导游'>导游</option><option value='司机'>司机</option></select></td>" +
                "<td><input type='text' value='" + item.MemName + "'/>" +
                "</td><td><input type='text' value='" + item.MemID + "'/></td>" +
                "<td><input type='text' value='" + item.MemPhone + "'/></td>" +
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