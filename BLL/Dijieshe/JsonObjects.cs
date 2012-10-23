using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Model;
using DAL;
using Newtonsoft.Json.Linq;
/// <summary>
///sigmagrid xhr请求对象
/// </summary>
namespace BLL
{ 
public class SigmaGridRequestObject : DalBase
{/*
  {
  "fieldsName": [
    "no",
    "tourertype",
    "realname",
    "phone",
    "idcardno",
    "othercardno",
    "memberid"
  ],
  "recordType": "array",
  "parameters": {
    "groupid": "e0774e72-6cf8-4158-9f8e-a0f301187e0a"
  },
  "action": "save",
  "insertedRecords": [],
  "updatedRecords": [
    [
      "2",
      "222",
      "游客1",
      "189546573331",
      "330381198812164236",
      "",
      "c1f48dd0-bf4c-4b6c-acdf-a0f0010b34e5"
    ]
  ],
  "deletedRecords": []
}
  */

    /*
     _gt_json:
     * {"fieldsName":["no","tourertype","realname","phone","idcardno","othercardno","memberhid"],
     * "recordType":"array",
     * "parameters":{},
     * "action":"save",
     * "insertedRecords":[],
     * "updatedRecords":[["1","成人游客","11111","13282151877","520822198010103916",""]],"deletedRecords":[]}
     */
    public JObject JO { get; set; }
    public SigmaGridRequestObject(Newtonsoft.Json.Linq.JObject jo)
    {
        JO = jo;
    }
    public JArray fieldsName { get; set; }
    public string recordType { get; set; }
  
    public string action { get; set; }
    public string[][] insertedRecords { get; set; }
    public string[][] updatedRecords { get; set; }
    public string[][] deletedRecords { get; set; }

    BLL.BLLDJTourGroup bllGroup = new BLL.BLLDJTourGroup();
    DJ_TourGroup group;
    public string Act()
    {
        string returnValue = string.Empty;
        Guid groupId;
        string paramGroupId =(string) JO["parameters"]["groupid"];
        action = (string)JO["action"];
        if (!Guid.TryParse(paramGroupId, out groupId))
        {
            BLL.ErrHandler.Redirect(BLL.ErrType.ParamIllegal);
        }
        group = bllGroup.GetTourGroupById(groupId);
        if (action == "save")
        {
            //delete/update/insert
            IList<Model.DJ_TourGroupMember> memberList = new List<Model.DJ_TourGroupMember>();

            foreach (JToken ro in (JArray) JO["insertedRecords"])
            {

                Model.DJ_TourGroupMember member = ConvertToMember(ro);
                member.DJ_TourGroup = group;
                group.Members.Add(member);
                
                //session.Save(group);
            session.Save(member); 
                session.Flush();
            }
            foreach (JToken ro in JO["updatedRecords"])
            {

                Model.DJ_TourGroupMember member = ConvertToMember(ro);

                session.Update(member);
                session.Flush();
            } foreach (JToken ro in JO["deletedRecords"])
            {

                Model.DJ_TourGroupMember member = ConvertToMember(ro);

                session.Delete(member); 
                session.Flush();
            }
           
        }

        if (action == "load")
        {
           // return bll BuildLoadResponse(group.Members);
        }
        return returnValue;
    }

    
   
    public Model.DJ_TourGroupMember ConvertToMember(JToken t)
    {

        List<string> ro = new List<string>();
        if (t.GetType() == typeof(JArray))
        {
            JArray ja = (JArray)t;
            foreach (JToken jt in ja)
            {
                ro.Add(jt.ToString());
            }
        }
        else
        {
            for (int i = 0; i <= 5; i++)
            {
                ro.Add(t[i.ToString()].ToString());
            }
        }

        Model.DJ_TourGroupMember member = new DJ_TourGroupMember();
        string memberId = ro[5];
        if (!string.IsNullOrEmpty(memberId))
        {
            member= bllGroup.GetMemberById( Guid.Parse(memberId));
        }
      
        member.IdCardNo = ro[3];
        member.PhoneNum = ro[2];
        member.RealName = ro[1];
        member.SpecialCardNo=ro[4];
        member.TouristType = ro[0];
        //  member.
        return member;



    }

  
}




}