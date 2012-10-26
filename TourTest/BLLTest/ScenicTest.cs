using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace TourTest.BLLTest
{
    [TestFixture]
    public class ScenicTest
    {
       
        [Test]
        public void GetChildAreaIds()
        {
            BLL.BLLScenic bllScenic = new BLL.BLLScenic();
          IList<Model.Scenic> scenics=  bllScenic.GetList_Mipang();
          Assert.IsTrue(scenics.Count > 0);
            
        }
    }
}
