using AccesoDatosControlNegocio;
using EntidadesControlNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ManejadoresControlNegocio
{
    public class ManejadorListaVenta
    {
        ConexionListaVenta conexionLista;
        ConexionProductos conexionProductos;

        public ManejadorListaVenta()
        {
            conexionLista= new ConexionListaVenta();
            conexionProductos= new ConexionProductos();
        }

        public void ConsultarProductos(DataGridView dgvProductos)
        {
            dgvProductos.Columns.Clear();
            dgvProductos.DataSource = conexionProductos.Consultar();
            dgvProductos.Columns[0].HeaderText = "ID";
            dgvProductos.Columns[1].HeaderText = "Nombre";
            dgvProductos.Columns[2].HeaderText = "Descripción";
            dgvProductos.Columns[3].HeaderText = "Precio";
            dgvProductos.Columns[4].HeaderText = "Medida";
            dgvProductos.Columns[5].HeaderText = "Categoria";
            dgvProductos.Columns[2].Visible = false;
            dgvProductos.Columns[4].Visible = false;
            dgvProductos.Columns[5].Visible = false;
        }

        public void BuscarProducto(int id, int cantidad, List<ListaVenta> listaVenta, DataGridView dgvVenta, TextBox txtTotal)
        {
            double total = 0;
            DataTable dt = new DataTable();
            dt = conexionLista.BuscarProducto(id);
            if (dt.Rows.Count > 0)
            {
                ListaVenta producto = new ListaVenta(Convert.ToInt32(dt.Rows[0]["id"].ToString()),
                    dt.Rows[0]["nombre"].ToString(), Convert.ToDouble(dt.Rows[0]["precio"].ToString()),
                    cantidad, (Convert.ToDouble(dt.Rows[0]["precio"].ToString()) * cantidad));
                listaVenta.Add(producto);

                dgvVenta.DataSource = null;
                dgvVenta.DataSource = listaVenta;

                int i = 0;
                do
                {
                    total += double.Parse(dgvVenta.Rows[i].Cells["Subtotal"].Value.ToString());
                    i++;
                } while(i < dgvVenta.Rows.Count && dgvVenta.Rows.Count > 0);

                txtTotal.Text = total.ToString();
            }
            else
            {
                MessageBox.Show($"El producto con el id: {id} no existe", "Error");
            }
            
        }
    }
}
