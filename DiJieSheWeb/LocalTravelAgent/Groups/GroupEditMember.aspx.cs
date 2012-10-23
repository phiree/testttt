using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LocalTravelAgent_Groups_GroupEditMember :basepageDjsGroupEdit
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindEditableList();
        }
    }
    private void BindEditableList()
    {
      
    }
}