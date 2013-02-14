using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
namespace BLL
{
    public class BLLDefault
    {
        DAL.DALMembership imem;
        public DALMembership Imem
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
