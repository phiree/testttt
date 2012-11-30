using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class CommonUser
    {
        /// <summary>
        /// id
        /// </summary>
        public virtual int Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>
        public virtual string IdCard { get; set; }
        /// <summary>
        /// 订票的人
        /// </summary>
        public virtual TourMembership User { get; set; }
    }
}
