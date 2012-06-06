using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Model;
namespace TourTest.TDD.ScenicCheck
{
    [TestFixture]
    public class TestCode
    {
        Scenic scenic = new Scenic();
            
        /// <summary>
        /// 申请开通网上售票 
        /// </summary>
        [Test]
        public void Apply()
        {
           // scenic.modu |= ScenicModule.SellOnLine;

        }
        /// <summary>
        /// 三个价格的大小关系
        /// </summary>
        [Test]
        public void SetPrice()
        {
            Scenic scenic = new Scenic();
         
           // Assert.IsTrue(scenic.CheckPrice());
        }
        /// <summary>
        /// 用户购买两个景点的门票
        /// </summary>
        [Test]
        public void BuyTicket()
        {
            //Member member = new Member();
            //Order order = new Order();
            //order.Member = member;
            //order.OrderTime = DateTime.Now;

            //OrderDetail detail = new OrderDetail();
            //Scenic s=new Scenic();
            //detail.Scenic = s;
            //detail.Price = s.OrderPrice;

        }

        [Test]
        public void TestJson()
        { 
           string json=@"[{""3435739478441954"":""yeZKjzq8y""},{""3435735283681249"":""yeZDyfrEZ""}]";

           Newtonsoft.Json.Linq.JArray arrya = Newtonsoft.Json.JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JArray>(json);

           Newtonsoft.Json.Linq.JToken token = arrya[0];
           foreach (Newtonsoft.Json.Linq.JToken t in arrya)
           {
               foreach (Newtonsoft.Json.Linq.JProperty p in t)
               {
                   Console.Write(p.Name+";;;"+p.Value+"|");
               }
           }

           Console.WriteLine(arrya.Count);
           Console.WriteLine(arrya[0]);
          
        }


    }
}
