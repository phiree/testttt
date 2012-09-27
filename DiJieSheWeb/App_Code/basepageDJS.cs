using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Model;
/// <summary>
///basepage 的摘要说明
/// </summary>
public class basepageDJS :basepage
{
    public DJ_DijiesheInfo CurrentDJS;
 
    protected override void OnLoad(EventArgs e)
    {
        if (CurrentMember != null)
        {
            DJ_User_TourEnterprise entUser = (DJ_User_TourEnterprise)CurrentMember;
            CurrentDJS = (DJ_DijiesheInfo)entUser.Enterprise;
        }
    }
}