using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

public partial class Manager_ScenicTopicSetting : System.Web.UI.Page
{
    BLLArea bllArea = new BLLArea();
    BLLTopic bllTopic = new BLLTopic();
    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindArea();
            BindTopics();
        }
    }

    private void BindArea()
    {
        ddlArea.DataSource = bllArea.GetSubArea("330000");
        ddlArea.DataTextField = "Name";
        ddlArea.DataValueField = "Code";
        ddlArea.DataBind();
    }

    private void BindTopics()
    {
        IList<Model.ScenicTopic> scenictopicList = bllTopic.GetScenicTopics( ddlArea.SelectedValue);
        rptScenicAdmin.DataSource = scenictopicList;
        rptScenicAdmin.DataBind();
    }
}