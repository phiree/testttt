using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
namespace IDAL
{
    public interface IDALSeoDescription
    {
        SeoDescription GetDescription(string type, int targetId);
        void Save(SeoDescription seodesc);
    }
}
