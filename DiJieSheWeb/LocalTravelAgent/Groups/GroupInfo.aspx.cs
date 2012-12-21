using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Groups_GroupInfo : basepageDJS
{
    private string excelPath = "d:/";
    public string DJSId;
    public BLL.BLLDJEnterprise bllenterp = new BLL.BLLDJEnterprise();
    public BLL.BLLDJTourGroup bllgroup = new BLL.BLLDJTourGroup();
    public BLL.BLLWorker bllworker = new BLL.BLLWorker();
    ExcelOplib.ExcelGroupOpr excel = new ExcelOplib.ExcelGroupOpr();
    Model.DJ_TourGroup group_model = new Model.DJ_TourGroup();

    protected void Page_Load(object sender, EventArgs e)
    {
        DJSId = CurrentDJS.Id.ToString();
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        string fullname = FileUpload1.FileName.ToString();//直接取得文件名
        string url = FileUpload1.PostedFile.FileName.ToString();//取得上传文件路径
        string typ = FileUpload1.PostedFile.ContentType.ToString();//获取文件MIME内容类型
        string typ2 = fullname.Substring(fullname.LastIndexOf(".") + 1);//后缀名, 不带".".
        int size = FileUpload1.PostedFile.ContentLength;
        string message = string.Empty;

        #region 保存
        if (typ2 == "xlsx" || typ2 == "xls" || typ2 == "xlsm")
        {
            if (size <= 4134904)
            {
                FileUpload1.SaveAs(excelPath + "temp." + typ2);
                ExcelOplib.Entity.GroupAll group_excel = excel.getGroup(excelPath + "temp." + typ2, out message);
                group_excel.GroupMemberList = group_excel.GroupMemberList.Where(x => !string.IsNullOrEmpty(x.Memtype)).ToList();

                #region group modify
                //group修改
                if (!string.IsNullOrEmpty(Request.QueryString["groupid"]))
                {
                    var group_db = bllgroup.GetOne(new Guid(Request.QueryString[0]));
                    group_db.Name = group_excel.GroupBasic.Name;
                    group_db.BeginDate = DateTime.Parse(group_excel.GroupBasic.Begindate);
                    group_db.DaysAmount = int.Parse(group_excel.GroupBasic.Days);
                    group_db.EndDate = DateTime.Parse(group_excel.GroupBasic.Begindate).AddDays(int.Parse(group_excel.GroupBasic.Days));
                    //group_db.Workers.Clear();

                    group_db.Members.Clear();
                    group_db.Routes.Clear();
                    group_model.DijiesheEditor = (Model.DJ_User_TourEnterprise)CurrentMember;
                    foreach (var item in group_excel.GroupMemberList.Where(x => x.Memtype == "导游" || x.Memtype == "司机"))
                    {
                        group_db.Workers.Add(new Model.DJ_Group_Worker()
                        {
                            DJ_TourGroup = group_db,
                            DJ_Workers = new Model.DJ_Workers()
                            {
                                IDCard = item.Memid,
                                SpecificIdCard = item.Cardno,
                                WorkerType = (Model.DJ_GroupWorkerType)Enum.Parse(typeof(Model.DJ_GroupWorkerType), item.Memtype),
                                Phone = item.Memphone,
                                Name = item.Memname
                            }
                        });
                    }
                    foreach (var item in group_excel.GroupMemberList.Where(x => x.Memtype != "导游" && x.Memtype != "司机"))
                    {
                        group_db.Members.Add(new Model.DJ_TourGroupMember()
                        {
                            DJ_TourGroup = group_db,
                            IdCardNo = item.Memid,
                            SpecialCardNo = item.Cardno,
                            MemberType = (Model.MemberType)Enum.Parse(typeof(Model.MemberType), item.Memtype),
                            PhoneNum = item.Memphone,
                            RealName = item.Memname
                        });
                    }
                    foreach (var item in group_excel.GroupRouteList)
                    {
                        var temp1 = item.Scenic.Split(new char[] { ',', '-' });
                        var temp2 = item.Scenic.Split(new char[] { ',', '-' });
                        foreach (var item2 in temp1)
                        {
                            group_db.Routes.Add(new Model.DJ_Route()
                            {
                                DJ_TourGroup = group_db,
                                DayNo = int.Parse(item.RouteDate),
                                Enterprise = bllenterp.GetDJS8name(item2).Count > 0 ? bllenterp.GetDJS8name(item2).First() : null
                            });
                        }
                    }
                    bllgroup.Save(group_db);
                }
                #endregion
                #region group new
                else
                {
                    group_model.Name = group_excel.GroupBasic.Name;
                    group_model.BeginDate = DateTime.Parse(group_excel.GroupBasic.Begindate);
                    group_model.DaysAmount = int.Parse(group_excel.GroupBasic.Days);
                    group_model.EndDate = DateTime.Parse(group_excel.GroupBasic.Begindate).AddDays(int.Parse(group_excel.GroupBasic.Days));
                    group_model.Workers = new List<Model.DJ_Group_Worker>();
                    group_model.Members = new List<Model.DJ_TourGroupMember>();
                    group_model.Routes = new List<Model.DJ_Route>();
                    group_model.DJ_DijiesheInfo = CurrentDJS;
                    group_model.DijiesheEditor = (Model.DJ_User_TourEnterprise)CurrentMember;
                    foreach (var item in group_excel.GroupMemberList.Where(x => x.Memtype == "导游" || x.Memtype == "司机"))
                    {
                        //是否已经存在该worker
                        var worker = bllworker.GetWorkers8Multi(null, item.Memname, null, null, null,
                            Enum.Parse(typeof(Model.DJ_GroupWorkerType), item.Memtype), CurrentDJS.Id.ToString());
                        //不存在，添加
                        if (worker.Count == 0)
                        {
                            var new_worker = new Model.DJ_Workers()
                                {
                                    IDCard = item.Memid,
                                    SpecificIdCard = item.Cardno,
                                    WorkerType = (Model.DJ_GroupWorkerType)Enum.Parse(typeof(Model.DJ_GroupWorkerType), item.Memtype),
                                    Phone = item.Memphone,
                                    Name = item.Memname,
                                    DJ_Dijiesheinfo=CurrentDJS
                                };
                            bllworker.Save(new_worker);
                            group_model.Workers.Add(new Model.DJ_Group_Worker()
                            {
                                DJ_TourGroup = group_model,
                                DJ_Workers = new_worker
                            });
                        }
                        //存在
                        else
                        {
                            group_model.Workers.Add(new Model.DJ_Group_Worker()
                            {
                                DJ_TourGroup = group_model,
                                DJ_Workers = worker.First()
                            });
                        }
                    }
                    foreach (var item in group_excel.GroupMemberList.Where(x => x.Memtype != "导游" && x.Memtype != "司机"))
                    {
                        group_model.Members.Add(new Model.DJ_TourGroupMember()
                        {
                            DJ_TourGroup = group_model,
                            IdCardNo = item.Memid,
                            SpecialCardNo = item.Cardno,
                            MemberType = (Model.MemberType)Enum.Parse(typeof(Model.MemberType), item.Memtype),
                            PhoneNum = item.Memphone,
                            RealName = item.Memname
                        });
                    }
                    foreach (var item in group_excel.GroupRouteList)
                    {
                        var temp_scenic = item.Scenic.Split(new char[] { ',', '-' }, StringSplitOptions.RemoveEmptyEntries);
                        var temp_hotel = item.Hotel.Split(new char[] { ',', '-' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (var item2 in temp_scenic)
                        {
                            group_model.Routes.Add(new Model.DJ_Route()
                            {
                                DJ_TourGroup = group_model,
                                DayNo = int.Parse(item.RouteDate),
                                Enterprise = bllenterp.GetDJS8name(item2).Count > 0 ? bllenterp.GetDJS8name(item2).First() : null
                            });
                        }
                        foreach (var item2 in temp_hotel)
                        {
                            group_model.Routes.Add(new Model.DJ_Route()
                            {
                                DJ_TourGroup = group_model,
                                DayNo = int.Parse(item.RouteDate),
                                Enterprise = bllenterp.GetDJS8name(item2).Count > 0 ? bllenterp.GetDJS8name(item2).First() : null
                            });
                        }
                    }
                    bllgroup.Save(group_model);
                }
                #endregion
                Response.Redirect("/LocalTravelAgent/Groups/GroupDetail.aspx?guid=" + group_model.Id);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('你的文件超过限制大小!')", true);
                return;
            }
        }
        else
        {
            //Label1.Text = "上传文件格式不正确.";
            return;
        }
        #endregion
    }
    protected void btn_download_Click(object sender, EventArgs e)
    {
        new ExcelOplib.ExcelOutput().Download2ExcelModel(this.Page);
    }
}

public class RouteSource
{
    public string dayno { get; set; }
    public string scenics { get; set; }
    public string hotels { get; set; }
}