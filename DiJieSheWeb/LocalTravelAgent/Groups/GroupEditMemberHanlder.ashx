<%@ WebHandler Language="C#" Class="GroupEditHanlder" %>

using System;
using System.Web;
using BLL;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        string jsonR = r["_gt_json"];
        Newtonsoft.Json.Linq.JObject jo = JObject.Parse(jsonR);

        SigmaGridRequestObject sro = new SigmaGridRequestObject(jo);
        sro.Act();
    }
    public bool IsReusable {
        get {
            return false;
        }
    }

}