using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using NUnit.Framework;
namespace TourTest.TestDAL
{
    [TestFixture]
    public class TEstDalBase
    {
        [Test]
        public void SaveObjectHasTime()
        {

            DalBase<Model.DJ_TourEnterprise> dalEnt = new DalBase<Model.DJ_TourEnterprise>();
            Model.DJ_TourEnterprise ent = new Model.DJ_TourEnterprise();
            ent.Name = "aa";
            ent.LastUpdateTime = DateTime.Now;
            dalEnt.Save(ent);
        }
    }
}
