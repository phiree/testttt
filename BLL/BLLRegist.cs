using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class BLLRegist:BLLDefault
    {
        IDAL.IMembership dal = new DAL.DALMembership();
        public void CreateUser(string realname, string phone, string address, string idcard,
            string loginname, string password)
        { 
            //Model.User user=new Model.User(){
            //    RealName=
            //}
        }
    }
}
