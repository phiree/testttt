using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Xml;
using Model;
using BLL;
using System.IO;
using System.Net;
namespace TourTest.BLLTest
{
    [TestFixture]
    public class TicketXmlParserTest
    {

        [Test]
        public void TestParse()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(
                "<?xml version=\"1.0\" encoding=\"utf-8\" ?> <tourism_response> <data> <header> <result_code>0</result_code> <result_message></result_message> </header><tourism_items><tourism_item> <title>四0一洞天门票</title> <price>20</price> <mipang_id>32676</mipang_id> <photo></photo> <pic_more>http://ustatic.17u.cn/uploadfile/scenerypic_17u/350_263/2011/11/21/2/2011112108183166079.jpg|http://ustatic.17u.cn/uploadfile/scenerypic_17u/350_263/2011/11/21/2/2011112108183016448.jpg|http://ustatic.17u.cn/uploadfile/scenerypic_17u/350_263/2011/11/21/2/2011112108182976503.jpg|http://ustatic.17u.cn/uploadfile/scenerypic_17u/350_263/2011/11/21/2/2011112108182760207.jpg|http://ustatic.17u.cn/uploadfile/scenerypic_17u/350_263/2011/11/21/2/2011112108182623583.jpg|http://ustatic.17u.cn/uploadfile/scenerypic_17u/350_263/2011/08/23/2/2011082315452138991.jpg|http://ustatic.17u.cn/uploadfile/scenerypic_17u/350_263/2011/08/23/2/2011082315452098031.jpg|http://ustatic.17u.cn/uploadfile/scenerypic_17u/350_263/2011/08/23/2/2011082315451973744.jpg|http://ustatic.17u.cn/uploadfile/scenerypic_17u/350_263/2011/08/23/2/2011082315451884578.jpg|http://ustatic.17u.cn/uploadfile/scenerypic_17u/350_263/2011/08/23/2/2011082315451786951.jpg</pic_more> <tickets> <ticket> <ticket_id>7605</ticket_id> <ticket_name>成人票</ticket_name> <ticket_price>25</ticket_price> </ticket> <ticket> <ticket_id>12269</ticket_id> <ticket_name>CS枪战</ticket_name> <ticket_price>120</ticket_price> </ticket> <ticket> <ticket_id>15960</ticket_id> <ticket_name>成人票(4.29-5.1)</ticket_name> <ticket_price>40</ticket_price> </ticket> </tickets> </tourism_item> <tourism_item> <title>黄大仙基地门票</title> <price>150</price> <mipang_id>34273</mipang_id> <photo></photo> <pic_more>http://ustatic.17u.cn/uploadfile/scenerypic_17u/350_263/2011/11/24/2/2011112415575170684.png|http://ustatic.17u.cn/uploadfile/scenerypic_17u/350_263/2011/10/25/2/2011102511013132687.jpg|http://ustatic.17u.cn/uploadfile/scenerypic_17u/350_263/2011/10/25/2/2011102511013172552.jpg</pic_more> <tickets> <ticket> <ticket_id>7918</ticket_id> <ticket_name>成人票</ticket_name> <ticket_price>150</ticket_price> </ticket> </tickets> </tourism_item> </tourism_items></data> </tourism_response> "
                );

            TextReader reader = new StringReader(doc.InnerXml);
           
            BLL.TicketXmlParser ticketParser = new BLL.TicketXmlParser(reader);
            List<Scenic> sceniclist = ticketParser.Parse();

            Assert.AreEqual(25, sceniclist[0].Tickets[0].GetPrice(PriceType.PayOnline));

            StreamReader sr = new StreamReader(
                        WebRequest.Create("http://www.mipang.com/var/res/benniu/routes-1.xml").
                        GetResponse().GetResponseStream());
            string str = sr.ReadToEnd();
            Console.Write(str);

            Assert.IsTrue(new TicketXmlParser(
                    new StreamReader(
                        WebRequest.Create("http://www.mipang.com/var/res/benniu/routes-1.xml").
                        GetResponse().GetResponseStream())).Parse().Count 
                        > 0);


        }
    }
}
/*
 <tourism_item>
<title>四0一洞天门票</title>
<price>20</price>
<mipang_id>32676</mipang_id>
<photo></photo>
<pic_more>http://ustatic.17u.cn/uploadfile/scenerypic_17u/350_263/2011/11/21/2/2011112108183166079.jpg|http://ustatic.17u.cn/uploadfile/scenerypic_17u/350_263/2011/11/21/2/2011112108183016448.jpg|http://ustatic.17u.cn/uploadfile/scenerypic_17u/350_263/2011/11/21/2/2011112108182976503.jpg|http://ustatic.17u.cn/uploadfile/scenerypic_17u/350_263/2011/11/21/2/2011112108182760207.jpg|http://ustatic.17u.cn/uploadfile/scenerypic_17u/350_263/2011/11/21/2/2011112108182623583.jpg|http://ustatic.17u.cn/uploadfile/scenerypic_17u/350_263/2011/08/23/2/2011082315452138991.jpg|http://ustatic.17u.cn/uploadfile/scenerypic_17u/350_263/2011/08/23/2/2011082315452098031.jpg|http://ustatic.17u.cn/uploadfile/scenerypic_17u/350_263/2011/08/23/2/2011082315451973744.jpg|http://ustatic.17u.cn/uploadfile/scenerypic_17u/350_263/2011/08/23/2/2011082315451884578.jpg|http://ustatic.17u.cn/uploadfile/scenerypic_17u/350_263/2011/08/23/2/2011082315451786951.jpg</pic_more>
<tickets>
<ticket>
<ticket_id>7605</ticket_id>
<ticket_name>成人票</ticket_name>
<ticket_price>25</ticket_price>
</ticket>
<ticket>
<ticket_id>12269</ticket_id>
<ticket_name>CS枪战</ticket_name>
<ticket_price>120</ticket_price>
</ticket>
<ticket>
<ticket_id>15960</ticket_id>
<ticket_name>成人票(4.29-5.1)</ticket_name>
<ticket_price>40</ticket_price>
</ticket>
</tickets>
</tourism_item>
<tourism_item>
<title>黄大仙基地门票</title>
<price>150</price>
<mipang_id>34273</mipang_id>
<photo></photo>
<pic_more>http://ustatic.17u.cn/uploadfile/scenerypic_17u/350_263/2011/11/24/2/2011112415575170684.png|http://ustatic.17u.cn/uploadfile/scenerypic_17u/350_263/2011/10/25/2/2011102511013132687.jpg|http://ustatic.17u.cn/uploadfile/scenerypic_17u/350_263/2011/10/25/2/2011102511013172552.jpg</pic_more>
<tickets>
<ticket>
<ticket_id>7918</ticket_id>
<ticket_name>成人票</ticket_name>
<ticket_price>150</ticket_price>
</ticket>
</tickets>
</tourism_item>
 */
