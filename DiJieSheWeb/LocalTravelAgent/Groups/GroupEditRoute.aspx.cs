using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
public partial class LocalTravelAgent_Groups_GroupEditRoute :basepageDjsGroupEdit
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ucrecomment.AreaCode = CurrentDJS.Area.Code;
    }

   
}