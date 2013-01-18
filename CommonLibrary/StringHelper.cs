using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLibrary
{
    public class StringHelper
    {
        public static string TrimAll(string s)
        {
            return s.Replace(" |",string.Empty);
        }
        public static string BuildJsonArray(IList<string> strArr)
        {

            System.Text.StringBuilder sbJson = new System.Text.StringBuilder();
            sbJson.Append("[");
            foreach (string str in strArr)
            {
                sbJson.Append("\\\"");

                sbJson.Append(str); sbJson.Append("\\\"");
                if (strArr.IndexOf(str) < strArr.Count - 1)
                {
                    sbJson.Append(",");
                }
            }
            sbJson.Append("]");
            return sbJson.ToString();

        }
      /// <summary>
         /// 身份证验证
         /// </summary>
         /// <param name="Id">身份证号</param>
         /// <returns></returns>
         public static bool CheckIDCard(string Id,out string errMsg)
         {
             errMsg = string.Empty;
             if (Id.Length == 18)
             {
                 bool check = CheckIDCard18(Id,out errMsg);
                 return check;
             }
             else if (Id.Length == 15)
             {
                 bool check = CheckIDCard15(Id,out errMsg);
                 return check;
             }
             else
             {
                 errMsg = "号码位数不对!";
                 return false;
             }
         }
         /// <summary>
         /// 18位身份证验证
         /// </summary>
         /// <param name="Id">身份证号</param>
         /// <returns></returns>
         private static bool CheckIDCard18(string Id,out string errMsg)
         {
             errMsg = string.Empty;
             long n = 0;
             if (long.TryParse(Id.Remove(17), out n) == false || n < Math.Pow(10, 16) || long.TryParse(Id.Replace('x', '0').Replace('X', '0'), out n) == false)
             {
                 errMsg = "格式有误";
                 return false;//数字验证
             }
             string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
             if (address.IndexOf(Id.Remove(2)) == -1)
             {
                 errMsg = "省份不正确";
                 return false;//省份验证
             }
             string birth = Id.Substring(6, 8).Insert(6, "-").Insert(4, "-");
             DateTime time = new DateTime();
             if (DateTime.TryParse(birth, out time) == false)
             {
                 errMsg = "生日不正确";
                 return false;//生日验证
             }
             string[] arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');
             string[] Wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');
             char[] Ai = Id.Remove(17).ToCharArray();
             int sum = 0;
             for (int i = 0; i < 17; i++)
             {
                 sum += int.Parse(Wi[i]) * int.Parse(Ai[i].ToString());
             }
             int y = -1;
             Math.DivRem(sum, 11, out y);
             if (arrVarifyCode[y] != Id.Substring(17, 1).ToLower())
             {
                 errMsg = "校验码不正确";
                 return false;//校验码验证
             }
             return true;//符合GB11643-1999标准
         }
         /// <summary>
         /// 15位身份证验证
         /// </summary>
         /// <param name="Id">身份证号</param>
         /// <returns></returns>
         private static bool CheckIDCard15(string Id,out string errMsg)
         {
             errMsg = string.Empty;
             long n = 0;
             if (long.TryParse(Id, out n) == false || n < Math.Pow(10, 14))
             {
                 errMsg = "格式有误";
                 return false;//数字验证
             }
             string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
             if (address.IndexOf(Id.Remove(2)) == -1)
             {
                 errMsg = "省份有误";
                 return false;//省份验证
             }
             string birth = Id.Substring(6, 6).Insert(4, "-").Insert(2, "-");
             DateTime time = new DateTime();
             if (DateTime.TryParse(birth, out time) == false)
             {
                 errMsg = "生日不正确";
                 return false;//生日验证
             }
             return true;//符合15位身份证标准
         }
    }
}
