using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
namespace TourTest.Common
{
    [TestFixture]
public    class AppSettingsManagerTest
    {
        [Test]
        public void UpdateTest()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            string startTime="aabb";
            dict.Add("startTime",startTime);
            dict.Add("endTime", DateTime.Now.ToString());

            CommonLibrary.AppSettingsManager manager = new CommonLibrary.AppSettingsManager();
            manager.Update(dict);

            Assert.AreEqual(System.Configuration.ConfigurationManager.AppSettings["startTime"], "aabb");
        }
    }
}
