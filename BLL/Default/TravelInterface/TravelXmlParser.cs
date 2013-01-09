using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using Model;

namespace BLL
{
    public class TravelXmlParser
    {
        BLLArea bllarea = new BLLArea();

        public TextReader DocReader { get; set; }

        private TravelXmlParser() { }

        public TravelXmlParser(TextReader docReader)
        {
            this.DocReader = docReader;
        }

        public List<Model.DJ_TourEnterprise> Parse()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TravelData));

            TravelData traveldata = (TravelData)serializer.Deserialize(DocReader);

            List<Model.DJ_TourEnterprise> enterpricelist = new List<Model.DJ_TourEnterprise>();
            foreach (var item in traveldata.TravelInfos)
            {
                Model.DJ_TourEnterprise s = ParseTicket(item);
                enterpricelist.Add(s);
            }
            return enterpricelist;
        }

        private Model.DJ_TourEnterprise ParseTicket(TravelInfo item)
        {
            Model.DJ_TourEnterprise te = new Model.DJ_TourEnterprise();
            te.Name = item.UnitName;
            te.Area = bllarea.GetAreaByCode(item.Areacode) ;
            te.Address = item.Address;
            te.ChargePersonName = item.Manager;
            te.ChargePersonPhone = item.ManagerTel;
            te.Email = item.Email;
            te.Fax = item.Fax;
            te.Url = item.Url;
            te.Type = EnterpriseType.景点;

            return te;
        }
    }

    public class TravelData
    {
        public List<TravelInfo> TravelInfos { get; set; }
    }

    [System.Xml.Serialization.XmlRoot("TravelInfo")]
    public class TravelInfo
    {
        public string GlobalUnitID { get; set; }
        public string UnitName { get; set; }
        public string Areacode { get; set; }
        public string AreaName { get; set; }
        public string Address { get; set; }
        public string Post { get; set; }
        public string Manager { get; set; }
        public string ManagerTel { get; set; }
        public string Contractperson { get; set; }
        public string ContractTel { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Url { get; set; }
    }
}
