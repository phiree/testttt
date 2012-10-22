<%@ WebHandler Language="C#" Class="ValidateHandler" %>

using System;
using System.Web;

/// <summary>
/// 验证身份证
/// </summary>
public class ValidateHandler : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";

        var id = context.Request.Form[0];
        var idlist=id.Split(new char[]{'-'},StringSplitOptions.RemoveEmptyEntries);
        var result_dic=new CommonLibrary.Mydic(string.Empty,true);
        foreach (var item in idlist)
        {
            var temp=CommonLibrary.ValidateHelper.verify_idcard(item);
            if (!temp.bl)
            {
                result_dic.bl = false;
                result_dic.obj = "\""+item+"\"号码错误, 请在excel中修改后再上传!";
            }
        }
        context.Response.Write(result_dic.bl+"-"+result_dic.obj);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}