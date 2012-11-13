using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExcelOplib.Entity;
using Model;

public partial class Admin_Initial : System.Web.UI.Page
{
    BLL.BLLArea bllarea = new BLL.BLLArea();
    BLL.BLLDJ_GovManageDepartment bllgov = new BLL.BLLDJ_GovManageDepartment();
    BLL.BLLDJEnterprise blldjs = new BLL.BLLDJEnterprise();
    BLL.BLLScenic bllscenic = new BLL.BLLScenic();
    BLL.BLLDJ_User blldjuser = new BLL.BLLDJ_User();
    BLL.BLLMembership bllmem = new BLL.BLLMembership();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnInitial_Click(object sender, EventArgs e)
    {
        ExcelOplib.ExcelDjsOpr djsopr = new ExcelOplib.ExcelDjsOpr();
        IList<ExcelOplib.Entity.DJSEntity> enlist = djsopr.getDJSlist();
        IList<Enter_excel> templist = new List<Enter_excel>();

        //初始化管理部门
        IList<Model.DJ_GovManageDepartment> govDic = new List<Model.DJ_GovManageDepartment>();
        foreach (var item in enlist.Where(x => x.EnterpType == 数据类型.管理部门))
        {
            govDic.Add(new Model.DJ_GovManageDepartment()
            {
                Name = item.Department1,
                Area = bllarea.GetAraByAreaname(item.Diqu),
                seoname = item.Seoname
            });
        }
        foreach (var item in govDic)
        {
            if (bllgov.GetGovDptByName(item.Name).Count == 0)
            {
                bllgov.Save(item);
            }
            Model.DJ_User_Gov user_gov = new Model.DJ_User_Gov();
            if (blldjuser.GetGov_UserByName(item.seoname) == null)
            {
                user_gov.Name = item.seoname;
                user_gov.Password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(item.seoname, "MD5"); ;
                user_gov.GovDpt = bllgov.GetGovDptByName(item.Name)[0];
                user_gov.PermissionType = Model.PermissionType.报表查看员 | Model.PermissionType.团队录入员
                    | Model.PermissionType.信息编辑员 | Model.PermissionType.用户管理员;
                blldjuser.SaveOrUpdate(user_gov);
            }
        }


        //初始化地接社,景区,宾馆
        foreach (var item in enlist)
        {
            if (!string.IsNullOrEmpty(item.Department3))
            {
                string[] results = item.Department3.Split(new string[] { ",", "，" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var item2 in results)
                {
                    templist.Add(new Enter_excel()
                    {
                        name = item2,
                        area = item.Diqu,
                        type = item.EnterpType.ToString(),
                        seoname = item.Seoname
                    });
                }
            }
        }

        foreach (var item in templist)
        {
            var area = bllarea.GetAraByAreaname(item.area);
            switch (item.type)
            {
                case "地接社":
                    var temp_djs = blldjs.GetDJS8Muti(area.Id, Model.EnterpriseType.旅行社.ToString(), null, item.name);
                    if (temp_djs.Count == 0)
                    {
                        blldjs.AddDjs(item.name, string.Empty, area, "", "", "", "", "", item.seoname);
                    }
                    break;
                case "景区":
                    var temp_scenic = blldjs.GetDJS8Muti(area.Id, Model.EnterpriseType.景点.ToString(), null, item.name);
                    if (temp_scenic.Count == 0)
                    {
                        bllscenic.Save(new Model.Scenic()
                        {
                            Name = item.name,
                            Area = area,
                            SeoName = item.seoname,
                            Type = Model.EnterpriseType.景点
                        });
                    }
                    break;
                case "宾馆":
                    var temp_hotel = blldjs.GetDJS8Muti(area.Id, Model.EnterpriseType.宾馆.ToString(), null, item.name);
                    if (temp_hotel.Count == 0)
                    {
                        blldjs.Save(new Model.DJ_TourEnterprise()
                        {
                            Name = item.name,
                            Area = area,
                            SeoName = item.seoname,
                            Type = Model.EnterpriseType.宾馆
                        });
                    }
                    break;
            }
            var mem = bllmem.GetMember(item.seoname);   
            if (mem != null)
            {
                var memEnterp = (Model.DJ_User_TourEnterprise)mem;
                memEnterp.Enterprise = blldjs.GetDJS8name(item.name).First();
                bllmem.CreateUpdateMember(memEnterp);
            }
            else
            {
                bllmem.CreateUpdateMember(new Model.DJ_User_TourEnterprise()
                {
                    Enterprise = blldjs.GetDJS8name(item.name).First(),
                    Name = item.seoname,
                    PermissionType = PermissionType.报表查看员 | PermissionType.团队录入员 | PermissionType.信息编辑员 | PermissionType.用户管理员,
                    Password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(item.seoname, "MD5")
                });
            }
        }
    }
}

public class Enter_excel
{
    public string name { get; set; }
    public string area { get; set; }
    public string type { get; set; }
    public string seoname { get; set; }
}