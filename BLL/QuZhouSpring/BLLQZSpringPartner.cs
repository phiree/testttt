using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class BLLQZSpringPartner
    {
        DALQZSpringPartner dalqz = new DALQZSpringPartner();
        public IList<QZSpringPartner> GetListByName(string name)
        {
            return dalqz.GetListByName(name);
        }

        public QZSpringPartner GetOne(Guid id)
        {
            return dalqz.GetOne(id);
        }

        public void Save(QZSpringPartner qz)
        {
            dalqz.Save(qz);
        }
    }
}
