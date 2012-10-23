using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Model;
/// <summary>
///basepage 的摘要说明
/// </summary>
public class SigmaGridSaveObject
{

    /*
     _gt_json:
     * {"fieldsName":["no","tourertype","realname","phone","idcardno","othercardno"],
     * "recordType":"array",
     * "parameters":{},
     * "action":"save",
     * "insertedRecords":[],
     * "updatedRecords":[["1","成人游客","11111","13282151877","520822198010103916",""]],"deletedRecords":[]}
     */
    public string[] fieldsName { get; set; }
    public string recordType { get; set; }
    public object parameters { get; set; }
    public string action { get; set; }
    public string[][] insertedRecords { get; set; }
    public string[][] updatedRecords { get; set; }
    public string[][] deletedRecords { get; set; }

    public void Save()
    { 
        //delete/update/insert
        IList<Model.DJ_TourGroupMember> Member = new List<Model.DJ_TourGroupMember>();
        foreach (string[] strMember in insertedRecords)
        {
            if (strMember.Length != 6)
            {
                throw new Exception("参数有误");
            }
            Model.DJ_TourGroupMember member = ConvertToMember(strMember);

        }
    }
    public Model.DJ_TourGroupMember ConvertToMember(string[] strMember)
    {
        Model.DJ_TourGroupMember member = new DJ_TourGroupMember();
        member.IdCardNo = strMember[4];
        member.PhoneNum = strMember[3];
        member.RealName = strMember[2];
        member.TouristType = strMember[1];
      //  member.
        return member;
        

    
    }
   
}
