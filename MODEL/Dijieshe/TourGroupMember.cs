using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    //组员
    public class TourGroupMember
    {
        public virtual Guid Id { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public virtual string RealName { get; set; }
        public virtual string PhoneNum { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public virtual string Gender { get; set; }
        /// <summary>
        /// 身份证号码
        /// </summary>
        public virtual string IdCardNo { get; set; }
        /// <summary>
        /// 是否儿童
        /// </summary>
        public bool IsChild { get; set; }
        /// <summary>
        ///儿童监护者.如果多个,用逗号隔开
        /// </summary>
        public string  Keeper { get; set; }


    }
    public enum MemberType
    {
        游客 = 1,
        导游,
        司机
    }
}
