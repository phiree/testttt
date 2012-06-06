using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

/******************************************************
Form表单控件值验证脚本

1. 表单控件增加属性DefaultValue属性，当提交表单时的第2个参数为true时，进行默认值填充

2. [textarea]控件增加属性LimitLength，系统将自动验证非空内容的字符数限制
3. 按控件的Format属性中定义的格式规则对其值进行判断：
Format属性取值范围：
* notNull       必填或必选

* int           整型
* number        数值

* idcard        身份证号
* email         E-mail地址
* mobile        11位手机号
* vphone        6位虚拟网号
* postcode      邮编
* shortDate     短日期格式(yyyy-M-d 或 yyyy/M/d)
* longDate      长日期格式(yyyy年M月d日)
* datetime      日期时间(yyyy-M-d h:mm[:ss] 或 yyyy/M/d h:mm[:ss])
* year          年(4位数字)
* month         月(1-12)
* day           日(简单模式: 1-31)
说明：允许同时定义多个规则，则在各个值之间用“|”分隔，且判断时会按规则的顺序进行判断（notNull判断始终最先判断）。

例子：<input type="text" Format="notNull|int" />        <!--文本框的值必须为非空-->
******************************************************/

namespace CommonLibrary
{
    public static class ValidateHelper
    {
        //是否为 整数
        public static Mydic verify_int(string obj)
        {
            string pattern = @"^[\+\-]?\d+$";
            if (Regex.Match(obj, pattern).Success)
            {
                return new Mydic(null, true);
            }
            else
            {
                return new Mydic("您输入的值非有效的整数，请确认！",
                    false);
            }
        }
        //是否为 数值
        public static Mydic verify_number(string obj)
        {
            string pattern = @"^[\+\-]?[\d]*?[\.]?[\d]+$";
            if (Regex.Match(obj, pattern).Success)
            {
                return new Mydic(null, true);
            }
            else
            {
                return new Mydic("您输入的值非有效的数值类型，请确认！",
                    false);
            }
        }
        //是否为 身份证号码
        public static Mydic verify_idcard(string obj)
        {
            string pattern = @"^[\d]{15}(|[\d]{2}[\dXx])$";
            if (Regex.Match(obj, pattern).Success)
            {
                return new Mydic(null, true);
            }
            else
            {
                return new Mydic("您输入的值非有效的身份证号，请确认！",
                    false);
            }
        }
        //是否为 Email地址
        public static Mydic verify_email(string obj)
        {
            string pattern = @"([a-zA-Z0-9._-])+@([a-zA-Z0-9_-])+(\.[a-zA-Z0-9_-])+";
            if (Regex.Match(obj, pattern).Success)
            {
                return new Mydic(null, true);
            }
            else
            {
                return new Mydic("您输入的值非有效的电子邮箱地址，请确认！",
                    false);
            }
        }
        //是否为 手机号码
        public static bool verify_mobile(string obj)
        {
            string pattern = @"^\d{11}$";
            if (Regex.Match(obj, pattern).Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //是否为 虚拟网号码
        public static bool verify_vphone(string obj)
        {
            string pattern = @"^\d{6}$";
            if (Regex.Match(obj, pattern).Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //是否为 邮编
        public static Mydic verify_postcode(string obj)
        {
            string pattern = @"^\d{6}$";
            if (Regex.Match(obj, pattern).Success)
            {
                return new Mydic(null, true);
            }
            else
            {
                return new Mydic("您输入的值非有效的邮政编码，请确认！",
                    false);
            }
        }
        //是否为 短日期格式（yyyy-M-d）
        public static Mydic verify_shortdate(string obj)
        {
            string pattern = @"^\d{4}[\-/]\d{1,2}[\-/]\d{1,2}$";
            if (Regex.Match(obj, pattern).Success)
            {
                return new Mydic(null, true);
            }
            else
            {
                return new Mydic("您输入的值非有效的身份证号，请确认！",
                    false);
            }
        }
        //是否为 长日期格式（yyyy年M月d日）
        public static Mydic verify_longdate(string obj)
        {
            string pattern = @"^\d{4}\年\d{1,2}\月\d{1,2}日$";
            if (Regex.Match(obj, pattern).Success)
            {
                return new Mydic(null, true);
            }
            else
            {
                return new Mydic("您输入的值非有效的长日期格式（yyyy年M月d日），请确认！",
                    false);
            }
        }
        //是否为 日期时间格式（yyyy-M-d hh:mm(:ss)）
        public static Mydic verify_datetime(string obj)
        {
            string pattern = @"^\d{4}[\-/]\d{1,2}[\-/]\d{1,2}(|( \d{1,2}:\d{2}(|:\d{2})))$";
            if (Regex.Match(obj, pattern).Success)
            {
                return new Mydic(null, true);
            }
            else
            {
                return new Mydic("您输入的值非有效的日期时间格式（yyyy-M-d m:ss），请确认！",
                    false);
            }
        }
        //是否为 年份
        public static Mydic verify_year(string obj)
        {
            string pattern = @"^\d{4}$";
            if (Regex.Match(obj, pattern).Success)
            {
                return new Mydic(null, true);
            }
            else
            {
                return new Mydic("您输入的值非有效的年份，请确认！",
                    false);
            }
        }
        //是否为 月份
        public static Mydic verify_month(string obj)
        {
            string pattern = @"^(0?[1-9]|1[012])$";
            if (Regex.Match(obj, pattern).Success)
            {
                return new Mydic(null, true);
            }
            else
            {
                return new Mydic("您输入的值非有效的月份，请确认！",
                    false);
            }
        }

        public static bool verify_website(string obj)
        {
            string pattern = @"http://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";
            if (Regex.Match(obj, pattern).Success)
            {
                return true;
            }
            else
                return false;


        }

        //是否为 日（简单模式）
        public static Mydic verify_day(string obj)
        {
            string pattern = @"^([012]?[1-9]|3[01])$";
            if (Regex.Match(obj, pattern).Success)
            {
                return new Mydic(null, true);
            }
            else
            {
                return new Mydic("您输入的值非有效的日，请确认！",
                    false);
            }
        }
        //是否 为空或未选择项
        public static void verify_notnull(string obj)
        {
        }
        //是否 空串（或者只含空格）
        public static Mydic verifyEmptyStr(string obj)
        {
            string pattern = @"^[ 　]*$";
            if (Regex.Match(obj, pattern).Success)
            {
                return new Mydic(null, true);
            }
            else
            {
                return new Mydic(null, false);
            }
        }
        // 字符串包含验证函数
        public static Mydic contain(string obj, string inner)
        {
            if (obj.IndexOf(inner) >= 0)
                return new Mydic(null, true);
            else
                return new Mydic(null, false);
        }
        //检查输入串的最大字符数
        public static Mydic verifyMaxLength(string obj, int maxlength)
        {
            if (obj.Length <= maxlength)
                return new Mydic(null, true);
            else
                return new Mydic(null, false);
        }



    }

    public class Mydic
    {
        public Object obj { get; set; }
        public bool bl { get; set; }
        public Mydic(object obj, bool bl)
        {
            this.obj = obj;
            this.bl = bl;
        }
    }
}
