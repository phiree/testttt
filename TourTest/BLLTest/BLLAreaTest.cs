using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace TourTest.BLLTest
{
    [TestFixture]
    public class BLLAreaTest
    {
        //IDAL.IArea dal = new DAL.DALArea();
        //[Test]
        //public void GetAreaProvinceTest()
        //{

        //    dal.GetAreaProvince();
        //}
        //[Test]
        //public void GetChildAreaIds()
        //{
        //    BLL.BLLArea bllArea = new BLL.BLLArea();
        //    string ids = bllArea.GetChildAreaIds("330100");
        //    Console.Write(ids);
        //    Assert.IsTrue(ids.Length > 10);
        //}
        DAL.DALArea dalArea;
        BLL.BLLArea bllArea;
        [SetUp]
        public void Init()
        {
            bllarea = new BLL.BLLArea();

        }

        BLL.BLLArea bllarea = new BLL.BLLArea();
        [Test]
        public void GetAreaTest_zero()
        {
            var result = bllarea.GetArea(0);
            Assert.AreEqual(result.Count, 0);
        }

        [Test]
        public void GetAreaTest_navigate()
        {
            var result = bllarea.GetArea(-1);
            Assert.AreEqual(result.Count, 0);
        }

        [Test]
        public void GetAreaTest_zhejiang()
        {
            var result = bllarea.GetArea(33);
            Assert.AreEqual(result.Count, 12);
        }

        [Test]
        public void GetSubAreaTest_null()
        {
            var result = bllarea.GetSubArea(null);
            Assert.IsNull(result);
        }

        [Test]
        public void GetSubAreaTest_shortinlength()
        {
            var result = bllarea.GetSubArea("12345");
            Assert.IsNull(result);
        }

        [Test]
        public void GetSubAreaTest_wrongarea()
        {
            var result = bllarea.GetSubArea("123456");
            Assert.IsNull(result);
        }

        [Test]
        public void GetSubAreaTest_zhejiangsheng()
        {
            var result = bllarea.GetSubArea("330000");
            Assert.AreEqual(result.Count, 11);
        }

        [Test]
        public void GetAreaByAreaidTest_wrongid()
        {
            var result = bllarea.GetAreaByAreaid(0);
            Assert.IsNull(result);
        }

        [Test]
        public void GetAreaByAreaidTest_rightid()
        {
            var result = bllarea.GetAreaByAreaid(2);
            Assert.AreEqual(result.Name, "北京市市辖区");
        }

        [Test]
        public void GetAreaByAreanameTest_null()
        {
            var result = bllarea.GetAreaByAreaname(null);
            Assert.IsNull(result);
        }

        [Test]
        public void GetAreaByAreanameTest_wrongname()
        {
            var result = bllarea.GetAreaByAreaname("阿波罗");
            Assert.IsNull(result);
        }

        [Test]
        public void GetAreaByAreanameTest_rightname()
        {
            var result = bllarea.GetAreaByAreaname("北京市市辖区");
            Assert.AreEqual(result.Code, "110100");
        }

        [Test]
        public void GetAreaBySeoNameTest_null()
        {
            var result = bllarea.GetAreaBySeoName(null);
            Assert.IsNull(result);
        }

        [Test]
        public void GetAreaBySeoNameTest_wrongname()
        {
            var result = bllarea.GetAreaBySeoName("abc");
            Assert.IsNull(result);
        }

        [Test]
        public void GetAreaBySeoNameTest_rightname()
        {
            var result = bllarea.GetAreaBySeoName("hangzhoushixiaqu");
            Assert.AreEqual(result.Name, "浙江省杭州市市辖区");
        }

        [Test]
        [Category("GetAreaByCodeTest")]
        public void GetAreaByCodeTest_null()
        {
            var result = bllarea.GetAreaByCode(null);
            Assert.IsNull(result);
        }

        [Test]
        [Category("GetAreaByCodeTest")]
        public void GetAreaByCodeTest_wrongcode()
        {
            var result = bllarea.GetAreaByCode("123");
            Assert.IsNull(result);
        }

        [Test]
        [Category("GetAreaByCodeTest")]
        public void GetAreaByCodeTest_rightcode()
        {
            var result = bllarea.GetAreaByCode("330101");
            Assert.AreEqual(result.Name, "浙江省杭州市市辖区");
        }

        [Test]
        public void GetAreaProvinceTest()
        {
            var result = bllarea.GetAreaProvince();
            Assert.AreEqual(34, result.Count);
        }

        [Test]
        public void GetChildAreaIdsTest_null()
        {
            var result = bllarea.GetChildAreaIds(null);
            Assert.IsNullOrEmpty(result);
        }

        [Test]
        public void GetChildAreaIdsTest_wrongcode()
        {
            var result = bllarea.GetChildAreaIds("123");
            Assert.IsNullOrEmpty(result);
        }

        [Test]
        public void GetChildAreaIdsTest_rightcode()
        {
            var result = bllarea.GetChildAreaIds("330100");
            Assert.AreEqual("1019,1020,1021,1022,1023,1024,1025,1026,1027,1028,1029,1030,1031,1032,1033", result);
            var result2 = bllarea.GetChildAreaIds("330000");
            Console.WriteLine(result2);
            Assert.AreEqual("1018,1019,1034,1047,1060,1069,1076,1084,1095,1103,1109,1120,", result2);
        }
    }
}
