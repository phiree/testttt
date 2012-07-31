using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;

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
        rptScenic.DataSource = scenictopicList;
        rptScenic.DataBind();
    }

    protected void rptScenic_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Repeater rep = e.Item.FindControl("rptTopic") as Repeater;//找到里层的repeater对象
            DataRowView rowv = (DataRowView)e.Item.DataItem;//找到分类Repeater关联的数据项 
            int scenicid = Convert.ToInt32(rowv["Id"]); //获取填充子类的id 
            rep.DataSource = bllTopic.GetScenicTopics(scenicid.ToString());
            rep.DataBind();
        }
    }
}