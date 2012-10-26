using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using System.Xml;
using System.Net;
public partial class Manager_ImportMipangTicket : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    BLLScenic bllScenic = new BLLScenic();
    BLLTicket bllTicket = new BLLTicket();
    protected void btnImport_Click(object sender, EventArgs e)
    {
        IList<Scenic> scenicList = ParseXml();

        ///删除所有米胖导入的门票
        IList<Scenic> importedMipangScenic = bllScenic.GetList_Mipang();
        foreach (Scenic mipangScenic in importedMipangScenic)
        {
            bllScenic.Delete(mipangScenic);
            
        }

        foreach (Scenic s in scenicList)
        {
            bllScenic.Save(s);
            
        }
        lblDesc.Text = "共导入" + scenicList.Count;
    }

    private void BindList()
    { 

    }

    IList<Scenic> ParseXml()
    {
        string address = tbxAddress.Text;
        WebRequest wq = WebRequest.Create(address);
        StreamReader sr = new StreamReader(wq.GetResponse().GetResponseStream());

        XmlDocument doc = new XmlDocument();
        TicketXmlParser txp = new TicketXmlParser(sr);

        IList<Scenic> ScenicList = txp.Parse();

        return ScenicList;
    }
    protected void btnMove_Click(object sender, EventArgs e)
    {
        System.Text.StringBuilder sbErr = new System.Text.StringBuilder();
        string[] rowStrings = tbxMoves.Text.Split(Environment.NewLine.ToCharArray());
        foreach (string s in rowStrings)
        {
            if (string.IsNullOrEmpty(s)) continue;
            string[] pair = s.Split(',');
            if (pair.Length != 2)
            {
                sbErr.AppendLine(s+":格式有误");
                continue;
            }
            int mipangId=0;
            if (!int.TryParse(pair[0], out mipangId))
            {
                sbErr.AppendLine(s+":mipangid不是数字");
                continue;
            }
            string moveResult;
            bllTicket.Move(mipangId, pair[1], out moveResult);
            if (!string.IsNullOrEmpty(moveResult))
            {
                sbErr.AppendLine(moveResult);
            }
          }
        lblMoveError.Text = sbErr.ToString();
    }

    protected void btnGetMipangList_Click(object o, EventArgs e)
    {
        rptMipangList.DataSource = ParseXml();
        rptMipangList.DataBind();
        
    }
}