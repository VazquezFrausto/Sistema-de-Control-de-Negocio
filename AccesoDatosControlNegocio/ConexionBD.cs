using System;
using System.Data;
using System.Windows.Forms;
using MySqlConnector;

namespace AccesoDatosControlNegocio
{
    public class ConexionBD
    {
        MySqlConnection connection;

        public ConexionBD()
        {
            try
            {
                MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
                builder.Server = "localhost";
                builder.Port = 3306;
                builder.Database = "controlnegocio";
                builder.UserID = "root";
                builder.Password = "";
                connection = new MySqlConnection(builder.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectarse a la base de datos. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Ejecutar(string query)
        {
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
            }
        }

        public DataSet Consultar(string query)
        {
            try
            {
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(query, connection);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
