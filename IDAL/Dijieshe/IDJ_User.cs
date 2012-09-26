using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDAL
{
    public interface IDJ_User
    {
        #region User_TourEnterprise
        Model.DJ_User_TourEnterprise GetUser_TEbyId(Guid id);
        #endregion
    }
}
