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
    BLLOperationLog bllOp = new BLLOperationLog();
    public EnterpriseType ParamEntType = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        ParseParam();
        lblMsg.Visible = false;
        BuildEntNames();
        if (!IsPostBack)
        {
            BindList();
            if (Request.Cookies["select_tab"] != null)
            {
                Response.Cookies["select_tab"].Value = "0";
            }
        }
    }
    private void ParseParam()
    {


        string param = Request["entType"];

        int intParam;
        if (!int.TryParse(param, out intParam))
        {
            BLL.ErrHandler.Redirect(BLL.ErrType.ParamIllegal);
        }
        if (!Enum.IsDefined(typeof(Model.EnterpriseType), intParam))
        {

    

            BLL.ErrHandler.Redirect(BLL.ErrType.ParamIllegal);

        }


        ParamEntType = (EnterpriseType)intParam;


    }


    private void BuildEntNames()
    {
        IList<DJ_TourEnterprise> ents = bllEnt.GetRewardEntList(string.Empty,CurrentDpt, ParamEntType, RewardType.从未纳入);
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
        bllEnt.SetVerify(CurrentDpt.Area, entName, RewardType.已纳入, ParamEntType, out errMsg);
        if (!string.IsNullOrEmpty(errMsg))
        {
            lblMsg.Text = errMsg;
            lblMsg.Visible = true;
        }
      
        BindList();
      

    }

    /// <summary>
    /// 绑定列表 筛选依据: 企业类型:宾馆/景点,
    /// </summary>
    private void BindList()
    {
        RewardType rt = 0;
        int index = int.Parse(hfState.Value);
        if (index==0)
        { rt = RewardType.已纳入 | RewardType.纳入后移除; }
        if (index == 1)
        { rt = RewardType.已纳入; }
        if (index == 2)
        { rt = RewardType.纳入后移除; }


        IList<Model.DJ_TourEnterprise> entList = bllEnt.GetRewardEntList(string.Empty,CurrentDpt, ParamEntType, rt).OrderByDescending(x => x.LastUpdateTime).ToList();
        rptEntList.DataSource = entList;
        rptEntList.DataBind();

    }



    /// <summary>
    /// 管理类型:宾馆/景区
    /// </summary>






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

            RewardType currentType = ent.GetRewart(CurrentDpt.Area);
            RewardType t = currentType == RewardType.纳入后移除 ? RewardType.已纳入 : RewardType.纳入后移除;

            bllEnt.SetVerify(ent, t);
            Model.OperationLog log = new OperationLog();
            log.Member = CurrentMember;
            log.OperationTime = DateTime.Now;
            log.OprationType = OperationType.管理部门管理纳入企业;
            log.TargetId = entId.ToString();
            log.Content = "从:" + currentType.ToString() + "变为:" + t.ToString();
            bllOp.Save(log);
            BindList();
        }
    }
    protected void rptEntList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DJ_TourEnterprise ent = e.Item.DataItem as DJ_TourEnterprise;
            Button btnVerifyState = e.Item.FindControl("btnVerifyState") as Button;
            btnVerifyState.Text = ent.GetRewart(CurrentDpt.Area) == RewardType.纳入后移除 ? "已移除,点击重新纳入" : "已纳入,点击移除";
            if (btnVerifyState.Text == "已移除,点击重新纳入")
            {
                btnVerifyState.Attributes.CssStyle["color"] = "#DE1E1E";
            }
            else
            {
                btnVerifyState.Attributes.CssStyle["color"] = "#11406C";
            }
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindList();
    }
}