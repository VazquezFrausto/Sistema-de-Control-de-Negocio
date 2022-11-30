using System;
using System.Data;
using System.Windows.Forms;

namespace AccesoDatosControlNegocio
{
    public class ConexionListaVenta
    {
        ConexionBD conexionBD;
        public ConexionListaVenta()
        {
            conexionBD= new ConexionBD();
        }

        public DataTable BuscarProducto(int id)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = $"SELECT id, nombre, precio FROM v_producto WHERE id={id}";
                dt = conexionBD.Consultar(query).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar el producto. {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
