using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Model;
/// <summary>
///根据不同用户类型跳转到不同页面
/// </summary>
public class Redirector 
{
    public static string RedirectForUser(TourMembership member)
    {
      
        string redirectUrl = string.Empty;
        Type UserType = member.GetType();
      
     
        if (UserType == typeof(DJ_User_Gov))
        {
            redirectUrl = "/TourManagerDpt/";
        }
        else if (UserType == typeof(DJ_User_TourEnterprise))
        {
            DJ_User_TourEnterprise entUser = (DJ_User_TourEnterprise)member;
            if (entUser == null)
            { throw new Exception("企业管理员没有对应的企业" ); }
            DJ_TourEnterprise ent = entUser.Enterprise;
            if (ent.Type == EnterpriseType.旅行社)
            {
                redirectUrl = "/LocalTravelAgent/";
            }
            else
            {
                redirectUrl = "/TourEnterprise/";
            }
           
        }
        else if (member.Name == "admin")
        {
            redirectUrl = "/admin/";
        }
        return redirectUrl;
    }
}