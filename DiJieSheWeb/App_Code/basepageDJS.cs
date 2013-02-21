using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Model;
/// <summary>
///basepage 的摘要说明
/// </summary>
public class basepageDJS : basepage
{
    private DJ_DijiesheInfo currentDJS;
    public DJ_DijiesheInfo CurrentDJS
    {
        get
        {
            if (currentDJS == null)
            {
                if (CurrentMember != null)
                {
                    DJ_User_TourEnterprise entUser = (DJ_User_TourEnterprise)CurrentMember;
                    DJ_DijiesheInfo dijieshe = (DJ_DijiesheInfo)entUser.Enterprise;

                    if (dijieshe == null)
                    {
                        BLL.ErrHandler.Redirect(BLL.ErrType.AccessDenied,"该用户没有对应的地接社"+CurrentMember.Name);
                    }
                    currentDJS = dijieshe;
                }
                else
                {
                    BLL.ErrHandler.Redirect(BLL.ErrType.AccessDenied,"currentnumber为空");

                }
            }
            return currentDJS;
        }
    }
}