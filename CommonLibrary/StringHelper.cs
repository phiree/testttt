using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLibrary
{
    public class StringHelper
    {
        public static string BuildJsonArray(IList<string> strArr)
        {

            System.Text.StringBuilder sbJson = new System.Text.StringBuilder();
            sbJson.Append("[");
            foreach (string str in strArr)
            {
                sbJson.Append("\\\"");

                sbJson.Append(str); sbJson.Append("\\\"");
                if (strArr.IndexOf(str) < strArr.Count - 1)
                {
                    sbJson.Append(",");
                }
            }
            sbJson.Append("]");
            return sbJson.ToString();

        }
    }
}
