using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Model;
using System.Collections;
using System.Xml.Serialization;
using System.IO;
namespace BLL
{
    /*
     * <?xml version="1.0" encoding="utf-8" ?>
<tourism_response>
<data>
     * -------------------
<header>
<result_code>0</result_code>
<result_message></result_message>
</header>
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
     * ------------------------
     * </tourism_response>
</data>

     */
    /// <summary>
    /// 
    /// </summary>
    public class TicketXmlParser
    {
      
        public TextReader DocReader { get; set; }
        public TicketXmlParser(TextReader docReader)
        {

            this.DocReader = docReader;
            

        }

        public List<Scenic> Parse()
        {
            
          
            XmlSerializer serializer =
             new XmlSerializer(typeof(tourism_response));

            tourism_response resp = (tourism_response)serializer.Deserialize(DocReader);

            List<Scenic> scenicList = new List<Scenic>();
            foreach (tourism_item item in resp.data.tourism_items)
            {
                Scenic s = ParseTicket(item);
                scenicList.Add(s);
            }
            return scenicList;
        }

        private Scenic ParseTicket(tourism_item item)
        {
            Scenic s = new Scenic();
            s.Name = item.title;
            s.MipangId = item.mipang_id;
            s.Phone = item.photo;
            s.Type = EnterpriseType.景点;
            s.IsHide = true;

            ///构造景点的area对象
            ///现有数据: 浙江/江苏/All/杭州/建德
            ///目标数据:浙江省杭州市
            s.Desec = item.city;
            


            foreach (ticket ticket in item.tickets)
            {
                Ticket t = new Ticket();
                t.IsMain = true;
                t.Name = ticket.ticket_name;

               
                TicketPrice tp1 = new TicketPrice();
                TicketPrice tp2= new TicketPrice();
                TicketPrice tp3 = new TicketPrice();
                tp1.Price = ticket.ticket_price;
                tp1.PriceType = PriceType.Normal;
                tp1.Ticket = t;

                tp2.Price = ticket.ticket_price;
                tp2.PriceType = PriceType.PreOrder;
                tp2.Ticket = t;

                tp3.Price = ticket.ticket_price;
                tp3.PriceType = PriceType.PayOnline;
                tp3.Ticket = t;

                t.TicketPrice.Add(tp1);
                t.TicketPrice.Add(tp2);
                t.TicketPrice.Add(tp3);

              //  t.TicketPrice = tps;
                t.Scenic = s;
                s.Tickets.Add(t);
            }


            return s;
        }

    }
    public class tourism_response
    {
        public data data { get; set; }
    }
    public class data
    {
        public header header { get; set; }
        public List<tourism_item> tourism_items { get; set; }
    }
    public class header
    {
        public string result_code { get; set; }
        public string result_message { get; set; }
    }
    public class tourism_item
    {
        public string title { get; set; }
        public string price { get; set; }
        public string city { get; set; }
        public string mipang_id { get; set; }
        public string photo { get; set; }
        public string pic_more { get; set; }
        public List<ticket> tickets { get; set; }
    }
    [System.Xml.Serialization.XmlRoot("ticket")]
    public class ticket
    {
        public string ticket_id { get; set; }
        public string ticket_name { get; set; }
        public decimal ticket_price { get; set; }
    }
}
