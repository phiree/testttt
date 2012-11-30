using BLL;
using System;
using IDAL;
using NUnit.Framework;

namespace TESTDEMO
{
    
    
    /// <summary>
    ///这是 BLLFormatSerialNoTest 的测试类，旨在
    ///包含所有 BLLFormatSerialNoTest 单元测试
    ///</summary>
    [TestFixture]
    public class BLLFormatSerialNoTest
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
        ///BLLFormatSerialNo 构造函数 的测试
        ///</summary>
        [Test]
        public void BLLFormatSerialNoConstructorTest()
        {
            BLLFormatSerialNo target = new BLLFormatSerialNo();
            Assert.Inconclusive("TODO: 实现用来验证目标的代码");
        }

        /// <summary>
        ///EnsureFormatItemLength 的测试
        ///</summary>
        [Test]
        public void EnsureFormatItemLengthTest()
        {
            BLLFormatSerialNo target = new BLLFormatSerialNo(); // TODO: 初始化为适当的值
            int length = 0; // TODO: 初始化为适当的值
            int value = 0; // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = target.EnsureFormatItemLength(length, value);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetSerialNo 的测试
        ///</summary>
        [Test]
        public void GetSerialNoTest()
        {
            BLLFormatSerialNo target = new BLLFormatSerialNo(); // TODO: 初始化为适当的值
            string flag = string.Empty; // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = target.GetSerialNo(flag);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetSerialNo 的测试
        ///</summary>
        [Test]
        public void GetSerialNoTest1()
        {
            BLLFormatSerialNo target = new BLLFormatSerialNo(); // TODO: 初始化为适当的值
            string flag = string.Empty; // TODO: 初始化为适当的值
            bool includeDay = false; // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = target.GetSerialNo(flag, includeDay);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///IdalFS 的测试
        ///</summary>
        [Test]
        public void IdalFSTest()
        {
            BLLFormatSerialNo target = new BLLFormatSerialNo(); // TODO: 初始化为适当的值
            IDALFormatSerialNo expected = null; // TODO: 初始化为适当的值
            IDALFormatSerialNo actual;
            target.IdalFS = expected;
            actual = target.IdalFS;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
