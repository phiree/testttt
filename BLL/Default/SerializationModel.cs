using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Default
{
    /// <summary>
    /// 一定格式的字符串和对象之间的转换
    /// </summary>
  public  class SerializationModel
    {
      /// <summary>
      /// 旅游团的成员
      /// </summary>
      /// <param name="formatString">成人游客(儿童,外宾,港澳台),证件号码,身份证</param>
      /// <returns></returns>
      public static Model.DJ_TourGroupMember SerializeMember(string singleModelString)
      {
          Model.DJ_TourGroupMember member = new Model.DJ_TourGroupMember();
          //foreach (DJ_TourGroupMember member in CurrentGroup.Members)
          //{
          //    bllGroupMember.Delete(member);
          //}
          //CurrentGroup.Members.Clear();
          //string[] arrStrMember = tbx.Text.Split(Environment.NewLine.ToCharArray());
          ////CurrentGroup.Members
          //string errMsg = string.Empty;
          //foreach (string s in arrStrMember)
          //{
          //    if (string.IsNullOrEmpty(s)) continue;
          //    DJ_TourGroupMember member = ParseMember(s, out errMsg);
          //    if (!string.IsNullOrEmpty(errMsg))
          //    {
          //        lblSimpleMsg.ForeColor = System.Drawing.Color.Red;
          //        lblSimpleMsg.Text = errMsg;
          //        break;
          //    }
          //    // bllGroup.Save(member);
          //    CurrentGroup.Members.Add(member);
          //}
          //bllGroup.Save(CurrentGroup);

          return member;
      }
    
    }
}
