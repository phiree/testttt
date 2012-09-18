using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
namespace Model
{
    //组员
    public class TourGroupMemberMap:ClassMap<DJ_TourGroupMember>
    {
        public TourGroupMemberMap()
        {
            Id(x => x.Id);
            Map(x => x.IdCardNo);
            Map(x => x.IsChild);

            Map(x => x.Keeper);
            Map(x => x.PhoneNum);
            Map(x => x.RealName);
            Map(x => x.Gender);
         
        }
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
  
}
