using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NHibernate;
using NHibernate.Cfg;
using Model;
using NHibernate.Tool.hbm2ddl;
namespace TourTest.NhibernateTest
{
    [TestFixture]
    class MappintTest
    {
        [Test]
        public void Can_generate_schema()
        {
            var cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(typeof(Ticket).Assembly);

          //  new SchemaExport(cfg).Execute(false, true, false);
        }
    }
}
