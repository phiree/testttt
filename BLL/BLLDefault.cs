using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class BLLDefault
    {
        IDAL.IMembership imem;
        public IDAL.IMembership Imem
        {
            get
            {
                if (imem == null)
                {
                    imem = new DAL.DALMembership();
                }
                return imem;
            }
            set
            {
                imem = value;
            }
        }

    }
}
