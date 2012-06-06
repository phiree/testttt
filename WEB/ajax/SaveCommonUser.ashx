<%@ WebHandler Language="C#" Class="SaveCommonUser" %>

using System;
using System.Web;
using System.Web.Security;
/// <summary>
/// 保存常用联系人.
/// </summary>
public class SaveCommonUser : IHttpHandler {

    BLL.BLLCommonUser bllCU = new BLL.BLLCommonUser();
    public void ProcessRequest (HttpContext context) {

       MembershipUser mu= Membership.GetUser();
       if (mu == null) return;
       Guid userId = (Guid)mu.ProviderUserKey;
        var req = context.Request;
        string paramcommonusers = req["cu"];
        char spliter='_';
        string[] cus = paramcommonusers.TrimEnd(spliter).Split(spliter);
        foreach (string s in cus)
        {
            string[] cuprop = s.Split('-');
            string name = cuprop[0];
            string idcard = cuprop[1];
            
            bllCU.Save(userId, name, idcard);
        
        }
        
      
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}

