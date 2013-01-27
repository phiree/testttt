using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Model;
using BLL;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;

public partial class qumobile_CheckTicket : basepage
{
    //门票不在有效期内
    const string InValidPeriodMsgFormat = "验票失败!不在有效期内.该门票有效期为 {0}至{1}.";
    #region 初始化参数
    BLLTicketAssign bllticketassign = new BLLTicketAssign();
    BLLTicketPrice bllticketprice = new BLLTicketPrice();
    BLLOrderDetail bllorderdetail = new BLLOrderDetail();
    BLLCommonUser bllcommonuser = new BLLCommonUser();
    BLLDJTourGroup blldjtourgroup = new BLLDJTourGroup();
    BLLDJRoute blldjroute = new BLLDJRoute();
    BLLDJConsumRecord bllrecord = new BLLDJConsumRecord();
    BLLTicket bllTicket = new BLLTicket();
    BLLMembership bllMember = new BLLMembership();
    #endregion

    #region Init
    /// <summary>
    /// 为前台autocomplete插件做的ajax方法
    /// </summary>
    /// <param name="scid">景区id</param>
    /// <returns></returns>
    [WebMethod]
    public static string GetAllHints(string scid)
    {
        Scenic s = new BLLScenic().GetScenicById(int.Parse(scid));
        List<TicketAssign> list = new BLLTicketAssign().GetIdcardandname("", "", s,true);
        Dictionary<string, string> data = new Dictionary<string, string>();
        foreach (TicketAssign item in list)
        {
            //这里的key是真实身份证号，val是带*身份证号
            data.Add(item.Name + "/" + item.IdCard, item.Name + "/" + item.IdCard.Substring(0, 6) + "********" + item.IdCard.Substring(14));
        }
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(data.GetType());
        using (MemoryStream ms = new MemoryStream())
        {
            serializer.WriteObject(ms, data);
            return System.Text.Encoding.UTF8.GetString(ms.ToArray());
        }
    }

    



    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitData();
        }
    }

    private void InitData()
    {
        Msg.InnerText = "";
        ScenicAdmin sa= bllMember.GetScenicAdmin((Guid)CurrentUser.ProviderUserKey);
        hfscid.Value = sa.Scenic.Id.ToString();
        detailinfo.Visible = false;
       
    }
    #endregion

    #region event

    protected void btnSearch_Click(object sender, EventArgs e)
    {
      
        Msg.InnerText = "";
        Scenic CurrentScenic = bllMember.GetScenicAdmin((Guid)CurrentUser.ProviderUserKey).Scenic;
        if (hfdata.Value.Split('/').Length < 2)
        {
            Msg.InnerText = "无此身份证购票信息";
            return;
        }
        string name = hfdata.Value.Split('/')[0];
        string idcard = hfdata.Value.Split('/')[1];
        int flag = 0;
        foreach (TicketAssign item in new BLLTicketAssign().GetIdcardandname("", "", CurrentScenic,true).Where(x => x.Name == name))
        {
            if (item.IdCard == idcard)
            {
                flag = 1;
                idcard = item.IdCard;
            }
        }
        if (flag == 0)
        {
            foreach (DJ_Group_Worker work in new BLLDJTourGroup().GetGuiderWorkerByTE(CurrentScenic).ToList())
            {
                if (work.DJ_Workers.IDCard == idcard)
                {
                    flag = 1;
                    idcard = work.DJ_Workers.IDCard;
                }
            }
        }
        if (flag == 0)
        {
            Msg.InnerText = "无此身份证购票信息";
            return;
        }
        if (Request.Cookies["idcard"] != null)
            Request.Cookies["idcard"].Value = idcard;
        if (Response.Cookies["idcard"] != null)
            Response.Cookies["idcard"].Value = idcard;
        bindTicketInfo(name, idcard);
    }



    #endregion
    #region 绑定票价信息
    public void bindTicketInfo(string name, string idcard)
    {
        username.InnerHtml = name;
        useridcard.InnerHtml = idcard.Substring(0, 6) + "********" + idcard.Substring(14);
        //预定
        Scenic CurrentScenic = bllMember.GetScenicAdmin((Guid)CurrentUser.ProviderUserKey).Scenic; ;
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
        ShowResult();
    }
    #endregion
    public void ShowResult()
    {
        detailinfo.Visible = true;
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
                t.Scenic = bllMember.GetScenicAdmin((Guid)CurrentUser.ProviderUserKey).Scenic;
                bllticketassign.GetOlTicketInfoByIdcard(ViewState["idcard"].ToString(), t, out ttolcount, out uscount, 3);
                HtmlContainerControl hcolgpcount = e.Item.FindControl("olgpcount") as HtmlContainerControl;
                hcolgpcount.InnerHtml = ttolcount.ToString();
                HtmlContainerControl hcolgpusedcount = e.Item.FindControl("olgpusedcount") as HtmlContainerControl;
                hcolgpusedcount.InnerHtml = uscount.ToString();

                TextBox tbx = e.Item.FindControl("txtolusecount") as TextBox;
                tbx.Text = ttolcount.ToString();
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
                t.Scenic = bllMember.GetScenicAdmin((Guid)CurrentUser.ProviderUserKey).Scenic;
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

    protected void rptguiderinfo_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            int Index = 0;
            DJ_TourGroup tourgroup = e.Item.DataItem as DJ_TourGroup;
            Literal laGuideName = e.Item.FindControl("laGuideName") as Literal;
            laGuideName.Text = tourgroup.Workers.Where(x => x.DJ_Workers.WorkerType == DJ_GroupWorkerType.导游).ToList<DJ_Group_Worker>()[0].DJ_Workers.Name;
            HiddenField hfroute = e.Item.FindControl("hfrouteId") as HiddenField;
            int flag = 0;
            foreach (DJ_Route route in tourgroup.Routes)
            {
                if (tourgroup.BeginDate.AddDays(route.DayNo - 1).ToShortDateString() == DateTime.Now.ToShortDateString() && route.Enterprise.Id == bllMember.GetScenicAdmin((Guid)CurrentUser.ProviderUserKey).Scenic.Id)
                {
                    if (flag == Index)
                    {
                        hfroute.Value = route.Id.ToString();
                        Literal laIsChecked = e.Item.FindControl("laIsChecked") as Literal;
                        CheckBox selectItem = e.Item.FindControl("selectItem") as CheckBox;
                        TextBox tbAdult = e.Item.FindControl("txtAdultsAmount") as TextBox;
                        TextBox tbChild = e.Item.FindControl("txtChildrenAmount") as TextBox;
                        DJ_GroupConsumRecord record = bllrecord.GetGroupConsumRecordByRouteId(route.Id);
                        if (record != null)
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

    protected void Btnckpass_Click(object sender, EventArgs e)
    {
        Scenic CurrentScenic = bllMember.GetScenicAdmin((Guid)CurrentUser.ProviderUserKey).Scenic;
        int IsSuccess = 0;//是否验票成功
        int guiderSuccess = 0;//导游是否验票成功
        if (txtinfo.Text != "录入游客身份证或名字")
        {
            Msg.InnerText = "无此身份证购票信息";
        }
        int yditems, olrptitems, guideritems, IsSelecttiem;
        if (!IsCanChecked(out yditems, out olrptitems, out guideritems, out IsSelecttiem))
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
                    //判断此票是否过期，当前版本的做法为判断ticket的起始状态，将来需要对ticketAssign做起始状态的冗余字段，来验证
                    Ticket ticket = bllTicket.GetTicket(int.Parse((yditem.FindControl("hfticketid") as HiddenField).Value));
                    if (DateTime.Now > ticket.EndDate || DateTime.Now < ticket.BeginDate)
                    {
                        string message = "该票的使用期限为" + ticket.BeginDate.ToString("yyyy-MM-dd") + "至" + ticket.EndDate.ToString("yyyy-MM-dd");
                        message += "请在规定的时间内使用该门票！";
                        Msg.InnerText = string.Format(InValidPeriodMsgFormat, ticket.BeginDate.ToString("yyyy-MM-dd"), ticket.EndDate.ToString("yyyy-MM-dd"));
                        return;
                    }

                    if (wtusecount > ttcount - usedydcount)
                    {
                        int jxydcount = wtusecount - ttcount + usedydcount;
                        TicketAssign ta = bllticketassign.GetLasetRecordByidcard(ViewState["idcard"].ToString(), ticket, 2);
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
                        //添加验票员信息
                        ta.ScenicAdmin = bllMember.GetScenicAdmin((Guid)CurrentUser.ProviderUserKey);
                        ta.saName = CurrentUser.UserName;
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
                        Msg.InnerText = "超出购买张数，请检查购票数量";
                        flag = 1;
                        break;
                    }
                    else
                    {
                        //判断此票是否过期，当前版本的做法为判断ticket的起始状态，将来需要对ticketAssign做起始状态的冗余字段，来验证
                        Ticket ticket = bllTicket.GetTicket(int.Parse((repitem.FindControl("hfticketid") as HiddenField).Value));
                        if (DateTime.Now > ticket.EndDate || DateTime.Now < ticket.BeginDate)
                        {
                            string message = "该票的使用期限为" + ticket.BeginDate.ToString("yyyy-MM-dd") + "至" + ticket.EndDate.ToString("yyyy-MM-dd");
                            message += "请在规定的时间内使用该门票！";
                            Msg.InnerText = Msg.InnerText = string.Format(InValidPeriodMsgFormat, ticket.BeginDate.ToString("yyyy-MM-dd"), ticket.EndDate.ToString("yyyy-MM-dd"));
                   
                            return;
                        }

                        for (int i = 0; i < oluse; i++)
                        {
                            IList<TicketAssign> list = bllticketassign.Getolnotusedticketassign(ViewState["idcard"].ToString(), int.Parse((repitem.FindControl("hfticketid") as HiddenField).Value), 3);
                            TicketAssign ta = list[0];
                            ta.IsUsed = true;
                            ta.UsedTime = DateTime.Now;
                            //添加验票员信息
                            ta.ScenicAdmin = bllMember.GetScenicAdmin((Guid)CurrentUser.ProviderUserKey);
                            ta.saName = CurrentUser.UserName;
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
        if (IsSelecttiem != 0 && guideritems == 0)
        {
            foreach (RepeaterItem guideritem in rptguiderinfo.Items)
            {
                CheckBox hick = guideritem.FindControl("selectItem") as CheckBox;
                if (hick.Checked && hick.Enabled)
                {
                    TextBox tbAdult = guideritem.FindControl("txtAdultsAmount") as TextBox;
                    TextBox tbChild = guideritem.FindControl("txtChildrenAmount") as TextBox;
                    if (tbAdult.Text != "" && tbChild.Text != "")
                    {
                        HiddenField hfrouteid = guideritem.FindControl("hfrouteId") as HiddenField;
                        DJ_Route route = blldjroute.GetById(Guid.Parse(hfrouteid.Value));
                        bllrecord.Save(CurrentScenic, route, DateTime.Now, int.Parse(tbAdult.Text), int.Parse(tbChild.Text), 0, 0, 0);
                        BindPrintLink();
                        guiderSuccess = 1;
                    }
                }
            }
        }
        if (guiderSuccess == 1)
        {
            Msg.InnerText = "验票通过";
            Btnckpass.Visible = false;
        }
        if (IsSuccess == 1)
        {
            Msg.InnerText = "验票通过";
            Btnckpass.Visible = false;
        }
       // detailinfo.Visible = false;
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
        if (t.Scenic.Id == bllMember.GetScenicAdmin((Guid)CurrentUser.ProviderUserKey).Scenic.Id)
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
            if (item.Id == bllMember.GetScenicAdmin((Guid)CurrentUser.ProviderUserKey).Scenic.Id)
            {
                return true;
            }
        }
        return false;
    }
    #endregion

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
            if (hick.Checked && hick.Enabled)
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
        Scenic CurrentScenic = bllMember.GetScenicAdmin((Guid)CurrentUser.ProviderUserKey).Scenic;

        //未输入票数
        if (!rptguiderinfo.Visible)//没有导游信息时显示的提示信息
        {
            if (yditems == rptpayyd.Items.Count && olrptitems == rptpayonline.Items.Count)
            {
                if (rptpayyd.Visible == true || rptpayonline.Visible == true)
                {
                    Msg.InnerText = "请输入使用张数";
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
                    if (HaveYz == 1)
                        Msg.InnerText="请选择一个已验证的团队信息";
                    else
                        Msg.InnerText = "请选择一个已验证的团队信息";
                    return false;
                }
                else if (guideritems > 0)
                {
                    Msg.InnerText = "请输入完整使用人数";
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
                            Msg.InnerText = "请输入使用张数";
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
    private void BindPrintLink()
    {
        string routeids = "";
        foreach (RepeaterItem item in rptguiderinfo.Items)
        {
            HiddenField hfrouteId = item.FindControl("hfrouteId") as HiddenField;
            DJ_GroupConsumRecord record = bllrecord.GetGroupConsumRecordByRouteId(Guid.Parse(hfrouteId.Value));
            if (record != null)
                routeids += hfrouteId.Value + ",";
        }
        BtnPrint.HRef = "/ScenicManager/PrintCer.aspx?routeids=" + routeids;
    }
}