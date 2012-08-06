using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using System.IO;

public partial class ScenticManager_UpdateScenticInfo : basepage
{
    BLLScenic bllscenic = new BLLScenic();
    BLLMembership bllMember = BLLFactory.CreateBLLMember();
    BLLScenicImg bllscenicimg = new BLLScenicImg();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }
    }

    private void bind()
    {
        Model.ScenicAdmin user = new BLLMembership().GetScenicAdmin((Guid)CurrentUser.ProviderUserKey);

        Scenic scenic = user.Scenic;
        ScenicName.Text = scenic.Name;
        ScenicLevel.Text = scenic.Level;
        ScenicArea.Text = scenic.Area.Name;
        Address.Text = scenic.Address;
        Desc.Text = scenic.TransGuid;
        IList<ScenicImg> list = bllscenicimg.GetSiByType(scenic, 1);
        if (list.Count > 0)
            ScenicImg.ImageUrl = "/ScenicImg/" + list[0].Name;
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        Model.ScenicAdmin user = new BLLMembership().GetScenicAdmin((Guid)CurrentUser.ProviderUserKey);
        Scenic scenic = user.Scenic;
        scenic.Name = ScenicName.Text.Trim();
        scenic.Level = ScenicLevel.Text.Trim();
        scenic.Area.Name = ScenicArea.Text.Trim();
        scenic.Address = Address.Text;
        scenic.TransGuid = Desc.Text;
        scenic.Photo = "";
        scenic.Position = hfposition.Value;
        ScenicCheckProgress temp = scenic.CheckProgress.First<ScenicCheckProgress>(x => x.Module == ScenicModule.SellOnLine);
        temp.CheckStatus = CheckStatus.NotApplied;
        bllscenic.UpdateScenicInfo(scenic);

        bind();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('更新成功');window.location=window.location", true);
    }



    protected void btnupdatescpic_Click(object sender, EventArgs e)
    {
        Response.Redirect("/ScenicManager/ScenicPictureShow.aspx");
    }
}