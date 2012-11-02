using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExcelOplib.Entity;

public partial class Admin_Initial : System.Web.UI.Page
{
    BLL.BLLArea bllarea = new BLL.BLLArea();
    BLL.BLLDJ_GovManageDepartment bllgov = new BLL.BLLDJ_GovManageDepartment();
    BLL.BLLDJEnterprise blldjs = new BLL.BLLDJEnterprise();
    BLL.BLLScenic bllscenic = new BLL.BLLScenic();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnInitial_Click(object sender, EventArgs e)
    {
        ExcelOplib.ExcelDjsOpr djsopr = new ExcelOplib.ExcelDjsOpr();
        IList<ExcelOplib.Entity.DJSEntity> enlist=djsopr.getDJSlist();
        IList<Enter_excel> templist = new List<Enter_excel>();

        //初始化管理部门
        IList<Model.DJ_GovManageDepartment> govDic = new List<Model.DJ_GovManageDepartment>();
        foreach (var item in enlist)
        {
            if (govDic.Where(x => x.Name == item.Department2).Count() == 0)
            {
                govDic.Add(new Model.DJ_GovManageDepartment() { 
                    Name=item.Department2,
                    Area=bllarea.GetAraByAreaname(item.Department3)
                });
            }
        }
        foreach (var item in govDic)
        {
            if (bllgov.GetGovDptByName(item.Name).Count!=0)
            {
                bllgov.Save(item);
            }
        }

        //初始化地接社,景区,宾馆
        foreach (var item in enlist)
        {
            if (!string.IsNullOrEmpty(item.Department3))
            {
                string[] results = item.Department3.Split(new string[] { "," ,"，"},StringSplitOptions.RemoveEmptyEntries);
                foreach (var item2 in results)
                {
                    templist.Add(new Enter_excel() { 
                        name=item2,
                        area=item.Diqu,
                        type=item.EnterpType.ToString()
                    });
                }
            }
        }

        foreach (var item in templist)
        {
            var area=bllarea.GetAraByAreaname(item.area);
            switch (item.type)
            { 
                case "地接社":
                    var temp_djs=blldjs.GetDJS8Muti(area.Id,Model.EnterpriseType.旅行社.ToString(),null,item.name);
                    if (temp_djs.Count == 0)
                    {
                        blldjs.AddDjs(item.name, string.Empty,area , "", "", "");
                    }
                    else
                    {
                        //不用[更新]
                        //var temp=temp_djs.First();
                        //temp.
                        //blldjs.UpdateDjs(temp);
                    }
                    break;
                case "景区":
                    var temp_scenic=blldjs.GetDJS8Muti(area.Id,Model.EnterpriseType.景点.ToString(),null,item.name);
                    if (temp_scenic.Count == 0)
                    {
                        bllscenic.Save(new Model.Scenic(){
                            Name=item.name,
                            Area=area
                        });
                    }
                    break;
                case "宾馆":
                    var temp_hotel=blldjs.GetDJS8Muti(area.Id,Model.EnterpriseType.宾馆.ToString(),null,item.name);
                    if (temp_hotel.Count == 0)
                    {
                        blldjs.Save(new Model.DJ_TourEnterprise() { 
                            Name=item.name,
                            Area=area,
                            Type = Model.EnterpriseType.宾馆
                        });
                    }
                    break;
            }
        }
    }
}

public class Enter_excel {
    public string name { get; set; }
    public string area { get; set; }
    public string type { get; set; }
}