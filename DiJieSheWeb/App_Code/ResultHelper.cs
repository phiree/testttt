using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// 返回值帮助类:
/// 返回对象:bool和string
/// </summary>
public class ResultHelper
{
    public bool bresult { get; set; }
    public string sresult { get; set; }

    public ResultHelper(bool b_result,string s_result)
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
        this.bresult = b_result;
        this.sresult = s_result;
    }
}