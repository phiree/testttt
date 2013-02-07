using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
namespace TourTest.CommonLibraryTest
{
    [TestFixture]
   public class IOHelperTest
    {

        [Test]
        public void WriteContentTest()
        {
            string name = "d:\\aa\\b\\c\\d\\test.log";
            CommonLibrary.IOHelper.WriteContentToFile(name, "test");
            string content = System.IO.File.ReadAllText(name);
            Assert.AreEqual("test", content);
            System.IO.File.Delete(name);
        }
    }
}
