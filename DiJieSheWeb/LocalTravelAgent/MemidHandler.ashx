<%@ WebHandler Language="C#" Class="MemidHandler" %>

using System;
using System.Web;

public class MemidHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        string[] datas = context.Request.Form[0].Split(new char[] { '{' }, StringSplitOptions.RemoveEmptyEntries);
        BLL.BLLDijiesheInfo bllDJS = new BLL.BLLDijiesheInfo();
        foreach (var item in datas)
        {
            string[] tmp = item.Split(new char[] { ',' });
            string memtype = tmp[0];
            string memname = tmp[1];
            string memid = tmp[2];
            string memphone = tmp[3];
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}