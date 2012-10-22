<%@ WebHandler Language="C#" Class="GroupHandler" %>

using System;
using System.Web;
using System.Linq;

public class GroupHandler : IHttpHandler
{
    BLL.BLLDJEnterprise bllenter = new BLL.BLLDJEnterprise();

    public void ProcessRequest(HttpContext context)
    {
        IDAL.IDJEnterprise djEnterprice = new DAL.DALDJEnterprise();

        System.Web.Script.Serialization.JavaScriptSerializer json
            = new System.Web.Script.Serialization.JavaScriptSerializer();
        ExcelOplib.Entity.GroupAll ga = json.Deserialize<ExcelOplib.Entity.GroupAll>(context.Request.Form[0]);
        Model.DJ_TourGroup tg = new Model.DJ_TourGroup();

        //基本信息
        tg.Name = ga.GroupBasic.Name;
        tg.DJ_DijiesheInfo = ga.DjsId != 0 ? bllenter.GetDJS8id(ga.DjsId.ToString())[0] as Model.DJ_DijiesheInfo : null;
        tg.BeginDate = DateTime.Parse(ga.GroupBasic.Begindate);
        tg.EndDate = DateTime.Parse(ga.GroupBasic.Enddate);
        tg.DaysAmount = int.Parse(ga.GroupBasic.Days);
        tg.AdultsAmount = int.Parse(ga.GroupBasic.PeopleAdult);
        tg.ChildrenAmount = int.Parse(ga.GroupBasic.PeopleChild);
        tg.Gether = ga.GroupBasic.StartPlace;
        tg.BackPlace = ga.GroupBasic.EndPlace;
        tg.No = ga.GroupBasic.GroupNo;

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
                    Description = "早餐",
                    Enterprise = bllDJS.GetDJS8name(item.Breakfast)[0]
                });
            }
            if (!string.IsNullOrWhiteSpace(item.Lunch))
            {
                routes.Add(new Model.DJ_Route()
                {
                    DayNo = i,
                    DJ_TourGroup = tg,
                    Description = "中餐",
                    Enterprise = bllDJS.GetDJS8name(item.Lunch)[0]
                });
            }
            if (!string.IsNullOrWhiteSpace(item.Dinner))
            {
                routes.Add(new Model.DJ_Route()
                {
                    DayNo = i,
                    DJ_TourGroup = tg,
                    Description = "晚餐",
                    Enterprise = bllDJS.GetDJS8name(item.Dinner)[0]
                });
            }
            if (!string.IsNullOrWhiteSpace(item.Hotel1))
            {
                routes.Add(new Model.DJ_Route()
                {
                    DayNo = i,
                    DJ_TourGroup = tg,
                    Description = "住宿1",
                    Enterprise = bllDJS.GetDJS8name(item.Hotel1)[0]
                });
            }
            if (!string.IsNullOrWhiteSpace(item.Hotel2))
            {
                routes.Add(new Model.DJ_Route()
                {
                    DayNo = i,
                    DJ_TourGroup = tg,
                    Description = "住宿2",
                    Enterprise = bllDJS.GetDJS8name(item.Hotel2)[0]
                });
            }
            if (!string.IsNullOrWhiteSpace(item.Scenic1))
            {
                routes.Add(new Model.DJ_Route()
                {
                    DayNo = i,
                    DJ_TourGroup = tg,
                    Description = "景点1",
                    Enterprise = bllDJS.GetDJS8name(item.Scenic1)[0]
                });
            }
            if (!string.IsNullOrWhiteSpace(item.Scenic2))
            {
                routes.Add(new Model.DJ_Route()
                {
                    DayNo = i,
                    DJ_TourGroup = tg,
                    Description = "景点2",
                    Enterprise = bllDJS.GetDJS8name(item.Scenic2)[0]
                });
            }
            if (!string.IsNullOrWhiteSpace(item.Scenic3))
            {
                routes.Add(new Model.DJ_Route()
                {
                    DayNo = i,
                    DJ_TourGroup = tg,
                    Description = "景点3",
                    Enterprise = bllDJS.GetDJS8name(item.Scenic3)[0]
                });
            }
            if (!string.IsNullOrWhiteSpace(item.Scenic4))
            {
                routes.Add(new Model.DJ_Route()
                {
                    DayNo = i,
                    DJ_TourGroup = tg,
                    Description = "景点4",
                    Enterprise = bllDJS.GetDJS8name(item.Scenic4)[0]
                });
            }
            if (!string.IsNullOrWhiteSpace(item.Scenic5))
            {
                routes.Add(new Model.DJ_Route()
                {
                    DayNo = i,
                    DJ_TourGroup = tg,
                    Description = "景点5",
                    Enterprise = bllDJS.GetDJS8name(item.Scenic5)[0]
                });
            }
            if (!string.IsNullOrWhiteSpace(item.Scenic6))
            {
                routes.Add(new Model.DJ_Route()
                {
                    DayNo = i,
                    DJ_TourGroup = tg,
                    Description = "景点6",
                    Enterprise = bllDJS.GetDJS8name(item.Scenic6)[0]
                });
            }
            if (!string.IsNullOrWhiteSpace(item.Scenic7))
            {
                routes.Add(new Model.DJ_Route()
                {
                    DayNo = i,
                    DJ_TourGroup = tg,
                    Description = "景点7",
                    Enterprise = bllDJS.GetDJS8name(item.Scenic7)[0]
                });
            }
            if (!string.IsNullOrWhiteSpace(item.Scenic8))
            {
                routes.Add(new Model.DJ_Route()
                {
                    DayNo = i,
                    DJ_TourGroup = tg,
                    Description = "景点8",
                    Enterprise = bllDJS.GetDJS8name(item.Scenic8)[0]
                });
            }
            if (!string.IsNullOrWhiteSpace(item.Scenic9))
            {
                routes.Add(new Model.DJ_Route()
                {
                    DayNo = i,
                    DJ_TourGroup = tg,
                    Description = "景点9",
                    Enterprise = bllDJS.GetDJS8name(item.Scenic9)[0]
                });
            }
            if (!string.IsNullOrWhiteSpace(item.Scenic10))
            {
                routes.Add(new Model.DJ_Route()
                {
                    DayNo = i,
                    DJ_TourGroup = tg,
                    Description = "景点10",
                    Enterprise = bllDJS.GetDJS8name(item.Scenic10)[0]
                });
            }
            if (!string.IsNullOrWhiteSpace(item.ShoppingPoint1))
            {
                routes.Add(new Model.DJ_Route()
                {
                    DayNo = i,
                    DJ_TourGroup = tg,
                    Description = "购物点1",
                    Enterprise = bllDJS.GetDJS8name(item.ShoppingPoint1)[0]
                });
            }
            if (!string.IsNullOrWhiteSpace(item.ShoppingPoint2))
            {
                routes.Add(new Model.DJ_Route()
                {
                    DayNo = i,
                    DJ_TourGroup = tg,
                    Description = "购物点2",
                    Enterprise = bllDJS.GetDJS8name(item.ShoppingPoint2)[0]
                });
            }
            if (!string.IsNullOrWhiteSpace(item.ShoppingPoint3))
            {
                routes.Add(new Model.DJ_Route()
                {
                    DayNo = i,
                    DJ_TourGroup = tg,
                    Description = "购物点3",
                    Enterprise = bllDJS.GetDJS8name(item.ShoppingPoint3)[0]
                });
            }
            i++;
        }
        tg.Routes = routes;

        //汇总信息
        string result=djEnterprice.AddGroup(tg);
        context.Response.Write(result);
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}