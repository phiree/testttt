using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DAL;
using Model;
using Rhino.Mocks;
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

            IList<DJ_TourEnterprise> entList = dalEnt.GetList("330100", EnterpriseType.景点 | EnterpriseType.宾馆 | EnterpriseType.购物点 | EnterpriseType.旅行社
                 , null);
            Assert.IsTrue(entList.Count > 0);
        }
        /// <summary>
        /// 更改某个企业的 纳入状态
        /// </summary>
        [Test]
        public void SetVerifyTest()
        {
            MockRepository mocks = new MockRepository();
            DJ_TourEnterprise ent = new DJ_TourEnterprise();
            DALDJEnterprise dalEnt = mocks.StrictMock<DALDJEnterprise>();
            Expect.Call(delegate { dalEnt.Save(ent); });
          
            blldjs.daldjs = dalEnt;
          
            
            Area area = new Area();
            area.Code = "330100";
           
            ent.Area = area;

            blldjs.SetVerify(ent, RewardType.已纳入);

            Assert.AreEqual(RewardType.已纳入, ent.CityVeryfyState);
            Assert.AreEqual((RewardType)0, ent.CountryVeryfyState);
            Assert.AreEqual((RewardType)0, ent.ProvinceVeryfyState);
            Area newArea = new Area();
            newArea.Code = "330301";
            ent.Area = newArea;
            blldjs.SetVerify(ent, RewardType.纳入后移除);
            Assert.AreEqual(RewardType.纳入后移除, ent.CountryVeryfyState);
            Assert.AreEqual( RewardType.已纳入 , ent.CityVeryfyState);
            Assert.AreEqual((RewardType)0, ent.ProvinceVeryfyState);
        }

    }
}
