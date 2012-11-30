using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace TourTest.BLLTest
{
    [TestFixture]
    public class BackManagerTest
    {
        BLL.BLLBackManager bllbackmanager = new BLL.BLLBackManager();

        [Test]
        public void GetScenicListTest_null()
        {
            var result = bllbackmanager.GetScenicList(null);
            Assert.IsTrue(result.Count > 0);
        }

        [Test]
        public void GetScenicListTest_wrongcondition0()
        {
            var result = bllbackmanager.GetScenicList(" 123");
            Assert.IsTrue(result.Count > 0);
        }

        [Test]
        public void GetScenicListTest_wrongcondition1()
        {
            var result = bllbackmanager.GetScenicList(" where 123");
            Assert.IsNull(result);
        }

        [Test]
        public void GetScenicListTest_wrongcondition2()
        {
            var result = bllbackmanager.GetScenicList(" where 123=234");
            Assert.IsTrue(result.Count == 0);
        }

        [Test]
        public void GetScenicListTest_rightcondition()
        {
            var strcondi = " where s.Area.Code like '3301__'";
            var result = bllbackmanager.GetScenicList(strcondi);
            Assert.IsTrue(result.Count > 0);
        }

        [Ignore]
        public void GetScenicList(string strCondition, int pageIndex, int pageSize, out long totalRecord)
        {
            totalRecord = 1;
        }

    }
}
