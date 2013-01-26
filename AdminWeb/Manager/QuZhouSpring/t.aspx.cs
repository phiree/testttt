using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TicketService;
public partial class Manager_QuZhouSpring_t : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TicketServiceSoapClient client = new TicketServiceSoapClient();
        
    }
}