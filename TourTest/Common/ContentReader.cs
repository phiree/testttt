using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CommonLibrary;

namespace TourTest.Common
{
    [TestFixture]
    public class ContentReader
    {
        [Test]
        public void testContentReader()
        {
           HTMLInfo htmlinfo = new HTMLInfo();
           string html=htmlinfo.GetHTMLInfo("首页", null, 0);
           string oldhtml="<div>这是测试首页<p>测试测试测试测试测试</p></div>";
           Assert.AreEqual(oldhtml, html);
           html = htmlinfo.GetHTMLInfo("景区", "西湖", 1);
           oldhtml = "<p>这是一个西湖订票说明页面s</p>";
           Assert.AreEqual(oldhtml, html);
        }
    }
}
