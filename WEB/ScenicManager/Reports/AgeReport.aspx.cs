using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
public partial class ScenicManager_Reports_AgeReport : bpScenicManager
{
   BLL.BLLIdcardReport bllIdcardReport = new BLL.BLLIdcardReport();
    BLL.enumGroupByType groupType = BLL.enumGroupByType.Age;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!Page.IsPostBack)
        {
            Dictionary<string, int> provinceData = bllIdcardReport.GetListForScenic("",
                CurrentScenic.Id, null, null, null, groupType, 0)
                ;
            BindChart("游客地理分布图", provinceData);
        }
    }
    private void BindChart(string seryName, Dictionary<string, int> pointValues)
    {

        Series se = new Series(seryName);
        se.ChartType = SeriesChartType.Bar;
        se["CollectedToolTip"] = "Other";
        se["CollectedThreshold"] = "1";
        se.AxisLabel = "$PERCENT";
        se.MarkerStep =1;
        // se.ChartType = SeriesChartType.Column;
        se.XValueType = ChartValueType.String; se["PieLabelStyle"] = "Outside";
       se.Label = "#PERCENT{P2}";
   

        Chart1.ChartAreas["ChartArea1"].AxisX.Interval = 10;       // se.LabelFormat = "hh:mm:ss";


        //一个point 表示该series在某点的数据
      //  se.IsValueShownAsLabel = true;
        
        se.Points.DataBindXY(pointValues.Keys, pointValues.Values);

        Chart1.Series.Clear();
        Chart1.Series.Add(se);
    }
}
 