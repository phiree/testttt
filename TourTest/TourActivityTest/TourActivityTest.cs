using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NHibernate;
using Model;
using FluentNHibernate.Testing;
using FizzWare.NBuilder;
namespace TourTest.TourActivityTest
{
    [TestFixture]
    public class TourActivityTest
    {
       /// <summary>
       /// 创建一个活动
       /// </summary>
        [Test]
        public void CreateActivityTest()
        {
           // Model.TourActivity.TourActivity
        }
        [Test]
        public void CheckRuleTest()
        {
            var partners = Builder<ActivityPartner>.CreateListOfSize(2)
                .TheFirst<ActivityPartner>(1).With(x => x.PartnerCode = "p1")
                    .With(x=>x.NeedCheckTime=false)
                .TheLast<ActivityPartner>(1).With(x => x.PartnerCode = "p2")
                    .With(x=>x.NeedCheckTime=true)
                .Build();

            var ticketlist=Builder<Ticket>.CreateListOfSize(2)
                .TheFirst<Ticket>(1).With(x=>x.ProductCode="t1")
                .TheLast<Ticket>(1).With(x => x.ProductCode = "t2").Build();

            var datelist = Builder<DateTime>.CreateListOfSize(3).Build();

            var touractivity = Builder<TourActivity>.CreateNew()
                .With(x=>x.BeginHour=10)
                .With(x=>x.BeginDate=DateTime.Now.AddDays(10))
                .Build();


            foreach (ActivityPartner p in partners)
            {
                foreach (Ticket t in ticketlist)
                {
                    foreach (DateTime date in datelist)
                    {
                        var assign = Builder<ActivityTicketAssign>.CreateNew()
                            .With(x => x.AssignedAmount = 2)
                            .With(x => x.SoldAmount = 0)
                            .With(x => x.DateAssign = date)
                            .With(x => x.Partner = p)
                            .With(x => x.Ticket = t)
                            .With(x => x.TourActivity = touractivity)
                            .Build();
                        touractivity.ActivityTicketAssign.Add(assign);
                    }
                }
            }
            string errMsg;
            //不需要检查请票时间
            //Assert.AreEqual(true, touractivity.CheckBuyHour(partners[0], out errMsg));
                      //检查开始日期
           // Assert.AreEqual(true, touractivity.CheckBuyTime(out errMsg));

                

            
            
        }
       
    }
}
