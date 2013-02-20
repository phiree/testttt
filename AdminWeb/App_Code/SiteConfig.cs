using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///SiteConfig 的摘要说明
/// </summary>
public class SiteConfig
{

    public const string SyncTableName = "testforprocUserTicket";//testforprocUserTicket2";
    public const string SyncServerConnection = @"Server=60.191.70.234,98;
                                                database=TourzjWeiboManage;
                                                uid=sa;pwd=zmmisateacher";

    //用存储过程的方式导入数据,否则用业务逻辑
    public const bool ImportUsingProc = true;
    
    //excel上传 导入 的配置
   
}