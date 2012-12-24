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
     public class TourGroupTest
    {
        DJ_TourGroup group;
        [SetUp]
        public void Init()
        {
             group = Builder<DJ_TourGroup>.CreateNew().Build();
        }
         [Test]
         public void CopyToTest()
         {
            
             var routeList = Builder<DJ_Route>.CreateListOfSize(10).All().With(x => x.DJ_TourGroup = group)
                 .Build();
             group.Routes = routeList;

             var newGroup = new DJ_TourGroup();
             group.CopyTo(newGroup);
             Assert.AreEqual(newGroup.Routes.Count,group.Routes.Count);
            

         }

         [Test]
         public void GetGroupStateTest()
         {
             group.BeginDate = DateTime.Now.AddDays(-2);
             group.EndDate = DateTime.Now.AddDays(-1);
             Assert.AreEqual(TourGroupState.已经结束, group.GroupState);

             group.BeginDate = DateTime.Now.AddDays(-1);
             group.EndDate = DateTime.Now.AddDays(1);
             Assert.AreEqual(TourGroupState.正在进行, group.GroupState);

             group.BeginDate = DateTime.Now.AddDays(+1);
             group.EndDate = DateTime.Now.AddDays(+2);
             Assert.AreEqual(TourGroupState.尚未开始, group.GroupState);

             group.BeginDate = DateTime.Now;
             group.EndDate = DateTime.Now.AddDays(+2);
             Assert.AreEqual(TourGroupState.正在进行, group.GroupState);

             group.BeginDate = DateTime.Now.AddDays(-2);
             group.EndDate = DateTime.Now;
             Assert.AreEqual(TourGroupState.正在进行, group.GroupState);
         }

         [Test]
         public void GetGroupMemberTest()
         {
             var members = Builder<DJ_TourGroupMember>.CreateListOfSize(10)
                 .Section(0, 2)
                 .With(x => x.MemberType = MemberType.成)
                 .Section(3, 5)
                 .With(x => x.MemberType = MemberType.儿)
                 .Section(6, 7)
                 .With(x => x.MemberType = MemberType.港澳台)
                 .Section(8, 9)
                 .With(x => x.MemberType = MemberType.外)
                 .Build();
             var group = Builder<DJ_TourGroup>.CreateNew().With(x => x.Members = members).Build();
             Assert.AreEqual(group.AdultsAmount, 7);
             Assert.AreEqual(group.ChildrenAmount, 3);
             Assert.AreEqual(group.ForeignersAmount, 2);
             Assert.AreEqual(group.GangaotaisAmount, 2);
                
         }
    }
}
