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
     public class TourGroupMemberTest
    {
         [Test]
         public void CopyToTest()
         {
             var member = Builder<DJ_TourGroupMember>.CreateNew().Do(x=>x.IdCardNo="cc").Build();
            
             var newMember = new DJ_TourGroupMember();
             member.CopyTo(newMember);
             Assert.AreEqual("cc", newMember.IdCardNo);

         }
    }
}
