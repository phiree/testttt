using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Model;

namespace TourTest.BLLTest
{
    [TestFixture]
    public class CommonUserTest
    {
        BLL.BLLCommonUser bllcommonuser = new BLL.BLLCommonUser();

        [Test]
        public void GetCommonUserByUserIdTest_rightcondition()
        {
            var result = bllcommonuser.GetCommonUserByUserId(Guid.NewGuid());
            Assert.IsTrue(result.Count == 0);
        }

        [Test]
        public void GetCommonUserByIdCardTest_null()
        {
            var result = bllcommonuser.GetCommonUserByIdCard(null);
            Assert.IsTrue(result.Count == 0);
        }

        [Test]
        public void GetCommonUserByIdCardTest_wrongid()
        {
            var result = bllcommonuser.GetCommonUserByIdCard("");
            Assert.IsTrue(result.Count == 0);
        }

        [Test]
        public void GetCommonUserByUserIdandidcardTest_condition1()
        {
            var result = bllcommonuser.GetCommonUserByUserIdandidcard(Guid.NewGuid(), null);
            Assert.Null(result);
        }

        [Test]
        public void GetCommonUserByUserIdandidcardTest_condition2()
        {
            var result = bllcommonuser.GetCommonUserByUserIdandidcard(Guid.NewGuid(), "");
            Assert.Null(result);
        }

        [Test]
        public void GetCommonUserByUserIdandidcardTest_condition3()
        {
            var result = bllcommonuser.GetCommonUserByUserIdandidcard(Guid.NewGuid(), "123");
            Assert.Null(result);
        }

        [Test]
        public void GetTest_null()
        {
            var result = bllcommonuser.Get(Guid.NewGuid(), null, null);
            Assert.Null(result);
        }

        [Test]
        public void SaveCommonUserTest_condition1()
        {
            CommonUser cu = new CommonUser();
            cu.Name = "小A";
            cu.IdCard = "330381198812164236";
            cu.User = new BLL.BLLMembership().GetMember("admin");
            string message;
            bllcommonuser.SaveCommonUser(cu, out message);
            Assert.AreEqual(string.Empty, message);

            CommonUser cu2 = new CommonUser();
            cu.Name = "小A";
            cu.IdCard = "330381198812164236";
            cu.User = new BLL.BLLMembership().GetMember("admin");
            string message2;
            bllcommonuser.SaveCommonUser(cu2, out message2);
            Assert.AreEqual("已存在", message2);
        }
    }
}
