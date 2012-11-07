using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;

namespace TourTest.BLLTest
{
    [TestFixture]
    public class RouteTest
    {
        MockRepository mocks = new MockRepository();
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
        public void SaveFromNameListTest()
        {
            DAL.DALDJ_Route dalRoute = mocks.StrictMock<DAL.DALDJ_Route>();
            Expect.Call(delegate { dalRoute.Save(new Model.DJ_Route()); });
            BLL.BLLDJRoute bllRoute = new BLL.BLLDJRoute();
            bllRoute.Idjroute = dalRoute;

            
            string errMsg;
          IList<Model.DJ_Route> routes= bllRoute.CreateRouteFromNameList(1, new List<string>() { "a", "b", "cc" }, out errMsg);

          Assert.AreEqual(0, routes.Count);
          Assert.IsTrue(errMsg.Length > 2);
        }
    }
}
