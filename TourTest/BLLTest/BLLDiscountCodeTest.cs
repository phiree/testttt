using BLL;
using System;
using Model;
using System.Collections.Generic;
using IDAL;
using NUnit.Framework;

namespace TourTest.BLLTest
{
    
    
    /// <summary>
    ///这是 BLLDiscountCodeTest 的测试类，旨在
    ///包含所有 BLLDiscountCodeTest 单元测试
    ///</summary>
    [TestFixture]
    public class BLLDiscountCodeTest
    {

        BLLDiscountCode target = new BLLDiscountCode(); // TODO: 初始化为适当的值

        [Test]
        public void GetDiscountCodeByCardidTest_null()
        {
            var result = target.GetDiscountCodeByCardid(null);
            Assert.IsTrue(result.Count == 0);
        }

        /// <summary>
        ///GetDiscountCodeByDisCode 的测试
        ///</summary>
        [Test]
        public void GetDiscountCodeByDisCodeTest()
        {
            //string discode = string.Empty; // TODO: 初始化为适当的值
            //DiscountCode expected = null; // TODO: 初始化为适当的值
            //DiscountCode actual;
            //actual = target.GetDiscountCodeByDisCode(discode);
            //Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///updateDiscountCode 的测试
        ///</summary>
        [Test]
        public void updateDiscountCodeTest()
        {
            
            //DiscountCode dc = null; // TODO: 初始化为适当的值
            //target.updateDiscountCode(dc);
        }

        /// <summary>
        ///Idiscountcode 的测试
        ///</summary>
        [Test]
        public void IdiscountcodeTest()
        {
            
            //IDiscountCode expected = null; // TODO: 初始化为适当的值
            //IDiscountCode actual;
            //target.Idiscountcode = expected;
            //actual = target.Idiscountcode;
            //Assert.AreEqual(expected, actual);
        }
    }
}
