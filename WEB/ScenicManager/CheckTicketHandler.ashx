<%@ WebHandler Language="C#" Class="CheckTicketHandler" %>

using System;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using Model;
using BLL;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Json;
public class CheckTicketHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "application/json";

        string term = context.Request["term"];
        string sid = context.Request["sid"];
        
        List<string> test=new List<string>();
        test.Add("12345");
        test.Add("34567");
        Dictionary<string, string> dic = GetList(term, sid);
        string jsonNames = CommonLibrary.JosnHelper.GetJson<Dictionary<string,string>>(dic);

        context.Response.Write(jsonNames);
    }



    private  Dictionary<string,string> GetList(string term,string scid)
    {
        Scenic s = new BLLScenic().GetScenicById(int.Parse(scid));
        List<TicketAssign> list = new BLLTicketAssign().GetIdcardandname(term,term, s,false);
        //再这里要加上当天会来此景点的导游信息,并把它包装成为TicketAssign
        IList<DJ_Workers> listdjGW = new BLLDJTourGroup().GetTourGroupByTeId(s.Id);
        foreach (DJ_Workers gw in listdjGW)
        {
            //排除以后的人员信息
            if (list.Where(x => x.IdCard == gw.IDCard).Count() == 0)
            {
                TicketAssign ta = new TicketAssign();
                ta.Name = gw.Name;
                ta.IdCard = gw.IDCard;
                list.Add(ta);
            }
        }
        Dictionary<string, string> data = new Dictionary<string, string>();
        foreach (TicketAssign item in list)
        {
            //这里的key是真实身份证号，val是带*身份证号
            data.Add(item.Name + "/" + item.IdCard, item.Name + "/" + item.IdCard.Substring(0, 6) + "********" + item.IdCard.Substring(14));
        }
        return data;
    }
    public bool IsReusable {
        get {
            return false;
        }
    }
    
    

}