using EntidadesControlNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccesoDatosControlNegocio
{
    public class ConexionAlmacenes
    {
        ConexionBD conexionBD;
        public ConexionAlmacenes()
        {
            conexionBD = new ConexionBD();
        }

        public void Guardar(int idProducto, int cantidad)
        {
            try
            {
                string query = $"INSERT INTO almacen VALUES(default, {idProducto}, {cantidad})";
                conexionBD.Ejecutar(query);
                MessageBox.Show($"Producto ingresado exitosamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al ingresar el producto. {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Actualizar(int idProducto, int cantidad)
        {
            try
            {
                string query = $"UPDATE almacen SET cantidad='{cantidad}' WHERE id={idProducto}";
                conexionBD.Ejecutar(query);
                MessageBox.Show($"Actualizado exitoso.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar el producto. {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<Almacenes> Consultar(string buscar = null)
        {
            List<Almacenes> listaAlmacen = new List<Almacenes>();
            try
            {
                DataTable dt = new DataTable();
                string query = $"SELECT id, id_producto, nombre, cantidad FROM v_almacen WHERE nombre LIKE '%{buscar}%'";
                dt = conexionBD.Consultar(query).Tables[0];
                foreach (DataRow fila in dt.Rows)
                {
                    Almacenes almacen = new Almacenes(
                        Convert.ToInt32(fila["id"].ToString()),
                        Convert.ToInt32(fila["id_producto"].ToString()),
                        fila["nombre"].ToString(),
                        Convert.ToInt32(fila["cantidad"].ToString()));
                    listaAlmacen.Add(almacen);
                }
                return listaAlmacen;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al consultar el stock. {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public void Ingresar(int idProducto, int cantidad)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = $"SELECT id, id_producto, nombre, cantidad FROM v_almacen WHERE id_producto={idProducto}";
                dt = conexionBD.Consultar(query).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    Actualizar(idProducto, cantidad);
                }
                else
                {
                    Guardar(idProducto, cantidad);
                }
            }
            catch (Exception ex )
            {
                MessageBox.Show($"Error al ingresar el producto. {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
