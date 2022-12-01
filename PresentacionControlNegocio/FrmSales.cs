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
        ManejadorVentas manejadorVentas;
        ManejadorDetallesVentas manejadorDetallesVentas;

        public FrmSales()
        {
            manejadorLista = new ManejadorListaVenta();
            manejadorVentas = new ManejadorVentas();
            manejadorDetallesVentas = new ManejadorDetallesVentas();
            InitializeComponent();
        }

        void Actualizar()
        {
            manejadorLista.ConsultarProductos(dgvProductos);
        }

        void Limpiar()
        {
            listaVenta.Clear();
            dgvVenta.DataSource = null;
            dgvVenta.Rows.Clear();
            dgvVenta.Columns.Clear();
            txtID.Clear();
            txtID.Focus();
        }

        private void FrmSales_Load(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtID.Text.Trim()))
            {
                manejadorLista.BuscarProducto(Convert.ToInt32(txtID.Text), Convert.ToInt32(numCantidad.Value),
                listaVenta, dgvVenta, txtTotal);
                txtID.Clear();
                txtID.Focus();  
                numCantidad.Value = 1;
            }
        }

        private void FrmSales_FormClosing(object sender, FormClosingEventArgs e)
        {
            Limpiar();
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            if (listaVenta.Count > 0)
            {
                manejadorVentas.Guardar(Convert.ToDouble(txtTotal.Text), DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));

                foreach (var item in listaVenta)
                {
                    manejadorDetallesVentas.Guardar(item.Id, item.Cantidad, item.Subtotal);
                }

                Limpiar();
            }
        }

        private void dgvVenta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                manejadorLista.QuitarProducto(e.RowIndex, listaVenta, dgvVenta, txtTotal);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            manejadorLista.ConsultarProductos(dgvProductos, txtBuscar.Text);
        }

        private void numCantidad_Enter(object sender, EventArgs e)
        {
            
        }
    }
}
