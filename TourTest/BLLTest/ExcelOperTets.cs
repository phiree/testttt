using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace TourTest.BLLTest
{ 
    [TestFixture]
    public class ExcelOperTets
    {
        [Test]
        public void Run()
        {
            new ExcelOplib.ExcelOpr().Run();
        }
    }
}
