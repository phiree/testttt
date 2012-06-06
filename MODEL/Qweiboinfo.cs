using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Qweiboinfo
    {
        public int ret { get; set; }
        public string msg { get; set; }
        public int errcode { get; set; }
        public data data { get; set; }
    }
    public class data
    {
        public string name { get; set; }
        public string openid { get; set; }
        public string nick { get; set; }
        public string head { get; set; }
        public string location { get; set; }
        public string country_code { get; set; }
        public string province_code { get; set; }
        public string city_code { get; set; }
        public int isvip { get; set; }
        public int isent { get; set; }
        public string introduction { get; set; }
        public string verifyinfo { get; set; }
        public string email { get; set; }
        public string birth_year { get; set; }
        public string birth_month { get; set; }
        public string birth_day { get; set; }
        public int sex { get; set; }
        public int fansnum { get; set; }
        public int idolnum { get; set; }
        public int tweetnum { get; set; }
        public object tag { get; set; }
        public object edu { get; set; }
    }

    public class Qweibo_tadd
    {
        public int ret { get; set; }
        public string msg { get; set; }
        public int errcode { get; set; }
        public object data { get; set; }
    }
}
