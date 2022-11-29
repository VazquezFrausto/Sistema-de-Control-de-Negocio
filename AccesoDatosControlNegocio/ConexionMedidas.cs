using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using EntidadesControlNegocio;

namespace AccesoDatosControlNegocio
{
    public class ConexionMedidas
    {
        ConexionBD conexionBD;
        public ConexionMedidas()
        {
            conexionBD = new ConexionBD();
        }

        public void Guardar(string nombre, string abreviatura)
        {
            try
            {
                string query = $"INSERT INTO medida VALUES(default, '{nombre}', '{abreviatura}')";
                conexionBD.Ejecutar(query);
                MessageBox.Show($"Guardado exitoso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la medida. {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<Medidas> Consultar()
        {
            List<Medidas> listaMedidas = new List<Medidas>();
            try
            {
                DataTable dt = new DataTable();
                string query = $"SELECT id,nombre,abreviatura FROM medida";
                dt = conexionBD.Consultar(query).Tables[0];
                foreach (DataRow fila in dt.Rows)
                {
                    Medidas medida = new Medidas(
                        Convert.ToInt32(fila["id"].ToString()),
                        fila["nombre"].ToString(),
                        fila["abreviatura"].ToString());
                    listaMedidas.Add(medida);
                }
                return listaMedidas;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al consultar las medidas. {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable CargarMedidas()
        {
            try
            {
                DataTable dt = new DataTable();
                string query = $"SELECT id,nombre FROM medida";
                dt = conexionBD.Consultar(query).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al consultar las medidas. {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
