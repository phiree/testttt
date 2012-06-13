<%@ WebHandler Language="C#" Class="allpoint" %>

using System;
using System.Web;
using BLL;
using Model;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Web.Script.Serialization;
using System.Text;

public class allpoint : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        IList<Ticket> list = null;
        list = new BLLScenic().GetScenicByScenicName("", "", 0);
        List<Model.ScenicMap> list2 = new List<Model.ScenicMap>();
        foreach (Ticket item in list)
        {
            Model.ScenicMap m = new Model.ScenicMap();
            m.id = item.Scenic.Id;
            m.name = item.Scenic.Name;
            m.img = item.Scenic.Photo;
            m.desc = item.Scenic.Desec;
            m.address = item.Scenic.Address;
            m.position = item.Scenic.Position;
            m.level = item.Scenic.Level;
            m.price = new BLLTicketPrice().GetTicketPriceByScenicandtypeid(item.Scenic.Id, 3).Price.ToString("0") + "元";
            m.scseoname = item.Scenic.SeoName;
            m.areaseoname = item.Scenic.Area.SeoName;
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