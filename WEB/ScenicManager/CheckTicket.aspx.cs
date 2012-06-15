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
    protected void Page_Load(object sender, EventArgs e)
    {
        hfscid.Value = Master.Scenic.Id.ToString();
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
        //绑定预定信息
        rptpeopleinfo.DataSource = new BLLTicketAssign().GetIdcardandname("", "", CurrentScenic);
        rptpeopleinfo.DataBind();
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
            bllticketassign.GetTicketInfoByIdCard(idcard, CurrentScenic, out totalyudingcount, out usedyudingcount,2);
            if (totalyudingcount == 0)
                idcardyuding.Visible = false;
            else
                idcardyuding.Visible = true;
            yddj = bllticketprice.GetTicketPriceByScenicandtypeid(CurrentScenic.Id, 2).Price.ToString("0");
            //在线购买
            bllticketassign.GetOlTicketInfoByIdcard(idcard, CurrentScenic, out totalolcount, out useolcount, 3);
            if (totalolcount == 0)
                idcardol.Visible = false;
            else
                idcardol.Visible = true;
            tp_nav.Attributes.Add("style", "margin-top:20px;");
            //list.Visible = false;
            detailinfo.Visible = true;
            ywdiv.Visible = true;
        }
    }
    protected void btnpay_Click(object sender, EventArgs e)
    {
        if (txtUseCount.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('请输入使用数量')", true);
            bllticketassign.GetTicketInfoByIdCard(ViewState["idcard"].ToString(), CurrentScenic, out totalyudingcount, out usedyudingcount, 2);
            yddj = bllticketprice.GetTicketPriceByScenicandtypeid(CurrentScenic.Id, 2).Price.ToString("0");
            bllticketassign.GetOlTicketInfoByIdcard(ViewState["idcard"].ToString(), CurrentScenic, out totalolcount, out useolcount, 3);
            return;
        }
        tp_nav.Attributes.Add("style", "margin:20px; auto;");
        ywdiv.Visible = true;
        //txinfo.Attributes.Remove("class");
        CurrentScenic = Master.Scenic;
        int wtusecount = int.Parse(txtUseCount.Text);
        bllticketassign.GetTicketInfoByIdCard(ViewState["idcard"].ToString(), CurrentScenic, out totalyudingcount, out usedyudingcount,2);
        if (wtusecount > totalyudingcount - usedyudingcount)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('使用数超过预定数，如需添加请选择下面的添加预定')", true);
            bllticketassign.GetTicketInfoByIdCard(ViewState["idcard"].ToString(), CurrentScenic, out totalyudingcount, out usedyudingcount, 2);
            yddj = bllticketprice.GetTicketPriceByScenicandtypeid(CurrentScenic.Id, 2).Price.ToString("0");
            bllticketassign.GetOlTicketInfoByIdcard(ViewState["idcard"].ToString(), CurrentScenic, out totalolcount, out useolcount, 3);
            return;
        }
        else
        {
            for (int i = 0; i < wtusecount; i++)
            {
                IList<TicketAssign> list = bllticketassign.GetNotUsedTicketAssign(ViewState["idcard"].ToString(), CurrentScenic,2);
                TicketAssign ta = list[0];
                ta.IsUsed = true;
                ta.UsedTime = DateTime.Now;
                bllticketassign.SaveOrUpdate(ta);
            }
        }
        bllticketassign.GetTicketInfoByIdCard(ViewState["idcard"].ToString(), CurrentScenic, out totalyudingcount, out usedyudingcount,2);
        yddj = bllticketprice.GetTicketPriceByScenicandtypeid(CurrentScenic.Id, 2).Price.ToString("0");
        bllticketassign.GetOlTicketInfoByIdcard(ViewState["idcard"].ToString(), CurrentScenic, out totalolcount, out useolcount, 3);
    }
    //protected void btnaddyuding_Click(object sender, EventArgs e)
    //{
    //    if (txtyudingcount.Text == "")
    //    {
    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('请输入需要预定的张数')", true);
    //        bllticketassign.GetTicketInfoByIdCard(ViewState["idcard"].ToString(), CurrentScenic, out totalyudingcount, out usedyudingcount, 2);
    //        yddj = bllticketprice.GetTicketPriceByScenicandtypeid(CurrentScenic.Id, 2).Price.ToString("0");
    //        bllticketassign.GetOlTicketInfoByIdcard(ViewState["idcard"].ToString(), CurrentScenic, out totalolcount, out useolcount, 3);
    //        return;
    //    }
    //    tp_nav.Attributes.Add("style", "margin-top:20px;");
    //    //txinfo.Attributes.Remove("class");
    //    CurrentScenic = Master.Scenic;
    //    int jxydcount = int.Parse(txtyudingcount.Text);
    //    TicketAssign ta = bllticketassign.GetLasetRecordByidcard(ViewState["idcard"].ToString(),CurrentScenic,2);
    //    OrderDetail od = ta.OrderDetail;
    //    od.Quantity = od.Quantity + jxydcount;
    //    od.Remark = "在景区预定" + jxydcount + "张门票";
    //    bllorderdetail.saveorupdate(od);
    //    for (int i = 0; i < jxydcount; i++)
    //    {
    //        TicketAssign ticketassign = new TicketAssign();
    //        ticketassign.IdCard = ViewState["idcard"].ToString();
    //        ticketassign.IsUsed = false;
    //        ticketassign.Name = ta.Name;
    //        ticketassign.OrderDetail = od;
    //        ticketassign.UsedTime = DateTime.Now;
    //        bllticketassign.SaveOrUpdate(ticketassign);
    //    }
    //    bllticketassign.GetTicketInfoByIdCard(ViewState["idcard"].ToString(), CurrentScenic, out totalyudingcount, out usedyudingcount,2);
    //    yddj = bllticketprice.GetTicketPriceByScenicandtypeid(CurrentScenic.Id, 2).Price.ToString("0");
    //    bllticketassign.GetOlTicketInfoByIdcard(ViewState["idcard"].ToString(), CurrentScenic, out totalolcount, out useolcount, 3);
        
    //}
    protected void btnok_Click(object sender, EventArgs e)
    {
        //txinfo.Attributes.Remove("class");
        tp_nav.Attributes.Add("style", "margin-top:20px;");
        ywdiv.Visible = true;
        CurrentScenic = Master.Scenic;
        int oluse = int.Parse(txtolusecount.Text);
        bllticketassign.GetOlTicketInfoByIdcard(ViewState["idcard"].ToString(), CurrentScenic, out totalolcount, out useolcount, 3);
        if (oluse > totalolcount - useolcount)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('使用数超过已支付票数，如需添加请选择下面的添加预定')", true);
            bllticketassign.GetTicketInfoByIdCard(ViewState["idcard"].ToString(), CurrentScenic, out totalyudingcount, out usedyudingcount, 2);
            yddj = bllticketprice.GetTicketPriceByScenicandtypeid(CurrentScenic.Id, 2).Price.ToString("0");
            bllticketassign.GetOlTicketInfoByIdcard(ViewState["idcard"].ToString(), CurrentScenic, out totalolcount, out useolcount, 3);
            return;
        }
        for (int i = 0; i < oluse; i++)
        {
            IList<TicketAssign> list = bllticketassign.Getolnotusedticketassign(ViewState["idcard"].ToString(), CurrentScenic, 3);
            TicketAssign ta = list[0];
            ta.IsUsed = true;
            ta.UsedTime = DateTime.Now;
            bllticketassign.SaveOrUpdate(ta);
        }
        bllticketassign.GetTicketInfoByIdCard(ViewState["idcard"].ToString(), CurrentScenic, out totalyudingcount, out usedyudingcount, 2);
        yddj = bllticketprice.GetTicketPriceByScenicandtypeid(CurrentScenic.Id, 2).Price.ToString("0");
        bllticketassign.GetOlTicketInfoByIdcard(ViewState["idcard"].ToString(), CurrentScenic, out totalolcount, out useolcount, 3);
        
    }



    [WebMethod]
    public static string GetAllHints(string scid)
    {
        Scenic s=new BLLScenic().GetScenicById(int.Parse(scid));
        List<TicketAssign> list= new BLLTicketAssign().GetIdcardandname("", "",s);
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
        string name = hfdata.Value.Split('/')[0];
        string idcard = hfdata.Value.Split('/')[1];
        username.InnerHtml = name;
        useridcard.InnerHtml = idcard;
        //预定
        CurrentScenic = Master.Scenic;
        ViewState["idcard"] = idcard;
        bllticketassign.GetTicketInfoByIdCard(idcard, CurrentScenic, out totalyudingcount, out usedyudingcount, 2);
        if (totalyudingcount == 0)
            idcardyuding.Visible = false;
        else
            idcardyuding.Visible = true;
        yddj = bllticketprice.GetTicketPriceByScenicandtypeid(CurrentScenic.Id, 2).Price.ToString("0");
        //在线购买
        bllticketassign.GetOlTicketInfoByIdcard(idcard, CurrentScenic, out totalolcount, out useolcount, 3);
        if (totalolcount == 0)
            idcardol.Visible = false;
        else
            idcardol.Visible = true;
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
        bllticketassign.GetTicketInfoByIdCard(idcard, CurrentScenic, out totalyudingcount, out usedyudingcount, 2);
        if (totalyudingcount == 0)
            idcardyuding.Visible = false;
        else
            idcardyuding.Visible = true;
        yddj = bllticketprice.GetTicketPriceByScenicandtypeid(CurrentScenic.Id, 2).Price.ToString("0");
        //在线购买
        bllticketassign.GetOlTicketInfoByIdcard(idcard, CurrentScenic, out totalolcount, out useolcount, 3);
        if (totalolcount == 0)
            idcardol.Visible = false;
        else
            idcardol.Visible = true;
        tp_nav.Attributes.Add("style", "margin-top:20px;");
        ywdiv.Visible = true;
        //list.Visible = false;
        detailinfo.Visible = true;

        bindywrecord();
    }
    protected void Btnckpass_Click(object sender, EventArgs e)
    {
        CurrentScenic = Master.Scenic;
        if (txtUseCount.Text != "")
        {
            int wtusecount = int.Parse(txtUseCount.Text);
            bllticketassign.GetTicketInfoByIdCard(ViewState["idcard"].ToString(), CurrentScenic, out totalyudingcount, out usedyudingcount, 2);
            if (wtusecount > totalyudingcount - usedyudingcount)
            {
                int jxydcount = wtusecount-totalyudingcount+usedyudingcount;
                TicketAssign ta = bllticketassign.GetLasetRecordByidcard(ViewState["idcard"].ToString(), CurrentScenic, 2);
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
                IList<TicketAssign> list = bllticketassign.GetNotUsedTicketAssign(ViewState["idcard"].ToString(), CurrentScenic, 2);
                TicketAssign ta = list[0];
                ta.IsUsed = true;
                ta.UsedTime = DateTime.Now;
                bllticketassign.SaveOrUpdate(ta);
            }
        }
        if (txtolusecount.Text != "")
        {
            int oluse = int.Parse(txtolusecount.Text);
            for (int i = 0; i < oluse; i++)
            {
                IList<TicketAssign> list = bllticketassign.Getolnotusedticketassign(ViewState["idcard"].ToString(), CurrentScenic, 3);
                TicketAssign ta = list[0];
                ta.IsUsed = true;
                ta.UsedTime = DateTime.Now;
                bllticketassign.SaveOrUpdate(ta);
            }
        }
        bllticketassign.GetTicketInfoByIdCard(ViewState["idcard"].ToString(), CurrentScenic, out totalyudingcount, out usedyudingcount, 2);
        yddj = bllticketprice.GetTicketPriceByScenicandtypeid(CurrentScenic.Id, 2).Price.ToString("0");
        bllticketassign.GetOlTicketInfoByIdcard(ViewState["idcard"].ToString(), CurrentScenic, out totalolcount, out useolcount, 3);
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
        string idcard = hfautoidcard.Value;
        IList<TicketAssign> list = bllticketassign.GetTaByIdCard(idcard);
        if (list.Count == 0)
            return;
        else
        {
            string name = bllticketassign.GetTaByIdCard(idcard)[0].Name;
            username.InnerHtml = name;
            useridcard.InnerHtml = idcard;
            //预定
            CurrentScenic = Master.Scenic;
            ViewState["idcard"] = idcard;
            bllticketassign.GetTicketInfoByIdCard(idcard, CurrentScenic, out totalyudingcount, out usedyudingcount, 2);
            if (totalyudingcount == 0)
                idcardyuding.Visible = false;
            else
                idcardyuding.Visible = true;
            yddj = bllticketprice.GetTicketPriceByScenicandtypeid(CurrentScenic.Id, 2).Price.ToString("0");
            //在线购买
            bllticketassign.GetOlTicketInfoByIdcard(idcard, CurrentScenic, out totalolcount, out useolcount, 3);
            if (totalolcount == 0)
                idcardol.Visible = false;
            else
                idcardol.Visible = true;
            tp_nav.Attributes.Add("style", "margin-top:20px;");
            ywdiv.Visible = true;
            //list.Visible = false;
            detailinfo.Visible = true;

            bindywrecord();
        }
    }
}