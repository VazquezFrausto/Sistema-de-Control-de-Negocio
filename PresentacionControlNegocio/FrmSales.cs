using EntidadesControlNegocio;
using ManejadoresControlNegocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentacionControlNegocio
{
    public partial class FrmSales : Form
    {
        static List<ListaVenta> listaVenta = new List<ListaVenta>();
        ManejadorListaVenta manejadorLista;

        public FrmSales()
        {
            manejadorLista = new ManejadorListaVenta();
            InitializeComponent();
        }

        void Actualizar()
        {
            manejadorLista.ConsultarProductos(dgvProductos);
        }

        private void FrmSales_Load(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtID.Text))
            {
                manejadorLista.BuscarProducto(Convert.ToInt32(txtID.Text), Convert.ToInt32(numCantidad.Value),
                listaVenta, dgvVenta, txtTotal);
            }
        }

        private void FrmSales_FormClosing(object sender, FormClosingEventArgs e)
        {
            listaVenta.Clear();
            dgvVenta.DataSource = null;
            dgvVenta.Rows.Clear();
            dgvVenta.Columns.Clear();
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {

        }
    }
}
