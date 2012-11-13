using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Model;
using BLL;
public partial class Admin_Demo : System.Web.UI.Page
{


    string dptAdminAccount1 = "tz10";//管理部门登录帐号

    string dijiesheAdminAcount1 = "linhai_lhsjtlxs";//地接社管理员
    string dijiesheName1 = "临海市交通旅行社";
    
    string dijiesheAdminAcount2 = "linhai_tzhclyyxgs";//地接社管理员
    string dijiesheName2 = "台州海创旅游有限公司";

    string hoteladmin1 = "linhai_jtdjd";
    string hotelName1 = "君泰大酒店";
    string hoteladmin2 = "linhai_lhsjtbg";
    string hotelName2 = "临海市交通宾馆";

    string scenicName1 = "情人谷";
    string scenicAdminAccount1 = "linhai_qrg";
    string scenicName2 = "东湖公园";
    string scenicAdminAccount2 = "linhai_dhgy";
    string scenicName3 = "龙兴寺";
    string scenicAdminAccount3 = "linhai_lxs";

    DJ_TourEnterprise demoHotel1;
    DJ_TourEnterprise demoHotel2;
    DJ_TourEnterprise demoDjs1;
    DJ_TourEnterprise demoDjs2;
    DJ_TourEnterprise demoScenic1;
    DJ_TourEnterprise demoScenic2;
    DJ_TourEnterprise demoScenic3;
    //测试团队名称前缀,与正常团队区分.
    string demoGroupNamePrefix = "DEMO临海两日游";
    protected void Page_Load(object sender, EventArgs e)
    {
        demoHotel1 = bllEnt.GetDJS8name(hotelName1)[0];
        demoHotel2 = bllEnt.GetDJS8name(hotelName2)[0];
        demoDjs1 = bllEnt.GetDJS8name(dijiesheName1)[0];
        demoDjs2 = bllEnt.GetDJS8name(dijiesheName2)[0];
        demoScenic1 = bllEnt.GetDJS8name(scenicName1)[0];
        demoScenic2 = bllEnt.GetDJS8name(scenicName2)[0];
        demoScenic3 = bllEnt.GetDJS8name(scenicName3)[0];
    }
    /*GovAdmin_-75259*/

    protected void btnDptAdminLogin_Click(object sender, EventArgs e)
    {
        DemoLogin(dptAdminAccount1, "/TourManagerDpt/");
    }

    protected void btnAdminLogin_Click(object sender, EventArgs e)
    {
        DemoLogin("admin", "/admin/");
    }
    protected void btnDjsLogin_Click(object sender, EventArgs e)
    {
        DemoLogin(dijiesheAdminAcount1, "/LocalTravelAgent/");
    }
    protected void btnEntLogin_Click(object sender, EventArgs e)
    {
        DemoLogin(hoteladmin1, "/TourEnterprise/");
    }
   
    BLLDJTourGroup bllGroup = new BLLDJTourGroup();
    BLLDJEnterprise bllEnt = new BLLDJEnterprise();
    private DJ_TourGroup CreateDemoGroup(DateTime beginTime)
    {
        DJ_TourGroup group = new DJ_TourGroup();
        group.BeginDate = beginTime;
        group.DJ_DijiesheInfo = (Model.DJ_DijiesheInfo)demoDjs1;
        
        group.DaysAmount =2;
        group.EndDate = beginTime.AddDays(group.DaysAmount);
        
        DJ_Group_Worker memberdaoyou = new DJ_Group_Worker();
        memberdaoyou.DJ_TourGroup = group;
        memberdaoyou.IDCard = "210905197807210546";
        memberdaoyou.SpecificIdCard = "导游证号: D-3706-004050";
        memberdaoyou.WorkerType = DJ_GroupWorkerType.导游;
        memberdaoyou.Phone = "13280008000";
        memberdaoyou.Name = "张三";

        DJ_Group_Worker membersiji = new DJ_Group_Worker();
        membersiji.DJ_TourGroup = group;
        membersiji.IDCard = "210905197807210546";
        membersiji.SpecificIdCard = "驾驶证号:362101096266";
        membersiji.WorkerType = DJ_GroupWorkerType.司机;
        membersiji.Phone = "13280008000";
        membersiji.Name = "王师傅";


        DJ_TourGroupMember member1 = new DJ_TourGroupMember();
        member1.DJ_TourGroup = group;
        member1.IdCardNo = "210905197807210546";
        member1.MemberType = MemberType.成人游客;
        member1.PhoneNum = "13280008000";
        member1.RealName = "张三";

        DJ_TourGroupMember member2 = new DJ_TourGroupMember();
        member2.DJ_TourGroup = group;
        member2.IdCardNo = "210905197807210546";
        member2.MemberType = MemberType.儿童;
        member2.PhoneNum = "13280008000";
        member2.RealName = "张小明";

        DJ_TourGroupMember member3 = new DJ_TourGroupMember();
        member3.DJ_TourGroup = group;
        member3.SpecialCardNo = "证件号:HK0930234";
        member3.MemberType = MemberType.港澳台;
        member3.PhoneNum = "13280008000";
        member3.RealName = "张学友";

        DJ_TourGroupMember member4 = new DJ_TourGroupMember();
        member4.DJ_TourGroup = group;
        member4.SpecialCardNo = "证件号:019203493l";
        member4.MemberType = MemberType.外宾;
        member4.PhoneNum = "13280008000";
        member4.RealName = "Carl Smith";

        group.Workers.Add(membersiji);
        group.Workers.Add(memberdaoyou);
        group.Members.Add(member1);
        group.Members.Add(member2);
        group.Members.Add(member3);
        group.Members.Add(member4);

        group.Name = demoGroupNamePrefix+ Math.Abs(Guid.NewGuid().GetHashCode()).ToString().Substring(0, 6);
    
        DJ_Route route1 = new DJ_Route();
        route1.DayNo = 1;
        route1.Description = "住宿";
        route1.DJ_TourGroup = group;
        route1.Enterprise = demoHotel1;

        DJ_Route route11 = new DJ_Route();
        route11.DayNo = 1;
        route11.Description = "景点";
        route11.DJ_TourGroup = group;
        route11.Enterprise = demoScenic1;

        DJ_Route route111 = new DJ_Route();
        route111.DayNo = 1;
        route111.Description = "景点";
        route111.DJ_TourGroup = group;
        route111.Enterprise = demoScenic2;

        DJ_Route route2 = new DJ_Route();
        route2.DayNo = 2;
        route2.Description = "景点";
        route2.DJ_TourGroup = group;
        route2.Enterprise = demoScenic3;
        //group.Routes

        group.Routes.Add(route1);
        group.Routes.Add(route2);
        group.Routes.Add(route11);
        group.Routes.Add(route111);

        group.DijiesheEditor =(DJ_User_TourEnterprise) new BLLMembership().GetMember(dijiesheAdminAcount1);
        return group;

    }

    BLL.BLLDJConsumRecord bllConsum = new BLLDJConsumRecord();
    protected void btnReport_Click(object sender, EventArgs e)
    {
        DeleteDemoData();
        BuildDemoDeta();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "DeleteAlert", "alert('测试数据复位成功')", true);
     
    }
    public void BuildDemoDeta()
    { 
           List<DJ_TourGroup> Groups = new List<DJ_TourGroup>();
        for (int i = 1; i <= 12; i++)
        {
            DateTime beginDate = new DateTime(DateTime.Now.Year, i, DateTime.Now.Day);
            DJ_TourGroup g = CreateDemoGroup(beginDate);
            bllGroup.Save(g);
            Groups.Add(g);
        }
        foreach (DJ_TourGroup g in Groups)
        {
            foreach (DJ_Route r in g.Routes)
            {
                Model.DJ_GroupConsumRecord cr = new DJ_GroupConsumRecord();
                cr.Route = r;
                cr.AdultsAmount = r.DJ_TourGroup.AdultsAmount;
                cr.ChildrenAmount = r.DJ_TourGroup.ChildrenAmount;
                cr.ConsumeTime = r.DJ_TourGroup.BeginDate.AddDays(r.DayNo);
                cr.Enterprise = r.Enterprise;
                cr.LiveDay = 1;
                bllConsum.DAL.Save(cr);
            }
        }
    }
    
    private void DeleteDemoData()
    {
        bllConsum.DeleteDemoRecords(demoGroupNamePrefix);

        bllGroup.DeleteDemoGroups(demoGroupNamePrefix);
    }

    private void DemoLogin(string userName, string targetUrl)
    {
        FormsAuthentication.SetAuthCookie(userName, true);
        //  Response.Redirect(targetUrl);
        ClientScript.RegisterStartupScript(this.Page.GetType(), "",
        "var opener=window.open('" + targetUrl + "','Graph','width=960,height=650;'); opener=null;", true);
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        DeleteDemoData();

        ScriptManager.RegisterStartupScript(this,this.GetType(), "DeleteAlert", "alert('测试数据删除成功')",true);
    }
}