using Proyecto_Grupo2.Clases;
using System;
using System.Windows.Forms;

namespace Proyecto_Grupo2.Vistas.Controls
{
    public partial class BuscarPacienteControl : UserControl
    {
        private readonly Timer searchTimer;

        public BuscarPacienteControl()
        {
            InitializeComponent();

            searchTimer = new Timer { Interval = 400 };
            searchTimer.Tick += searchTimer_Tick;
            Disposed += delegate { searchTimer.Dispose(); };
        }

        private void busquedaNombreTextBox_TextChanged(object sender, EventArgs e)
        {
            busquedaDPITextBox.ReadOnly = !string.IsNullOrWhiteSpace(busquedaNombreTextBox.Text);
            ProgramarBusqueda();
        }

        private void busquedaDPITextBox_TextChanged(object sender, EventArgs e)
        {
            busquedaNombreTextBox.ReadOnly = !string.IsNullOrWhiteSpace(busquedaDPITextBox.Text);
            ProgramarBusqueda();
        }

        private void ProgramarBusqueda()
        {
            searchTimer.Stop();
            searchTimer.Start();
        }

        private void searchTimer_Tick(object sender, EventArgs e)
        {
            searchTimer.Stop();
            BuscarPacientes();
        }

        private void BuscarPacientes()
        {
            try
            {
                resultadoBusquedaDataGridView.AutoGenerateColumns = true;
                resultadoBusquedaDataGridView.DataSource = PacienteService.Buscar(
                    busquedaNombreTextBox.Text,
                    busquedaDPITextBox.Text);
            }
            catch (PacienteQueryException exception)
            {
                MessageBox.Show(exception.Message, "Error en la búsqueda", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void BuscarPacienteControl_Load(object sender, EventArgs e)
        {
            busquedaNombreTextBox.ReadOnly = false;
            busquedaDPITextBox.ReadOnly = false;
            resultadoBusquedaDataGridView.DataSource = null;
        }

    }
}
