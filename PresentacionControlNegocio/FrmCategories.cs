using System;
using System.Windows.Forms;
using ManejadoresControlNegocio;

namespace PresentacionControlNegocio
{
    public partial class FrmCategories : Form
    {
        ManejadorCategorias manejadorCategorias;

        public FrmCategories()
        {
            manejadorCategorias = new ManejadorCategorias();
            InitializeComponent();
        }

        void Actualizar()
        {
            manejadorCategorias.Consultar(dgvCategorias);
        }
        void Limpiar()
        {
            txtNombre.Clear();
            txtNombre.Focus();
        }
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmCategories_Load(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombre.Text.Trim()))
            {
                manejadorCategorias.Guardar(txtNombre.Text.Trim());
            }
            Actualizar();
            Limpiar();
        }

        private void dgvCategorias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == 2)
            //{
            //    MessageBox.Show($"Fila: {e.RowIndex}");
            //}
        }

        private void FrmCategories_FormClosing(object sender, FormClosingEventArgs e)
        {
            Limpiar();
        }
    }
}
