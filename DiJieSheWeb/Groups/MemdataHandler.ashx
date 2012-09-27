<%@ WebHandler Language="C#" Class="MemdataHandler" %>

using System;
using System.Web;
using System.Linq;

public class MemdataHandler : IHttpHandler {

    BLL.BLLDJEnterprise blldjs = new BLL.BLLDJEnterprise();
    
    public void ProcessRequest (HttpContext context) {
        string id = context.Request.QueryString["id"];
        Model.DJ_TourGroup group = blldjs.GetGroup8gid(id);
        string html = string.Empty;
        
        foreach (Model.DJ_TourGroupMember item in group.Members)
        {
            html += "<tr><td><select><option value='成人游客'>成人游客</option><option value='儿童游客'>儿童游客</option>" +
                "<option value='导游'>导游</option><option value='司机'>司机</option></select></td>" +
                "<td><input type='text' value='" + item.RealName + "'/>" +
                "</td><td><input type='text' value='" + item.IdCardNo + "'/></td>" +
                "<td><input type='text' value='" + item.PhoneNum + "'/></td>" +
                "<td><input type='hidden' /><input type='hidden' />" +
                "<input onclick='delrow(this)' class='delrow' type='button' style='width: 25px;' value='-' /></td></tr>";
        }
        context.Response.Write(html);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}