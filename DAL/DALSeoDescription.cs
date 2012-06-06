using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using IDAL;
namespace DAL
{
    public class DALSeoDescription:IDALSeoDescription
    {
        public SeoDescription GetDescription(string type, int targetId)
        {
            throw new NotImplementedException();
        }

        public void Save(SeoDescription seodesc)
        {
            throw new NotImplementedException();
        }
    }
}
