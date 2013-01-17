using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace CommonLibrary
{
   public class AppSettingsManager
    {
     
       public AppSettingsManager() { }
      
       public static void  Update(Dictionary<string, string> newValues)
       {
           var map = new ExeConfigurationFileMap();

           //Get app.config path
           map.ExeConfigFilename = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;

           //Get Config and AppSettings
           var config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
           var appSettings = config.AppSettings;


           foreach (string key in newValues.Keys)
           {
               KeyValueConfigurationElement setting = appSettings.Settings[key];
               if (setting == null)
               {
                   appSettings.Settings.Add(key, newValues[key]);
               }
               else
               {
                   appSettings.Settings[key].Value = newValues[key];
               }
           }
           //save app.config
           config.Save();
       }
    }
}
