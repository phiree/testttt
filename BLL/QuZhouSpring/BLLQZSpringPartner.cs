using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class BLLQZSpringPartner:BLLBase<QZSpringPartner>
    {
        DALQZSpringPartner dalqz = new DALQZSpringPartner();
        public IList<QZSpringPartner> GetListByName(string name)
        {
            return dalqz.GetListByName(name);
        }

       

      
    }
}
