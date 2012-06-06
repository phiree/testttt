<%@ WebHandler Language="C#" Class="map" %>

using System;
using System.Web;
using BLL;
using Model;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Web.Script.Serialization;

public class map : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        IList<Scenic> list = new BLLScenic().GetScenic();
        List<Model.map> list2 = new List<Model.map>();
        foreach (Scenic item in list)
        {
            Model.map m = new Model.map();
            m.name = item.Name;
            m.img = item.Photo;
            m.desc = item.Desec;
            m.address = item.Address;
            m.position = item.Position;
            list2.Add(m);
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