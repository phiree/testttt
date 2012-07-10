using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;

namespace TourTest.BLLTest
{
    [TestFixture]
    public class OrderTest
    {
        [Test]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="scenicid">10</param>
        /// <param name="dateBegin">201205</param>
        /// <param name="dateEnd">201206</param>
        /// <param name="paidstate">true,false,null</param>
        /// <param name="paidway"></param>
        /// <returns></returns>
        public void GetMonthOrderTest()
        {
            int scenicid=10;
            string datebegin="201204";
            string dateend="201206";
            bool? paidstate=true;
            var idalOrder = MockRepository.GenerateStub<IDAL.IOrder>();
            IList<Model.OrderDetail> odlist = new List<Model.OrderDetail>();
            odlist.Add(new Model.OrderDetail()
            {
                Order = new Model.Order() { PayTime=new DateTime(2012,6,27)}
            });
            idalOrder.Stub(x => x.GetMonthOrder(scenicid, datebegin, dateend, paidstate)).Return(odlist);
        }
    }
}
