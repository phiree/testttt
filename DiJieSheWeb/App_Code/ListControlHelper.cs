using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
/// <summary>
///ListControlHelper 的摘要说明
/// </summary>
public class ListControlHelper
{
    public ListControlHelper()
    {
        
    }
    public static void CheckItems(ListControl all, IList<string> needChecked)
    {
        foreach (ListItem item in all.Items)
        {
            foreach (string itemCheck in needChecked)
            {
                if (item.Text == itemCheck)
                {
                    item.Selected = true;
                }
            }
        }
    }
}