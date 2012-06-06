using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using NUnit.Framework;
namespace TourTest
{
    [TestFixture]
    public class EnumTEst
    {
        [Test]
        public void UserTypeEnumTest()
        {
            TourMembership tm = new BLL.BLLMembership().GetMember("yuanfei");
          

        }
    }
}
