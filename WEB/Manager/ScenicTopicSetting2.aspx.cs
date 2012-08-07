using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_ScenicTopicSetting2 : System.Web.UI.Page
{
    BLL.BLLTopic bllTopic = new BLL.BLLTopic();
    int scid;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Request["scid"]))
        {
            Response.Redirect("/manager");
        }
        if (!IsPostBack)
        {
            BindTopicStore();
            BindTopicOwn();
        }
    }

    private void BindTopicStore()
    {
        IList<Model.Topic> topics = bllTopic.GetAllTopics();
        rptTopicStore.DataSource = topics;
        rptTopicStore.DataBind();
    }

    private void BindTopicOwn()
    {
        scid = int.Parse(Request["scid"]);
        IList<Model.Topic> topics = bllTopic.GetTopicByscid(scid);
        rptTopicOwn.DataSource = topics;
        rptTopicOwn.DataBind();
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        scid = int.Parse(Request["scid"]);
        IList<string> topicnames = hiddentag.Value.Split(new char[] { '+' }, StringSplitOptions.RemoveEmptyEntries);
        bllTopic.SaveScenictopic(topicnames, scid);
        BindTopicOwn();
        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "btnsave", "alert('保存成功')", true);
    }
}