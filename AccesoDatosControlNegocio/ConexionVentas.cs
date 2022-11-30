using EntidadesControlNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccesoDatosControlNegocio
{
    public class ConexionVentas
    {
        ConexionBD conexionBD;
        public ConexionVentas()
        {
            conexionBD = new ConexionBD();
        }

        public void Guardar(double total, string fecha)
        {
            try
            {
                string query = $"INSERT INTO venta VALUES(default, {total}, '{fecha}')";
                conexionBD.Ejecutar(query);
                MessageBox.Show($"Venta guardada exitosamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la venta. {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<Ventas> Consultar()
        {
            List<Ventas> listaVentas = new List<Ventas>();
            try
            {
                DataTable dt = new DataTable();
                string query = $"SELECT id, total, fecha FROM venta";
                dt = conexionBD.Consultar(query).Tables[0];
                foreach (DataRow fila in dt.Rows)
                {
                    Ventas venta = new Ventas(
                        Convert.ToInt32(fila["id"].ToString()),
                        Convert.ToDouble(fila["total"].ToString()),
                        fila["fecha"].ToString());
                    listaVentas.Add(venta);
                }
                return listaVentas;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al consultar las ventas. {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
