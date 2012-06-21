using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BLL.BLLForTDD;
namespace TourTest.TDD.Member
{
    /// <summary>
    /// 创建用户
    /// </summary>
    public  class MemberShipTest
    {
        public void CreateTest()
        {
            
            Assert.IsTrue( new BLLMember().CreateMember("yuanfei","password" ));
        }
    }
}
