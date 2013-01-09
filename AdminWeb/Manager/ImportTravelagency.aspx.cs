using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Xml;
using BLL;

public partial class Manager_ImportTravelagency : System.Web.UI.Page
{
    BLLDJEnterprise bllenterp = new BLLDJEnterprise();

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnImport_Click(object sender, EventArgs e)
    {
        IList<Model.DJ_TourEnterprise> enpList = ParseXml();
        bllenterp.SaveOrUpdate(enpList);
        lblDesc.Text = "共导入" + enpList.Count;
    }

    IList<Model.DJ_TourEnterprise> ParseXml()
    {
        //string address = tbxAddress.Text;
        //WebRequest wq = WebRequest.Create(address);
        //StreamReader sr = new StreamReader(wq.GetResponse().GetResponseStream());

        string address = tbxAddress.Text;
        StreamReader sr = new StreamReader(address);

        XmlDocument doc = new XmlDocument();
        TravelXmlParser txp = new TravelXmlParser(sr);

        IList<Model.DJ_TourEnterprise> EnterpriceList = txp.Parse();

        return EnterpriceList;
    }
}