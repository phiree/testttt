using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CommonLibrary;
using System.IO;
using System.Configuration;
using BLL;
namespace TourTest.Common
{
    [TestFixture]
    public class ListHelperTest
    {
        [Test]
        public void ExtendStringListTest()
        {
            List<string> s1 = new List<string>();
            s1.Add("a");
            s1.Add("cb");

            s1 = CommonLibrary.ListHelper.ExtendStringList(s1, 10);
            Assert.AreEqual(10, s1.Count);
            Assert.AreEqual("a", s1[0]);
            Assert.AreEqual("cb", s1[1]);
        }
    }
}

