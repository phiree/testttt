using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DAL;
using Model;
namespace TourTest.BLLTest
{
    [TestFixture]
    public class DJSTourEnterpriseTest
    {
        BLL.BLLDJEnterprise blldjs = new BLL.BLLDJEnterprise();
        BLL.BLLArea bllarea = new BLL.BLLArea();
        DALDJEnterprise dalEnt = new DALDJEnterprise();
        [Test]
        public void GetListTest()
        {
            int totalRecords;
           IList<DJ_TourEnterprise> entList= dalEnt.GetList("330100", EnterpriseType.景点 | EnterpriseType.宾馆 | EnterpriseType.购物点 | EnterpriseType.旅行社
                , null, false, 0, 0, out  totalRecords);
           Assert.IsTrue(entList.Count > 0);
         }
    }
}
