using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Core;
using System.IO;
using System.Reflection;

namespace ExcelOplib
{
    /// <summary>
    /// 到处接口
    /// </summary>
    public class ExcelOutput
    {
        /// <summary>
        /// 导出数据到excel
        /// </summary>
        /// <param name="ds">数据集</param>
        /// <param name="path">制定路径(包括路径和文件名扩展名)</param>
        public void PersistenceDB2Excel4Scenic(DataSet ds, string path)
        {
            Microsoft.Office.Interop.Excel.Application excel1 = new Microsoft.Office.Interop.Excel.Application();
            Workbook workbook1 = null;
            Worksheet worksheet1 = null;
            //if (!File.Exists(path))
            //{
            //    workbook1 = excel1.Workbooks.Add(Missing.Value);
            //    worksheet1 = (Worksheet)workbook1.Worksheets["sheet1"];
            //    excel1.Visible = false;
            //    //赋值给title
            //    worksheet1.Cells[1, 1] = "名称";
            //    worksheet1.Cells[1, 2] = "等级";
            //    worksheet1.Cells[1, 3] = "景区地址";
            //    worksheet1.Cells[1, 4] = "seoname";
            //    worksheet1.Cells[1, 5] = "区域";
            //    worksheet1.Cells[1, 6] = "景区主题";
            //    worksheet1.Cells[1, 7] = "topicseo";
            //    worksheet1.Cells[1, 8] = "交通指南";
            //    worksheet1.Cells[1, 9] = "订票说明";
            //    worksheet1.Cells[1, 10] = "景区详情";
            //    worksheet1.Cells[1, 11] = "景区简介";
            //    worksheet1.Cells[1, 12] = "主图";
            //}
            for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
            {
                for (int column = 1; column <= ds.Tables[0].Columns.Count - 1; column++)
                {
                    worksheet1.Cells[row + 2, column] = ds.Tables[0].Rows[row][column].ToString();
                }
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
