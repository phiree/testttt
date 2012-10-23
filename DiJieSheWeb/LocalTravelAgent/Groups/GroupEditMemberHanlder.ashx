<%@ WebHandler Language="C#" Class="GroupEditHanlder" %>

using System;
using System.Web;

/*
 _gt_json:
 * {"fieldsName":["no","tourertype","realname","phone","idcardno","othercardno"],
 * "recordType":"array",
 * "parameters":{},
 * "action":"save",
 * "insertedRecords":[],
 * "updatedRecords":[["1","成人游客","11111","13282151877","520822198010103916",""]],"deletedRecords":[]}
 */
public class GroupEditHanlder : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {

        var r = context.Request;
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}