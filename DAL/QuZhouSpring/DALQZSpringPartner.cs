using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using Model;

namespace DAL
{
    public class DALQZSpringPartner:DalBase<QZSpringPartner>
    {

        public IList<QZSpringPartner> GetListByName(string name)
        {
            string sql = "select qz from QZSpringPartner qz where 1=1 ";
            if (!string.IsNullOrEmpty(name))
            {
                sql += " and qz.Name like '%" + name + "%'";
            }
            return GetList(sql);
        }
    }
}
