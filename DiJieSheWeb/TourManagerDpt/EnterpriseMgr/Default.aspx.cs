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
    }

   
    private void BuildEntNames()
    {
       IList<DJ_TourEnterprise> ents= bllEnt.GetDJSForDpt(CurrentDpt.Area.Code);
       System.Text.RegularExpressions.Regex Reg = new System.Text.RegularExpressions.Regex(@",|""|'");
       foreach (DJ_TourEnterprise ent in ents)
       {
           EntNames += "\\\"" + Reg.Replace(ent.Name,string.Empty)+ "\\\",";
       }
       EntNames = EntNames.TrimEnd(',');
       EntNames = "["+ EntNames+ "]";
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    { 
        //将所选企业纳入奖励范围
        //CHECK if the enterprise exists
        //todo:优化:bllenterprise优化.
        string entName=tbxName.Text.Trim();
        string errMsg;
        bllEnt.SetVerify(CurrentDpt, entName, RewardType.已纳入, out errMsg);

        lblMsg.Visible = true;

    }

    /// <summary>
    /// 绑定列表 筛选依据: 企业类型:宾馆/景点,
    /// </summary>
    private void BindList()
    { }



    /// <summary>
    /// 管理类型:宾馆/景区
    /// </summary>
    UIEntType uiEntType;
    UIEntType UiEntType
    {

        get
        {
            string param = Request["entType"];
            if (!Enum.TryParse<UIEntType>(param, out uiEntType))
            {
                BLL.ErrHandler.Redirect(BLL.ErrType.ParamIllegal);
            }

            return uiEntType;

        }

    }

    enum UIEntType
    {
        宾馆 = 1,
        景区
    }
  
}