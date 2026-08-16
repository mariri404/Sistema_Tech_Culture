using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gestion_tech_culture
{
    public partial class TechCultureLogin : Form
    {
        public TechCultureLogin()
        {
            InitializeComponent();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            //Conexion a la DB
            SqlConnection conx = ConexionDB.ObtenerConexion();
            string query = "SELECT Codigo, NombreYApellido, Puesto FROM Empleados WHERE Codigo = @Codigo AND Contraseña = @Contraseña AND Puesto = @Puesto";

            using (conx)
            {
                //Parámetros de inicio de sesión y query
                string codigo = txtCodigo.Text;
                string contraseña = txtContraseña.Text;
                string puesto = cboPuesto.SelectedItem.ToString();

                //Conexión a la base de datos y parámetros
                SqlCommand cmd = new SqlCommand(query, conx);
                cmd.Parameters.AddWithValue("@Codigo", codigo);
                cmd.Parameters.AddWithValue("@Contraseña", contraseña);
                cmd.Parameters.AddWithValue("@Puesto", puesto);

                using (SqlDataReader reader = cmd.ExecuteReader()) 
                {
                    if (reader.Read()) //Si las credenciales son correctas
                    {
                        MessageBox.Show("Inicio de sesión exitoso", "Sesión iniciada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Empleado empLog = new Empleado();
                        empLog.Codigo = Convert.ToInt32(reader["Codigo"]);
                        empLog.NombreYApellido = reader["NombreYApellido"].ToString();
                        
                        SesionUsuario.EmpleadoActual = empLog;

                        //EL usuario es dirigido a una ventana según su puesto
                        switch (puesto)
                        {
                            case "DBA":
                                Panel_DBA ventanaDBA = new Panel_DBA();
                                this.Hide();
                                ventanaDBA.Show();
                                break;

                            case "Analista de nómina":
                                Panel_AnalistaNomina ventanaNomina = new Panel_AnalistaNomina();
                                this.Hide();
                                ventanaNomina.Show();
                                break;

                            case "Cajero":
                                Panel_Cajero ventanaCajero = new Panel_Cajero();
                                this.Hide();
                                ventanaCajero.Show();
                                break;

                            case "Analista de ventas":
                                Panel_AnalistaVentas ventanaVentas = new Panel_AnalistaVentas();
                                this.Hide(); 
                                ventanaVentas.Show();
                                break;
                            default:
                                MessageBox.Show("Debe seleccionar un puesto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                        }
                    }
                    else //Si no se encuentra al empleado
                    {
                        MessageBox.Show("Credenciales o cargo incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ckbVerContraseña_CheckedChanged(object sender, EventArgs e)
        {
            //Ver contraseña
            if (ckbVerContraseña.Checked)
            {
                txtContraseña.UseSystemPasswordChar = false;
                txtContraseña.PasswordChar = '\0'; // Esto muestra la contraseña
            }
            else
            {
                txtContraseña.UseSystemPasswordChar = true;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

