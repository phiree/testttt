using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLibrary
{
    public class MakeAccount
    {
        public string automakeaccount(int scenicid)
        {
            return "admin" + scenicid.ToString();
        }
    }
}
