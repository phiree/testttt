using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Model;
using DAL;
/// <summary>
///sigmagrid xhr请求对象
/// </summary>
public class SigmaGridRequestObject : DalBase
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
    public IList<KeyValuePair<string, string>> parameters { get; set; }
    public string action { get; set; }
    public string[][] insertedRecords { get; set; }
    public string[][] updatedRecords { get; set; }
    public string[][] deletedRecords { get; set; }


    public string Act()
    {
        string returnValue = string.Empty;
        Guid groupId;
        string paramGroupId = parameters[0].Value;
        if (!Guid.TryParse(paramGroupId, out groupId))
        {
            BLL.ErrHandler.Redirect(BLL.ErrType.ParamIllegal);
        }
       DJ_TourGroup group = new BLL.BLLDJTourGroup().GetTourGroupById(groupId);
        if (action == "save")
        {
            //delete/update/insert
            IList<Model.DJ_TourGroupMember> memberList = new List<Model.DJ_TourGroupMember>();

            foreach (string[] strMember in insertedRecords)
            {

                Model.DJ_TourGroupMember member = ConvertToMember(strMember);

                group.Members.Add(member);
            }
            foreach (string[] strMember in updatedRecords)
            {
                Model.DJ_TourGroupMember member = ConvertToMember(strMember);
                session.SaveOrUpdate(member);
            }
            foreach (string[] strMember in updatedRecords)
            {
                Model.DJ_TourGroupMember member = ConvertToMember(strMember);
                session.Delete(member);
            }
            session.Flush();
        }

        if (action == "load")
        {
            return BuildLoadResponse(group.Members);
        }
        return returnValue;
    }


    public Model.DJ_TourGroupMember ConvertToMember(string[] strMember)
    {
        if (strMember.Length != 7)
        {
            throw new Exception("参数有误");
        }
        Model.DJ_TourGroupMember member = new DJ_TourGroupMember();
        member.IdCardNo = strMember[4];
        member.PhoneNum = strMember[3];
        member.RealName = strMember[2];
        member.TouristType = strMember[1];
        string memberId = strMember[6];
        if (!string.IsNullOrEmpty(memberId))
        {
            member.Id = Guid.Parse(memberId);
        }
        //  member.
        return member;



    }
    /*
        
		{ name: 'no' },
		{ name: 'tourertype' },
		{ name: 'realname' },
		{ name: 'phone' },
		{ name: 'idcardno' },
		{ name: 'othercardno' }  
     * { name: 'memberid' },
		
     */
    private string BuildLoadResponse(IList<Model.DJ_TourGroupMember> memberList)
    {
        System.Text.StringBuilder sbJson = new System.Text.StringBuilder();
        sbJson.Append("{\"data\":[");
        foreach (Model.DJ_TourGroupMember member in memberList)
        { 
          
            sbJson.Append("{");
            sbJson.Append(string.Format("\"{0}\":\"{1}\",", fieldsName[0],memberList.IndexOf(member)));
            sbJson.Append(string.Format("\"{0}\":\"{1}\",", fieldsName[1], member.TouristType));
            sbJson.Append(string.Format("\"{0}\":\"{1}\",", fieldsName[2], member.RealName));
            sbJson.Append(string.Format("\"{0}\":\"{1}\",", fieldsName[3], member.PhoneNum));
            sbJson.Append(string.Format("\"{0}\":\"{1}\",", fieldsName[4], member.IdCardNo));
            sbJson.Append(string.Format("\"{0}\":\"{1}\",", fieldsName[5], member.SpecialCardNo));
            sbJson.Append(string.Format("\"{0}\":\"{1}\"", fieldsName[6], member.Id));
            sbJson.Append("}");
            if (memberList.IndexOf(member) < memberList.Count - 1)
            {
                sbJson.Append(",");
            }
        }
        
        sbJson.Append("],pageInfo:null,exception:null}");
        return sbJson.ToString();
    }
}


/// <summary>
/// sigmagrid load方法返回的对象
/// 
/// </summary>
public class SigmaGridLoadObject
{
    /*{"data":
        *  [
        *      {"no":52,"name":"abc40","age":25,"gender":"br","english":88,"math":76}
        *      ,{"no":53,"name":"abc33","age":25,"gender":"br","english":98,"math":99}
        *      ,{"no":54,"name":"abc34","age":24,"gender":"us","english":23,"math":77}
        *      ,{"no":55,"name":"abc35","age":23,"gender":"fr","english":67,"math":55}
        *   ],
        *   "pageInfo":
        *      {"pageSize":10,"pageNum":3,"totalRowNum":25,"totalPageNum":3,"startRowNum":21,"endRowNum":25},
        *   "exception":null
        * }*/
    // public 
}
