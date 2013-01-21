using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Model;
using BLL;
using System.Runtime.Serialization.Json;
using System.IO;

public partial class qumobile_CheckTicket : basepage
{
    #region 初始化参数
    BLLScenic bllScenic = new BLLScenic();
    BLLMembership bllMember = new BLLMembership();
    #endregion

    #region Init
    /// <summary>
    /// 为前台autocomplete插件做的ajax方法
    /// </summary>
    /// <param name="scid">景区id</param>
    /// <returns></returns>
    [WebMethod]
    public static string GetAllHints(string scid)
    {
        Scenic s = new BLLScenic().GetScenicById(int.Parse(scid));
        List<TicketAssign> list = new BLLTicketAssign().GetIdcardandname("", "", s);
        Dictionary<string, string> data = new Dictionary<string, string>();
        foreach (TicketAssign item in list)
        {
            //这里的key是真实身份证号，val是带*身份证号
            data.Add(item.Name + "/" + item.IdCard, item.Name + "/" + item.IdCard.Substring(0, 6) + "********" + item.IdCard.Substring(14));
        }
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(data.GetType());
        using (MemoryStream ms = new MemoryStream())
        {
            serializer.WriteObject(ms, data);
            return System.Text.Encoding.UTF8.GetString(ms.ToArray());
        }
    }

    



    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitData();
        }
    }

    private void InitData()
    {
        ScenicAdmin sa= bllMember.GetScenicAdmin((Guid)CurrentUser.ProviderUserKey);
        hfscid.Value = sa.Scenic.Id.ToString();
    }
    #endregion

    #region event

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //Scenic CurrentScenic = bllMember.GetScenicAdmin((Guid)CurrentUser.ProviderUserKey).Scenic;
        //if (hfdata.Value.Split('/').Length < 2)
        //{
        //    Msg.InnerText = "无此身份证购票信息";
        //    return;
        //}
        //string name = hfdata.Value.Split('/')[0];
        //string idcard = hfdata.Value.Split('/')[1];
        //int flag = 0;
        //foreach (TicketAssign item in new BLLTicketAssign().GetIdcardandname("", "", CurrentScenic).Where(x => x.Name == name))
        //{
        //    if (item.IdCard == idcard)
        //    {
        //        flag = 1;
        //        idcard = item.IdCard;
        //    }
        //}
        //if (flag == 0)
        //{
        //    foreach (DJ_Group_Worker work in new BLLDJTourGroup().GetGuiderWorkerByTE(Master.Scenic).ToList())
        //    {
        //        if (work.DJ_Workers.IDCard == idcard)
        //        {
        //            flag = 1;
        //            idcard = work.DJ_Workers.IDCard;
        //        }
        //    }
        //}
        //if (flag == 0)
        //{
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "s", "alert('无此身份证购票信息')", true);
        //    return;
        //}
        //if (Request.Cookies["idcard"] != null)
        //    Request.Cookies["idcard"].Value = idcard;
        //if (Response.Cookies["idcard"] != null)
        //    Response.Cookies["idcard"].Value = idcard;
        //bindTicketInfo(name, idcard);
        //BindPrintLink();
    }



    #endregion
}