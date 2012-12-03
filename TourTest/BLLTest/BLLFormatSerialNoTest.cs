using BLL;
using System;
using IDAL;
using NUnit.Framework;
using Rhino.Mocks;
using System.Collections.Generic;
using Model;
using DAL;

namespace TourTest.BLLTest
{


    /// <summary>
    ///这是 BLLFormatSerialNoTest 的测试类，旨在
    ///包含所有 BLLFormatSerialNoTest 单元测试
    ///</summary>
    [TestFixture]
    public class BLLFormatSerialNoTest
    {

        BLLFormatSerialNo target = new BLLFormatSerialNo(); // TODO: 初始化为适当的值

        /// <summary>
        ///GetSerialNo 的测试
        ///</summary>
        [Test]
        public void GetSerialNoTest_multiflag()
        {
            ////mock对象
            ////var mocks = new MockRepository();
            //var dal = MockRepository.GenerateStub<DALFormatSerialNo>();
            //List<FormatSerialNo> formatlist = new List<FormatSerialNo>();
            ////formatlist.Add(new FormatSerialNo() { 
            ////    Flag="FA",
            ////    Year="2012",
            ////    Month="12",
            ////    Day="3",
            ////    Value="001"
            ////});
            ////formatlist.Add(new FormatSerialNo()
            ////{
            ////    Flag = "FA",
            ////    Year = "2013",
            ////    Month = "12",
            ////    Day = "3",
            ////    Value = "001"
            ////});
            //dal.Stub(x => x.GetSerialNoList("TK")).Return(formatlist);
            //target.DalFS = dal;

            ////test
            //Assert.Throws<InvalidOperationException>(delegate { target.GetSerialNo("FA"); });
            //20120612 ->20120612TK001
            string expect = "120626TK0001";
            var IdalFormat = MockRepository.GenerateStub<DALFormatSerialNo>();
            List<Model.FormatSerialNo> nos = new List<Model.FormatSerialNo>();
            IdalFormat.Stub(x => x.GetSerialNoList("TK")).Return(nos);

            BLL.BLLFormatSerialNo bllFS = new BLL.BLLFormatSerialNo();
            bllFS.DalFS = IdalFormat;
            string actual = bllFS.GetSerialNo("TK");
            Assert.AreEqual(expect, actual);

            Model.FormatSerialNo n1 = new Model.FormatSerialNo();
            n1.Year = "12";
            n1.Month = "06";
            n1.Day = "26";
            n1.Value = "0001";
            n1.Flag = "TK";
            nos.Add(n1);

            IdalFormat.Stub(x => x.GetSerialNoList("TK")).Return(nos);
            expect = "120626TK0002";
            actual = bllFS.GetSerialNo("TK");
            Assert.AreEqual(expect, actual);
        }

        /// <summary>
        ///GetSerialNo 的测试
        ///</summary>
        [Test]
        public void GetSerialNoTest_wrongyear()
        {
            //mock对象
            MockRepository mocks = new MockRepository();
            DALFormatSerialNo idal = mocks.Stub<DALFormatSerialNo>();
            IList<FormatSerialNo> formatlist = new List<FormatSerialNo>();
            formatlist.Add(new FormatSerialNo()
            {
                Flag = "FA",
                Year = "2012",
                Month = "12",
                Day = "3",
                Value = "FA201212030003",
                FormatId = 1
            });
            idal.Stub(x => x.GetSerialNoList("FA")).Return(formatlist);
            target.DalFS = idal;

            //test

        }

        /// <summary>
        ///EnsureFormatItemLength 的测试
        ///</summary>
        [Test]
        public void EnsureFormatItemLengthTest()
        {

        }

        /// <summary>
        ///IdalFS 的测试
        ///</summary>
        [Test]
        public void IdalFSTest()
        {

        }
    }
}
