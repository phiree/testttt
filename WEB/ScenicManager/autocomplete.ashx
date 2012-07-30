<%@ WebHandler Language="C#" Class="autocomplete" %>

using System;
using System.Web;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Web.Services;

public class autocomplete : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        context.Response.Write("Hello World");
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}