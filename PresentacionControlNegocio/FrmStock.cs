using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManejadoresControlNegocio;

namespace PresentacionControlNegocio
{
    public partial class FrmStock : Form
    {
        ManejadorAlmacenes manejadorAlmacenes;
        public FrmStock()
        {
            manejadorAlmacenes = new ManejadorAlmacenes();
            InitializeComponent();
        }

        void Actualizar()
        {
            manejadorAlmacenes.Consultar(dgvAlmacen);
            if (cmbProductos.Items.Count == 0)
            {
                MessageBox.Show("No hay productos disponibles", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
            }
        }

        private void FrmStock_Load(object sender, EventArgs e)
        {
            manejadorAlmacenes.CargarProductos(cmbProductos);
            Actualizar();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            manejadorAlmacenes.Ingresar(Convert.ToInt32(cmbProductos.SelectedValue.ToString()),
                Convert.ToInt32(numCantidad.Value));
            Actualizar();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            manejadorAlmacenes.Consultar(dgvAlmacen, txtBuscar.Text);
        }
    }
}
