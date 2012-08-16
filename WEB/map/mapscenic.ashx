<%@ WebHandler Language="C#" Class="mapscenic" %>

using System;
using System.Web;
using BLL;
using Model;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Web.Script.Serialization;
using System.Text;

public class mapscenic : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string pos = context.Request.QueryString["pos"];
        IList<Scenic> list = new BLLScenic().GetScenicByScenicPosition(pos);
        List<Model.ScenicMap> list2 = new List<Model.ScenicMap>();
        foreach (Scenic item in list)
        {
            Model.ScenicMap m = new Model.ScenicMap();
            m.id = item.Id;
            m.level = item.Level;
            m.name = item.Name;
            if (new BLLScenicImg().GetSiByType(item, 1).Count > 0)
                m.img = new BLLScenicImg().GetSiByType(item, 1)[0].Name;
            m.desc = item.Desec;
            m.address = item.Address;
            m.position = item.Position;
            foreach (Ticket t in item.Tickets.Where(x => x.IsMain == true))
            {
                m.price = t.TicketPrice[0].Price.ToString("0") + "元";
            } 
            m.scseoname = item.SeoName;
            m.areaseoname = item.Area.SeoName;
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