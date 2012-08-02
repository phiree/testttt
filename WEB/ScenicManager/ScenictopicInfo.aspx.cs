using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ScenicManager_ScenictopicInfo : bpScenicManager
{
    BLL.BLLTopic bllTopic = new BLL.BLLTopic();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindTopicStore();
            BindTopicOwn();
        }
    }

    private void BindTopicStore()
    {
        IList<Model.Topic> topics=bllTopic.GetAllTopics();
        rptTopicStore.DataSource = topics;
        rptTopicStore.DataBind();
    }

    private void BindTopicOwn()
    {
        IList<Model.Topic> topics = bllTopic.GetTopicByscid(Master.Scenic.Id);
        rptTopicOwn.DataSource = topics;
        rptTopicOwn.DataBind();
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        IList<string> topicnames=hiddentag.Value.Split(new char[] { '+' }, StringSplitOptions.RemoveEmptyEntries);
        bllTopic.Save(topicnames, Master.Scenic.Id);
        BindTopicOwn();
    }
}