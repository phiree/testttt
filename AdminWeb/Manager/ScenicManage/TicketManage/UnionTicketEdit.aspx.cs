using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
public partial class Manager_ScenicManage_TicketManage_UnionTicketEdit : System.Web.UI.Page
{
    /// <summary>
    /// 创建/编辑套票信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    int ticketId;
    public TicketBase CurrentTicket;
    BLLTicket bllTicket = new BLLTicket();
    BLLScenicTicket bllScenicTicket = new BLLScenicTicket();
    BLLScenic bllScenic = new BLLScenic();
    protected void Page_Load(object sender, EventArgs e)
    {
        string paramTicketId = Request["ticketid"];
        if (!int.TryParse(paramTicketId, out ticketId))
        {
            throw new Exception("参数不合法");
        }
        CurrentTicket = bllTicket.GetTicket(ticketId);

        if (!IsPostBack)
        {
            BindScenics();   
        }

    }
    private void BindScenics()
    {
        rptScenics.DataSource = bllScenicTicket.GetScenicByTicket(ticketId);
        rptScenics.DataBind();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        int total;
      IList<Scenic> scenics=  bllTicket.Search(tbxKeyword.Text.Trim(), 0, 99, out total);
      rptSearchScenics.DataSource = scenics;
      rptSearchScenics.DataBind();
    }
    protected void rptScenics_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "deletescenic")
        { 
          //删除对应关系
            int scenicId = Convert.ToInt32(e.CommandArgument);
            bllScenicTicket.Delete(scenicId, ticketId);
            BindScenics();
        }
    }
    protected void rptSearchScenics_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "addscenic")
        {
            int scenicId = Convert.ToInt32(e.CommandArgument);

            bllScenicTicket.Add(scenicId, ticketId);
            BindScenics();
        }
    }
}