using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
namespace BLL
{
    /// <summary>
    /// 一定格式的字符串和对象之间的转换
    /// </summary>
    public class SerializationModel
    {
        /// <summary>
        /// 旅游团的成员
        /// </summary>
        /// <param name="formatString">成人游客(儿童,外宾,港澳台),证件号码,身份证</param>
        /// <returns></returns>
        public static Model.DJ_TourGroupMember SerializeMember(string singleModelString, out string errMsg)
        {
            errMsg = "";
            string[] strArrMember = singleModelString.Split('\\');
            //类型,姓名,证件号,电话号码
            int strLength = strArrMember.Length;
            if (strLength < 2)
            {
                errMsg = "此行格式有误:" + singleModelString + ".";
                return null;
            }
            string strType = strArrMember[0];
            string name = strArrMember[1];
            
            string idcardNo = string.Empty;
            string phoneNum = string.Empty;
            string specialCardNo = string.Empty;
            switch (strLength)
            {
                //类型,姓名
                case 2:
                    
                    break;
                //类型,姓名,证件号码
                //类型,姓名,电话号码
                case 3:
                    string arr3 = strArrMember[2].Replace(" |-",string.Empty);
                    if (arr3.Length == 15 || arr3.Length == 18)
                    {
                        if (!CommonLibrary.StringHelper.CheckIDCard(arr3, out errMsg))
                        {
                            errMsg = "此行省份证号码有误:" + errMsg;
                            return null;
                        }
                        else
                            idcardNo = arr3;
                    }
                    else if (arr3.Length == 11)
                    {
                        phoneNum = arr3;
                    }
                    else
                    {
                        specialCardNo = arr3;
                    }
                    

                    break;
                //类型 姓名,证件,电话号码
                case 4:
                    string arr43 = strArrMember[2].Replace(" |-", string.Empty);
                    string arr44 = strArrMember[3].Replace(" |-", string.Empty);
                    if (arr43.Length == 15 || arr43.Length == 18)
                    {
                        if (!CommonLibrary.StringHelper.CheckIDCard(arr43, out errMsg))
                        {
                            errMsg = "此行省份证号码有误:" + errMsg;
                            return null;
                        }
                        else
                            idcardNo = arr43;
                    }
                    else
                    {
                        specialCardNo = arr43;
                    }
                    phoneNum = arr44;

                    break;
            }
            Model.DJ_TourGroupMember member = new Model.DJ_TourGroupMember();
            Model.MemberType memberType= MemberType.成;

            if (new string[] { "成", "成人", "成人游客" }.Contains(strType))
            {
                memberType = MemberType.成;
            }
            else if (new string[] { "儿", "儿童","儿童游客" }.Contains(strType))
            {
                memberType = MemberType.儿;
            }
            else
            {
                errMsg = "此行游客类型有误,请输入 '成人' 或者 '儿童' " + singleModelString;
                return null;
            }
            member.MemberType = memberType;
            member.RealName = strArrMember[1];
            member.PhoneNum = phoneNum;
            member.SpecialCardNo = specialCardNo;
            member.IdCardNo = idcardNo;
            return member;
        }


    }
}
