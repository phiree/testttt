<%@ WebHandler Language="C#" Class="UpdatePosition" %>

using System;
using System.Web;
using BLL;
using Model;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Web.Script.Serialization;
using System.Text;
using System.Runtime.Serialization.Json;
using System.IO;

public class UpdatePosition : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        BLLScenic bllscenic = new BLLScenic();
        IList<Scenic> list = bllscenic.GetScenic();
        List<ScenicMap> list2 = new List<ScenicMap>();
        foreach (Scenic item in list)
        {
            ScenicMap map = new ScenicMap();
            map.name = item.Address;
            list2.Add(map);
        }
        string JSON = new JavaScriptSerializer().Serialize(list2);//把list转换为JSON格式的字符串
        context.Response.Write(JSON);
    }





   
    public bool IsReusable {
        get {
            return false;
        }
    }

}

