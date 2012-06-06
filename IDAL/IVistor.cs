using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDAL
{
    public interface IVistor
    {
        void Vote(Model.Scenic Scenic, int num);
    }
}
