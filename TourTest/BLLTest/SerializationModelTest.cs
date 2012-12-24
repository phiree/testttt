using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;
using BLL;
using Model;
namespace TourTest.BLLTest
{
    [TestFixture]
    public class SerializationModelTest
    {
        [Test]
        public void SerializeMember()
        {
            DJ_TourGroupMember member = new DJ_TourGroupMember();
            string errMsg;
            //11111111111  类型,姓名,电话
            string formatedstring = "成人游客,小明,14093039130";
           member= SerializationModel.SerializeMember(formatedstring, out errMsg);
           Assert.AreEqual(MemberType.成, member.MemberType);
           Assert.AreEqual("小明", member.RealName);
           Assert.AreEqual("14093039130", member.PhoneNum);
           //11111111111  类型,姓名,身份证
           string formatedstring1 = "成人游客,小明,420822198010103916";
           member = SerializationModel.SerializeMember(formatedstring1, out errMsg);
           Assert.AreEqual(MemberType.成, member.MemberType);
           Assert.AreEqual("小明", member.RealName);
           Assert.AreEqual("420822198010103916", member.IdCardNo);

           //11111111111  类型,姓名,其他证件
           string formatedstring11 = "成人游客,小明,W345342363";
           member = SerializationModel.SerializeMember(formatedstring11, out errMsg);
           Assert.AreEqual(MemberType.成, member.MemberType);
           Assert.AreEqual("小明", member.RealName);
           Assert.AreEqual("W345342363", member.SpecialCardNo);

            ///22222222 类型,姓名 身份证 电话
           string formatedstring2 = "成人游客,小明,420822198010103916,13920291023";
           member = SerializationModel.SerializeMember(formatedstring2, out errMsg);
           Assert.AreEqual(MemberType.成, member.MemberType);
           Assert.AreEqual("小明", member.RealName);
           Assert.AreEqual("420822198010103916", member.IdCardNo);
           Assert.AreEqual("13920291023", member.PhoneNum);
            //3333333333类型 姓名,其他证件,电话
           string formatedstring3 = "成人游客,小明,W23432rewq34,13920291023";
           member = SerializationModel.SerializeMember(formatedstring3, out errMsg);
           Assert.AreEqual(MemberType.成, member.MemberType);
           Assert.AreEqual("小明", member.RealName);
           Assert.AreEqual("W23432rewq34", member.SpecialCardNo);
           Assert.AreEqual("13920291023", member.PhoneNum);

          
        }
    }
}
