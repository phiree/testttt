<%@ WebHandler Language="C#" Class="SearchBigMap" %>

using System;
using System.Web;
using BLL;
using Model;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Web.Script.Serialization;
using System.Text;

public class SearchBigMap : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        BLLTicket bllticket=new BLLTicket();
        BLLScenicImg bllscenicimg = new BLLScenicImg();
        BLLScenic bllscenic = new BLLScenic();
        context.Response.ContentType = "text/plain";
        string scenicid = context.Request.QueryString["scenicid"];
        string[] scids = scenicid.Split(',');
        List<Model.ScenicMap> list = new List<Model.ScenicMap>();
        foreach (string scid in scids)
        {
            ScenicMap m = new ScenicMap();
            Scenic scenic = bllscenic.GetScenicById(int.Parse(scid));
            ScenicImg si= bllscenicimg.GetSiByType(scenic, 1)[0];
            m.address = si.Scenic.Address;
            m.desc = si.Scenic.Desec;
            m.id = si.Scenic.Id;
            m.img = si.Name;
            m.level = si.Scenic.Level;
            m.name = si.Scenic.Name;
            m.position = si.Scenic.Position;
            foreach (Ticket item in si.Scenic.Tickets.Where(x=>x.IsMain==true))
            {
                m.price=item.TicketPrice[0].Price.ToString("0") + "元";
            }
            //m.price = new BLLTicketPrice().GetTicketPriceByScenicandtypeid(scenic.Id, 3).Price.ToString("0") + "元";
            m.scseoname = si.Scenic.SeoName;
            m.areaseoname = new BLL.BLLArea().GetAreaByCode(si.Scenic.Area.Code.Substring(0, 4) + "00").SeoName + "_" + si.Scenic.Area.SeoName;
            list.Add(m);
        }
        string JSON = new JavaScriptSerializer().Serialize(list);//把list转换为JSON格式的字符串
        context.Response.Write(JSON);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}