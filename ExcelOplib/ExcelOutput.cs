using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Office.Core;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Web;
using System.Web.UI;

namespace ExcelOplib
{
    /// <summary>
    /// 导出接口
    /// </summary>
    public class ExcelOutput
    {
        /// <summary>
        /// 导出数据到excel
        /// </summary>
        /// <param name="dt">数据表</param>
        /// <param name="page">返回(当前)页</param>
        /// <param name="titlelist">标题列表</param>
        public static void Download2Excel(DataTable dt, Page page, List<string> titlelist)
        {
            HttpResponse resp;
            resp = page.Response;
            resp.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            resp.AppendHeader("Content-Disposition", "attachment;filename=" + DateTime.Now.ToShortTimeString() + ".xls");
            // resp.ContentType = "application/vnd.ms-excel";
            string colCaption = "", colContent = "", colfooter = "";
            foreach (var item in titlelist)
            {
                colCaption += item + "\t";
            }
            colCaption += "\n";
            resp.Write(colCaption);
            foreach (DataRow record in dt.Rows)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    colContent += record.ItemArray[i] + "\t";
                }
                colContent += "\n";
            }
            resp.Write(colContent);
            resp.Write(colfooter);
            //写缓冲区中的数据到HTTP头文档中 
            resp.End();
        }

        /// <summary>
        /// 下载excel模版
        /// </summary>
        /// <param name="dt">数据表</param>
        /// <param name="page">返回(当前)页</param>
        /// <param name="titlelist">标题列表</param>
        public static void Download2ExcelModel(Page page)
        {
            HttpResponse resp;
            resp = page.Response;
            resp.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            resp.AppendHeader("Content-Disposition", "attachment;filename=" + DateTime.Now.ToShortTimeString() + ".xls");
            string colCaption = string.Empty;
            colCaption += "团队名称\t";
            colCaption += "开始时间\t";
            colCaption += "天数\t";
            colCaption += "\t";
            colCaption += "导游姓名\t";
            colCaption += "导游身份证号\t";
            colCaption += "导游电话号码\t";
            colCaption += "导游证号\t";
            colCaption += "\t";
            colCaption += "司机姓名\t";
            colCaption += "司机身份证号\t";
            colCaption += "司机电话号码\t";
            colCaption += "司机证号\t";
            colCaption += "\t";
            colCaption += "类型\t";
            colCaption += "游客姓名\t";
            colCaption += "游客身份证号\t";
            colCaption += "游客电话号码\t";
            colCaption += "\t";
            colCaption += "日期\t";
            colCaption += "景点\t";
            colCaption += "住宿\t";
            colCaption += "\n";
            resp.Write(colCaption);
            //写缓冲区中的数据到HTTP头文档中 
            resp.End();
        }
    }
}
