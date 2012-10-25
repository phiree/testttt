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
    protected void btnImport_Click(object sender, EventArgs e)
    {
        IList<Scenic> scenicList = ParseXml();

        foreach (Scenic s in scenicList)
        {
            bllScenic.Save(s);
        }
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
}