using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLibrary
{
    public class NearbyCalc
    {
        const double PI = 3.1415926535;
        /// <summary>
        /// 参照物坐标
        /// </summary>
        private string orglocation { get; set; }
        /// <summary>
        /// 比较物坐标字典，object是唯一标识符
        /// </summary>
        private Dictionary<object, string> comparelocation { get; set; }
        /// <summary>
        /// 计较结果，int为序列，object为唯一标识符
        /// </summary>
        private Dictionary<int, object> compareresult { get; set; }

        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="orl">参照物</param>
        /// <param name="cmplocation">比较物坐标字典</param>
        public Queue<object> CalcNearby(string orl, Dictionary<object, string> cmplocation, int count)
        {
            var orl_x = double.Parse(orl.Split(',')[0]);
            var orl_y = double.Parse(orl.Split(',')[1]);
            //唯一标识符和计算结果对
            Dictionary<object, double> cmp_result = new Dictionary<object, double>();
            foreach (var item in cmplocation)
            {
                var cmp_x = double.Parse(item.Value.Split(',')[0]);
                var cmp_y = double.Parse(item.Value.Split(',')[1]);
                cmp_result.Add(item.Key, CalculateDistance(orl_x, orl_y, cmp_x, cmp_y));
            }
            //排序后的唯一标识符和计算结果对
            var com_dic = cmp_result.OrderBy(x => x.Value);
            Queue<object> queue = new Queue<object>();
            for (int i = 0; i < com_dic.Count() && i < count; i++)
            {
                queue.Enqueue(com_dic.ElementAt(i).Key);
            }
            return queue;
        }

        private double CalculateDistance(double lat1, double lng1, double lat2, double lng2)
        {
            double EARTH_RADIUS = 6378.137;   // 地球半径
            double radLat1 = lat1 * PI / 180;     // 转化为弧度值
            double radLat2 = lat2 * PI / 180;
            double a = radLat1 - radLat2;
            double b = (lng1 - lng2) * PI / 180;
            double s = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2) + Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(b / 2), 2)));
            s = s * EARTH_RADIUS;
            return s;
        }
    }

}
