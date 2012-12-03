using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class BLLFactory
    {
        private static BLL.BLLMembership bllMember;
        private static BLL.BLLScenic bllScenic;
        public static BLLMembership CreateBLLMember()
        {
            if (bllMember == null)
                bllMember = new BLLMembership();

            return bllMember;
        }
        public static BLLScenic CreateBLLScenic()
        {
            return bllScenic == null ? new BLLScenic() : bllScenic;
        }

    }
}
