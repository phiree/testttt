using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace IDAL
{
    public interface IDJTourGroup
    {
        IList<DJ_TourGroup> GetTourGroupByGuideIdcard(string idcard);
        DJ_TourGroup GetTourGroupById(Guid id);
        IList<DJ_TourGroup> GetTourGroupByTEId(Guid id);
        Model.DJ_TourGroup GetTgByproductid(Guid proid);
        //根据旅游单位id和导游身份证号查找旅游团队
        IList<DJ_TourGroup> GetTgByIdcardAndTE(string idcard, DJ_TourEnterprise TE);
    }
}
