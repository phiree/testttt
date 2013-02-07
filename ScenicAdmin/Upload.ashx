<%@ WebHandler Language="C#" Class="Upload" %>

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;

public class Upload : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string mark = context.Request.QueryString["mark"];
        switch (mark)
        {
            case "upload":
                {
                    HttpPostedFile file = context.Request.Files["FileData"];
                    string uploadpath = context.Server.MapPath(context.Request["folder"] + "\\");
                    string[] files = Directory.GetFiles(context.Server.MapPath(string.Format("~/ScenicManager/Upload")));
                    string path = files[0].Split('\\')[files[0].Split('\\').Length - 1];
                    File.Delete(context.Server.MapPath(string.Format("~/ScenicManager/Upload/{0}", path)));
                    string time = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString()
               + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                    string new_Name = time;
                    string kzm = file.FileName.Substring(file.FileName.LastIndexOf("."));
                    string fileName = uploadpath + new_Name + kzm;
                    if (file != null)
                    {
                        if (!Directory.Exists(uploadpath))
                        {
                            Directory.CreateDirectory(uploadpath);
                        }
                        file.SaveAs(fileName);
                        context.Response.Write(string.Format( new_Name + kzm)); //标志位1标识上传成功，后面的可以返回前台的参数，比如上传后的路径等，中间使用|隔开
                    }
                    else
                    {
                        context.Response.Write("0|");
                    }
                    break;
                }
            case "delete":
                {
                    context.Response.ContentType = "text/plain";
                    context.Response.Clear();
                    string[] file = Directory.GetFiles(context.Server.MapPath(string.Format("~/Upload")));
                    File.Delete(context.Server.MapPath(string.Format("~/Upload/" + file[0])));
                    context.Response.Write("1");
                    break;
                }
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}