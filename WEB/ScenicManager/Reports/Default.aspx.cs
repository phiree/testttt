using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using CommonLibrary;
public partial class ScenicManager_Reports_Default : bpScenicManager
{
    BLL.BLLIdcardReport bllIdcardReport = new BLL.BLLIdcardReport();
    BLL.enumGroupByType groupType = BLL.enumGroupByType.ProvinceCode;
    protected void Page_Load(object sender, EventArgs e)
    {
        string geCode = Request["code"];
     
        if (!string.IsNullOrEmpty(geCode))
        {
            groupType = BLL.enumGroupByType.CityCode;
            if (geCode.EndsWith("00"))
            {
                groupType = BLL.enumGroupByType.CountryCode;

            }

        }
        if (!Page.IsPostBack)
        {
            Dictionary<string, int> provinceData = bllIdcardReport.GetListForScenic("",CurrentScenic.Id, null, null, null, groupType, Convert.ToInt32(geCode));
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


        //一个point 表示该series在某点的数据
        se.IsValueShownAsLabel = true;
        se.Points.DataBindXY(pointValues.Keys, pointValues.Values);

        Chart1.Series.Clear();
        Chart1.Series.Add(se);
    }
    protected void chart1_custom(object sender, EventArgs e)
    {
        foreach (CustomLabel lbl in Chart1.ChartAreas[0].AxisX.CustomLabels)
        {
            if (groupType == BLL.enumGroupByType.ProvinceCode)
            {
                string pcode = string.Empty;
                //当前生成省份链接
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
            //当前生成城市链接
            if (groupType == BLL.enumGroupByType.CityCode)
            {
                string pcode = string.Empty;
                if (IdCardInfo.CityDict.ContainsValue(lbl.Text))
                {
                    KeyValuePair<int, string> p = IdCardInfo.CityDict.Single(x => x.Value == lbl.Text);
                    if (p.Key != null)
                    {
                        pcode = p.Key.ToString();
                    }
                    lbl.Url = "default.aspx?code=" + pcode;
                }
            }
            
        }

    }
}