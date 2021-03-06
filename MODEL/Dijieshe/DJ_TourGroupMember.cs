﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    //组员
    public class DJ_TourGroupMember
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
        public virtual bool IsChild { get; set; }
        /// <summary>
        ///儿童监护者.如果多个,用逗号隔开
        /// </summary>
        public virtual string  Keeper { get; set; }
      
        /// <summary>
        /// 其他类型的证件号码:护照,
        /// </summary>
        public virtual string SpecialCardNo { get; set; }
        public virtual MemberType MemberType { get; set; }
        public virtual DJ_TourGroup DJ_TourGroup { get; set; }
        public virtual void CopyTo(DJ_TourGroupMember newMember)
        {
            newMember.Gender = Gender;
            newMember.IdCardNo = IdCardNo;
            newMember.MemberType = MemberType;
            newMember.PhoneNum = PhoneNum;
            newMember.RealName = RealName;
            newMember.SpecialCardNo = SpecialCardNo;
            
        }

    }
    public enum MemberType
    {
        成 = 1,
        儿,
        外,
        港澳台
       
    }
}
