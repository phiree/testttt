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
            Dictionary<Model.EnterpriseType, IList<string>> entDicts = new Dictionary<Model.EnterpriseType, IList<string>>();
            entDicts.Add(Model.EnterpriseType.宾馆, new List<string>() { "宾馆1", "宾馆2", "宾馆3" });
            entDicts.Add(Model.EnterpriseType.景点, new List<string>() { "景区1", "景区2", "景区3" });
            IList<Model.DJ_ProductRoute> routes = bllRoute.CreateRouteFromNameList(1, entDicts, out errMsg);

          Assert.AreEqual(6, routes.Count);
          Console.Write("errMSG:"+errMsg+".");
        //  Assert.IsTrue(errMsg.Length > 2);
        }
    }
}
