﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class BLLDJ_User
    {
        IDAL.IDJ_User Idj_user_enterprise=new DAL.DALDJ_User();
        #region User_TourEnterprise
        public Model.DJ_User_TourEnterprise GetUser_TEbyId(Guid id)
        {
            return Idj_user_enterprise.GetUser_TEbyId(id);
        }
        #endregion
    }
}