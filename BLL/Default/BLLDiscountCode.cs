using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using IDAL;
using Model;

namespace BLL
{
    public class BLLDiscountCode
    {
        IDiscountCode idiscountcode;

        public IDiscountCode Idiscountcode
        {
            get
            {
                if (idiscountcode == null)
                {
                    idiscountcode = new DALDiscountCode();
                }
                return idiscountcode;
            }
            set { idiscountcode = value; }
        }

        public IList<Model.DiscountCode> GetDiscountCodeByCardid(string cardid)
        {
            return  Idiscountcode.GetDiscountCodeByCardid(cardid);
        }
        public Model.DiscountCode GetDiscountCodeByDisCode(string discode)
        {
            return Idiscountcode.GetDiscountByDisCode(discode);
        }

        public void updateDiscountCode(Model.DiscountCode dc)
        {
             Idiscountcode.updateDiscountCode(dc);
        }
    }
}
