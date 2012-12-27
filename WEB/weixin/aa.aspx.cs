using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using System.Web.Security;

public partial class aa : System.Web.UI.Page
{
    const string Token = "faketoken";		//你的token
    protected void Page_Load(object sender, EventArgs e)
    {
        string postStr = "";

        if (Request.QueryString.Count == 0)
        {
            return;
        }

        //Valid();

        if (CheckSignature() && Request.HttpMethod.ToLower() == "post")
        {
            Stream s = System.Web.HttpContext.Current.Request.InputStream;
            byte[] b = new byte[s.Length];
            s.Read(b, 0, (int)s.Length);
            postStr = Encoding.UTF8.GetString(b);
            if (!string.IsNullOrEmpty(postStr))
            {
                ResponseMsg(postStr);
            }
            //WriteLog("postStr:" + postStr);
        }
    }

    /// <summary>
    /// 验证微信签名
    /// </summary>
    /// * 将token、timestamp、nonce三个参数进行字典序排序
    /// * 将三个参数字符串拼接成一个字符串进行sha1加密
    /// * 开发者获得加密后的字符串可与signature对比，标识该请求来源于微信。
    /// <returns></returns>
    private bool CheckSignature()
    {
        string signature = Request.QueryString["signature"].ToString();
        string timestamp = Request.QueryString["timestamp"].ToString();
        string nonce = Request.QueryString["nonce"].ToString();
        string[] ArrTmp = { Token, timestamp, nonce };
        Array.Sort(ArrTmp);     //字典排序
        string tmpStr = string.Join("", ArrTmp);
        tmpStr = FormsAuthentication.HashPasswordForStoringInConfigFile(tmpStr, "SHA1");
        tmpStr = tmpStr.ToLower();
        if (tmpStr == signature)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Valid()
    {
        WriteLog("valide step 1");
        string echoStr = Request.QueryString["echoStr"].ToString();
        if (CheckSignature())
        {
            if (!string.IsNullOrEmpty(echoStr))
            {
                Response.Write(echoStr);
                Response.End();
            }
        }
    }

    /// <summary>
    /// 返回信息结果(微信信息返回)
    /// </summary>
    /// <param name="weixinXML"></param>
    private void ResponseMsg(string postStr)
    {
        //回复消息的部分:你的代码写在这里
        System.Xml.XmlDocument postObj = new System.Xml.XmlDocument();
        postObj.LoadXml(postStr);

        var FromUserNameList = postObj.GetElementsByTagName("FromUserName");
        string FromUserName = string.Empty;
        for (int i = 0; i < FromUserNameList.Count; i++)
        {
            if (FromUserNameList[i].ChildNodes[0].NodeType == System.Xml.XmlNodeType.CDATA)
            {
                FromUserName = FromUserNameList[i].ChildNodes[0].Value;
            }
        }

        var toUsernameList = postObj.GetElementsByTagName("ToUserName");
        string ToUserName = string.Empty;
        for (int i = 0; i < toUsernameList.Count; i++)
        {
            if (toUsernameList[i].ChildNodes[0].NodeType == System.Xml.XmlNodeType.CDATA)
            {
                ToUserName = toUsernameList[i].ChildNodes[0].Value;
            }
        }

        var keywordList = postObj.GetElementsByTagName("Content");
        string Content = string.Empty;
        for (int i = 0; i < keywordList.Count; i++)
        {
            if (keywordList[i].ChildNodes[0].NodeType == System.Xml.XmlNodeType.CDATA)
            {
                Content = keywordList[i].ChildNodes[0].Value;
            }
        }

        var CreateTimeList = postObj.GetElementsByTagName("CreateTime");
        string CreateTime = CreateTimeList[0].Value;
        var time = DateTime.Now;
        var textpl = "<xml><ToUserName><![CDATA[" + FromUserName + "]]></ToUserName>" +
            "<FromUserName><![CDATA[" + ToUserName + "]]></FromUserName>" +
            "<CreateTime>" + ConvertDateTimeInt(DateTime.Now) + "</CreateTime><MsgType><![CDATA[text]]></MsgType>" +
            "<Content><![CDATA[欢迎来到微信世界---" + Content + "]]></Content><FuncFlag>0</FuncFlag></xml> ";
        WriteLog(textpl);
        Response.Write(textpl);
        Response.End();
    }

    /// <summary>
    /// unix时间转换为datetime
    /// </summary>
    /// <param name="timeStamp"></param>
    /// <returns></returns>
    private DateTime UnixTimeToTime(string timeStamp)
    {
        DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
        long lTime = long.Parse(timeStamp + "0000000");
        TimeSpan toNow = new TimeSpan(lTime);
        return dtStart.Add(toNow);
    }

    /// <summary>
    /// datetime转换为unixtime
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>
    private int ConvertDateTimeInt(System.DateTime time)
    {
        System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
        return (int)(time - startTime).TotalSeconds;
    }

    /// <summary>
    /// 写日志(用于跟踪)
    /// </summary>
    private void WriteLog(string strMemo)
    {
        string filename = "D:/WEBHOME/kuaidi/logs/log.txt";
        if (!Directory.Exists("D:/WEBHOME/kuaidi/logs/"))
            Directory.CreateDirectory("D:/WEBHOME/kuaidi/logs/");
        StreamWriter sr = null;
        try
        {
            if (!File.Exists(filename))
            {
                sr = File.CreateText(filename);
            }
            else
            {
                sr = File.AppendText(filename);
            }
            sr.WriteLine(strMemo);
        }
        catch
        {
        }
        finally
        {
            if (sr != null)
                sr.Close();
        }
    }
}