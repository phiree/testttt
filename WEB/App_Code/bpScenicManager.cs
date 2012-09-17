using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using BLL;
using System.Web.Security;
/// <summary>
///bpScenicManager 的摘要说明
/// </summary>
public class bpScenicManager : basepage
{
    protected Scenic CurrentScenic;
    protected BLLScenic BllScenic = BLLFactory.CreateBLLScenic();
    protected override void OnLoad(EventArgs e)
    {
        CurrentUser = Membership.GetUser();
        CurrentScenic = new BLLMembership().GetScenicAdmin((Guid)CurrentUser.ProviderUserKey).Scenic;
        base.OnLoad(e);
    }
    public bpScenicManager()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
        
    }
}