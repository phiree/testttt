using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TourManagerDpt_EnterpriseMgr_Default : System.Web.UI.Page
{

   

    protected void Page_Load(object sender, EventArgs e)
    {

       
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    { 
        
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