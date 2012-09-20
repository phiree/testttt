using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LocalTravelAgent_DjsEdit : System.Web.UI.Page
{

    BLL.BLLDijiesheInfo blldjs = new BLL.BLLDijiesheInfo();
    BLL.BLLArea bllarea = new BLL.BLLArea();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        blldjs.AddDjs("新疆牙买提", "新疆乌鲁木齐", 
            bllarea.GetAreaByCode("330100"), "阿凡提", "15988886666", "010-156489765");
    }
}