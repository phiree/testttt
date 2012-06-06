using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
public partial class err : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string errMsg = string.Empty;
        string paramErrType = Request["err"];
        int errId;
        if (!int.TryParse(paramErrType, out errId))
        {
            errMsg = "参数有误";
            return;

        }
        ErrType errType;
        if (!Enum.TryParse(paramErrType, out errType))
        {
            errMsg = "参数有误";
            return;  
        }
        switch (errType)
        {
            case ErrType.UnknownError:
                errMsg = "未知错误";
                break;
            case ErrType.VoteInfoIsNull:
                errMsg = "投票信息有误";
                break;  
            case ErrType.AccessDenied:
                errMsg = "您没有访问此页面的权限";
                break;
            case ErrType.ParamIllegal:
                errMsg = "参数非法";
                break;
            case ErrType.QQOAuth:
                errMsg = "QQ服务器出错";
                break;
            case ErrType.SourceIllegal:
                errMsg = "来源不明";
                break;
        }
        lblMsg.Text = errMsg;
        
    }
}