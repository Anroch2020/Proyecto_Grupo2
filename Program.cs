using Proyecto_Grupo2.Clases;
using System;
using System.Windows.Forms;
using Proyecto_Grupo2.Vistas;

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
            Application.Run(new MedicosForm());
        }
    }
}
