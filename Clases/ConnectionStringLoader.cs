using System;
using System.Configuration;
using System.IO;
using System.Xml;

namespace Proyecto_Grupo2.Clases
{
    internal static class ConnectionStringLoader
    {
        public static string Get(string name)
        {
            var fromEnv = Environment.GetEnvironmentVariable("CONNSTR_" + name);
            if (!string.IsNullOrEmpty(fromEnv)) return fromEnv;

            var localPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App.Local.config");
            if (File.Exists(localPath))
            {
                var doc = new XmlDocument();
                doc.Load(localPath);
                var node = doc.SelectSingleNode("//connectionStrings/add[@name='" + name + "']");
                var value = node == null || node.Attributes["connectionString"] == null
                    ? null : node.Attributes["connectionString"].Value;
                if (!string.IsNullOrEmpty(value)) return value;
            }

            var fromConfig = ConfigurationManager.ConnectionStrings[name] == null
                ? null : ConfigurationManager.ConnectionStrings[name].ConnectionString;
            if (string.IsNullOrEmpty(fromConfig))
                throw new InvalidOperationException("Connection string '" + name +
                    "' not found. Create App.Local.config or set CONNSTR_" + name + ".");
            return fromConfig;
        }
    }
}
