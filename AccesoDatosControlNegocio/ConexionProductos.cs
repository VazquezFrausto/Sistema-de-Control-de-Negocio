using EntidadesControlNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccesoDatosControlNegocio
{
    public class ConexionProductos
    {
        ConexionBD conexionBD;
        public ConexionProductos()
        {
            conexionBD = new ConexionBD();
        }

        public void Guardar(string nombre, string descripcion, double precio, int categoria, int medida)
        {
            try
            {
                string query = $"INSERT INTO producto VALUES(default, '{nombre}', '{descripcion}', {precio}, {medida}, {categoria})";
                conexionBD.Ejecutar(query);
                MessageBox.Show($"Guardado exitoso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el producto. {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<Productos> Consultar()
        {
            List<Productos> listaProductos = new List<Productos>();
            try
            {
                DataTable dt = new DataTable();
                string query = $"SELECT id, nombre, descripcion, precio, medida, categoria FROM v_producto";
                dt = conexionBD.Consultar(query).Tables[0];
                foreach (DataRow fila in dt.Rows)
                {
                    Productos producto = new Productos(
                        Convert.ToInt32(fila["id"].ToString()),
                        fila["nombre"].ToString(),
                        fila["descripcion"].ToString(),
                        Convert.ToDouble(fila["precio"].ToString()),
                        fila["medida"].ToString(),
                        fila["categoria"].ToString());
                    listaProductos.Add(producto);
                }
                return listaProductos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al consultar los productos. {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
