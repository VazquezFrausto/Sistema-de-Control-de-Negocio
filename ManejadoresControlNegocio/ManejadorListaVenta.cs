using AccesoDatosControlNegocio;
using EntidadesControlNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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

        public void ConsultarProductos(DataGridView dgvProductos, string buscar = null)
        {
            dgvProductos.Columns.Clear();
            dgvProductos.DataSource = conexionProductos.Consultar(buscar);
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

                Consultar(listaVenta, dgvVenta);

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

        public void QuitarProducto(int index, List<ListaVenta> listaVenta, DataGridView dgvVenta, TextBox txtTotal)
        {
            double total = Convert.ToDouble(txtTotal.Text); 
            total -= double.Parse(dgvVenta.Rows[index].Cells["Subtotal"].Value.ToString());
            txtTotal.Text = total.ToString();
            listaVenta.RemoveAt(index);
            Consultar(listaVenta, dgvVenta);
        }

        public void Consultar(List<ListaVenta> listaVenta, DataGridView dgvVenta)
        {
            dgvVenta.DataSource = null;
            dgvVenta.Columns.Clear();
            dgvVenta.DataSource = listaVenta;

            dgvVenta.Columns.Add(new DataGridViewButtonColumn()
            {
                Text = "Quitar",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat,
            });

            dgvVenta.Columns[5].DefaultCellStyle.BackColor = Color.FromArgb(240, 0, 36);
            dgvVenta.Columns[5].DefaultCellStyle.ForeColor = Color.White;
        }
    }
}
