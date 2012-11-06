using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLibrary
{
   public class ListHelper
    {
       public static List<string> ExtendStringList(IList<string> entNames, int amount)
       {
           List<string> result = new List<string>();


           for (int i = 0; i < amount; i++)
           {
               string s = string.Empty;
               if (i < entNames.Count)
               {
                   s = entNames[i];
               }
               result.Add(s);
           }
           return result;
       }
    }
}
