using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TALLERM.Support
{
    public static class ConfigsFromManager
    {
        public static string getConfig(string configname)
        {
            return ConfigurationManager.AppSettings[configname];
        }

        public static int getIntConfig(string configname)
        {
            return int.Parse(ConfigurationManager.AppSettings[configname]);
        }

        public static short getShortConfig(string configname)
        {
            return short.Parse(ConfigurationManager.AppSettings[configname]);
        }

        public static Byte getByteConfig(string configname)
        {
            return Byte.Parse(ConfigurationManager.AppSettings[configname]);
        }
    }
}
