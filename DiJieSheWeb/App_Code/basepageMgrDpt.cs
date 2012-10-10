using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Model;
/// <summary>
///basepage 的摘要说明
/// 政府管理用户的basepage,提供当前用户的行政管辖范围
/// </summary>
public class basepageMgrDpt : basepage
{
    public DJ_GovManageDepartment CurrentDpt
    {
        get
        {
            if (CurrentMember != null)
            {
                DJ_User_Gov govUser = (DJ_User_Gov)CurrentMember;
                DJ_GovManageDepartment govDpt = govUser.GovDpt;
                if (govDpt == null)
                {
                    BLL.ErrHandler.Redirect(BLL.ErrType.AccessDenied);
                }
                return govDpt;
            }
            else
            {
                BLL.ErrHandler.Redirect(BLL.ErrType.AccessDenied);
                return null;
            }
          
        }

    }



}