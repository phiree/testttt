using BLL;
using System;
using Model;
using NUnit.Framework;

namespace TourTest.BLLTest
{


    /// <summary>
    ///这是 BLLContractScenicPriceTest 的测试类，旨在
    ///包含所有 BLLContractScenicPriceTest 单元测试
    ///</summary>
    [TestFixture]
    public class BLLContractScenicPriceTest
    {

        BLLContractScenicPrice target = new BLLContractScenicPrice(); // TODO: 初始化为适当的值

        /// <summary>
        ///BLLContractScenicPrice 构造函数 的测试
        ///</summary>
        //[Test]
        //public void BLLContractScenicPriceConstructorTest()
        //{
        //    BLLContractScenicPrice target = new BLLContractScenicPrice();
        //    Assert.Inconclusive("TODO: 实现用来验证目标的代码");
        //}

        /// <summary>
        ///GetcspByscid 的测试
        ///</summary>
        [Test]
        public void GetcspByscidTest()
        {

            int scid = 0; // TODO: 初始化为适当的值
            ContractScenicPrice expected = null; // TODO: 初始化为适当的值
            ContractScenicPrice actual;
            actual = target.GetcspByscid(scid);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///SaveOrUpdate 的测试_null param
        ///</summary>
        [Test]
        public void SaveOrUpdateTest_null()
        {

            ContractScenicPrice csp = null; // TODO: 初始化为适当的值

            Assert.Throws<ArgumentNullException>(delegate { target.SaveOrUpdate(csp); });
        }

        /// <summary>
        ///SaveOrUpdate 的测试
        ///</summary>
        [Test]
        public void SaveOrUpdateTest_rightcondition()
        {
            ContractScenicPrice csp = null;
            Scenic scenic = new BLL.BLLScenic().GetScenic()[0];
            if (scenic != null)
            {
                csp = new ContractScenicPrice()
                {
                    PriceContract = "pricecontract",
                    Scenic = scenic
                };
                target.SaveOrUpdate(csp);
                var result = target.GetcspByscid(scenic.Id);
                Assert.AreEqual("pricecontract", result.PriceContract);
            }
            else
            {
                Assert.Throws<ArgumentNullException>(delegate { target.SaveOrUpdate(csp); });
            }
        }

    }
}
