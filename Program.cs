using Proyecto_Grupo2.Clases;
using System;
using System.Windows.Forms;
using Proyecto_Grupo2.Vistas;
using System.Configuration;
using System.IO;
using System.Xml;

namespace Proyecto_Grupo2
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppTheme.ensureInitialized();
            Application.Run(new LoginForm());
        }
    }
    internal static class ConnectionStringLoader
    {
        public static string Get(string name)
        {
            // 1. Try environment variable first (useful for CI/deployment)
            var fromEnv = Environment.GetEnvironmentVariable($"CONNSTR_{name}");
            if (!string.IsNullOrEmpty(fromEnv))
                return fromEnv;

            // 2. Try local, gitignored override file
            var localPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App.Local.config");
            if (File.Exists(localPath))
            {
                var doc = new XmlDocument();
                doc.Load(localPath);
                var node = doc.SelectSingleNode($"//connectionStrings/add[@name='{name}']");
                var value = node?.Attributes?["connectionString"]?.Value;
                if (!string.IsNullOrEmpty(value))
                    return value;
            }

            // 3. Fall back to App.config (will be empty in the public repo)
            var fromConfig = ConfigurationManager.ConnectionStrings[name]?.ConnectionString;
            if (string.IsNullOrEmpty(fromConfig))
                throw new InvalidOperationException(
                    $"Connection string '{name}' not found. Create App.Local.config or set CONNSTR_{name}.");

            return fromConfig;
        }
    }
}
