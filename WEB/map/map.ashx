<%@ WebHandler Language="C#" Class="map" %>

using System;
using System.Web;
using BLL;
using Model;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Web.Script.Serialization;
using System.Text;

public class map : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        BLLScenic bllScenic = new BLLScenic();
        BLLScenicImg bllScenicImg = new BLLScenicImg();
        BLLArea bllArea = new BLLArea();
        context.Response.ContentType = "text/plain";
        IList<ScenicMap> listMap = null;
        int pageindex = 1, areaid = 0;
        if (context.Request.Cookies["strurlareaid"].Value != "" && context.Request.Cookies["strurlareaid"].Value != "1018")
            areaid = int.Parse(context.Request.Cookies["strurlareaid"].Value);
        if (context.Request.Cookies["pageindex"].Value != "")
            pageindex = int.Parse(context.Request.Cookies["pageindex"].Value);
        if (context.Request.QueryString["type"] == "1")
        {
            if (context.Request.Cookies["scname"] != null)
            {
                string scname = HttpUtility.UrlDecode(context.Request.Cookies["scname"].Value, Encoding.GetEncoding("UTF-8"));
                listMap = bllScenic.GetScenicMapByCondition(scname, context.Request.Cookies["level"].Value, areaid, HttpUtility.UrlDecode(HttpUtility.UrlDecode(HttpUtility.UrlDecode(context.Request.Cookies["topic"].Value, Encoding.GetEncoding("UTF-8")), Encoding.GetEncoding("UTF-8")), Encoding.GetEncoding("UTF-8")));
            }
        }
        else
        {
            string scname = HttpUtility.UrlDecode(context.Request.Cookies["scname"].Value, Encoding.GetEncoding("UTF-8"));
            listMap = bllScenic.GetScenicMapByCondition(scname, context.Request.Cookies["level"].Value, areaid, HttpUtility.UrlDecode(HttpUtility.UrlDecode(context.Request.Cookies["topic"].Value, Encoding.GetEncoding("UTF-8")), Encoding.GetEncoding("UTF-8")));
        }
        //List<Model.ScenicMap> list2 = new List<Model.ScenicMap>();
        //Model.ScenicMap m;
        //foreach (Scenic item in list)
        //{
        //    if ((!string.IsNullOrEmpty(item.Position)) && (item.Position != "null") && (item.Position != "undefined"))
        //    {
        //        m = new Model.ScenicMap();
        //        m.id = item.Id;
        //        m.name = item.Name;
        //        //var imglist= bllScenicImg.GetSiByType(item, 1);
        //        //if (imglist.Count > 0)
        //        //{
        //        //    string extention = imglist[0].Name.Split('.')[1];
        //        //    m.img = imglist[0].Name.Split('.')[0] + "_s." + extention;
        //        //}
        //        //m.desc = item.Desec;
        //        //m.address = item.Address;
        //        m.position = item.Position;
        //        //m.level = item.Level;
        //        //if (item.Tickets.Where(x => x.IsMain == true).Count() > 0)
        //        //{
        //        //    m.price=item.Tickets.Where(x => x.IsMain == true).ToList()[0].TicketPrice[0].Price.ToString("0") + "元";
        //        //}
        //        ////string.Format("{0:f2}", new BLL.BLLTicketPrice().GetTicketPriceByScenicId(item.Id)[1].Price);
        //        //m.scseoname = item.SeoName;
        //        //m.areaseoname = bllArea.GetAreaByCode(item.Area.Code.Substring(0, 4) + "00").SeoName + "_" + item.Area.SeoName;
        //        list2.Add(m);
        //    }
        //}

        if (listMap.Count % 15 != 0)
            context.Response.Cookies.Add(new HttpCookie("resultcount", ((listMap.Count / 15) + 1).ToString()));
        else
            context.Response.Cookies.Add(new HttpCookie("resultcount", (listMap.Count / 15).ToString()));
        context.Response.Cookies.Add(new HttpCookie("numcount", listMap.Count.ToString()));
        string JSON = new JavaScriptSerializer().Serialize(listMap);//把list转换为JSON格式的字符串
        context.Response.Write(JSON);
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}