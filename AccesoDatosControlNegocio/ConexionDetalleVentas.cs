using EntidadesControlNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccesoDatosControlNegocio
{
    public class ConexionDetalleVentas
    {
        ConexionBD conexionBD;
        public ConexionDetalleVentas()
        {
            conexionBD= new ConexionBD();
        }

        public void Guardar(int idProducto, int cantidad, double precio)
        {
            try
            {
                int idVenta = VentaActual();
                string query = $"INSERT INTO detalle_venta VALUES(default, {idVenta}, {idProducto}, {cantidad}, {precio})";
                conexionBD.Ejecutar(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los detalles de la venta. {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<DetallesVentas> Consultar(int idVenta)
        {
            List<DetallesVentas> listaDetalles = new List<DetallesVentas>();
            try
            {
                DataTable dt = new DataTable();
                string query = $"SELECT id, venta, nombre, cantidad, precio FROM v_detalleventa WHERE venta={idVenta}";
                dt = conexionBD.Consultar(query).Tables[0];
                foreach (DataRow fila in dt.Rows)
                {
                    DetallesVentas detallesVentas = new DetallesVentas(
                        Convert.ToInt32(fila["id"].ToString()),
                        Convert.ToInt32(fila["venta"].ToString()),
                        fila["nombre"].ToString(),
                        Convert.ToInt32(fila["cantidad"].ToString()),
                        Convert.ToDouble(fila["precio"].ToString()));
                    listaDetalles.Add(detallesVentas);
                }
                return listaDetalles;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al consultar los detalles de la venta. {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public int VentaActual()
        {
            try
            {
                DataTable dt = new DataTable();
                string query = $"SELECT MAX(id) AS actual FROM venta";
                dt = conexionBD.Consultar(query).Tables[0];
                int actual = Convert.ToInt32(dt.Rows[0]["actual"].ToString());
                return actual;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al consultar la venta actual. {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
    }
}
