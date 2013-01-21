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
        BLLScenicImg bllScenicImg = new BLLScenicImg();
        BLLScenic bllScenic = new BLLScenic();
        BLLArea bllArea=new BLLArea();
        int scid = int.Parse(context.Request.QueryString["scid"]);
        BLLTicketPrice bllTicketPrice = new BLLTicketPrice();
        Scenic scenic = bllScenic.GetScenicById(scid);
        Model.ScenicMap scenicMap = new Model.ScenicMap();
        scenicMap.id = scenic.Id;
        scenicMap.name = scenic.Name;
        var imglist = bllScenicImg.GetSiByType(scenic, 1);
        if (imglist.Count > 0)
        {
            string extention = imglist[0].Name.Split('.')[1];
            scenicMap.img = imglist[0].Name.Split('.')[0] + "_s." + extention;
        }
        scenicMap.desc = scenic.Desec;
        scenicMap.position = scenic.Position;
        scenicMap.address = scenic.Address;
        scenicMap.level = scenic.Level;
        if (scenic.Tickets.Where(x => x.IsMain == true).Count() > 0)
        {
            scenicMap.price = bllTicketPrice.GetTicketPriceByScenicandtypeid(scenic.Tickets.Where(x => x.IsMain == true).ToList()[0], PriceType.PayOnline).ToString() + "元";
        }
        scenicMap.scseoname = scenic.SeoName;
        scenicMap.areaseoname = bllArea.GetAreaByCode(scenic.Area.Code.Substring(0, 4) + "00").SeoName + "_" + scenic.Area.SeoName;
        string JSON = new JavaScriptSerializer().Serialize(scenicMap);//把list转换为JSON格式的字符串
        context.Response.Write(JSON);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}