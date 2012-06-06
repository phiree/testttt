using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
namespace TourTest
{
    public class TestData
    {
        public Role GetOneRole_Name_Role1()
        {
            Role r = new Role();
            r.Name = "role1";
            r.Id = new Guid("AD43BF4C-BF09-4203-BC09-3BDB7B8A7AC7");
            return r;
        }
    }
}
