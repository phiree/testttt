﻿<%@ WebHandler Language="C#" Class="GroupHandler" %>

using System;
using System.Web;
using System.Linq;

public class GroupHandler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        IDAL.IDJEnterprise djEnterprice = new DAL.DALDJEnterprise();

        System.Web.Script.Serialization.JavaScriptSerializer json
            = new System.Web.Script.Serialization.JavaScriptSerializer();
        ExcelOplib.Entity.GroupAll ga = json.Deserialize<ExcelOplib.Entity.GroupAll>(context.Request.Form[0]);
        Model.DJ_TourGroup tg = new Model.DJ_TourGroup();

        //基本信息
        tg.Name = ga.GroupBasic.Name;
        tg.BeginDate = DateTime.Parse(ga.GroupBasic.Begindate);
        tg.EndDate = DateTime.Parse(ga.GroupBasic.Enddate);
        tg.DaysAmount = int.Parse(ga.GroupBasic.Days);
        tg.AdultsAmount = int.Parse(ga.GroupBasic.PeopleAdult);
        tg.ChildrenAmount = int.Parse(ga.GroupBasic.PeopleChild);

        //人员信息
        var tgmlist = new System.Collections.Generic.List<Model.DJ_TourGroupMember>();
        foreach (var item in ga.GroupMemberList.Where(x => x.Memtype == "成人游客"))
        {
            tgmlist.Add(new Model.DJ_TourGroupMember()
            {
                RealName = item.Memname,
                IdCardNo = item.Memid,
                PhoneNum = item.Memphone,
                IsChild = false
            });
        }
        foreach (var item in ga.GroupMemberList.Where(x => x.Memtype == "儿童游客"))
        {
            tgmlist.Add(new Model.DJ_TourGroupMember()
            {
                RealName = item.Memname,
                IdCardNo = item.Memid,
                PhoneNum = item.Memphone,
                IsChild = true,
                Keeper = item.Cardno
            });
        }
        tg.Members = tgmlist;

        //司机信息//导游信息
        var workerlist = new System.Collections.Generic.List<Model.DJ_Group_Worker>();
        foreach (var item in ga.GroupMemberList.Where(x => x.Memtype == "司机"))
        {
            workerlist.Add(new Model.DJ_Group_Worker()
            {
                IDCard = item.Memid,
                Name = item.Memname,
                Phone = item.Memphone,
                SpecificIdCard = item.Cardno,
                WorkerType = Model.DJ_GroupWorkerType.司机,
                DJ_TourGroup = tg
            });
        }
        foreach (var item in ga.GroupMemberList.Where(x => x.Memtype == "导游"))
        {
            workerlist.Add(new Model.DJ_Group_Worker()
            {
                IDCard = item.Memid,
                Name = item.Memname,
                Phone = item.Memphone,
                SpecificIdCard = item.Cardno,
                WorkerType = Model.DJ_GroupWorkerType.导游,
                DJ_TourGroup = tg
            });
        }
        tg.Workers = workerlist;

        //行程信息
        var routes = new System.Collections.Generic.List<Model.DJ_Route>();
        BLL.BLLDJEnterprise bllDJS = new BLL.BLLDJEnterprise();
        int i = 1;
        foreach (var item in ga.GroupRouteList)
        {
            if (!string.IsNullOrWhiteSpace(item.Breakfast))
            {
                routes.Add(new Model.DJ_Route()
                {
                    DayNo = i,
                    DJ_TourGroup = tg,
                    Behavior = "饭店",
                    Enterprise = bllDJS.GetDJS8name(item.Breakfast)[0]
                });
            }
            if (!string.IsNullOrWhiteSpace(item.Lunch))
            {
                routes.Add(new Model.DJ_Route()
                {
                    DayNo = i,
                    DJ_TourGroup = tg,
                    Behavior = "饭店",
                    Enterprise = bllDJS.GetDJS8name(item.Lunch)[0]
                });
            }
            if (!string.IsNullOrWhiteSpace(item.Dinner))
            {
                routes.Add(new Model.DJ_Route()
                {
                    DayNo = i,
                    DJ_TourGroup = tg,
                    Behavior = "饭店",
                    Enterprise = bllDJS.GetDJS8name(item.Dinner)[0]
                });
            }
            if (!string.IsNullOrWhiteSpace(item.Hotel1))
            {
                routes.Add(new Model.DJ_Route()
                {
                    DayNo = i,
                    DJ_TourGroup = tg,
                    Behavior = "住宿",
                    Enterprise = bllDJS.GetDJS8name(item.Hotel1)[0]
                });
            }
            if (!string.IsNullOrWhiteSpace(item.Hotel2))
            {
                routes.Add(new Model.DJ_Route()
                {
                    DayNo = i,
                    DJ_TourGroup = tg,
                    Behavior = "住宿",
                    Enterprise = bllDJS.GetDJS8name(item.Hotel2)[0]
                });
            }
            if (!string.IsNullOrWhiteSpace(item.Scenic1))
            {
                routes.Add(new Model.DJ_Route()
                {
                    DayNo = i,
                    DJ_TourGroup = tg,
                    Behavior = "景点",
                    Enterprise = bllDJS.GetDJS8name(item.Scenic1)[0]
                });
            }
            if (!string.IsNullOrWhiteSpace(item.Scenic2))
            {
                routes.Add(new Model.DJ_Route()
                {
                    DayNo = i,
                    DJ_TourGroup = tg,
                    Behavior = "景点",
                    Enterprise = bllDJS.GetDJS8name(item.Scenic2)[0]
                });
            }
            if (!string.IsNullOrWhiteSpace(item.Scenic3))
            {
                routes.Add(new Model.DJ_Route()
                {
                    DayNo = i,
                    DJ_TourGroup = tg,
                    Behavior = "景点",
                    Enterprise = bllDJS.GetDJS8name(item.Scenic3)[0]
                });
            }
            if (!string.IsNullOrWhiteSpace(item.Scenic4))
            {
                routes.Add(new Model.DJ_Route()
                {
                    DayNo = i,
                    DJ_TourGroup = tg,
                    Behavior = "景点",
                    Enterprise = bllDJS.GetDJS8name(item.Scenic4)[0]
                });
            }
            if (!string.IsNullOrWhiteSpace(item.Scenic5))
            {
                routes.Add(new Model.DJ_Route()
                {
                    DayNo = i,
                    DJ_TourGroup = tg,
                    Behavior = "景点",
                    Enterprise = bllDJS.GetDJS8name(item.Scenic5)[0]
                });
            }
            if (!string.IsNullOrWhiteSpace(item.ShoppingPoint1))
            {
                routes.Add(new Model.DJ_Route()
                {
                    DayNo = i,
                    DJ_TourGroup = tg,
                    Behavior = "购物",
                    Enterprise = bllDJS.GetDJS8name(item.ShoppingPoint1)[0]
                });
            }
            if (!string.IsNullOrWhiteSpace(item.ShoppingPoint2))
            {
                routes.Add(new Model.DJ_Route()
                {
                    DayNo = i,
                    DJ_TourGroup = tg,
                    Behavior = "购物",
                    Enterprise = bllDJS.GetDJS8name(item.ShoppingPoint2)[0]
                });
            }
            if (!string.IsNullOrWhiteSpace(item.ShoppingPoint3))
            {
                routes.Add(new Model.DJ_Route()
                {
                    DayNo = i,
                    DJ_TourGroup = tg,
                    Behavior = "购物",
                    Enterprise = bllDJS.GetDJS8name(item.ShoppingPoint3)[0]
                });
            }
            if (!string.IsNullOrWhiteSpace(item.ShoppingPoint4))
            {
                routes.Add(new Model.DJ_Route()
                {
                    DayNo = i,
                    DJ_TourGroup = tg,
                    Behavior = "购物",
                    Enterprise = bllDJS.GetDJS8name(item.ShoppingPoint4)[0]
                });
            }
            if (!string.IsNullOrWhiteSpace(item.ShoppingPoint5))
            {
                routes.Add(new Model.DJ_Route()
                {
                    DayNo = i,
                    DJ_TourGroup = tg,
                    Behavior = "购物",
                    Enterprise = bllDJS.GetDJS8name(item.ShoppingPoint5)[0]
                });
            }
            i++;
        }
        tg.Routes = routes;
        
        //汇总信息
        djEnterprice.AddGroup(tg);
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}