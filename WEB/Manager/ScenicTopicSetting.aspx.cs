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
    BLLBackManager bllmanager = new BLLBackManager();
    

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
        IList<Model.Scenic> scenicList = bllmanager.GetScenicList(" where s.Area.Code=" + ddlArea.SelectedValue);
        rptScenic.DataSource = scenicList;
        rptScenic.DataBind();
    }

    protected void rptScenic_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Repeater rep = e.Item.FindControl("rptTopic") as Repeater;//找到里层的repeater对象
            Model.Scenic s = (Model.Scenic)e.Item.DataItem;//找到分类Repeater关联的数据项 
            int scenicid = Convert.ToInt32(s.Id); //获取填充子类的id 
            rep.DataSource = bllTopic.GetTopicByscid(scenicid);
            rep.DataBind();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindTopics();
    }
}