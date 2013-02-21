using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class ErrHandler
    {
        const string errorPageUrl = "/err.aspx";

        public static void Redirect(ErrType errType)
        {
            Redirect(errType, string.Empty);
        }
        public static void Redirect(ErrType errType,string errMsg)
        {
            Uri reffer = System.Web.HttpContext.Current.Request.UrlReferrer;
            if (reffer != null)
            {
                errMsg += "(" + reffer.AbsoluteUri;
            }
            TourLog.ErrorLog.Error(errMsg);
            System.Web.HttpContext.Current.Response.Redirect(errorPageUrl + "?err=" + (int)errType,true);
        }
    }
   public enum ErrType
    {
       UnknownError
       ,VoteInfoIsNull
        ,AccessDenied//权限不足，禁止访问。
       ,ParamIllegal //参数非法
       ,QQOAuth
       ,SourceIllegal//来路不正
       ,ObjectIsNull//对象为空
    }
}
