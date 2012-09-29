<%@ WebHandler Language="C#" Class="MemidHandler" %>

using System;
using System.Web;
using System.Linq;

public class MemidHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        string[] datas = context.Request.Form[0].Split(new char[] { '{' }, StringSplitOptions.RemoveEmptyEntries);
        BLL.BLLDJEnterprise bllDJS = new BLL.BLLDJEnterprise();
        string groupid=context.Request.Cookies["GROUPID"].Value;
        Model.DJ_TourGroup tg = bllDJS.GetGroup8gid(groupid);
        //清除原有成员,重新加入成员
        tg.Members.Clear();
        //Model.DJ_TourGroupMember tgm = new Model.DJ_TourGroupMember();
        foreach (var item in datas)
        {
            string[] tmp = item.Split(new char[] { ',' });
            string memtype = tmp[0];
            string memname = tmp[1];
            string memid = tmp[2];
            string memphone = tmp[3];
            //Model.DJ_TourGroupMember temp=
            //    tg.Members.First<Model.DJ_TourGroupMember>(x => x.RealName == memname);
            ////已经存在该成员
            //if (temp != null)
            //{ 
            
            //}
            tg.Members.Add(new Model.DJ_TourGroupMember()
            {
               RealName=memname,
               PhoneNum=memphone,
               Gender="男",
               IdCardNo=memid,
               IsChild=false,
               Keeper="监护人"
            });
        }
        bllDJS.UpdateGroup(tg);
        context.Response.Write("成功");
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}