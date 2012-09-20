<%@ WebHandler Language="C#" Class="MemBasicHandler" %>

using System;
using System.Web;

public class MemBasicHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}