using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace TourTest
{
    [TestFixture]
    public class PromStaticTest
    {
        [Test]
        public void AddPromTest()
        {
            BLL.BLLProm bll = new BLL.BLLProm();
            bll.AddPromInfo(Guid.Parse(
                "2b369eb5-b7c1-4948-a5b2-a02000ca3349"), "tencent");
        }
    }
}
