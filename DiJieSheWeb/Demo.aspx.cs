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


    string dptAdminAccount1 = "tz10";//临海市风景旅游管理局
    string dptAdminAccount2 = "lis1";//莲都区风景旅游局

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

    string daoyouIdCard1 = "210905197807210546";//110101196605096119;
    string daoyouIdCard2 = "110101196605096119";

    DJ_TourEnterprise demoHotel1;
    DJ_TourEnterprise demoHotel2;
    DJ_TourEnterprise demoDjs1;
    DJ_TourEnterprise demoDjs2;
    DJ_TourEnterprise demoScenic1;
    DJ_TourEnterprise demoScenic2;
    DJ_TourEnterprise demoScenic3;

    DJ_Workers memberdaoyou = new DJ_Workers();
    DJ_Workers memberdaoyou2 = new DJ_Workers();

    DJ_Workers membersiji = new DJ_Workers();
    DJ_Workers membersiji2 = new DJ_Workers();
   
    //测试团队名称前缀,与正常团队区分.
    string demoGroupNamePrefix = "DEMO临海两日游";
    protected void Page_Load(object sender, EventArgs e)
    {


       
     //   bllWorker.Save(membersiji2);

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
    protected void btnScenicLogin_Click(object sender, EventArgs e)
    {
        DemoLogin(scenicName1, "http://www.tourol.com/ScenicManager/CheckTicket.aspx");
    }
    protected void btnDjsLogin_Click(object sender, EventArgs e)
    {
        DemoLogin(dijiesheAdminAcount1, "/LocalTravelAgent/");
    }
    protected void btnDjsLogin_Click2(object sender, EventArgs e)
    {
        DemoLogin(dijiesheAdminAcount2, "/LocalTravelAgent/");
    }
    protected void btnDjsLoginUI_Click(object sender, EventArgs e)
    {
        DemoLogin(dijiesheAdminAcount2, "/LTALogin.aspx");
    }
    protected void btnEntLogin_Click(object sender, EventArgs e)
    {
        DemoLogin(hoteladmin1, "/TourEnterprise/");
    }

    private void SaveWorkers()
    {
        string errMsg;
        bllWorker.Save("李晓", "13282139128", "110101196605096119", "D-3829-13904"
            , demoDjs1.Name, DJ_GroupWorkerType.导游
            , (Model.DJ_DijiesheInfo)demoDjs1,out  memberdaoyou,  out errMsg);
     
        bllWorker.Save("张三", "13282139128", "210905197807210546", " D-3706-004050"
         , demoDjs1.Name, DJ_GroupWorkerType.导游
         , (Model.DJ_DijiesheInfo)demoDjs1, out memberdaoyou2, out errMsg);

        bllWorker.Save("王勇", "13282139128", "210905197807210546", " 浙A U7863"
       , demoDjs1.Name, DJ_GroupWorkerType.司机
       , (Model.DJ_DijiesheInfo)demoDjs1, out membersiji, out errMsg);

        bllWorker.Save("赵光", "1893821234", "210905197807210546", " 浙A 84932"
      , demoDjs1.Name, DJ_GroupWorkerType.司机
      , (Model.DJ_DijiesheInfo)demoDjs1, out membersiji2, out errMsg);

    }
   
    BLLDJTourGroup bllGroup = new BLLDJTourGroup();
    BLLDJEnterprise bllEnt = new BLLDJEnterprise();
    BLLDJGroup_Worker bllGW = new BLLDJGroup_Worker();
    private DJ_TourGroup CreateDemoGroup(DateTime beginTime)
    {
        DJ_TourGroup group = new DJ_TourGroup();
        group.BeginDate = beginTime;
        group.DJ_DijiesheInfo = (Model.DJ_DijiesheInfo)demoDjs1;
        
        group.DaysAmount =2;
        group.EndDate = beginTime.AddDays(group.DaysAmount);

       
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

      //  group.Workers.Add(gwmembersiji);
       // group.Workers.Add(gwmemberdaoyou);
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
        //创建工作人员
        SaveWorkers();
         List<DJ_TourGroup> Groups = new List<DJ_TourGroup>();
        for (int i = 1; i <= 12; i++)
        {
            DateTime beginDate = new DateTime(DateTime.Now.Year, i, DateTime.Now.Day);
            DJ_TourGroup g1 = CreateDemoGroup(beginDate);  
            bllGroup.Save(g1);
            DJ_Group_Worker gwmemberdaoyou1 = new DJ_Group_Worker();
            gwmemberdaoyou1.DJ_TourGroup = g1;
            gwmemberdaoyou1.DJ_Workers = memberdaoyou;
            bllGW.Save(gwmemberdaoyou1);

            DJ_TourGroup g2 = new DJ_TourGroup();
            g1.CopyTo(g2);
            g2.DJ_DijiesheInfo =(DJ_DijiesheInfo) demoDjs2;
            g2.DijiesheEditor = (DJ_User_TourEnterprise)new BLLMembership().GetMember(dijiesheAdminAcount2);

          
           // g2.Workers.Add(memberdaoyou);
            g2.Name = demoGroupNamePrefix + Guid.NewGuid().GetHashCode().ToString().Substring(0, 6);
            DJ_Group_Worker gwmemberdaoyou = new DJ_Group_Worker();
            gwmemberdaoyou.DJ_TourGroup = g2;
            gwmemberdaoyou.DJ_Workers = memberdaoyou2;
           bllGroup.Save(g2); 
            bllGW.Save(gwmemberdaoyou);

           
            Groups.Add(g2);
       
            Groups.Add(g1);
        }
        //刷卡.验票
        foreach (DJ_TourGroup g in Groups)
        {
            //只对过去的验票.
            if (g.BeginDate.DayOfYear>= DateTime.Now.DayOfYear)
            {
                continue;
            }
            foreach (DJ_Route r in g.Routes)
            {
                Model.DJ_GroupConsumRecord cr = new DJ_GroupConsumRecord();
                cr.Route = r;
                cr.AdultsAmount = r.DJ_TourGroup.AdultsAmount;
                cr.ChildrenAmount = r.DJ_TourGroup.ChildrenAmount;
                cr.ConsumeTime = r.DJ_TourGroup.BeginDate.AddDays(r.DayNo);
                cr.Enterprise = r.Enterprise;
                cr.LiveDay = g.DaysAmount;
                cr.RoomNum = 2;
                bllConsum.DAL.Save(cr);
            }
        }
    }

    BLLWorker bllWorker = new BLLWorker();
    private void DeleteDemoData()
    {
        //消费记录
        bllConsum.DeleteDemoRecords(demoGroupNamePrefix);
        //小组信息(包括司机,导游关系表)
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