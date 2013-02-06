using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace CommonLibrary
{
   public  class IOHelper
    {
       public static void WriteContentToFile(string physiclePath, string content)
       {
           if(!File.Exists(physiclePath))
           {
               CreateDirectory(new DirectoryInfo( Path.GetDirectoryName(physiclePath)));
              FileStream fs= File.Create(physiclePath);
              fs.Close();
           }
           File.AppendAllText(physiclePath, content);
       }
       private static void CreateDirectory(DirectoryInfo directory)
       {
           if (!directory.Parent.Exists)
               CreateDirectory(directory.Parent);
           directory.Create();
       }
    }
}
