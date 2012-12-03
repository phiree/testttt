using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;
using DAL;
namespace TourTest.BLLTest
{
    [TestFixture]
    public class FormatSerialNoTest
    {
        [Test]
        public void GetNoTest()
        {
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

        [Test]
        public void EnsureFormatItemLengthTest()
        {
            string actual = string.Empty;
            BLL.BLLFormatSerialNo bll = new BLL.BLLFormatSerialNo();
            int length=3;
            int value=4;
            actual = bll.EnsureFormatItemLength(length, value);
            Assert.AreEqual(value.ToString("d"+length), actual);
        }
    }
}
