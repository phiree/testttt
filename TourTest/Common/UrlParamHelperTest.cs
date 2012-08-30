
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CommonLibrary;
namespace TourTest.Common
{
    [TestFixture]
    public class UrlParamHelperTest
    {

        [Test]
        public void BuildLinkTest()
        {
            Uri  url =new Uri("http://www.erewr.com/discounttickets/default.aspx?area=hangzhou&topic=t_shanshui&level=4a");
            string type = "area";
            string value = "ningbo";
            UrlParamHelper helper = new UrlParamHelper(url.AbsoluteUri);
            Assert.AreEqual("/ningbo/4a/t_shanshui",helper.BuildLink2(type,value));

            value = "";
            Assert.AreEqual("/4a/t_shanshui", helper.BuildLink2(type, value));

        }
    }
    }