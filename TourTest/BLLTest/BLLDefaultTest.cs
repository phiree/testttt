using BLL;
using System;
using IDAL;
using NUnit.Framework;

namespace TourTest.BLLTest
{
    
    
    /// <summary>
    ///这是 BLLDefaultTest 的测试类，旨在
    ///包含所有 BLLDefaultTest 单元测试
    ///</summary>
    [TestFixture]
    public class BLLDefaultTest
    {
        BLLDefault target = new BLLDefault(); // TODO: 初始化为适当的值

        /// <summary>
        ///BLLDefault 构造函数 的测试
        ///</summary>
        //[Test]
        //public void BLLDefaultConstructorTest()
        //{
        //    BLLDefault target = new BLLDefault();
        //    Assert.Inconclusive("TODO: 实现用来验证目标的代码");
        //}

        /// <summary>
        ///Imem 的测试
        ///</summary>
        [Test]
        public void ImemTest()
        {
            IMembership expected =new DAL.DALMembership(); // TODO: 初始化为适当的值
            IMembership actual;
            target.Imem = expected;
            actual = target.Imem;
            Assert.AreEqual(expected, actual);
        }
    }
}
