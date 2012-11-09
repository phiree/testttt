using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
namespace TourControls
{
   public class RewardLabel:Label
    {
       public bool IsVerified
       {
           get;
           set;
       }
       protected override void OnLoad(EventArgs e)
       {
           if (IsVerified)
           {
               this.CssClass = "rewardbg";
           }
           base.OnLoad(e);
       }
    }
}
