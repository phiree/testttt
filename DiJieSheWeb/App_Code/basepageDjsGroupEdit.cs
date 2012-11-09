using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Model;
/// <summary>
///basepage 的摘要说明
/// </summary>
public class basepageDjsGroupEdit : basepageDJS
{

    DJ_TourGroup currentGroup;
    public DJ_TourGroup CurrentGroup
    {
        get
        {
            if (currentGroup == null)
            {
                Guid groupId;
                string param = Request["groupId"];
                if (Guid.TryParse(param, out groupId))
                {
                    DJ_TourGroup g = new BLL.BLLDJTourGroup().GetOne(groupId);
                    if (g == null)
                    {
                        BLL.ErrHandler.Redirect(BLL.ErrType.ObjectIsNull);
                    }
                    else
                    {
                        currentGroup = g;
                       
                    }
                }

                else 
                {
                    BLL.ErrHandler.Redirect(BLL.ErrType.ParamIllegal);
                }
            }

            return currentGroup;
        }
        set {
            currentGroup = value;
        }
    }

}