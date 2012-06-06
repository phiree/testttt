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
        [Test]
        public void GetAreaProvinceTest()
        {
            IDAL.IArea dal = new DAL.DALArea();
            dal.GetAreaProvince();
        }
    }
}
