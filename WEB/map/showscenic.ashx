<%@ WebHandler Language="C#" Class="qiehuan" %>

using System;
using System.Web;
using BLL;
using Model;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Web.Script.Serialization;
using System.Text;

public class qiehuan : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        IList<Scenic> list = null;
            string scname = HttpUtility.UrlDecode(context.Request.Cookies["scname"].Value, Encoding.GetEncoding("UTF-8"));
            string level = HttpUtility.UrlDecode(context.Request.Cookies["level"].Value, Encoding.GetEncoding("UTF-8"));
            if (level != "全部")
                list = new BLLScenic().GetScenicByScenicName(scname, level,0,HttpUtility.UrlDecode(context.Request.Cookies["topic"].Value, Encoding.GetEncoding("UTF-8")));
            else if (scname != "")
                list = new BLLScenic().GetScenicByScenicName(scname, "", 0, HttpUtility.UrlDecode(context.Request.Cookies["topic"].Value, Encoding.GetEncoding("UTF-8")));
        List<Model.ScenicMap> list2 = new List<Model.ScenicMap>();
        if (list != null)
        {
            foreach (Scenic item in list)
            {
                Model.ScenicMap m = new Model.ScenicMap();
                m.id = item.Id;
                m.name = item.Name;
                if (new BLLScenicImg().GetSiByType(item, 1).Count > 0)
                    m.img = new BLLScenicImg().GetSiByType(item, 1)[0].Name;
                m.desc = item.Desec;
                m.address = item.Address;
                m.position = item.Position;
                m.scseoname = item.SeoName;
                m.areaseoname = item.Area.SeoName;
                list2.Add(m);
            }
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