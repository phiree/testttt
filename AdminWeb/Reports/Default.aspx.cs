using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using CommonLibrary;
/// <summary>
/// 根据身份证信息生成的报表
/// </summary>
public partial class Reports_Default : System.Web.UI.Page
{
    BLL.BLLIdcardReport bllIdcardReport = new BLL.BLLIdcardReport();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        string geCode = Request["code"];
        BLL.enumGroupByType groupType = BLL.enumGroupByType.ProvinceCode;
        if (!string.IsNullOrEmpty(geCode))
        {
            groupType = BLL.enumGroupByType.CityCode;

        }
        if (!Page.IsPostBack)
        { 
            Dictionary<string,int> provinceData=bllIdcardReport.GetListForScenic("33",null,null,null,null, groupType,Convert.ToInt32(geCode));
            BindChart("游客地理分布图", provinceData);
        }
    }
    private void BindChart(string seryName, Dictionary<string, int> pointValues)
    {

        Series se = new Series(seryName);
        se.ChartType = SeriesChartType.Bar;
       // se.ChartType = SeriesChartType.Column;
        se.XValueType = ChartValueType.String;

        Chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;       // se.LabelFormat = "hh:mm:ss";

      // se.Label = "#PERCENT{P2}";
        //se["PieLabelStyle"] = "Outside";

        // Chart1.Legends.Add("Legend1");

        // Chart1.Legends[0].Enabled = true;

        // Chart1.Legends[0].Docking = Docking.Bottom;

        // Chart1.Legends[0].Alignment = System.Drawing.StringAlignment.Center;

        //se.LegendText = "#PERCENT{P2}";


        //一个point 表示该series在某点的数据
        se.IsValueShownAsLabel = true;
        se.Points.DataBindXY(pointValues.Keys,pointValues.Values );
      
        Chart1.Series.Clear();
        Chart1.Series.Add(se);
     //  Chart1.Series[0]["CollectedThresholdUsePercent"] = "true";
        /*
                Chart1.Series[0].Label = "#PERCENT{P2}";
                Chart1.Series[0]["PieLabelStyle"] = "Outside";*/

    }
    protected void chart1_custom(object sender, EventArgs e)
    {
        foreach (CustomLabel lbl in Chart1.ChartAreas[0].AxisX.CustomLabels)
        {
            string pcode = string.Empty;
            if (IdCardInfo.ProvinceDict.ContainsValue(lbl.Text))
            {
                KeyValuePair<int, string> p = IdCardInfo.ProvinceDict.Single(x => x.Value == lbl.Text);
                if (p.Key != null)
                {
                    pcode = p.Key.ToString();
                }
                lbl.Url = "default.aspx?code=" + pcode;
            }
        }
       
    }
}