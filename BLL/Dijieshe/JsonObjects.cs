using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Model;
using DAL;
using Newtonsoft.Json.Linq;
/// <summary>
///sigmagrid xhr请求对象
/// </summary>
namespace BLL
{
    public class SigmaGridRequestObject : DalBase
    {
        public JObject JO { get; set; }
        public SigmaGridRequestObject(Newtonsoft.Json.Linq.JObject jo)
        {
            JO = jo;
        }
        public JArray fieldsName { get; set; }
        public string recordType { get; set; }

        public string action { get; set; }
        public string[][] insertedRecords { get; set; }
        public string[][] updatedRecords { get; set; }
        public string[][] deletedRecords { get; set; }

        BLL.BLLDJTourGroup bllGroup = new BLL.BLLDJTourGroup();
        BLL.BLLDJEnterprise bllEnter = new BLLDJEnterprise();
        BLL.BLLTourGroupMember bllGroupMember = new BLLTourGroupMember();
        DJ_TourGroup group;

        public string Act4Member()
        {
            string returnValue = string.Empty;
            Guid groupId;
            string paramGroupId = (string)JO["parameters"]["groupid"];
            action = (string)JO["action"];
            if (!Guid.TryParse(paramGroupId, out groupId))
            {
                BLL.ErrHandler.Redirect(BLL.ErrType.ParamIllegal);
            }
            group = bllGroup.GetOne(groupId);
            if (action == "save")
            {
                IList<Model.DJ_TourGroupMember> memberList = new List<Model.DJ_TourGroupMember>();
                foreach (JToken ro in (JArray)JO["insertedRecords"])
                {
                    Model.DJ_TourGroupMember member = ConvertToMember(ro);
                    member.DJ_TourGroup = group;
                    group.Members.Add(member);
                    session.Save(member);
                    session.Flush();
                }
                foreach (JToken ro in JO["updatedRecords"])
                {
                    Model.DJ_TourGroupMember member = ConvertToMember(ro);
                    session.Update(member);
                    session.Flush();
                } foreach (JToken ro in JO["deletedRecords"])
                {
                    Model.DJ_TourGroupMember member = ConvertToMember(ro);
                    session.Delete(member);
                    session.Flush();
                }
            }
            if (action == "load")
            {
                // return bll BuildLoadResponse(group.Members);
            }
            return returnValue;
        }

        public string Act4Routes()
        {
            string returnValue = string.Empty;
            Guid groupId;
            string paramGroupId = (string)JO["parameters"]["groupid"];
            action = (string)JO["action"];
            if (!Guid.TryParse(paramGroupId, out groupId))
            {
                BLL.ErrHandler.Redirect(BLL.ErrType.ParamIllegal);
            }
            group = bllGroup.GetOne(groupId);
            if (action == "save")
            {
                IList<Model.DJ_Route> memberList = new List<Model.DJ_Route>();
                string ename = string.Empty;
                foreach (JToken ro in (JArray)JO["insertedRecords"])
                {
                    IList<Model.DJ_Route> routes = ConvertToRoute(ro, out ename);
                    foreach (var item in routes)
                    {
                        if (item.Enterprise == null)
                        {
                            return ename+":该项无法识别!请重新输入!";
                        }
                    }
                    foreach (var item in routes)
                    {
                        session.SaveOrUpdate(item);
                        group.Routes.Add(item);
                    }
                    session.Save(group);
                    session.Flush();
                }
                foreach (JToken ro in JO["updatedRecords"])
                {
                    IList<Model.DJ_Route> routes = ConvertToRoute(ro, out ename);
                    foreach (var item in routes)
                    {
                        if (item.Enterprise == null)
                        {
                            return ename + ":该项无法识别!请重新输入!";
                        }
                    }
                    foreach (var item in group.Routes.Where(x=>x.DayNo==routes[0].DayNo))
                    {
                        session.Delete(item);
                        session.Flush();
                    }
                    foreach (var item in routes)
                    {
                        session.Save(item);
                        session.Flush();
                    }
                }
                foreach (JToken ro in JO["deletedRecords"])
                {
                    IList<Model.DJ_Route> routes = ConvertToRoute(ro, out ename);
                    foreach (var item in routes)
                    {
                        if (item.Enterprise == null)
                        {
                            return ename + ":该项无法识别!请重新输入!";
                        }
                    }
                    foreach (var item in group.Routes.Where(x => x.DayNo == routes[0].DayNo))
                    {
                        session.Delete(item);
                        session.Flush();
                    }
                }
            }
            if (action == "load")
            {
                // return bll BuildLoadResponse(group.Members);
            }
            return returnValue;
        }

        public IList<Model.DJ_Route> ConvertToRoute(JToken t, out string ename)
        {
            ename = string.Empty;
            List<string> ro = new List<string>();
            if (t.GetType() == typeof(JArray))
            {
                JArray ja = (JArray)t;
                foreach (JToken jt in ja)
                {
                    ro.Add(jt.ToString());
                }
            }
            else//jtoken
            {
                for (int i = 0; i <= 2; i++)
                {
                    ro.Add(t[i.ToString()].ToString());
                }
            }
            IList<Model.DJ_Route> routelist = new List<Model.DJ_Route>();
            //景点
            foreach (var item in ro[1].Split(new char[] { '-' },StringSplitOptions.RemoveEmptyEntries))
            {
                var e=bllEnter.GetDJS8name(item);
                if (e.Count > 0)
                {
                    routelist.Add(new DJ_Route()
                    {
                        DayNo = int.Parse(ro[0]),
                        //判断: 如果能找到企业便赋值, 否则null
                        Enterprise = e[0],
                        Description = "景点",
                        DJ_TourGroup = group
                    });
                }
                else
                {
                    ename = item;
                }
            }
            //住宿
            foreach (var item in ro[2].Split(new char[] { '-' },StringSplitOptions.RemoveEmptyEntries))
            {
                var e = bllEnter.GetDJS8name(item);
                if (e.Count > 0)
                {
                    routelist.Add(new DJ_Route()
                    {
                        DayNo = int.Parse(ro[0]),
                        //判断: 如果能找到企业便赋值, 否则null
                        Enterprise = e[0],
                        Description = "住宿",
                        DJ_TourGroup = group
                    });
                }
                else
                {
                    ename = item;
                }
            }
            return routelist;
        }

        public Model.DJ_TourGroupMember ConvertToMember(JToken t)
        {
            List<string> ro = new List<string>();
            if (t.GetType() == typeof(JArray))
            {
                JArray ja = (JArray)t;
                foreach (JToken jt in ja)
                {
                    ro.Add(jt.ToString());
                }
            }
            else//jtoken
            {
                for (int i = 0; i <= 5; i++)
                {
                    ro.Add(t[i.ToString()].ToString());
                }
            }
            Model.DJ_TourGroupMember member = new DJ_TourGroupMember();
            string memberId = ro[5];
            if (!string.IsNullOrEmpty(memberId))
            {
                member = bllGroupMember.GetOne(Guid.Parse(memberId));
            }
            member.IdCardNo = ro[3];
            member.PhoneNum = ro[2];
            member.RealName = ro[1];
            member.SpecialCardNo = ro[4];
            member.MemberType = (MemberType)Enum.Parse(typeof(MemberType), ro[0]);
            return member;
        }
    }




}