using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using NHibernate;

public partial class Manager_QuZhouSpring_TicketAssignBatch : System.Web.UI.Page
{
    protected ISession session = new HybridSessionBuilder().GetSession();
    //天数
    List<DateTime> dateList = new List<DateTime>();
    //已售总量
    Dictionary<string, int> DictAssign = new Dictionary<string, int>();
    //合作伙伴比例(总数为100
    Dictionary<string, int> DictPartnerPercent = new Dictionary<string, int>();
    //开始几天的倍数
    int[] peishuForStartDates = { 1, 1 };
    DALQZSpringPartner dalPartner = new DALQZSpringPartner();
    int partsAmount;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            tbxDate.Text = DateTime.Today.ToString();
        }
        InitData();
        //总共划分的份数
        int extraPart = 0;
        foreach (int i in peishuForStartDates)
        {
            extraPart += (i - 1);
        }
        partsAmount = Convert.ToInt32(dateList.Count + extraPart);
        if (true)//!IsPostBack)
        {
            BindScenic();

        }
        
    }
    #region Init
    private void InitData()
    {
        InitDateList();
        InitSoldAmountDict();
        InitPartnerPercentDict();
    }
    private void InitDateList()
    {
        DateTime enddate=new DateTime(2013,2,6);
        DateTime beginDate = Convert.ToDateTime(tbxDate.Text);
        int lastDay=(int)(enddate-beginDate).TotalDays;
        for (int i = 0; i < lastDay ; i++)
        {
            dateList.Add(DateTime.Now.Date.AddDays(i));
        }
    }
    private void InitPartnerPercentDict()
    {
        DictPartnerPercent.Clear();
        string tourolId = "tourol.cn";
        string xxzdid = "9c815efa-402a-40ce-860b-c0fa37f707eb";
     
            DictPartnerPercent.Add(tourolId, 33);
   
            DictPartnerPercent.Add(xxzdid, 67);
            DictPartnerPercent.Add("meiti", 0);
            DictPartnerPercent.Add("taizhou", 0);
       
    }

    private void InitSoldAmountDict()
    {
        DictPartnerPercent.Clear();
        string 江郎山风景名胜区 = "6a56e70d-e85b-4cb2-939c-5c414e845294";
        string 开化根雕博览园 = "03c52bd2-8f25-4f3e-99aa-210ad6ac1cf8";
        string 廿八都 = "0019ce2e-74ad-4346-a816-0b70c43adc58";
        string 龙游石窟 = "34142E7C-86AA-4D64-9C39-7467E2070B6B";
        string 清漾毛氏文化村 = "313E1987-7602-47FC-AAFF-D0326DF08473";
        string 钱江源莲花塘大峡谷联票 = "3F294078-13F9-4E70-A1F9-AE0626371A2E";
        string 钱江源枫楼坑景区 = "ABA2D309-C302-4471-A2DC-F4163EF8B954";
        string 戴笠故居 = "6E1B076E-8629-4CD1-9D4E-85B9B5290845";
        string 浮盖山 = "B163AF1C-330F-4EEA-99CC-AB10EEC09F52";
        string 龙游民居苑 = "E313B686-8B5B-4AD3-9954-F33E06953D81";
        string 九龙湖 = "B8BC6445-2325-45A5-8D0C-8479E03F6E0B";
        string 古田山国家级自然保护区 = "0E31A54B-3E6A-41A2-AAD0-900D07128DC6";

        string 卧龙山庄 = "c86157c5-5116-48a7-ac48-b455fb905bc9";
        string 九坛沟景区 = "87a34131-bcff-4cf9-bba5-82e53a4fa9b9";
        DictAssign.Add(江郎山风景名胜区, 4720);
        DictAssign.Add(开化根雕博览园, 10690);
        DictAssign.Add(廿八都, 10690);
        DictAssign.Add(龙游石窟, 10690);
        DictAssign.Add(清漾毛氏文化村, 10690);
        DictAssign.Add(钱江源莲花塘大峡谷联票, 10690);
        DictAssign.Add(钱江源枫楼坑景区, 10690);
        DictAssign.Add(戴笠故居, 10690);
        DictAssign.Add(浮盖山, 11080);
        DictAssign.Add(龙游民居苑, 11080);
        DictAssign.Add(九龙湖, 11230);
        DictAssign.Add(古田山国家级自然保护区, 11230);

        DictAssign.Add(卧龙山庄, 11620);
        DictAssign.Add(九坛沟景区, 11620);
    }
    #endregion


    protected void btnSave_Click(object sender, EventArgs e)
    {
        Save();
    }

    #region 计算,绑定

    private void BindScenic()
    {
        string sql = @"
select dj.Name,t.ProductCode,s.ScenicOrder,count(*) from TicketAssign ta, OrderDetail detail,[Order] od ,DJ_TourEnterprise dj,TicketPrice tp,Ticket t
,Scenic s

where ta.OrderDetail_id =detail.Id and detail.Order_id=od.Id 
and detail.TicketPrice_id=tp.Id and tp.Ticket_id=t.Id and t.Scenic_id=dj.Id and s.DJ_TourEnterprise_id=dj.Id
group by dj.Name,s.ScenicOrder,dj.id ,t.ProductCode order by s.ScenicOrder";
        IList<object> solo = session.CreateSQLQuery(sql).List<object>();
        rptAssign.DataSource = solo; rptAssign.ItemDataBound += new RepeaterItemEventHandler(rptAssign_ItemDataBound);
        rptAssign.DataBind();

    }
    double partAmountForScenic;
    void rptAssign_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            object[] reportObj = e.Item.DataItem as object[];
            //剩余票数
            Label lblSold = e.Item.FindControl("lblSold") as Label;
            Label lblTotal = e.Item.FindControl("lblTotal") as Label;

            lblTotal.Text = DictAssign[reportObj[1].ToString()].ToString();
            int lastAmount = Convert.ToInt32(lblTotal.Text) - Convert.ToInt32(lblSold.Text.Trim());
            //每一份数量
            partAmountForScenic = Math.Ceiling((double)(lastAmount / partsAmount));

            Repeater rptPartner = e.Item.FindControl("rptPartner") as Repeater;
            rptPartner.DataSource = dalPartner.GetAll<Model.QZSpringPartner>();
            rptPartner.ItemDataBound += new RepeaterItemEventHandler(rptPartner_ItemDataBound);
            rptPartner.DataBind();

        }
    }

    double assignedAmount;
    void rptPartner_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
          
            assignedAmount = 0;
            HiddenField hiFid = e.Item.FindControl("hiFid") as HiddenField;
            string friendlyId = hiFid.Value;
            Label lblPartnerPercent = e.Item.FindControl("lblPartnerPercent") as Label;
            if (!DictPartnerPercent.ContainsKey(friendlyId))
            { return; }
            lblPartnerPercent.Text = DictPartnerPercent[friendlyId].ToString();
            assignedAmount = Math.Ceiling((double)(Convert.ToDecimal(lblPartnerPercent.Text) * (decimal)partAmountForScenic / (decimal)100));
            Repeater rptDate = e.Item.FindControl("rptDate") as Repeater;

            rptDate.DataSource = dateList;

            rptDate.ItemDataBound += new RepeaterItemEventHandler(rptDate_ItemDataBound);
            rptDate.DataBind();
        }
    }

    void rptDate_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            
            TextBox tbxAmount = e.Item.FindControl("tbxAmount") as TextBox;
            assignedAmount = Math.Round(assignedAmount / 10) * 10;
            if (e.Item.ItemIndex < peishuForStartDates.Length)
            {
                tbxAmount.Text = (assignedAmount * peishuForStartDates[e.Item.ItemIndex]).ToString();
            }
            else
            {
                tbxAmount.Text = assignedAmount.ToString();
            }
        }
    }
    #endregion
    private void Save()
    {
        foreach (RepeaterItem item in rptAssign.Items)
        {

        }
    }
}