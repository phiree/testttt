using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace CommonLibrary
{
    public class UrlParamHelper
    {
        const string linkTypeArea = "area";
        const string linkTypeLevel = "level";
        const string pagerIndexParamName = "pgotindex";
        public string url { get; set; }
        private SortedDictionary<string, string> DictParameters = new SortedDictionary<string, string>();
        private SortedDictionary<string, string> DictParametersOrigional = new SortedDictionary<string, string>();

        public UrlParamHelper(string url)
        {
            this.url = url;
            BuildQueryParameters();
        }
        public static string BuildLink(string urlquery, string type, string value)
        {
            return BuildLink(urlquery, type, value, false);
        }

        public static string BuildLink(string urlquery, string type, string value, bool isAll)
        {
            string r = string.Empty;

            //判断url内是否有 area,level,它们的值分别是多少

            //判断type,如果type在url内,则用value替换 否则 插入至合适位置 构建结构如下的url/hostname/area/level

            /*分段*/
            urlquery = urlquery.Trim('/');
            //删除分页参数

            if (string.IsNullOrEmpty(urlquery))
            {
                r = "/" + value;

                return r;
            }
            urlquery = "/" + urlquery + "/";
            urlquery = Regex.Replace(urlquery, @"/\d+/", "/");
            urlquery = urlquery.Trim('/');
            // urlquery = urlquery == string.Empty ? "/" : urlquery;
            string[] section = urlquery.Split('/');
            if (section.Length == 1)
            {
                string sec = section[0];
                //4a
                if (System.Text.RegularExpressions.Regex.IsMatch(sec, @"\d(a|A)"))
                {
                    if (type == linkTypeLevel)
                    {
                        //全部等级
                        if (isAll)
                        {
                            r = "/";
                        }
                        else
                        {
                            r = "/" + value;
                        }
                    }
                    else if (type == linkTypeArea)
                    {
                        if (isAll)
                        {
                            r = "/" + sec;
                        }
                        else
                        {
                            r = "/" + value + "/" + sec;
                        }
                    }
                }
                else //hangzhou
                {
                    //全部级别
                    if (type == linkTypeLevel)
                    {
                        if (isAll)
                        { r = "/" + sec; }
                        else
                        { r = "/" + sec + "/" + value; }


                    }
                    else if (type == linkTypeArea)
                    {
                        if (isAll)
                        {
                            r = "/";
                        }
                        else
                        {
                            r = "/" + value;
                        }
                    }
                }

            }
            else if (section.Length == 2)
            {
                string sec1 = section[0];
                string sec2 = section[1];
                //第二个参数是level
                if (System.Text.RegularExpressions.Regex.IsMatch(sec2, @"\d(a|A)"))
                {
                    if (type == linkTypeArea)
                    {
                        if (isAll)
                        {
                            r = "/" + sec2;
                        }
                        else
                        {
                            r = "/" + value + "/" + sec2;
                        }
                    }
                    else if (type == linkTypeLevel)
                    {
                        if (isAll)
                        {
                            r = "/" + sec1;
                        }
                        else
                        {
                            r = "/" + sec1 + "/" + value;
                        }
                    }
                }
                else
                {
                    //连接地址出错了.
                }

            }




            return r;
        }

        public string BuildLink2(string type, string value)
        {
            return BuildLink2(type, value, false);
        }
        public string BuildLink2(string type, string value, bool isALl)
        {
            string r = string.Empty;
            //初始化
            InitDictionary();
            if (!DictParameters.ContainsKey(type))
            {
                DictParameters.Add(type, value);
            }
            else
            {
                DictParameters[type] = value;
            }

            foreach (string s in DictParameters.Keys)
            {
                if (DictParameters[s]!= "")
                {
                    r += "/" + DictParameters[s];
                }
            }
            if (r == string.Empty)
            {
                r = "/DiscountTicket/";
            }
            return r;
        }
        private void InitDictionary()
        {
            DictParameters.Clear();
            foreach (KeyValuePair<string, string> kv in DictParametersOrigional)
            {
                DictParameters.Add(kv.Key, kv.Value);
            }
        }
        private void BuildQueryParameters()
        {
            if (url.Contains('?'))
            {
                url = url.Substring(url.IndexOf('?') + 1);
            }
            else
            {
                url = string.Empty;
                return;
            }
            string[] paramers = url.Split('&');
            foreach (string s in paramers)
            {


                string[] paramValue = s.Split('=');
                if (paramValue.Length == 2)
                {
                    if (paramValue[0] == pagerIndexParamName) continue;
                    DictParametersOrigional.Add(paramValue[0], paramValue[1]);
                }
            }
        }
    }
}
