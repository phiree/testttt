using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Model;
namespace BLL.Default.MipangTicket
{
    /*
 Scenic    <tourism_item>
 Name  <title>【门票】东平国家森林公园门票&lt;景区取票，请至少提早一天预订，下订单时备注出游日期&gt;</title>
 <price>60</price>
<mipang_id>412743</mipang_id>
<photo>http://mcs4.malmam.com/uploads/image/121010/2218752_1084047_12f257f3be.jpg</photo>
<tickets>
<ticket>
<ticket_id>0</ticket_id>
TicketName   <ticket_name>成人票</ticket_name>
TicketPrice(type,price) <ticket_price>60</ticket_price>
</ticket>
</tickets>
</tourism_item>

     */
    /// <summary>
    /// 
    /// </summary>
    public class TicketXmlParser
    {
        public XmlDocument Doc { get; set; }
        public TicketXmlParser(XmlDocument doc)
        {
            this.Doc = doc;
        }
        public bool Parse()
        {
            bool result = true;
            foreach (XmlNode node in Doc.ChildNodes)
            {
                Ticket t = ParseTicket(node);
                //save ticket
            }
            return result;
        }

        public Ticket ParseTicket(XmlNode node)
        {
            Ticket t = new Ticket();

            //xml里每种门票只有一个价格--> 将三种价格都设置为一样
            return t;
        }
        //
    }
}
