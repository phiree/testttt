using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FizzWare.NBuilder;
using NUnit.Framework;
using Model;
namespace TourTest.ModelTest
{
    [TestFixture]
     public class AreaTest
    {
         [Test]
         public void GetLevelTest()
         {
             var area = new Area();
             area.Code = "330000";
             Assert.AreEqual(AreaLevel.省, area.Level);
             area.Code = "330100";
             Assert.AreEqual(AreaLevel.市, area.Level);
             area.Code = "330103";
             Assert.AreEqual(AreaLevel.区县, area.Level);

         }
    }
}
