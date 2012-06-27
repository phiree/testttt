using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BLL;
using Model;

namespace TourTest.BLLTest
{
    [TestFixture]
    public class MembershipTest
    {
        [Test]
        public void CreateUpdateMemberTest()
        {
            BLLMembership bllMember = new BLLMembership();
            bllMember.CreateUser("realname", "phone", "address", "idcard", "loginname", "password");

            TourMembership member = bllMember.GetMember("loginname");

            Assert.IsTrue(member != null);
            Assert.IsTrue(member.GetType() == typeof(User));
        }
        [Test]
        public void GetUserByUserName()
        {
            DAL.DALMembership dalmember = new DAL.DALMembership();
            TourMembership t = dalmember.GetMemberByName("yuanfei");
            Console.Write(t.GetType());
        }
        [Test]
        public void GetUsersByUsertypeTest()
        {
            //long total;
            //DAL.DALMembership dalmember = new DAL.DALMembership();
            //IList<Model.TourMembership> modelist 
            //    = dalmember.GetUsersByUsertype(Model.UserType.ScenicAdmin,1,2,out total);
            //foreach (var item in modelist)
            //{
            //    Console.Write(item.Name);
            //}
        }
    }
}
