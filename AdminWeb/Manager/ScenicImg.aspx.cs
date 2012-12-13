using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class Manager_ScenicImg : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }
    }

    private void bind()
    {
        rptScenic.DataSource = new BLLScenic().GetScenic();
        rptScenic.DataBind();
    }
    protected void rptScenic_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Scenic s = e.Item.DataItem as Scenic;
            List<ScenicImg> list = new List<ScenicImg>();
            list.AddRange(new BLLScenicImg().GetSiByType(s, 1).ToList());
            list.AddRange(new BLLScenicImg().GetSiByType(s, 12).ToList());
            Repeater rptImg = e.Item.FindControl("") as Repeater;
            rptImg.DataSource = list;
            rptImg.ItemDataBound+=new RepeaterItemEventHandler(rptImg_ItemDataBound);
            rptImg.ItemCommand+=new RepeaterCommandEventHandler(rptImg_ItemCommand);
            rptImg.DataBind();
            
        }
    }


    protected void rptImg_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            CheckBox cb = e.Item.FindControl("cbSelect") as CheckBox;
            ScenicImg si = e.Item.DataItem as ScenicImg;
            if (si.ImgType == ImgType.主图)
                cb.Checked = true;
        }
    }
    protected void rptImg_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "setMain")
        {
            int id =int.Parse(e.CommandArgument.ToString());
            ScenicImg si= new BLLScenicImg().GetSiBySiid(id);
            List<ScenicImg> listimg = new BLLScenicImg().GetSiByType(si.Scenic, 1).ToList();
            foreach (ScenicImg item in listimg)
            {
                item.ImgType = ImgType.辅图;
                new BLLScenicImg().SaveOrUpdate(item);
            }
            si.ImgType = ImgType.主图;
            new BLLScenicImg().SaveOrUpdate(si);
        }
    }
}