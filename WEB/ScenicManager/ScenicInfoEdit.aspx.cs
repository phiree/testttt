using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class ScenicManager_Default2 : System.Web.UI.Page
{
    BLLScenic bllscenic = new BLLScenic();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }
    }

    private void bind()
    {
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        Scenic scenic = Master.Scenic;
        scenic.BookNote = CkBookNote.Text;
        scenic.Desec = CkScjj.Text;
        bllscenic.UpdateScenicInfo(scenic);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('保存成功')", true);
    }
}