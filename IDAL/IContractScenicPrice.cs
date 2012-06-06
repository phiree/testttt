using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace IDAL
{
    public interface IContractScenicPrice
    {
        void SaveOrUpdate(ContractScenicPrice csp);
        ContractScenicPrice GetcspByscid(int scid);
    }
}
