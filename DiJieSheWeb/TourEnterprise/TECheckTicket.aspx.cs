using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.Web.Services;
using System.Runtime.Serialization.Json;
using System.IO;

public partial class TourEnterprise_TECheckTicket : System.Web.UI.Page
{
    BLLDJTourGroup blldjtourgroup = new BLLDJTourGroup();
    BLLDJConsumRecord blldjcr = new BLLDJConsumRecord();
    BLLDJRoute blldjroute = new BLLDJRoute();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            init();
        }
    }

    private void init()
    {
        detailinfo.Visible = false;
        rptGroupList.DataSource = blldjtourgroup.GetTourGroupByTEId(Master.CurrentTE.Id);
        rptGroupList.DataBind();
        hfetid.Value = Master.CurrentTE.Id.ToString();
    }


    private void bind()
    {
        if (txtTE_info.Text.Trim() != "")
        {
            string[] strinfos = txtTE_info.Text.Trim().Split('/');
            if (strinfos.Length > 1)
            {
                string idcard = strinfos[1];
                int flag = 0;
                foreach (DJ_Group_Worker work in new BLLDJTourGroup().GetGuiderWorkerByTE(Master.CurrentTE).ToList())
                {
                    if (work.IDCard.Substring(0, 6) + "********" + work.IDCard.Substring(14) == idcard)
                    {
                        flag = 1;
                        idcard = work.IDCard;
                    }
                }
                if (flag == 1)
                {
                    ViewState["idcard"] = idcard;
                    BindRptByIdcard(idcard);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(txtTE_info, txtTE_info.GetType(), "s", "alert('无此导游身份证信息')", true);
                    txtTE_info.Text = "";
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(txtTE_info, txtTE_info.GetType(), "s", "alert('无此导游身份证信息')", true);
                txtTE_info.Text = "";
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(txtTE_info, txtTE_info.GetType(), "s", "alert('无此导游身份证信息')", true);
            txtTE_info.Text = "";
        }
        BindPrintLink();
    }

    int Index = 0;
    protected void rptTourGroupInfo_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            DJ_TourGroup dj_tourgroup = e.Item.DataItem as DJ_TourGroup;
            Literal laGuideName = e.Item.FindControl("laGuideName") as Literal;
            foreach (DJ_Group_Worker work in dj_tourgroup.Workers)
            {
                if (work.WorkerType == DJ_GroupWorkerType.导游)
                {
                    laGuideName.Text += work.Name;
                }
            }
            HiddenField hfroute = e.Item.FindControl("hfrouteId") as HiddenField;
            int flag = 0;
            foreach (DJ_Route route in dj_tourgroup.Routes)
            {
                if (dj_tourgroup.BeginDate.AddDays(route.DayNo-1).ToShortDateString() == DateTime.Now.ToShortDateString()&&route.Enterprise.Id==Master.CurrentTE.Id)
                {
                    if (flag == Index)
                    {
                        hfroute.Value = route.Id.ToString();
                        Literal laChecked = e.Item.FindControl("laChecked") as Literal;
                        CheckBox selectItem = e.Item.FindControl("cbSelect") as CheckBox;
                        TextBox tbAdult = e.Item.FindControl("txtAdultsAmount") as TextBox;
                        TextBox tbChild = e.Item.FindControl("txtChildrenAmount") as TextBox;
                        TextBox tbLiveDay = e.Item.FindControl("txtLiveDay") as TextBox;
                        if (blldjcr.GetGroupConsumRecordByRouteId(route.Id) != null)
                        {
                            laChecked.Text = "已验证";
                            selectItem.Enabled = false;
                            tbAdult.Enabled = false;
                            tbChild.Enabled = false;
                            tbLiveDay.Enabled = false;
                        }
                        else
                        {
                            laChecked.Text = "未验证";
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

    protected void txtTE_info_Click(object sender, EventArgs e)
    {
        bind();
    }

    protected void btnCheckOut_Click(object sender, EventArgs e)
    {
        int guideritems, IsSelecttiem;
        IsCanChecked(out guideritems, out IsSelecttiem);
        if (IsSelecttiem != 0 && IsSelecttiem != guideritems)
        {
            foreach (RepeaterItem guideritem in rptTourGroupInfo.Items)
            {
                CheckBox hick = guideritem.FindControl("cbSelect") as CheckBox;
                if (hick.Checked && hick.Enabled)
                {
                    TextBox tbAdult = guideritem.FindControl("txtAdultsAmount") as TextBox;
                    TextBox tbChild = guideritem.FindControl("txtChildrenAmount") as TextBox;
                    TextBox tbLiveDay = guideritem.FindControl("txtLiveDay") as TextBox;
                    int MaxLiveDay;
                    HiddenField hfrouteid = guideritem.FindControl("hfrouteId") as HiddenField;
                    DJ_Route route = blldjroute.GetById(Guid.Parse(hfrouteid.Value));
                    List<DJ_Route> listWroute= blldjcr.GetLiveRouteByDay(out MaxLiveDay, int.Parse(tbLiveDay.Text), Master.CurrentTE, route);
                    if (MaxLiveDay < int.Parse(tbLiveDay.Text))
                    {
                        ScriptManager.RegisterStartupScript(btnCheckOut, btnCheckOut.GetType(), "s", "alert('住宿天数大于预定天数，请重新填写')", true);
                        break;
                    }
                    else if (tbAdult.Text != "" && tbChild.Text != "")
                    {
                        blldjcr.SaveList(listWroute, int.Parse(tbAdult.Text), int.Parse(tbChild.Text), int.Parse(tbLiveDay.Text));
                        BindPrintLink();
                        ScriptManager.RegisterStartupScript(btnCheckOut, btnCheckOut.GetType(), "s", "printTicket('验证成功，是否需要打印？')", true);
                        BindRptByIdcard(ViewState["idcard"].ToString());
                        break;
                    }
                }
            }
        }
    }

    private bool Verify(string adultamout, string childrenamout)
    {
        if (adultamout == "" || childrenamout == "")
        {
            ScriptManager.RegisterStartupScript(btnCheckOut, btnCheckOut.GetType(), "s", "alert('成人或者儿童数量不能为空，请重新填写')", true);
            return false;
        }
        return true;
    }

    /// <summary>
    /// 根据省份证号绑定数据
    /// </summary>
    /// <param name="idcard"></param>
    private void BindRptByIdcard(string idcard)
    {
        rptTourGroupInfo.DataSource = blldjtourgroup.GetTgByIdcardAndTE(idcard, Master.CurrentTE);
        rptTourGroupInfo.DataBind();
        if (rptTourGroupInfo.Items.Count > 0)
        {
            CheckBox hirb = rptTourGroupInfo.Items[0].FindControl("cbSelect") as CheckBox;
            hirb.Checked = true;
            detailinfo.Visible = true;
        }
        else
        {
            detailinfo.Visible = false;
            ScriptManager.RegisterStartupScript(txtTE_info, txtTE_info.GetType(), "s", "alert('无此导游身份证信息')", true);
        }
    }

    protected void btnBind_Click(object sender, EventArgs e)
    {
        string idcard = hfidcard.Value;
        int flag = 0;
        foreach (DJ_Group_Worker work in new BLLDJTourGroup().GetGuiderWorkerByTE(Master.CurrentTE).ToList())
        {
            if (work.IDCard.Substring(0, 6) + "********" + work.IDCard.Substring(14) == idcard)
            {
                flag = 1;
                idcard = work.IDCard;
            }
        }
        if (flag == 1)
        {
            ViewState["idcard"] = idcard;

            if (!string.IsNullOrEmpty(idcard))
            {
                BindRptByIdcard(idcard);
            }
            else
            {
                ScriptManager.RegisterStartupScript(txtTE_info, txtTE_info.GetType(), "s", "alert('无此导游身份证信息')", true);
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(txtTE_info, txtTE_info.GetType(), "s", "alert('无此导游身份证信息')", true);
        }
        BindPrintLink();
    }

    protected void rptRoute_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            DJ_Route route = e.Item.DataItem as DJ_Route;
            CheckBox cbSelect = e.Item.FindControl("ChSelect") as CheckBox;
            Literal LaIsCheck = e.Item.FindControl("LaIsCheck") as Literal;
            DJ_GroupConsumRecord gcr = blldjcr.GetGroupConsumRecordByRouteId(route.Id);
            if (gcr != null)
            {
                cbSelect.Checked = true;
                cbSelect.Enabled = false;
                LaIsCheck.Text = "已验证";
            }
            else
            {
                LaIsCheck.Text = "未验证";
            }
        }
    }

    #region 验票通过前审核
    public bool IsCanChecked(out int guideritems, out int IsSelecttiem)
    {
        guideritems = 0;
        IsSelecttiem = 0;
        int HaveYz = 0;
        foreach (RepeaterItem rpitem in rptTourGroupInfo.Items)
        {
            CheckBox hick = rpitem.FindControl("cbSelect") as CheckBox;
            if (hick.Checked && hick.Enabled)
            {
                IsSelecttiem++;
                TextBox tbAdult = rpitem.FindControl("txtAdultsAmount") as TextBox;
                TextBox tbChild = rpitem.FindControl("txtChildrenAmount") as TextBox;
                TextBox tbLiveDay = rpitem.FindControl("txtLiveDay") as TextBox;
                tbAdult.Text = Regex.Replace(tbAdult.Text, "[^0-9]", "");
                tbChild.Text = Regex.Replace(tbChild.Text, "[^0-9]", "");
                tbLiveDay.Text = Regex.Replace(tbChild.Text, "[^0-9]", "");
                if (tbAdult.Text == "" || tbChild.Text == "" || tbLiveDay.Text=="")
                {
                    guideritems++;
                }
            }
            if (hick.Checked && !hick.Enabled)
            {
                HaveYz = 1;
            }
        }
        if (IsSelecttiem == 0)
        {
            if(HaveYz==1)
                ScriptManager.RegisterStartupScript(btnCheckOut, btnCheckOut.GetType(), "s", "printTicket('请选择一个未验证的团队信息，是否对已验证的团队进行打印？')", true);
            else
                ScriptManager.RegisterStartupScript(btnCheckOut, btnCheckOut.GetType(), "s", "alert('请选择一个未验证的团队信息')", true);
            return false;
        }
        else if (IsSelecttiem == guideritems)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('请输入完整使用人数和住宿天数')", true);
            return false;
        }
        return true;
    }
    #endregion


    /// <summary>
    /// 为前台autocomplete插件做的ajax方法
    /// </summary>
    /// <param name="scid">旅游单位id</param>
    /// <returns></returns>
    [WebMethod]
    public static string GetAllHints(string etid)
    {
        List<DJ_Group_Worker> ListGw= new BLLDJTourGroup().GetTourGroupByTEId(int.Parse(etid)).ToList();
        Dictionary<string, string> data = new Dictionary<string, string>();
        foreach (DJ_Group_Worker item in ListGw)
        {
            data.Add(item.Name + "/" + item.IDCard.Substring(0, 6) + "********" + item.IDCard.Substring(14), "");
        }
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(data.GetType());
        using (MemoryStream ms = new MemoryStream())
        {
            serializer.WriteObject(ms, data);
            return System.Text.Encoding.UTF8.GetString(ms.ToArray());
        }
    }
    private void BindPrintLink()
    {
        string routeids = "";
        foreach (RepeaterItem item in rptTourGroupInfo.Items)
        {
            HiddenField hfrouteId = item.FindControl("hfrouteId") as HiddenField;
            DJ_GroupConsumRecord record= blldjcr.GetGroupConsumRecordByRouteId(Guid.Parse(hfrouteId.Value));
            if(record!=null)
                routeids += hfrouteId.Value + ",";
        }
        btnPrint.HRef="/TourEnterprise/PrintCer.aspx?routeids=" + routeids;
        //List<DJ_GroupConsumRecord> Listgcr = new List<DJ_GroupConsumRecord>();
        //string[] routeidsting = routeids.Split(',');
        //foreach (string routeid in routeidsting)
        //{
        //    if (routeid != "")
        //        Listgcr.Add(blldjcr.GetGroupConsumRecordByRouteId(Guid.Parse(routeid)));
        //}
        //rptPrint.DataSource = Listgcr;
        //rptPrint.DataBind();
    }

    protected void rptPrint_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Literal laGuiderName = e.Item.FindControl("laGuiderName") as Literal;
            DJ_GroupConsumRecord gcr = e.Item.DataItem as DJ_GroupConsumRecord;
            foreach (DJ_Group_Worker work in gcr.Route.DJ_TourGroup.Workers.Where(x => x.WorkerType == DJ_GroupWorkerType.导游))
            {
                laGuiderName.Text += work.Name + " ";
            }

        }
    }
}