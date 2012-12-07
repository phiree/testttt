using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FizzWare.NBuilder;
using NUnit.Framework;
using Model;
namespace TourTest
{
    [TestFixture]
     public class TourGroupTest
    {
         [Test]
         public void CopyToTest()
         {
             var group = Builder<DJ_TourGroup>.CreateNew().Build();
             var routeList = Builder<DJ_Route>.CreateListOfSize(10).All().With(x => x.DJ_TourGroup = group)
                 .Build();
             group.Routes = routeList;

             var newGroup = new DJ_TourGroup();
             group.CopyTo(newGroup);

         }
    }
}
