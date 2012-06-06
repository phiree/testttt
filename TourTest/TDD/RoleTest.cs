using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Model;
using BLL;
namespace TourTest.RoleTDD
{
    [TestFixture]
   public  class RoleTest
    {
       
        [Test]
        public void AddRole() {
            DAL.DALRole dalRole = new DAL.DALRole();
            Role r=new Role();
            r.Name="SiteAdmin";
            dalRole.CreateRole(r);
        }
    }
}
