<%@ WebHandler Language="C#" Class="AddGuide" %>

using System;
using System.Web;
using CommonLibrary;
public class AddGuide : IHttpHandler {

    BLL.BLLWorker bllWorker = new BLL.BLLWorker();
    BLL.BLLDJEnterprise bllEnt = new BLL.BLLDJEnterprise();
    public void ProcessRequest (HttpContext context) {

        string jsonString = context.Request["jr"];
        string entId = context.Request["entId"];
        Model.DJ_Workers worker = CommonLibrary.JosnHelper.ParseFromJson<Model.DJ_Workers>(jsonString);
        Model.DJ_TourEnterprise ent = bllEnt.GetOne(Convert.ToInt32(entId));
        worker.DJ_Dijiesheinfo =(Model.DJ_DijiesheInfo)ent;
        bllWorker.Save(worker);
        context.Response.Write(worker.Id);
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}