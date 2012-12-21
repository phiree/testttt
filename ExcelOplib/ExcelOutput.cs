using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
//using Microsoft.Office.Core;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Web;
using System.Web.UI;
using NPOI.HSSF.UserModel;
using NPOI.HPSF;
using NPOI.SS.UserModel;

namespace ExcelOplib
{
    /// <summary>
    /// 导出接口
    /// </summary>
    public class ExcelOutput
    {
        HSSFWorkbook hssfworkbook;

        void InitializeWorkbook()
        {
            hssfworkbook = new HSSFWorkbook();

            ////create a entry of DocumentSummaryInformation
            DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
            //dsi.Company = "NPOI Company";
            hssfworkbook.DocumentSummaryInformation = dsi;

            ////create a entry of SummaryInformation
            SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
            //si.Subject = "NPOI SDK Example";
            hssfworkbook.SummaryInformation = si;
        }

        MemoryStream WriteToStream()
        {
            //Write the stream data of workbook to the root directory
            MemoryStream file = new MemoryStream();
            hssfworkbook.Write(file);
            return file;
        }

        /// <summary>
        /// 导出数据到excel
        /// </summary>
        /// <param name="dt">数据表</param>
        /// <param name="page">返回(当前)页</param>
        /// <param name="titlelist">标题列表</param>
        /// <param name="title">文件名称</param>
        public void Download2Excel(DataTable dt, Page page, List<string> titlelist, string filename)
        {
            var resp = page.Response;
            resp.ContentType = "application/vnd.ms-excel";
            resp.AddHeader("Content-Disposition", string.Format("attachment;filename={0}.xls", filename));
            resp.Clear();

            InitializeWorkbook();

            #region generate data
            ISheet sheet1 = hssfworkbook.CreateSheet("Sheet1");
            var row0=sheet1.CreateRow(0);
            for (int i = 0; i < titlelist.Count; i++)
            {
                row0.CreateCell(i).SetCellValue(titlelist[i]);
            }
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                IRow row = sheet1.CreateRow(j + 1);
                for (int k = 0; k < dt.Columns.Count; k++)
                {
                    row.CreateCell(k).SetCellValue(dt.Rows[j].ItemArray[k].ToString());
                }
            }
            #endregion

            //写缓冲区中的数据到HTTP头文档中 
            resp.End();
        }

        /// <summary>
        /// 下载excel模版
        /// </summary>
        /// <param name="dt">数据表</param>
        /// <param name="page">返回(当前)页</param>
        /// <param name="titlelist">标题列表</param>
        public void Download2ExcelModel(Page page)
        {
            var resp = page.Response;
            resp.ContentType = "application/vnd.ms-excel";
            resp.AddHeader("Content-Disposition","attachment;filename=团队模版.xls");
            resp.Clear();
            InitializeWorkbook();
            #region generate data
            ISheet sheet1 = hssfworkbook.CreateSheet("Sheet1");
            IRow row0 = sheet1.CreateRow(0);
            //标题头
            row0.CreateCell(0).SetCellValue("团队名称");
            row0.CreateCell(1).SetCellValue("开始时间");
            row0.CreateCell(2).SetCellValue("天数");
            row0.CreateCell(3).SetCellValue("");
            row0.CreateCell(4).SetCellValue("导游姓名");
            row0.CreateCell(5).SetCellValue("导游身份证号");
            row0.CreateCell(6).SetCellValue("导游电话号码");
            row0.CreateCell(7).SetCellValue("导游证号");
            row0.CreateCell(8).SetCellValue("");
            row0.CreateCell(9).SetCellValue("司机姓名");
            row0.CreateCell(10).SetCellValue("司机身份证号");
            row0.CreateCell(11).SetCellValue("司机电话号码");
            row0.CreateCell(12).SetCellValue("司机证号");
            row0.CreateCell(13).SetCellValue("");
            row0.CreateCell(14).SetCellValue("类型(成/儿/外/港澳台)");
            row0.CreateCell(15).SetCellValue("游客姓名");
            row0.CreateCell(16).SetCellValue("游客身份证号");
            row0.CreateCell(17).SetCellValue("游客电话号码");
            row0.CreateCell(18).SetCellValue("");
            row0.CreateCell(19).SetCellValue("日程");
            row0.CreateCell(20).SetCellValue("景点");
            row0.CreateCell(21).SetCellValue("住宿");
            //示例说明
            var cel=sheet1.CreateRow(1).CreateCell(0);
            cel.SetCellValue("示例如下");
            //示例内容
            IRow row2 = sheet1.CreateRow(2);
            IRow row3 = sheet1.CreateRow(3);
            IRow row4 = sheet1.CreateRow(4);
            IRow row5 = sheet1.CreateRow(5);
            row2.CreateCell(0).SetCellValue("江南一日游");
            row2.CreateCell(1).SetCellValue("2012/12/9");
            row2.CreateCell(2).SetCellValue("3");
            row2.CreateCell(3).SetCellValue("");
            row2.CreateCell(4).SetCellValue("张道友");
            row2.CreateCell(5).SetCellValue("150626197605059170");
            row2.CreateCell(6).SetCellValue("18075649865");
            row2.CreateCell(7).SetCellValue("DZG2007XJ10632");
            row2.CreateCell(8).SetCellValue("");
            row2.CreateCell(9).SetCellValue("陈思基");
            row2.CreateCell(10).SetCellValue("150626197605058872");
            row2.CreateCell(11).SetCellValue("18055877556");
            row2.CreateCell(12).SetCellValue("司机证号");
            row2.CreateCell(13).SetCellValue("");
            row2.CreateCell(14).SetCellValue("成");
            row2.CreateCell(15).SetCellValue("游可依");
            row2.CreateCell(16).SetCellValue("150626197605059170");
            row2.CreateCell(17).SetCellValue("13955557556");
            row3.CreateCell(14).SetCellValue("儿");
            row3.CreateCell(15).SetCellValue("游可儿");
            row3.CreateCell(16).SetCellValue("无");
            row3.CreateCell(17).SetCellValue("无");
            row2.CreateCell(18).SetCellValue("");
            row2.CreateCell(19).SetCellValue("1");
            row2.CreateCell(20).SetCellValue("西湖,西溪湿地");
            row2.CreateCell(21).SetCellValue("希尔顿酒店");
            row3.CreateCell(19).SetCellValue("2");
            row3.CreateCell(20).SetCellValue("乌镇");
            row3.CreateCell(21).SetCellValue("乌镇客栈");
            row4.CreateCell(19).SetCellValue("3");
            row4.CreateCell(20).SetCellValue("苏州园林");
            row4.CreateCell(21).SetCellValue("苏州大酒店");
            //实际内容说明
            sheet1.CreateRow(7).CreateCell(0).SetCellValue("根据示例内容，从下一行开始填写团队内容");
            #endregion

            //colCaption += "团队名称\t";
            //colCaption += "开始时间\t";
            //colCaption += "天数\t";
            //colCaption += "\t";
            //colCaption += "导游姓名\t";
            //colCaption += "导游身份证号\t";
            //colCaption += "导游电话号码\t";
            //colCaption += "导游证号\t";
            //colCaption += "\t";
            //colCaption += "司机姓名\t";
            //colCaption += "司机身份证号\t";
            //colCaption += "司机电话号码\t";
            //colCaption += "司机证号\t";
            //colCaption += "\t";
            //colCaption += "类型\t";
            //colCaption += "游客姓名\t";
            //colCaption += "游客身份证号\t";
            //colCaption += "游客电话号码\t";
            //colCaption += "\t";
            //colCaption += "日期\t";
            //colCaption += "景点\t";
            //colCaption += "住宿\t";
            //colCaption += "\n";
            //resp.Write(colCaption);
            //写缓冲区中的数据到HTTP头文档中 
            resp.End();
        }

        ///// <summary>
        ///// 导出数据到excel
        ///// </summary>
        ///// <param name="dt">数据表</param>
        ///// <param name="page">返回(当前)页</param>
        ///// <param name="titlelist">标题列表</param>
        ///// <param name="title">文件名称</param>
        //public static void Download2Excel(DataTable dt, Page page, List<string> titlelist,string filename)
        //{
        //    HttpResponse resp;
        //    resp = page.Response;
        //    resp.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
        //    resp.AppendHeader("Content-Disposition", "attachment;filename=" + filename + ".xls");
        //    // resp.ContentType = "application/vnd.ms-excel";
        //    string colCaption = "", colContent = "", colfooter = "";
        //    foreach (var item in titlelist)
        //    {
        //        colCaption += item + "\t";
        //    }
        //    colCaption += "\n";
        //    resp.Write(colCaption);
        //    foreach (DataRow record in dt.Rows)
        //    {
        //        for (int i = 0; i < dt.Columns.Count; i++)
        //        {
        //            colContent += record.ItemArray[i] + "\t";
        //        }
        //        colContent += "\n";
        //    }
        //    resp.Write(colContent);
        //    resp.Write(colfooter);
        //    //写缓冲区中的数据到HTTP头文档中 
        //    resp.End();
        //}

        ///// <summary>
        ///// 下载excel模版
        ///// </summary>
        ///// <param name="dt">数据表</param>
        ///// <param name="page">返回(当前)页</param>
        ///// <param name="titlelist">标题列表</param>
        //public void Download2ExcelModel(Page page)
        //{
        //    HttpResponse resp;
        //    resp = page.Response;
        //    resp.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
        //    resp.AppendHeader("Content-Disposition", "attachment;filename=" + DateTime.Now.ToShortTimeString() + ".xls");
        //    string colCaption = string.Empty;
        //    colCaption += "团队名称\t";
        //    colCaption += "开始时间\t";
        //    colCaption += "天数\t";
        //    colCaption += "\t";
        //    colCaption += "导游姓名\t";
        //    colCaption += "导游身份证号\t";
        //    colCaption += "导游电话号码\t";
        //    colCaption += "导游证号\t";
        //    colCaption += "\t";
        //    colCaption += "司机姓名\t";
        //    colCaption += "司机身份证号\t";
        //    colCaption += "司机电话号码\t";
        //    colCaption += "司机证号\t";
        //    colCaption += "\t";
        //    colCaption += "类型\t";
        //    colCaption += "游客姓名\t";
        //    colCaption += "游客身份证号\t";
        //    colCaption += "游客电话号码\t";
        //    colCaption += "\t";
        //    colCaption += "日期\t";
        //    colCaption += "景点\t";
        //    colCaption += "住宿\t";
        //    colCaption += "\n";
        //    resp.Write(colCaption);
        //    //写缓冲区中的数据到HTTP头文档中 
        //    resp.End();
        //}
    }
}
