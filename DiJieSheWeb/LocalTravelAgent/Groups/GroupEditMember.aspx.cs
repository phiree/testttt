using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;
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
    string[] fieldsName = { "no", "tourertype", "realname", "phone", "idcardno", "othercardno", "memberid" };
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
       // JavaScriptSerializer serializer = new JavaScriptSerializer();
       //MemberJsonList= serializer.Serialize(CurrentGroup.Members);
        
    }
}