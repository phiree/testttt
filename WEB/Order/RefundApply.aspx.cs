using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
public partial class Order_RefundApply :AuthPage
{
    Refund CurrentRefund = new Refund();
    
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    private void LoadRefundInfo()
    { 
        
    }
    private void Apply()
    { 
         Refund refund = new Refund();
        BLLRefund bllRefund = new BLLRefund(CurrentMember,Request["orderid"]);
       
        bllRefund.ApplyRefund();
    }

    protected void btnApply_Click(object sender, EventArgs e)
    {
        Apply();
    }
}