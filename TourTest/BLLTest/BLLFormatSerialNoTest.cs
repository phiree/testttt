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
            //mock对象
            var mocks = new MockRepository();
            var dal = mocks.Stub<DALFormatSerialNo>();
            List<FormatSerialNo> formatlist = new List<FormatSerialNo>();
            formatlist.Add(new FormatSerialNo() { 
                Flag="FA",
                Year=DateTime.Today.Year.ToString().Substring(2, 2),
                Month = DateTime.Today.Month.ToString("D2"),
                Day = DateTime.Today.Day.ToString("D2"),
                Value="0001"
            });
            formatlist.Add(new FormatSerialNo()
            {
                Flag = "FA",
                Year = DateTime.Today.Year.ToString().Substring(2, 2),
                Month = DateTime.Today.Month.ToString("D2"),
                Day = DateTime.Today.Day.ToString("D2"),
                Value = "0002"
            });
            dal.Stub(x => x.GetSerialNoList("FA")).Return(formatlist);
            target.IdalFS = dal;

            //test
            Assert.AreEqual("121203FA0001", target.GetSerialNo("FA"));
            //Assert.Throws<ArgumentException>(delegate { target.GetSerialNo("FA"); });
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
            target.IdalFS = idal;

            //test

        }

        /// <summary>
        ///EnsureFormatItemLength 的测试
        ///</summary>
        [Test]
        public void EnsureFormatItemLengthTest()
        {

        }

    }
}
