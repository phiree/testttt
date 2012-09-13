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
    BLLTicketAssign bllticketassign = new BLLTicketAssign();
    BLLTicketPrice bllticketprice = new BLLTicketPrice();
    BLLOrderDetail bllorderdetail = new BLLOrderDetail();
    BLLCommonUser bllcommonuser = new BLLCommonUser();
    public int totalyudingcount;//预定总数
    public int usedyudingcount;//预定使用数
    public int totalolcount;//在线支付总数
    public int useolcount;//在线支付已使用数
    public string yddj;
    Scenic sss;
    protected void Page_Load(object sender, EventArgs e)
    {
        hfscid.Value = Master.Scenic.Id.ToString();
        if (txtinfo.Text != "录入游客身份证或名字" && txtinfo.Text != "")
        {
            btnbind_Click(null, null);
        }
        if (!IsPostBack)
        {
            bind();
            detailinfo.Visible = false;
            ywdiv.Visible = false;
        }
    }

    private void bind()
    {
        CurrentScenic = Master.Scenic;
        sss = Master.Scenic;
        //绑定预定信息
        rptpeopleinfo.DataSource = new BLLTicketAssign().GetIdcardandname("", "", CurrentScenic);
        rptpeopleinfo.DataBind();
        Request.Cookies.Add(new HttpCookie("idcard"));
        Response.Cookies.Add(new HttpCookie("idcard"));
        Request.Cookies["idcard"].Value = "";
        Response.Cookies["idcard"].Value = "";

    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        tp_nav.Attributes.Add("style", "margin-top:20px;");
        //txinfo.Attributes.Remove("class");
        //list.Visible = true;
        detailinfo.Visible = false;
        ywdiv.Visible = true;
    }

    protected void rptpeopleinfo_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "search")
        {
            //预定
            CurrentScenic = Master.Scenic;
            string idcard = e.CommandArgument.ToString();
            ViewState["idcard"] = idcard;
            //bllticketassign.GetTicketInfoByIdCard(idcard, CurrentScenic, out totalyudingcount, out usedyudingcount,2);
            rptpayyd.DataSource = bllticketassign.GetTicketTypeByIdCard(ViewState["idcard"].ToString());
            rptpayyd.DataBind();
            if (rptpayyd.Items.Count == 0)
                rptpayyd.Visible = false;
            else
                rptpayyd.Visible = true;
            //yddj = bllticketprice.GetTicketPriceByScenicandtypeid(CurrentScenic.Id, 2).Price.ToString("0");
            //在线购买
            //bllticketassign.GetOlTicketInfoByIdcard(idcard, CurrentScenic, out totalolcount, out useolcount, 3);
            rptpayonline.DataSource = bllticketassign.GetTicketTypeByIdCard(ViewState["idcard"].ToString());
            rptpayonline.DataBind();
            if (rptpayonline.Items.Count == 0)
                rptpayonline.Visible = false;
            else
                rptpayonline.Visible = true;
            tp_nav.Attributes.Add("style", "margin-top:20px;");
            //list.Visible = false;
            detailinfo.Visible = true;
            ywdiv.Visible = true;
        }
    }
    [WebMethod]
    public static string GetAllHints(string scid)
    {
        Scenic s = new BLLScenic().GetScenicById(int.Parse(scid));
        List<TicketAssign> list = new BLLTicketAssign().GetIdcardandname("", "", s);
        Dictionary<string, string> data = new Dictionary<string, string>();
        foreach (TicketAssign item in list)
        {
            data.Add(item.Name + "/" + item.IdCard, "");
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
            if (item.IdCard == idcard)
            {
                flag = 1;
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
        username.InnerHtml = name;
        useridcard.InnerHtml = idcard;
        //预定
        CurrentScenic = Master.Scenic;
        ViewState["idcard"] = idcard;
        //bllticketassign.GetTicketInfoByIdCard(idcard, CurrentScenic, out totalyudingcount, out usedyudingcount, 2);
        rptpayyd.DataSource = bllticketassign.GetTicketTypeByIdCard(ViewState["idcard"].ToString());
        rptpayyd.DataBind();
        if (rptpayyd.Items.Count == 0)
            rptpayyd.Visible = false;
        else
            rptpayyd.Visible = true;
        //yddj = bllticketprice.GetTicketPriceByScenicandtypeid(CurrentScenic.Id, 2).Price.ToString("0");
        //在线购买
        //bllticketassign.GetOlTicketInfoByIdcard(idcard, CurrentScenic, out totalolcount, out useolcount, 3);
        rptpayonline.DataSource = bllticketassign.GetTicketTypeByIdCard(idcard);
        rptpayonline.DataBind();
        if (rptpayonline.Items.Count == 0)
            rptpayonline.Visible = false;
        else
            rptpayonline.Visible = true;
        tp_nav.Attributes.Add("style", "margin-top:20px;");
        ywdiv.Visible = true;
        //list.Visible = false;
        detailinfo.Visible = true;
        bindywrecord();
    }
    protected void btnselect_Click(object sender, EventArgs e)
    {
        string name = hfselectname.Value;
        string idcard = hfselectidcard.Value;
        username.InnerHtml = name;
        useridcard.InnerHtml = idcard;
        //预定
        CurrentScenic = Master.Scenic;
        ViewState["idcard"] = idcard;
        rptpayyd.DataSource = bllticketassign.GetTicketTypeByIdCard(ViewState["idcard"].ToString());
        rptpayyd.DataBind();
        if (rptpayyd.Items.Count == 0)
            rptpayyd.Visible = false;
        else
            rptpayyd.Visible = true;
        //yddj = bllticketprice.GetTicketPriceByScenicandtypeid(CurrentScenic.Id, 2).Price.ToString("0");
        //在线购买
        //bllticketassign.GetOlTicketInfoByIdcard(idcard, CurrentScenic, out totalolcount, out useolcount, 3);
        rptpayonline.DataSource = bllticketassign.GetTicketTypeByIdCard(idcard);
        rptpayonline.DataBind();
        if (rptpayonline.Items.Count == 0)
            rptpayonline.Visible = false;
        else
            rptpayonline.Visible = true;
        tp_nav.Attributes.Add("style", "margin-top:20px;");
        ywdiv.Visible = true;
        //list.Visible = false;
        detailinfo.Visible = true;

        bindywrecord();
    }
    protected void Btnckpass_Click(object sender, EventArgs e)
    {
        if (txtinfo.Text != "录入游客身份证或名字")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('无此身份证购票信息')", true);
        }
        //txtUseCount.Text = Regex.Replace(txtUseCount.Text, "[^0-9]", "");
        //txtolusecount.Text = Regex.Replace(txtolusecount.Text, "[^0-9]", "");
        int yditems = 0;
        foreach (RepeaterItem rptitem in rptpayyd.Items)
        {
            TextBox tb = rptitem.FindControl("txtUseCount") as TextBox;
            tb.Text = Regex.Replace(tb.Text, "[^0-9]", "");
            if (tb.Text == "")
                yditems++;
        }
        int olrptitems = 0;
        foreach (RepeaterItem rpitem in rptpayonline.Items)
        {
            TextBox tb = rpitem.FindControl("txtolusecount") as TextBox;
            tb.Text = Regex.Replace(tb.Text, "[^0-9]", "");
            if (tb.Text == "")
                olrptitems++;
        }
        CurrentScenic = Master.Scenic;
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
                    //bllticketassign.GetTicketInfoByIdCard(ViewState["idcard"].ToString(), CurrentScenic, out totalyudingcount, out usedyudingcount, 2);
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

            ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('验票通过')", true);
        }
        else
        {
            if (rptpayyd.Visible == true)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('请输入使用张数')", true);
                //bllticketassign.GetTicketInfoByIdCard(ViewState["idcard"].ToString(), CurrentScenic, out totalyudingcount, out usedyudingcount, 2);
                rptpayyd.DataSource = bllticketassign.GetTicketTypeByIdCard(ViewState["idcard"].ToString());
                rptpayyd.DataBind();
                if (rptpayyd.Items.Count == 0)
                    rptpayyd.Visible = false;
                else
                    rptpayyd.Visible = true;
                //yddj = bllticketprice.GetTicketPriceByScenicandtypeid(CurrentScenic.Id, 2).Price.ToString("0");
                //bllticketassign.GetOlTicketInfoByIdcard(ViewState["idcard"].ToString(), CurrentScenic, out totalolcount, out useolcount, 3);
                rptpayonline.DataSource = bllticketassign.GetTicketTypeByIdCard(ViewState["idcard"].ToString());
                rptpayonline.DataBind();
                return;
            }
        }
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
                ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('验票通过')", true);
            }

        }
        else
        {
            if (rptpayonline.Visible == true)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('请输入使用张数')", true);
                //bllticketassign.GetTicketInfoByIdCard(ViewState["idcard"].ToString(), CurrentScenic, out totalyudingcount, out usedyudingcount, 2);
                rptpayyd.DataSource = bllticketassign.GetTicketTypeByIdCard(ViewState["idcard"].ToString());
                rptpayyd.DataBind();
                if (rptpayyd.Items.Count == 0)
                    rptpayyd.Visible = false;
                else
                    rptpayyd.Visible = true;
                //yddj = bllticketprice.GetTicketPriceByScenicandtypeid(CurrentScenic.Id, 2).Price.ToString("0");
                //bllticketassign.GetOlTicketInfoByIdcard(ViewState["idcard"].ToString(), CurrentScenic, out totalolcount, out useolcount, 3);
                rptpayonline.DataSource = bllticketassign.GetTicketTypeByIdCard(ViewState["idcard"].ToString());
                rptpayonline.DataBind();
                return;
            }
        }
        //txtUseCount.Text = "";
        //txtolusecount.Text = "";
        //bllticketassign.GetTicketInfoByIdCard(ViewState["idcard"].ToString(), CurrentScenic, out totalyudingcount, out usedyudingcount, 2);
        rptpayyd.DataSource = bllticketassign.GetTicketTypeByIdCard(ViewState["idcard"].ToString());
        rptpayyd.DataBind();
        if (rptpayyd.Items.Count == 0)
            rptpayyd.Visible = false;
        else
            rptpayyd.Visible = true;
        //yddj = bllticketprice.GetTicketPriceByScenicandtypeid(CurrentScenic.Id, 2).Price.ToString("0");
        //bllticketassign.GetOlTicketInfoByIdcard(ViewState["idcard"].ToString(), CurrentScenic, out totalolcount, out useolcount, 3);
        rptpayonline.DataSource = bllticketassign.GetTicketTypeByIdCard(ViewState["idcard"].ToString());
        rptpayonline.DataBind();
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
            //txinfo.Attributes.Remove("class");
            //list.Visible = true;
            detailinfo.Visible = false;
            ywdiv.Visible = false;
            return;
        }
        else
        {
            string name = bllticketassign.GetTaByIdCard(idcard)[0].Name;
            username.InnerHtml = name;
            useridcard.InnerHtml = idcard;
            //预定
            CurrentScenic = Master.Scenic;
            ViewState["idcard"] = idcard;
            rptpayyd.DataSource = bllticketassign.GetTicketTypeByIdCard(ViewState["idcard"].ToString());
            rptpayyd.DataBind();
            if (rptpayyd.Items.Count == 0)
                rptpayyd.Visible = false;
            else
                rptpayyd.Visible = true;
            //yddj = bllticketprice.GetTicketPriceByScenicandtypeid(CurrentScenic.Id, 2).Price.ToString("0");
            //在线购买
            //bllticketassign.GetOlTicketInfoByIdcard(idcard, CurrentScenic, out totalolcount, out useolcount, 3);
            rptpayonline.DataSource = bllticketassign.GetTicketTypeByIdCard(idcard);
            rptpayonline.DataBind();
            if (rptpayonline.Items.Count == 0)
                rptpayonline.Visible = false;
            else
                rptpayonline.Visible = true;
            tp_nav.Attributes.Add("style", "margin-top:20px;");
            ywdiv.Visible = true;
            //list.Visible = false;
            detailinfo.Visible = true;

            bindywrecord();
        }
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
}