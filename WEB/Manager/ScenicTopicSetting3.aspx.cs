using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_ScenicTopicSetting3 : System.Web.UI.Page
{
    BLL.BLLTopic blltopic = new BLL.BLLTopic();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindList();
        }
    }

    private void BindList()
    {
        IList<Model.Topic> topics = blltopic.GetAllTopics();
        rptTopic.DataSource = topics;
        rptTopic.DataBind();
    }

    protected void rptTopic_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string KeyName = e.CommandArgument.ToString();
        Model.Topic t = blltopic.GetTopicByName(KeyName);
        var seoname= (e.Item.FindControl("txtSeoname") as TextBox).Text;
        if (string.IsNullOrWhiteSpace(seoname))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "btnOk", "alert('seo名称不能为空！')", true);
            BindList();
            return;
        }
        t.seoname = seoname;
        if (blltopic.GetTopicBySeoname(t.seoname) == null)
        {
            blltopic.UpdateTopic(t);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "btnOk", "alert('修改成功')", true);
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "btnOk", "alert('已存在相同seo名称')", true);
        }
    }
}