﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace IDAL
{
    public interface IDJ_Group_Worker
    {
        IList<DJ_TourGroup> GetTgListByIdcard(string idcard);
    }
}