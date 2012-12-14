using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using BLL;
using Model;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Web.Services;
using System.Text.RegularExpressions;

public partial class ScenicManager_CheckTicket : bpScenicManager
{
    #region 公共的参数
    BLLTicketAssign bllticketassign = new BLLTicketAssign();
    BLLTicketPrice bllticketprice = new BLLTicketPrice();
    BLLOrderDetail bllorderdetail = new BLLOrderDetail();
    BLLCommonUser bllcommonuser = new BLLCommonUser();
    BLLDJTourGroup blldjtourgroup = new BLLDJTourGroup();
    BLLDJRoute blldjroute = new BLLDJRoute();
    BLLDJConsumRecord bllrecord = new BLLDJConsumRecord();
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        hfscid.Value = Master.Scenic.Id.ToString();
        if (txtinfo.Text != "录入游客身份证或名字" && txtinfo.Text != "")
        {
            btnbind_Click(null, null);
        }
        if (!IsPostBack)
        {
            Init();
            
        }
    }
    /// <summary>
    /// 初始化相关信息
    /// </summary>
    private void Init()
    {
        CurrentScenic = Master.Scenic;
        //绑定预定信息

        //再这里要加上当天会来此景点的导游信息,并把它包装成为TicketAssign
        List<TicketAssign> list= new BLLTicketAssign().GetIdcardandname("", "", CurrentScenic);
        List<DJ_Group_Worker> listdjGW = new BLLDJTourGroup().GetGuiderWorkerByTE(CurrentScenic).ToList();
        foreach (DJ_Group_Worker gw in listdjGW)
        {
            //排除以后的人员信息
            if (list.Where(x => x.IdCard == gw.DJ_Workers.IDCard).Count() == 0)
            {
                TicketAssign ta = new TicketAssign();
                ta.Name = gw.DJ_Workers.Name;
                ta.IdCard = gw.DJ_Workers.IDCard;
                list.Add(ta);
            }
        }
        rptpeopleinfo.DataSource = list;
        rptpeopleinfo.DataBind();
        Request.Cookies.Add(new HttpCookie("idcard"));
        Response.Cookies.Add(new HttpCookie("idcard"));
        Request.Cookies["idcard"].Value = "";
        Response.Cookies["idcard"].Value = "";
        detailinfo.Visible = false;
        ywdiv.Style.Add("visiblity", "hidden");
        rptguiderinfo.Visible = false;
    }
    
    /// <summary>
    /// 为前台autocomplete插件做的ajax方法
    /// </summary>
    /// <param name="scid">景区id</param>
    /// <returns></returns>
    [WebMethod]
    public static string GetAllHints(string scid)
    {
        Scenic s = new BLLScenic().GetScenicById(int.Parse(scid));
        List<TicketAssign> list = new BLLTicketAssign().GetIdcardandname("", "", s);
        //再这里要加上当天会来此景点的导游信息,并把它包装成为TicketAssign
        List<DJ_Workers> listdjGW = new BLLDJTourGroup().GetTourGroupByTeId(s.Id).ToList();
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
            data.Add(Guid.NewGuid().ToString(), item.Name + "/" + item.IdCard.Substring(0, 6) + "********" + item.IdCard.Substring(14));
        }
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(data.GetType());
        using (MemoryStream ms = new MemoryStream())
        {
            serializer.WriteObject(ms, data);
            return System.Text.Encoding.UTF8.GetString(ms.ToArray());
        }
    }


    protected void btnbind_Click(object sender, EventArgs e)
    {
        CurrentScenic = Master.Scenic;
        if (hfdata.Value.Split('/').Length < 2)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('无此身份证购票信息')", true);
            return;
        }
        string name = hfdata.Value.Split('/')[0];
        string idcard = hfdata.Value.Split('/')[1];
        int flag = 0;
        foreach (TicketAssign item in new BLLTicketAssign().GetIdcardandname("", "", CurrentScenic).Where(x => x.Name == name))
        {
            if (item.IdCard.Substring(0, 6) + "********" + item.IdCard.Substring(14)== idcard)
            {
                flag = 1;
                idcard = item.IdCard;
            }
        }
        if (flag == 0)
        {
            foreach (DJ_Group_Worker work in new BLLDJTourGroup().GetGuiderWorkerByTE(Master.Scenic).ToList())
            {
                if (work.DJ_Workers.IDCard.Substring(0, 6) + "********" + work.DJ_Workers.IDCard.Substring(14) == idcard)
                {
                    flag = 1;
                    idcard = work.DJ_Workers.IDCard;
                }
            }
        }
        if (flag == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('无此身份证购票信息')", true);
            return;
        }
        if (Request.Cookies["idcard"] != null)
            Request.Cookies["idcard"].Value = idcard;
        if (Response.Cookies["idcard"] != null)
            Response.Cookies["idcard"].Value = idcard;
        bindTicketInfo(name, idcard);
        BindPrintLink();
    }
    protected void btnselect_Click(object sender, EventArgs e)
    {
        string name = hfselectname.Value;
        string idcard = hfselectidcard.Value;
        int flag = 0;
        foreach (TicketAssign item in new BLLTicketAssign().GetIdcardandname("", "", CurrentScenic).Where(x => x.Name == name))
        {
            if (item.IdCard.Substring(0, 6) + "********" + item.IdCard.Substring(14) == idcard)
            {
                flag = 1;
                idcard = item.IdCard;
            }
        }
        if (flag == 0)
        {
            foreach (DJ_Group_Worker work in new BLLDJTourGroup().GetGuiderWorkerByTE(Master.Scenic).ToList())
            {
                if (work.DJ_Workers.IDCard.Substring(0, 6) + "********" + work.DJ_Workers.IDCard.Substring(14) == idcard)
                {
                    flag = 1;
                    idcard = work.DJ_Workers.IDCard;
                }
            }
        }
        if (flag == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('无此身份证购票信息')", true);
            return;
        }
        bindTicketInfo(name, idcard);
        BindPrintLink();
    }
    protected void Btnckpass_Click(object sender, EventArgs e)
    {
        int IsSuccess = 0;//是否验票成功
        int guiderSuccess = 0;//导游是否验票成功
        if (txtinfo.Text != "录入游客身份证或名字")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('无此身份证购票信息')", true);
        }
        int yditems,olrptitems,guideritems,IsSelecttiem;
        if (!IsCanChecked(out yditems, out olrptitems,out guideritems,out IsSelecttiem))
        {
            return;
        }
        //预定
        if (yditems != rptpayyd.Items.Count)
        {
            foreach (RepeaterItem yditem in rptpayyd.Items)
            {
                if (yditem.Visible == true)
                {
                    TextBox ydtb = yditem.FindControl("txtUseCount") as TextBox;
                    if (ydtb.Text == "")
                        ydtb.Text = "0";
                    int wtusecount = int.Parse(ydtb.Text);
                    int ttcount = Convert.ToInt32((yditem.FindControl("ydmpcount") as HtmlContainerControl).InnerHtml);
                    int usedydcount = Convert.ToInt32((yditem.FindControl("ydmpusedcount") as HtmlContainerControl).InnerHtml);
                    if (wtusecount > ttcount - usedydcount)
                    {
                        int jxydcount = wtusecount - ttcount + usedydcount;
                        TicketAssign ta = bllticketassign.GetLasetRecordByidcard(ViewState["idcard"].ToString(), new BLLTicket().GetTicket(int.Parse((yditem.FindControl("hfticketid") as HiddenField).Value)), 2);
                        OrderDetail od = ta.OrderDetail;
                        od.Quantity = od.Quantity + jxydcount;
                        od.Remark = "在景区预定" + jxydcount + "张门票";
                        bllorderdetail.saveorupdate(od);
                        for (int i = 0; i < jxydcount; i++)
                        {
                            TicketAssign ticketassign = new TicketAssign();
                            ticketassign.IdCard = ViewState["idcard"].ToString();
                            ticketassign.IsUsed = false;
                            ticketassign.Name = ta.Name;
                            ticketassign.OrderDetail = od;
                            ticketassign.UsedTime = DateTime.Now;
                            bllticketassign.SaveOrUpdate(ticketassign);
                        }
                    }
                    for (int i = 0; i < wtusecount; i++)
                    {
                        IList<TicketAssign> list = bllticketassign.GetNotUsedTicketAssign(ViewState["idcard"].ToString(), new BLLTicket().GetTicket(int.Parse((yditem.FindControl("hfticketid") as HiddenField).Value)), 2);
                        TicketAssign ta = list[0];
                        ta.IsUsed = true;
                        ta.UsedTime = DateTime.Now;
                        bllticketassign.SaveOrUpdate(ta);
                        //查询订单中所有的detail是否都已付完款
                        List<TicketAssign> listticketassign = bllticketassign.GetTaByIdCard(ViewState["idcard"].ToString()).ToList();
                        foreach (TicketAssign taitem in listticketassign)
                        {
                            Order or = taitem.OrderDetail.Order;
                            if (!or.IsPaid)
                            {
                                int flag = 0;
                                foreach (OrderDetail oditem in or.OrderDetail)
                                {
                                    int allodta = oditem.TicketAssignList.Count;
                                    int usedodta = oditem.TicketAssignList.Where(x => x.IsUsed == true).Count();
                                    if (allodta != usedodta)
                                    {
                                        flag = 1;
                                    }
                                }
                                if (flag == 0)
                                {
                                    or.IsPaid = true;
                                    or.PayTime = DateTime.Now;
                                    new BLLOrder().SaveOrUpdateOrder(or);
                                }
                            }

                        }
                    }
                }
            }
            IsSuccess = 1;
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('验票通过')", true);
        }
        //在线支付
        if (olrptitems != rptpayonline.Items.Count)
        {
            int flag = 0;
            foreach (RepeaterItem repitem in rptpayonline.Items)
            {
                if (repitem.Visible == true)
                {
                    TextBox tb = repitem.FindControl("txtolusecount") as TextBox;
                    if (tb.Text == "")
                        tb.Text = "0";
                    int oluse = int.Parse(tb.Text);
                    int gpcount = Convert.ToInt32((repitem.FindControl("olgpcount") as HtmlContainerControl).InnerHtml);
                    int usedcount = Convert.ToInt32((repitem.FindControl("olgpusedcount") as HtmlContainerControl).InnerHtml);
                    if (gpcount - usedcount < oluse)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('超出购买张数，请检查购票数量')", true);
                        flag = 1;
                        break;
                    }
                    else
                    {
                        for (int i = 0; i < oluse; i++)
                        {
                            IList<TicketAssign> list = bllticketassign.Getolnotusedticketassign(ViewState["idcard"].ToString(), int.Parse((repitem.FindControl("hfticketid") as HiddenField).Value), 3);
                            TicketAssign ta = list[0];
                            ta.IsUsed = true;
                            ta.UsedTime = DateTime.Now;
                            bllticketassign.SaveOrUpdate(ta);
                        }
                    }
                }
            }
            if (flag == 0)
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('验票通过')", true);
                IsSuccess = 1;
            }
        }
        //导游验票结果
        if (IsSelecttiem != 0 && guideritems==0)
        {
            foreach (RepeaterItem guideritem in rptguiderinfo.Items)
            {
                CheckBox hick = guideritem.FindControl("selectItem") as CheckBox;
                if (hick.Checked&&hick.Enabled)
                {
                    TextBox tbAdult = guideritem.FindControl("txtAdultsAmount") as TextBox;
                    TextBox tbChild = guideritem.FindControl("txtChildrenAmount") as TextBox;
                    if (tbAdult.Text != "" && tbChild.Text != "")
                    {
                        HiddenField hfrouteid = guideritem.FindControl("hfrouteId") as HiddenField;
                        DJ_Route route = blldjroute.GetById(Guid.Parse(hfrouteid.Value));
                        bllrecord.Save(CurrentScenic, route, DateTime.Now, int.Parse(tbAdult.Text), int.Parse(tbChild.Text),0,0,0);
                        BindPrintLink();
                        guiderSuccess = 1;
                    }
                }
            }
        }
        if (guiderSuccess == 1)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "printTicket('验票通过,是否需要打印凭证？')", true);
        }
        if (IsSuccess == 1)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('验票通过')", true);
        }
        rptpayyd.DataSource = bllticketassign.GetTicketTypeByIdCard(ViewState["idcard"].ToString());
        rptpayyd.DataBind();
        if (rptpayyd.Items.Count == 0)
            rptpayyd.Visible = false;
        else
            rptpayyd.Visible = true;
        rptpayonline.DataSource = bllticketassign.GetTicketTypeByIdCard(ViewState["idcard"].ToString());
        rptpayonline.DataBind();
        rptguiderinfo.DataSource = blldjtourgroup.GetTgByIdcardAndTe(ViewState["idcard"].ToString(), CurrentScenic);
        rptguiderinfo.DataBind();
    }

    //绑定游玩记录
    private void bindywrecord()
    {
        rptywrecord.DataSource = bllticketassign.GetYwCount(ViewState["idcard"].ToString());
        rptywrecord.DataBind();
    }
    protected void rptywrecord_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.FindControl("ywtime") != null)
        {
            string ywtime = (e.Item.FindControl("ywtime") as HtmlContainerControl).InnerHtml;
            (e.Item.FindControl("ywtime") as HtmlContainerControl).InnerHtml = bllticketassign.GetUsedCount(ViewState["idcard"].ToString(), DateTime.Parse(ywtime)).ToString();
        }
    }
    protected void btnauto_Click(object sender, EventArgs e)
    {
        CurrentScenic = Master.Scenic;
        string idcard = hfautoidcard.Value;
        IList<TicketAssign> list = bllticketassign.GetTaByIdcardandscenic(idcard, CurrentScenic);
        if (list.Count == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('无此身份证购票信息');", true);
            tp_nav.Attributes.Add("style", "");
            detailinfo.Visible = false;
            ywdiv.Style.Add("visiblity", "hidden");
            return;
        }
        else
        {
            string name = bllticketassign.GetTaByIdCard(idcard)[0].Name;
            bindTicketInfo(name, idcard);
        }
        BindPrintLink();
    }
    protected void rptpayonline_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Model.Ticket t = e.Item.DataItem as Model.Ticket;
            if (IsCurrentScenicTicket(t) || IsCurrentScenicTp(t))
            {
                int ttolcount = 0;
                int uscount = 0;
                t.Scenic = Master.Scenic;
                bllticketassign.GetOlTicketInfoByIdcard(ViewState["idcard"].ToString(), t, out ttolcount, out uscount, 3);
                HtmlContainerControl hcolgpcount = e.Item.FindControl("olgpcount") as HtmlContainerControl;
                hcolgpcount.InnerHtml = ttolcount.ToString();
                HtmlContainerControl hcolgpusedcount = e.Item.FindControl("olgpusedcount") as HtmlContainerControl;
                hcolgpusedcount.InnerHtml = uscount.ToString();
                if (ttolcount == 0)
                {
                    e.Item.Visible = false;
                }
            }
            else
            {
                e.Item.Visible = false;
            }
        }
    }
    protected void rptpayyd_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Model.Ticket t = e.Item.DataItem as Model.Ticket;
            if (IsCurrentScenicTicket(t) || IsCurrentScenicTp(t))
            {
                int ttolcount = 0;
                int uscount = 0;
                t.Scenic = Master.Scenic;
                bllticketassign.GetTicketInfoByIdCard(ViewState["idcard"].ToString(), t, out ttolcount, out uscount, 2);
                HtmlContainerControl hcydmpcount = e.Item.FindControl("ydmpcount") as HtmlContainerControl;
                hcydmpcount.InnerHtml = ttolcount.ToString();
                HtmlContainerControl hcydmpusedcount = e.Item.FindControl("ydmpusedcount") as HtmlContainerControl;
                hcydmpusedcount.InnerHtml = uscount.ToString();
                HtmlContainerControl hcyddj = e.Item.FindControl("yddj") as HtmlContainerControl;
                hcyddj.InnerHtml = bllticketprice.GetTicketPriceByScenicandtypeid(t, PriceType.PreOrder).Price.ToString("0") + "元";
                if (ttolcount == 0)
                {
                    e.Item.Visible = false;
                }
            }
            else
            {
                e.Item.Visible = false;
            }
        }
    }



    #region 判断是否是套票
    public bool IsTp(Ticket t)
    {
        BLLScenicTicket bllscenicticket = new BLLScenicTicket();
        IList<Scenic> list = bllscenicticket.GetScenicByTicket(t.Id);
        if (list.Count > 0)
            return true;
        return false;
    }
    #endregion
    #region 判断是否是这个景区的票
    public bool IsCurrentScenicTicket(Ticket t)
    {
        t = new BLLTicket().GetTicket(t.Id);
        if (t.Scenic.Id == Master.Scenic.Id)
            return true;
        else
            return false;
    }
    #endregion
    #region 判断是否是这个景区的套票
    public bool IsCurrentScenicTp(Ticket t)
    {
        t = new BLLTicket().GetTicket(t.Id);
        BLLScenicTicket bllscenicticket = new BLLScenicTicket();
        List<Scenic> list = bllscenicticket.GetScenicByTicket(t.Id).ToList();
        foreach (Scenic item in list)
        {
            if (item.Id == Master.Scenic.Id)
            {
                return true;
            }
        }
        return false;
    }
    #endregion
    #region 显示验票结果
    public void ShowResult()
    {
        tp_nav.Attributes.Add("style", "margin-top:20px;");
        ywdiv.Style.Add("visiblity", "visible");
        detailinfo.Visible = true;
        if (rptguiderinfo.Items.Count > 0)
        {
            rptguiderinfo.Visible = true;
            //设置第一个checkbox为选中状态
            (rptguiderinfo.Items[0].FindControl("selectItem") as CheckBox).Checked = true;
        }
        else
        {
            rptguiderinfo.Visible = false;
        }
        bindywrecord();
    }
    #endregion
    #region 绑定票价信息
    public void bindTicketInfo(string name, string idcard)
    {
        username.InnerHtml = name;
        useridcard.InnerHtml = idcard.Substring(0,6)+"********"+idcard.Substring(14);
        //预定
        CurrentScenic = Master.Scenic;
        ViewState["idcard"] = idcard;
        rptpayyd.DataSource = bllticketassign.GetTicketTypeByIdCard(ViewState["idcard"].ToString());
        rptpayyd.DataBind();
        if (rptpayyd.Items.Count == 0)
            rptpayyd.Visible = false;
        else
            rptpayyd.Visible = true;
        //在线购买
        rptpayonline.DataSource = bllticketassign.GetTicketTypeByIdCard(idcard);
        rptpayonline.DataBind();
        if (rptpayonline.Items.Count == 0)
            rptpayonline.Visible = false;
        else
            rptpayonline.Visible = true;
        //导游信息
        rptguiderinfo.DataSource = blldjtourgroup.GetTgByIdcardAndTe(idcard, CurrentScenic);
        rptguiderinfo.DataBind();
        ShowResult();
    }
    #endregion
    protected void rptguiderinfo_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            int Index = 0;
            DJ_TourGroup tourgroup= e.Item.DataItem as DJ_TourGroup;
            Literal laGuideName = e.Item.FindControl("laGuideName") as Literal;
            laGuideName.Text = tourgroup.Workers.Where(x => x.DJ_Workers.WorkerType == DJ_GroupWorkerType.导游).ToList<DJ_Group_Worker>()[0].DJ_Workers.Name;
            HiddenField hfroute = e.Item.FindControl("hfrouteId") as HiddenField;
            int flag = 0;
            foreach (DJ_Route route in tourgroup.Routes)
            {
                if (tourgroup.BeginDate.AddDays(route.DayNo-1).ToShortDateString() == DateTime.Now.ToShortDateString() && route.Enterprise.Id == Master.Scenic.Id)
                {
                    if (flag == Index)
                    {
                        hfroute.Value = route.Id.ToString();
                        Literal laIsChecked = e.Item.FindControl("laIsChecked") as Literal;
                        CheckBox selectItem = e.Item.FindControl("selectItem") as CheckBox;
                        TextBox tbAdult = e.Item.FindControl("txtAdultsAmount") as TextBox;
                        TextBox tbChild = e.Item.FindControl("txtChildrenAmount") as TextBox;
                        DJ_GroupConsumRecord record= bllrecord.GetGroupConsumRecordByRouteId(route.Id);
                        if ( record!= null)
                        {
                            laIsChecked.Text = "已验证";
                            selectItem.Enabled = false;
                            selectItem.Checked = true;
                            tbAdult.Enabled = false;
                            tbChild.Enabled = false;
                            tbAdult.Text = record.AdultsAmount.ToString();
                            tbChild.Text = record.ChildrenAmount.ToString();
                        }
                        else
                        {
                            laIsChecked.Text = "未验证";
                        }
                        Index++;
                    }
                    else
                    {
                        flag++;
                    }
                }
            }
        }
    }

    #region 验票通过前的审核内容
    private bool IsCanChecked(out int yditems, out int olrptitems, out int guideritems, out int IsSelecttiem)
    {
        yditems = 0;
        foreach (RepeaterItem rptitem in rptpayyd.Items)
        {
            TextBox tb = rptitem.FindControl("txtUseCount") as TextBox;
            tb.Text = Regex.Replace(tb.Text, "[^0-9]", "");
            if (tb.Text == "")
                yditems++;
        }
        olrptitems = 0;
        foreach (RepeaterItem rpitem in rptpayonline.Items)
        {
            TextBox tb = rpitem.FindControl("txtolusecount") as TextBox;
            tb.Text = Regex.Replace(tb.Text, "[^0-9]", "");
            if (tb.Text == "")
                olrptitems++;
        }
        guideritems = 0;
        IsSelecttiem = 0;
        int HaveYz = 0;
        foreach (RepeaterItem rpitem in rptguiderinfo.Items)
        {
            CheckBox hick = rpitem.FindControl("selectItem") as CheckBox;
            if (hick.Checked&&hick.Enabled)
            {
                IsSelecttiem++;
                TextBox tbAdult = rpitem.FindControl("txtAdultsAmount") as TextBox;
                TextBox tbChild = rpitem.FindControl("txtChildrenAmount") as TextBox;
                tbAdult.Text = Regex.Replace(tbAdult.Text, "[^0-9]", "");
                tbChild.Text = Regex.Replace(tbChild.Text, "[^0-9]", "");
                if (tbAdult.Text == "" || tbChild.Text == "")
                {
                    guideritems++;
                }
            }
            if (hick.Checked && !hick.Enabled)
            {
                HaveYz = 1;
            }
        }
        CurrentScenic = Master.Scenic;

        //未输入票数
        if (!rptguiderinfo.Visible)//没有导游信息时显示的提示信息
        {
            if (yditems == rptpayyd.Items.Count && olrptitems == rptpayonline.Items.Count)
            {
                if (rptpayyd.Visible == true || rptpayonline.Visible == true)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('请输入使用张数')", true);
                    rptpayyd.DataSource = bllticketassign.GetTicketTypeByIdCard(ViewState["idcard"].ToString());
                    rptpayyd.DataBind();
                    if (rptpayyd.Items.Count == 0)
                        rptpayyd.Visible = false;
                    else
                        rptpayyd.Visible = true;

                    rptpayonline.DataSource = bllticketassign.GetTicketTypeByIdCard(ViewState["idcard"].ToString());
                    rptpayonline.DataBind();
                    return false;
                }
            }
        }
        else//有导游信息时显示的提示信息
        {
            if (rptpayyd.Items.Count == 0 && rptpayonline.Items.Count == 0)//表明只有导游信息
            {
                if (IsSelecttiem == 0)
                {
                    if(HaveYz==1)
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "printTicket('请选择一个已验证的团队信息，是否对已验证的团队进行打印？')", true);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('请选择一个已验证的团队信息')", true);
                    return false;
                }
                else if (guideritems>0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('请输入完整使用人数')", true);
                    return false;
                }
            }
            else
            {
                if (IsSelecttiem == 0 || IsSelecttiem == guideritems)
                {
                    if (yditems == rptpayyd.Items.Count && olrptitems == rptpayonline.Items.Count)
                    {
                        if (rptpayyd.Visible == true || rptpayonline.Visible == true)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('请输入使用张数')", true);
                            rptpayyd.DataSource = bllticketassign.GetTicketTypeByIdCard(ViewState["idcard"].ToString());
                            rptpayyd.DataBind();
                            if (rptpayyd.Items.Count == 0)
                                rptpayyd.Visible = false;
                            else
                                rptpayyd.Visible = true;

                            rptpayonline.DataSource = bllticketassign.GetTicketTypeByIdCard(ViewState["idcard"].ToString());
                            rptpayonline.DataBind();
                            return false;
                        }
                    }
                }
            }
        }
        return true;
    }
    #endregion
    protected void rptpeopleinfo_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            TicketAssign ta = e.Item.DataItem as TicketAssign;
            Literal laType = e.Item.FindControl("laType") as Literal;
            List<DJ_Group_Worker> listdjGW = new BLLDJTourGroup().GetGuiderWorkerByTE(Master.Scenic).ToList();
            if (listdjGW.Where(x => x.DJ_Workers.IDCard == ta.IdCard).Count() > 0)
            {
                laType.Text = "导游";
            }
            else
            {
                laType.Text = "个人";
            }
        }
    }
    private void BindPrintLink()
    {
        string routeids = "";
        foreach (RepeaterItem item in rptguiderinfo.Items)
        {
            HiddenField hfrouteId = item.FindControl("hfrouteId") as HiddenField;
            DJ_GroupConsumRecord record = bllrecord.GetGroupConsumRecordByRouteId(Guid.Parse(hfrouteId.Value));
            if(record!=null)
                routeids += hfrouteId.Value+",";
        }
        BtnPrint.HRef = "/ScenicManager/PrintCer.aspx?routeids=" + routeids;
    }

}