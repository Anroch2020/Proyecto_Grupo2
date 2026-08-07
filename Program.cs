using Proyecto_Grupo2.Clases;
using Proyecto_Grupo2.Vistas;
using System;
using System.Windows.Forms;

namespace Proyecto_Grupo2
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppTheme.ensureInitialized();
            Application.Run(new LoginForm());
        }
    }
}
