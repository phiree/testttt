using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class DJ_Recommand
    {
        public virtual Guid Id { get; set; }
        public virtual DJ_GovManageDepartment DJ_GovManageDepartment { get; set; }
        public virtual string RewardPolicy { get; set; }
        public virtual string UploadFile { get; set; }
    }
}
