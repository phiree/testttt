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
