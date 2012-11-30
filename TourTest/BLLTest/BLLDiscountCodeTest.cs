using BLL;
using System;
using Model;
using System.Collections.Generic;
using IDAL;
using NUnit.Framework;

namespace TESTDEMO
{
    
    
    /// <summary>
    ///这是 BLLDiscountCodeTest 的测试类，旨在
    ///包含所有 BLLDiscountCodeTest 单元测试
    ///</summary>
    [TestFixture]
    public class BLLDiscountCodeTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试特性
        // 
        //编写测试时，还可使用以下特性:
        //
        //使用 ClassInitialize 在运行类中的第一个测试前先运行代码
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //使用 ClassCleanup 在运行完类中的所有测试后再运行代码
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //使用 TestInitialize 在运行每个测试前先运行代码
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //使用 TestCleanup 在运行完每个测试后运行代码
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///BLLDiscountCode 构造函数 的测试
        ///</summary>
        [Test]
        public void BLLDiscountCodeConstructorTest()
        {
            BLLDiscountCode target = new BLLDiscountCode();
            Assert.Inconclusive("TODO: 实现用来验证目标的代码");
        }

        /// <summary>
        ///GetDiscountCodeByCardid 的测试
        ///</summary>
        [Test]
        public void GetDiscountCodeByCardidTest()
        {
            BLLDiscountCode target = new BLLDiscountCode(); // TODO: 初始化为适当的值
            string cardid = string.Empty; // TODO: 初始化为适当的值
            IList<DiscountCode> expected = null; // TODO: 初始化为适当的值
            IList<DiscountCode> actual;
            actual = target.GetDiscountCodeByCardid(cardid);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetDiscountCodeByDisCode 的测试
        ///</summary>
        [Test]
        public void GetDiscountCodeByDisCodeTest()
        {
            BLLDiscountCode target = new BLLDiscountCode(); // TODO: 初始化为适当的值
            string discode = string.Empty; // TODO: 初始化为适当的值
            DiscountCode expected = null; // TODO: 初始化为适当的值
            DiscountCode actual;
            actual = target.GetDiscountCodeByDisCode(discode);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///updateDiscountCode 的测试
        ///</summary>
        [Test]
        public void updateDiscountCodeTest()
        {
            BLLDiscountCode target = new BLLDiscountCode(); // TODO: 初始化为适当的值
            DiscountCode dc = null; // TODO: 初始化为适当的值
            target.updateDiscountCode(dc);
            Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///Idiscountcode 的测试
        ///</summary>
        [Test]
        public void IdiscountcodeTest()
        {
            BLLDiscountCode target = new BLLDiscountCode(); // TODO: 初始化为适当的值
            IDiscountCode expected = null; // TODO: 初始化为适当的值
            IDiscountCode actual;
            target.Idiscountcode = expected;
            actual = target.Idiscountcode;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
