using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using BLL;
using Model;
public partial class TourManagerDpt_EnterpriseMgr_Default : basepageMgrDpt
{


    /// <summary>
    /// 该部门辖区内所有企业名称列表,用于输入时的智能提示
    /// </summary>
    public string EntNames = string.Empty;
    BLLDJEnterprise bllEnt = new BLLDJEnterprise();
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMsg.Visible = false;
        BuildEntNames();
        if (!IsPostBack)
        {
            BindList();
        }
    }


    private void BuildEntNames()
    {
        IList<DJ_TourEnterprise> ents = bllEnt.GetRewardEntList(CurrentDpt, ParamEntType, RewardType.从未纳入 | RewardType.已纳入);
        System.Text.RegularExpressions.Regex Reg = new System.Text.RegularExpressions.Regex(@",|""|'");
        foreach (DJ_TourEnterprise ent in ents)
        {
            EntNames += "\\\"" + Reg.Replace(ent.Name, string.Empty) + "\\\",";
        }
        EntNames = EntNames.TrimEnd(',');
        EntNames = "[" + EntNames + "]";
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        //将所选企业纳入奖励范围
        //CHECK if the enterprise exists
        //todo:优化:bllenterprise优化.
        string entName = tbxName.Text.Trim();
        string errMsg;
        bllEnt.SetVerify(CurrentDpt, entName, RewardType.已纳入, out errMsg);

        lblMsg.Visible = true;
        cbxState.SelectedIndex = 1;
        BindList();

    }

    /// <summary>
    /// 绑定列表 筛选依据: 企业类型:宾馆/景点,
    /// </summary>
    private void BindList()
    {
        RewardType rt = 0;
        if (cbxState.Items[0].Selected)
        { rt = RewardType.已纳入 | RewardType.纳入后移除; }
        if (cbxState.Items[1].Selected)
        { rt = RewardType.已纳入; }
        if (cbxState.Items[2].Selected)
        { rt = RewardType.纳入后移除; }


        IList<Model.DJ_TourEnterprise> entList = bllEnt.GetRewardEntList(CurrentDpt, ParamEntType, rt).OrderByDescending(x => x.LastUpdateTime).ToList();
        rptEntList.DataSource = entList;
        rptEntList.DataBind();

    }



    /// <summary>
    /// 管理类型:宾馆/景区
    /// </summary>
    EnterpriseType paramEntType;
    public Model.EnterpriseType ParamEntType
    {

        get
        {
            string param = Request["entType"];
            if (!Enum.TryParse<EnterpriseType>(param, out paramEntType))
            {
                BLL.ErrHandler.Redirect(BLL.ErrType.ParamIllegal);
            }

            return paramEntType;

        }

    }

    enum UIEntType
    {
        宾馆 = 1,
        景区
    }

    protected void cbxState_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindList();
    }
    protected void rptEntList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int entId = int.Parse(e.CommandArgument.ToString());


        if (e.CommandName.ToLower() == "verify")
        {
            DJ_TourEnterprise ent = bllEnt.GetDJS8id(entId.ToString())[0];

            RewardType t = ent.GetRewart(CurrentDpt);
            t = t == RewardType.纳入后移除 ? RewardType.已纳入 : RewardType.纳入后移除;

            bllEnt.SetVerify(CurrentDpt, ent, t);
            BindList();
        }
    }
    protected void rptEntList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DJ_TourEnterprise ent = e.Item.DataItem as DJ_TourEnterprise;
            Button btnVerifyState = e.Item.FindControl("btnVerifyState") as Button;
            btnVerifyState.Text = ent.GetRewart(CurrentDpt) == RewardType.纳入后移除 ? "已移除,点击重新纳入" : "已纳入,点击移除";
        }
    }
}