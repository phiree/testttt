using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CommonLibrary;
using System.IO;
using System.Configuration;
using BLL;
namespace TourTest.Common
{
    [TestFixture]
    public class JosnHelperTest
    {
        [Test]
        public void testJsonHelper()
        {
         //   string jsonStr = "{\"fieldsName\":[\"memberid\",\"no\",\"tourertype\",\"realname\",\"phone\",\"idcardno\",\"othercardno\"],\"recordType\":\"object\",\"parameters\":{\"groupid\":\"b3f88d1f-12b9-45fd-af3f-a0f300ba59e2\"},\"action\":\"save\",\"insertedRecords\":[{\"no\":\"1\",\"tourertype\":\"2\",\"realname\":\"33\",\"phone\":\"33\",\"idcardno\":\"420822198010103916\",\"othercardno\":\"11111\",\"memberid\":\"\"}],\"updatedRecords\":[],\"deletedRecords\":[]}";
            string jsonStr = "{\"parameters\":{\"groupid\":\"b3f88d1f-12b9-45fd-af3f-a0f300ba59e2\"}";

            BLL.SigmaGridRequestObject sro = JosnHelper.ParseFromJson<BLL.SigmaGridRequestObject>(jsonStr);
           // Assert.AreEqual(sro.fieldsName.Length,7);
       //  Assert.AreEqual(sro.parameters.groupid, "b3f88d1f-12b9-45fd-af3f-a0f300ba59e2");
        }
    }
}
