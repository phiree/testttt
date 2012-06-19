using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
namespace TourTest.webtest.pageobjects
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
   public class @default
    {

       /// <summary>
       /// 页面加载之后 显示提示信息.
       /// 获得焦点 显示空白./ 如果不输入任何信息 移出焦点,重新显示提示信息. 否则 显示输入的信息
       /// </summary>
       [Test]
       public void TipTest()
       {
           RemoteWebDriver driver = new OpenQA.Selenium.IE.InternetExplorerDriver();
           driver.Url = "www.tourol.com";
         //  driver.Manage().Timeouts().SetPageLoadTimeout(new TimeSpan(1000));
           string tbxKeyword = "tbxKeywords";
           string btnSearchID="btnSearch";
           string tipMsg = "输入景区或景点名称";
           IWebElement element = driver.FindElementById(tbxKeyword);
           Assert.AreEqual(tipMsg,element.GetAttribute("value"));
           element.Click();
           Assert.AreEqual(string.Empty, element.GetAttribute("value"));
           string searchWord="杭州";
           element.SendKeys(searchWord);
           Assert.AreEqual(searchWord, element.GetAttribute("value"));
           driver.Mouse.Click(((RemoteWebElement)element).Coordinates);


           Assert.AreEqual(searchWord, element.GetAttribute("value"));

          
       }
    }
}
