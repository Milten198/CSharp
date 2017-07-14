using SeleniumFrameworkCsharp.Utilities.Enums;
using System;
using System.Configuration;

namespace SeleniumFrameworkCsharp.Utilities.Configurations
{
    /// <summary>
    /// App.config support
    /// 
    /// Usage:
    /// string browser = TestConfiguration.BrowserParameter;
    /// </summary>
    class TestConfiguration
    {
        public static BrowserType BrowserParameter
        {
            get { return (BrowserType)Enum.Parse(typeof(BrowserType), ConfigurationManager.AppSettings["browserParameter"]); }
        }

        public static String ScreenshotDirectory
        {
            get { return ConfigurationManager.AppSettings["screenshotDirectory"]; }
        }

        public static String PageDefaultUrl
        {
            get { return ConfigurationManager.AppSettings["pageDefaultUrl"]; }
        }

   
        //---------------- DB setup -----------------        
        public static String[] DbDefaultUser
        {
            get { return ConfigurationManager.AppSettings["dbDefaultUser"].Split(','); }
        }

        public static String DbDefaultServer
        {
            get { return ConfigurationManager.AppSettings["dbDefaultServer"]; }
        }

        public static String DbDefaultDatabase
        {
            get { return ConfigurationManager.AppSettings["dbDefaultDatabase"]; }
        }
    }
}
