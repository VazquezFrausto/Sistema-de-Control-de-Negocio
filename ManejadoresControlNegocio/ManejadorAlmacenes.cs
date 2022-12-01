using AccesoDatosControlNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManejadoresControlNegocio
{
    public class ManejadorAlmacenes
    {
        ConexionAlmacenes conexionAlmacenes;
        public ManejadorAlmacenes()
        {
            conexionAlmacenes = new ConexionAlmacenes();
        }

        public void Ingresar(int idProducto, int cantidad)
        {
            conexionAlmacenes.Ingresar(idProducto, cantidad);
        }

        public void Guardar(int idProducto, int cantidad)
        {
            conexionAlmacenes.Guardar(idProducto, cantidad);
        }

        public void Actualizar(int idProducto, int cantidad)
        {
            conexionAlmacenes.Actualizar(idProducto, cantidad);
        }

        public void Consultar(DataGridView dgvAlmacen, string buscar = null)
        {
            dgvAlmacen.Columns.Clear();
            dgvAlmacen.DataSource = conexionAlmacenes.Consultar(buscar);
            dgvAlmacen.Columns[0].HeaderText = "ID";
            dgvAlmacen.Columns[0].Visible = false;
            dgvAlmacen.Columns[1].HeaderText = "ID";
            dgvAlmacen.Columns[2].HeaderText = "Producto";
            dgvAlmacen.Columns[3].HeaderText = "Cantidad";
        }

        public void CargarProductos(ComboBox cmbProductos)
        {
            ConexionProductos conexionProductos = new ConexionProductos();
            cmbProductos.DataSource = conexionProductos.CargarProductos();
            cmbProductos.DisplayMember = "nombre";
            cmbProductos.ValueMember = "id";
        }
    }
}
