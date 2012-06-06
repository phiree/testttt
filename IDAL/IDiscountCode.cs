using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDAL
{
    public interface IDiscountCode
    {
        IList<Model.DiscountCode> GetDiscountCodeByCardid(string cardid);
        Model.DiscountCode GetDiscountByDisCode(string DisCode);
        void updateDiscountCode(Model.DiscountCode dc);
    }
}
