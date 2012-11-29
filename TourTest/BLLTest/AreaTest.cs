using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace TourTest
{
    [TestFixture]
    public class AreaTest
    {
        IDAL.IArea dal = new DAL.DALArea();
        [Test]
        public void GetAreaProvinceTest()
        {

            dal.GetAreaProvince();
        }
        [Test]
        public void GetChildAreaIds()
        {
            BLL.BLLArea bllArea = new BLL.BLLArea();
            string ids = bllArea.GetChildAreaIds("330100");
            Console.Write(ids);
            Assert.IsTrue(ids.Length > 10);
        }
    }
}
