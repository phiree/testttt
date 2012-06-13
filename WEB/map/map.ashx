<%@ WebHandler Language="C#" Class="map" %>

using System;
using System.Web;
using BLL;
using Model;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Web.Script.Serialization;
using System.Text;

public class map : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
         IList<Ticket> list=null;
         int pageindex = 1;
         int areaid = 0;
         if (context.Request.Cookies["strurlareaid"].Value != "" && context.Request.Cookies["strurlareaid"].Value!="1018")
             areaid = int.Parse(context.Request.Cookies["strurlareaid"].Value);
         if (context.Request.Cookies["pageindex"].Value != "")
             pageindex = int.Parse(context.Request.Cookies["pageindex"].Value);
        if (context.Request.QueryString["type"] == "1")
        {
            if (context.Request.Cookies["scname"] != null)
            {
                string scname = HttpUtility.UrlDecode(context.Request.Cookies["scname"].Value, Encoding.GetEncoding("UTF-8"));
                list = new BLLScenic().GetScenicByScenicName(scname, context.Request.Cookies["level"].Value, areaid);
            }
            else
            {
                //list = new BLLScenic().GetScenic();
            }
        }
        else
        {
            string scname = HttpUtility.UrlDecode(context.Request.Cookies["scname"].Value, Encoding.GetEncoding("UTF-8"));
            //string level = HttpUtility.UrlDecode(context.Request.Cookies["level"].Value, Encoding.GetEncoding("UTF-8"));
            //if(level!="全部")
            //    list = new BLLScenic().GetScenicByScenicName(scname,level);
            //else if(scname!="")
            list = new BLLScenic().GetScenicByScenicName(scname, context.Request.Cookies["level"].Value, areaid);
        }
        List<Model.ScenicMap> list2 = new List<Model.ScenicMap>();
        context.Response.Cookies.Add(new HttpCookie("numcount",list.Count.ToString()));
        if (list.Count%15!=0)
            context.Response.Cookies.Add(new HttpCookie("resultcount",((list.Count/15)+1).ToString()));
        else
            context.Response.Cookies.Add(new HttpCookie("resultcount", (list.Count/15).ToString()));
        //if (list.Count <= 15)
        //{
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
                        //string.Format("{0:f2}", new BLL.BLLTicketPrice().GetTicketPriceByScenicId(item.Id)[1].Price);
                m.scseoname = item.Scenic.SeoName;
                m.areaseoname = item.Scenic.Area.SeoName;
                list2.Add(m);
            }
        //}
        //else
        //{
        //    for (int i = 0; i < 15; i++)
        //    {
        //        if ((pageindex - 1) * 15 + i < list.Count)
        //        {
        //            Model.map m = new Model.map();
        //            m.id = list[(pageindex - 1) * 15 + i].Scenic.Id;
        //            m.name = list[(pageindex - 1) * 15 + i].Scenic.Name;
        //            m.img = list[(pageindex - 1) * 15 + i].Scenic.Photo;
        //            m.desc = list[(pageindex - 1) * 15 + i].Scenic.Desec;
        //            m.address = list[(pageindex - 1) * 15 + i].Scenic.Address;
        //            m.position = list[(pageindex - 1) * 15 + i].Scenic.Position;
        //            m.level = list[(pageindex - 1) * 15 + i].Scenic.Level;
        //            m.price = new BLLTicketPrice().GetTicketPriceByScenicandtypeid(list[(pageindex - 1) * 15 + i].Scenic.Id, 3).Price.ToString("0") + "元";
        //            list2.Add(m);
        //        }
        //    }
        //}
        string JSON = new JavaScriptSerializer().Serialize(list2);//把list转换为JSON格式的字符串
        context.Response.Write(JSON);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}