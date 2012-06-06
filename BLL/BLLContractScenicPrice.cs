using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using IDAL;
using Model;

namespace BLL
{
    public class BLLContractScenicPrice
    {
        IContractScenicPrice icsp = new DALContractScenicPrice();

        public void SaveOrUpdate(ContractScenicPrice csp)
        {
            icsp.SaveOrUpdate(csp);
        }

        public ContractScenicPrice GetcspByscid(int scid)
        {
            return icsp.GetcspByscid(scid);
        }
    }
}
