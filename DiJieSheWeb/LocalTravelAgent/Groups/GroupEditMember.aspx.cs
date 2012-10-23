using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LocalTravelAgent_Groups_GroupEditMember : basepageDjsGroupEdit
{

    /*
        fields: [
          { name: 'memberid' },
		{ name: 'no' },
		{ name: 'tourertype' },
		{ name: 'realname' },
		{ name: 'phone' },
		{ name: 'idcardno' },
		{ name: 'othercardno' }
     */
    string[] fieldsName = { "memberid", "no", "touretype", "realname", "phone", "idcardno", "othercardno" };
    public string MemberJsonList = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BuildJsonData();
        }
    }
    private void BuildJsonData()
    {
        MemberJsonList = BLL.BLLDJTourGroup.BuildJsonForMemberList(CurrentGroup.Members);
    }
}