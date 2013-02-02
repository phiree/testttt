using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class Manager_QuZhouSpring_CancelTa : System.Web.UI.Page
{
    BLLTicketAssign bllTa = new BLLTicketAssign();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }
    }

    private void bind()
    {
        IList<TicketAssign> listTa= bllTa.GetTaByIdCard(txtIdCard.Text.Trim());
        rptTa.DataSource = listTa;
        rptTa.DataBind();

    }

    protected void rptTa_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "cancel")
        {
            Guid id = Guid.Parse(e.CommandArgument.ToString());
            TicketAssign ta= bllTa.GetOne(id);
            ta.IsUsed = false;
            bllTa.SaveOrUpdate(ta);
        }
    }
}