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
    DJ_GovManageDepartment currentDpt;
    public DJ_GovManageDepartment CurrentDpt
    {
        get
        {
            if (currentDpt == null)
            {
                if (CurrentMember != null)
                {
                    DJ_User_Gov govUser = (DJ_User_Gov)CurrentMember;
                    currentDpt = govUser.GovDpt;
                    if (currentDpt == null)
                    {
                        BLL.ErrHandler.Redirect(BLL.ErrType.AccessDenied);
                    }
                    return currentDpt;
                }
                else
                {
                    BLL.ErrHandler.Redirect(BLL.ErrType.AccessDenied);
                    return null;
                }
            }
            return currentDpt;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Obsolete("使用 Area.Level属性")]
    public string CurrentDptLevel {
        get { 
            //开始2位编号
            string bCode = CurrentDpt.Area.Code.Substring(0, 2);
            //中间2位编号
            string mCode = CurrentDpt.Area.Code.Substring(2, 2);
            //最后2位编号
            string lCode = CurrentDpt.Area.Code.Substring(4, 2);
            if (mCode == "00")
            {
                //省级
                return "1";
            }
            else if (lCode == "00")
            {
                //市级
                return "2";
            }
            else
            {
                return "3";
            }
        }
    }
}