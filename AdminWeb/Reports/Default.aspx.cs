using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
/// <summary>
/// 根据身份证信息生成的报表
/// </summary>
public partial class Reports_Default : System.Web.UI.Page
{
    BLL.BLLIdcardReport bllIdcardReport = new BLL.BLLIdcardReport();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        { 
            Dictionary<string,int> provinceData=bllIdcardReport.GetListForScenic("",null,null,null,null);
            BindChart("游客地理分布图", provinceData);
        }
    }
    private void BindChart(string seryName, Dictionary<string, int> pointValues)
    {

        Series se = new Series(seryName);
        se.ChartType = SeriesChartType.Column;
        se.XValueType = ChartValueType.Auto;
        se.MarkerStyle = MarkerStyle.Star10;
       // se.LabelFormat = "hh:mm:ss";
       // se.YValuesPerPoint = 30;
        //一个point 表示该series在某点的数据
        se.Points.DataBindXY(pointValues.Keys,pointValues.Values );
        Chart1.Series.Add(se);
    }
}