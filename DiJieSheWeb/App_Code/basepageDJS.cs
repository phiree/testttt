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
    public DJ_DijiesheInfo CurrentDJS
    {
        get
        {
            if (CurrentMember != null)
            {
                DJ_User_TourEnterprise entUser = (DJ_User_TourEnterprise)CurrentMember;
                DJ_DijiesheInfo dijieshe = (DJ_DijiesheInfo)entUser.Enterprise;
                if (dijieshe == null)
                {
                    BLL.ErrHandler.Redirect(BLL.ErrType.AccessDenied);
                }
                return dijieshe;
            }
            else
            {
                BLL.ErrHandler.Redirect(BLL.ErrType.AccessDenied);
                return null;
            }
          
        }

    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);



    }

}