using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;
using System.IO;
using System.Reflection;
using System.Xml.Linq;

namespace ExcelOplib
{
    public class XmlHelper
    {
        public static void Xml2Excel()
        {
            var xd = XDocument.Load("d:\\TravelInfo.xml");
            if (xd.Root == null) return;
            var travelModelList = new List<TravelModel>();
            foreach (var item in xd.Root.Descendants("TravelInfo"))//得到每一个TravelInfo节点,得到这个节点再取他的Name的这个节点的值
            {
                travelModelList.Add(new TravelModel()
                {
                    Name = item.Element("UnitName").Value,
                    AreaCode = item.Element("AreaCode").Value
                });
            }
            new ExcelOplib.XML2Excel().ConvertXml2Excel(travelModelList, "e:\\企业数据-旅行社(全部).xlsx");
        }
    }

    public class TravelModel
    {
        public string Name { get; set; }
        public string AreaCode { get; set; }
        public string Area { get; set; }
    }

    public class XML2Excel
    {
        public void ConvertXml2Excel(IList<TravelModel> Tlist, string path)
        {
            Microsoft.Office.Interop.Excel.Application excel1 = new Microsoft.Office.Interop.Excel.Application();
            Workbook workbook1 = null;
            Worksheet worksheet1 = null;
            if (!File.Exists(path))
            {
                workbook1 = excel1.Workbooks.Add(Missing.Value);
                worksheet1 = (Worksheet)workbook1.Worksheets["sheet1"];
                excel1.Visible = false;
                //赋值给title
                worksheet1.Cells[1, 1] = "名称";
                worksheet1.Cells[1, 2] = "地区";
            }
            else
            {
                workbook1 = excel1.Workbooks.Open(path, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                worksheet1 = (Worksheet)workbook1.Worksheets["sheet1"];
                excel1.Visible = false;
            }
            for (int row = 0; row < Tlist.Count; row++)
            {
                worksheet1.Cells[row + 2, 1] = Tlist[row].Name;
                worksheet1.Cells[row + 2, 2] = Tlist[row].AreaCode;
            }
            //excel属性
            excel1.Visible = false;
            excel1.DisplayAlerts = false;//不显示提示框
            workbook1.Close(true, path, null);
            //关闭1
            worksheet1 = null;
            workbook1 = null;
            excel1.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excel1);
            excel1 = null;
            System.GC.Collect();
        }
    }
}
