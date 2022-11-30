using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using EntidadesControlNegocio;

namespace AccesoDatosControlNegocio
{
    public class ConexionCategorias
    {
        ConexionBD conexionBD;
        public ConexionCategorias()
        {
            conexionBD = new ConexionBD();
        }

        public void Guardar(string nombre)
        {
            try
            {
                string query = $"INSERT INTO categoria VALUES(default, '{nombre}')";
                conexionBD.Ejecutar(query);
                MessageBox.Show($"Guardado exitoso.","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la categoría. {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<Categorias> Consultar()
        {
            List<Categorias> listaCategorias = new List<Categorias>();
            try
            {
                DataTable dt = new DataTable();
                string query = $"SELECT id,nombre FROM categoria";
                dt = conexionBD.Consultar(query).Tables[0];
                foreach (DataRow fila in dt.Rows)
                {
                    Categorias categoria = new Categorias(
                        Convert.ToInt32(fila["id"].ToString()),
                        fila["nombre"].ToString());
                    listaCategorias.Add(categoria);
                }
                return listaCategorias;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al consultar las categorías. {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable CargarCategorias()
        {
            try
            {
                DataTable dt = new DataTable();
                string query = $"SELECT id,nombre FROM categoria";
                dt = conexionBD.Consultar(query).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al consultar las categorías. {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
