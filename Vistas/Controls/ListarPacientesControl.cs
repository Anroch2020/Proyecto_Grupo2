using Proyecto_Grupo2.Clases;
using System;
using System.Windows.Forms;

namespace Proyecto_Grupo2.Vistas.Controls
{
    public partial class ListarPacientesControl : UserControl
    {
        public ListarPacientesControl()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void ListarPacientesControl_Load(object sender, EventArgs e)
        {
            try
            {
                listarPacientesDataGridView.AutoGenerateColumns = true;
                listarPacientesDataGridView.DataSource = PacienteService.ObtenerTodos();
            }
            catch (PacienteQueryException exception)
            {
                MessageBox.Show(exception.Message, "Error al cargar pacientes", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
