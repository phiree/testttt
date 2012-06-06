using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
namespace TourTest
{
    [TestFixture]
  public  class ScenicTest
    {
        [Test]
        public void UpdateScenicTest()
        {
            IDAL.IScenic dal = new DAL.DALScenic();

            Model.Scenic scenic = new Model.Scenic();
            scenic.ActiveTime = DateTime.Now.ToString();
            scenic.Address = "address";
            Model.Area area = new Model.Area();
            area.AreaOrder = 1;
            area.Code = "310000";
            area.Id = 1;
            area.Name = "杭州市";
            scenic.Area = area;
            scenic.Desec = "";
            scenic.Id = 2;
            scenic.Level = "1A";
            scenic.Name = "11111111杭州西湖";

            dal.UpdateScenicInfo(scenic);
        }
    }
}
