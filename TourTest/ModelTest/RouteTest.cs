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
    public class RouteTest
    {
         [Test]
        public void RedundancyTest()
         {
             DJ_TourEnterprise ent = Builder<DJ_TourEnterprise>.CreateNew().With(x => x.Name = "EntOriginal").Build();
             DJ_Route r = new DJ_Route();
             r.Enterprise = ent;
             r.RD_EnterpriseName = "EntOriginal";

             ent.Name = "EntModified";

             Assert.AreEqual(ent.Name,r.Enterprise.Name);
             Assert.AreEqual("EntOriginal", r.RD_EnterpriseName);
         }
    }
}
