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
    public DJ_TourGroup CurrentGroup
    {
        get {
            Guid groupId;
            string param = Request["groupId"];
            if (Guid.TryParse(param, out groupId))
            {
                DJ_TourGroup g = new BLL.BLLDJTourGroup().GetTourGroupById(groupId);
                if (g == null)
                {
                    BLL.ErrHandler.Redirect(BLL.ErrType.ObjectIsNull);
                }
                else
                {
                    return g;
                }
            }
            else {
                BLL.ErrHandler.Redirect(BLL.ErrType.ParamIllegal);
            }
            return null;
        }
    }

}