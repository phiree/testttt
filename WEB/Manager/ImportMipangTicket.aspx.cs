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
       

        ///删除所有米胖导入的景区
        IList<Scenic> importedMipangScenic = bllScenic.GetList_Mipang();
        foreach (Scenic mipangScenic in importedMipangScenic)
        {
            bllScenic.Delete(mipangScenic);
            
        }
        IList<Scenic> scenicList = ParseXml();
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
        string errmsg;
        bllTicket.BatchMove(tbxMoves.Text.Trim(), out errmsg);
        lblMoveError.Text = errmsg;
    }

    protected void btnGetMipangList_Click(object o, EventArgs e)
    {
        rptMipangList.DataSource = ParseXml();
        rptMipangList.DataBind();
        
    }
}