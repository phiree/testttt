
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CommonLibrary;
namespace TourTest.Common
{
    [TestFixture]
    public class testStringHelper
    {

        [Test]
        public void testBuildHref()
        {
            
            //打开首页,area链接地址
            string urlquery = "/3";
            string type = "area";
            string value = "hangzhou";
            Assert.AreEqual(UrlParamHelper.BuildLink(urlquery, type, value), "/hangzhou");
            // 每个level的连接地址
            urlquery = "/";
            type = "level";
            value = "5a";
            Assert.AreEqual(UrlParamHelper.BuildLink(urlquery, type, value), "/5a");


            //点击area之后, 每个area的连接地址
            urlquery = "/hangzhou/4";
            type = "area";
            value = "ningbo";
            Assert.AreEqual(UrlParamHelper.BuildLink(urlquery, type, value), "/ningbo");


            //点击area之后, 每个level的连接地址
            urlquery = "hangzhou";
            type = "level";
            value = "4a";
            Assert.AreEqual(UrlParamHelper.BuildLink(urlquery, type, value), "/hangzhou/4a");

            //再点击ningbo的链接 每个area的连接
            urlquery = "/hangzhou/4a";
            type = "area";
            value = "ningbo";
            Assert.AreEqual(UrlParamHelper.BuildLink(urlquery, type, value), "/ningbo/4a");
           
            //点击level之后,每个area的链接
            urlquery = "/ningbo/4a";
            type = "level";
            value = "5a";
            Assert.AreEqual(UrlParamHelper.BuildLink(urlquery, type, value), "/ningbo/5a");

            //点击area全部之后,每个area的连接
            urlquery = "/ningbo/5a";
            type = "area";
            value = "hangzhou";
            Assert.AreEqual(UrlParamHelper.BuildLink(urlquery, type, value), "/hangzhou/5a");

            //点击area全部之后,每个level的连接
            urlquery = "/5a";
            type = "level";
            value = "5a";
            Assert.AreEqual(UrlParamHelper.BuildLink(urlquery, type, value), "/5a");

            //点击level全部之后 每个area的连接
            urlquery = "/";
            type = "area";
            value = "ningbo";
            Assert.AreEqual(UrlParamHelper.BuildLink(urlquery, type, value), "/ningbo");
            //点击level全部之后 每个level的连接

            urlquery = "/";
            type = "level";
            value = "5a";
            Assert.AreEqual(UrlParamHelper.BuildLink(urlquery, type, value), "/5a");


            //全部级别的链接
            urlquery = "/hangzhou/4a";
            type = "level";
            value = "5a";
            Assert.AreEqual(UrlParamHelper.BuildLink(urlquery, type, value,true), "/hangzhou");

            //全部地区的链接
            urlquery = "/hangzhou/4a";
            type = "area";
            value = "hangzhou";
            Assert.AreEqual(UrlParamHelper.BuildLink(urlquery, type, value, true), "/4a");


            //全部地区的链接
            urlquery = "/4a";
            type = "area";
            value = "hangzhou";
            Assert.AreEqual(UrlParamHelper.BuildLink(urlquery, type, value, true), "/4a");

            //分页情况下的连接
            urlquery = "/4";
            type = "level";
            value = "3a";
            Assert.AreEqual(UrlParamHelper.BuildLink(urlquery, type, value, false), "/3a");

        }
        [Test]
        public void TestBuildLink2()
        { 
            string level="3a";
            string area="hangzhou";
            string url = string.Format("www.tourol.com/default.aspx?area={0}&level={1}", area, level);
            CommonLibrary.UrlParamHelper helper = new UrlParamHelper(url);
            Assert.AreEqual("/hangzhou/4a", helper.BuildLink2("level", "4a"));

             level = "";
             area = "";
             url = string.Format("www.tourol.com/default.aspx");
             helper = new UrlParamHelper(url);
            Assert.AreEqual("/4a", helper.BuildLink2("level", "4a"));

            level = "";
            area = "";
            url = string.Format("www.tourol.com/default.aspx?pgotindex=2");
            helper = new UrlParamHelper(url);
            Assert.AreEqual("/4a", helper.BuildLink2("level", "4a"));

            level = "";
            area = "ningbo";
            url = string.Format("www.tourol.com/default.aspx?area={0}&pgotindex=2",area);
            helper = new UrlParamHelper(url);
            Assert.AreEqual("/ningbo", helper.BuildLink2("area", area));

            level = "4a";
            url ="www.tourol.com/default.aspx?area=hangzhou";
            helper = new UrlParamHelper(url);
            Assert.AreEqual("/hangzhou/4a", helper.BuildLink2("level", level));
        }
    }
}
