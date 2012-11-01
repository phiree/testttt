using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;
namespace BLL
{
    public class BLLOperationLog
    {

        public DALOperationLog DALOL = new DALOperationLog();

        public IList<OperationLog> GetAll()
        {
           // int totalRecord;
            //return DALOL.GetList(null, null, null, null, null, null, false, 0, 0, out totalRecord);
            return DALOL.GetAll<OperationLog>();
        }
        public void Save(OperationLog log)
        {
            DALOL.Save(log);
        }
        
    }
}
