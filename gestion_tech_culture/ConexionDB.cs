using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gestion_tech_culture
{
    public static class ConexionDB
    {
        //Atributos
        public static string cadenaConexion = @"Server = (localdb)\AplicacionProductos;Database = TechCulture; Integrated Security = true";
        
        //Métodos
        //1. Conectarse a la DB
        public static SqlConnection ObtenerConexion()
        {
            try
            {
                SqlConnection conx = new SqlConnection(cadenaConexion);
                conx.Open();
                return conx;
            }
            catch (Exception)
            {
                MessageBox.Show("Error al obtener conexión a la base de datos:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        //2. Actualizar el DGV

        public static void ActualizarDGV(string tabla, DataGridView dgv, bool cargarPorCodigo, int? codigo = null)
        {
            //Verificar que se haya seleccionado una tabla
            string query = "";
            if (tabla == "")
            {
                MessageBox.Show("Seleccione una tabla", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else 
            {
                //Actualizar según si se quieren mostrar todos los registros o uno en específico
                if (cargarPorCodigo)
                {
                    query = $"SELECT *FROM {tabla} WHERE Codigo = {codigo}";
                }
                else
                { query = $"SELECT *FROM {tabla}"; }
            }

            //Conexión a la DB y actualización del DataGridView
            using (ConexionDB.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand(query, ConexionDB.ObtenerConexion());
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                dgv.DataSource = dt;
                cmd.ExecuteNonQuery();
            }
        }

        //3. Buscar un registro en la DB
        public static int BuscarRegistro(string tabla, DataGridView dgv)
        {
            //Query
            string query = $"SELECT COUNT(1) FROM {tabla} WHERE Codigo = @codigo";

            using (ConexionDB.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand(query, ConexionDB.ObtenerConexion());

                //Hacer la búsqueda del registro
                string input = Interaction.InputBox("Ingrese el código del registro", "Buscando información");

                if (string.IsNullOrWhiteSpace(input))
                {
                    //Si el usuario cancela o no ingresa nada, retorna 0
                    return 0;
                }
                if (!int.TryParse(input, out int codigo))
                {
                    //Si el input no fue un número, muestra el mensaje y retorna 0
                    MessageBox.Show("Código inválido. Ingrese un número entero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }

                cmd.Parameters.AddWithValue("@codigo", codigo);
                int count = (int)cmd.ExecuteScalar();

                //Verificar si existe un registro con el código ingresado
                if (count > 0)
                {
                    MessageBox.Show("Registro encontrado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ConexionDB.ActualizarDGV(tabla, dgv, true, codigo);
                    return codigo;
                }
                else
                {
                    MessageBox.Show("El código ingresado no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }
            } 
        }
    }
}