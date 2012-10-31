using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
public partial class TourManagerDpt_EnterpriseMgr_Default : System.Web.UI.Page
{



    BLLDJEnterprise bllEnt = new BLLDJEnterprise();
    protected void Page_Load(object sender, EventArgs e)
    {

       
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    { 
        //将所选企业纳入奖励范围
        //CHECK if the enterprise exists
        //todo:优化:bllenterprise优化.
        string entName=tbxName.Text.Trim();
        IList<DJ_TourEnterprise> entL = bllEnt.GetDJS8name(entName);
        if (entL.Count == 0)
        { 
        
        }
       

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