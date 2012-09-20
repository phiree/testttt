using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace TourTest.BLLTest
{
    [TestFixture]
    public class DJSTest
    {
        BLL.BLLDijiesheInfo blldjs = new BLL.BLLDijiesheInfo();
        BLL.BLLArea bllarea = new BLL.BLLArea();

        [Test]
        public void AddDjsTest()
        {
            blldjs.AddDjs("新疆牙买提", "新疆乌鲁木齐", bllarea.GetAreaByCode("330100"), "阿凡提", "15988886666", "010-156489765");
        }
    }
}
