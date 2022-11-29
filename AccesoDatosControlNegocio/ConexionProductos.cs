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
                MessageBox.Show($"Producto guardado exitosamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el producto. {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Actualizar(string nombre, string descripcion, double precio, int categoria, int medida, int id)
        {
            try
            {
                string query = $"UPDATE producto SET nombre='{nombre}', descripcion='{descripcion}', precio={precio}, id_medida={medida}, id_categoria={categoria} WHERE id={id}";
                conexionBD.Ejecutar(query);
                MessageBox.Show($"Actualizado exitoso.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el producto. {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Eliminar(int id)
        {
            try
            {
                if (DialogResult.Yes == MessageBox.Show("¿Desea eliminar el producto seleccionado?","Aviso",MessageBoxButtons.YesNo,MessageBoxIcon.Warning))
                {
                    string query = $"DELETE FROM producto WHERE id={id}";
                    conexionBD.Ejecutar(query);
                    MessageBox.Show($"Eliminado exitoso.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }    
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el producto. {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<Productos> Consultar(string buscar = null)
        {
            List<Productos> listaProductos = new List<Productos>();
            try
            {
                DataTable dt = new DataTable();
                string query = $"SELECT id, nombre, descripcion, precio, medida, categoria FROM v_producto WHERE nombre LIKE '%{buscar}%'";
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
