<%@ WebHandler Language="C#" Class="ProductEditHandler" %>

using System;
using System.Web;

public class ProductEditHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        string command = context.Request["command"];
        
        switch (command.ToLower())
        {
            case "loadproduct":
                string paramProductId = context.Request["pid"];
                break;
            case "save": break;
                
        }
    }

    private void GetProduct()
    { 
        
    }
    public bool IsReusable {
        get {
            return false;
        }
    }

}