<%@ WebHandler Language="C#" Class="EntpriseAutoCompleteHanlder" %>

using System;
using System.Web;
using System.Collections.Generic;
using BLL;
using Model;
public class EntpriseAutoCompleteHanlder : IHttpHandler {

    BLLDJEnterprise bllEnt = new BLLDJEnterprise();
    public void ProcessRequest (HttpContext context) {

        var request = context.Request;
        string conditions = string.Empty;
        
        string entType=request["entType"];
        string entName = request["entName"];
        string jsonNames = bllEnt.BuildJsonEnterprise(entName, entType);
        context.Response.ContentType = "application/json";
        context.Response.Write(jsonNames);
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }
    //private IList<DJ_TourEnterprise> GetList()
    //{ 
        
    //}

}