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
    public partial class AgregarLaptop : Form
    {
        public AgregarLaptop()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Laptop nuevaLap = new Laptop();

            //Verificar si hay algún campo vacío
            if (string.IsNullOrEmpty(txtMarca.Text) ||
                string.IsNullOrEmpty(txtModelo.Text) ||
                string.IsNullOrEmpty(txtFechaLanzamiento.Text) ||
                string.IsNullOrEmpty(cboUso.SelectedItem.ToString()) ||
                string.IsNullOrEmpty(txtColor.Text) ||
                string.IsNullOrEmpty(txtPantalla.Text) ||
                string.IsNullOrEmpty(txtCPU.Text) ||
                string.IsNullOrEmpty(cboRAM.SelectedItem.ToString()) ||
                string.IsNullOrEmpty(txtGraficos.Text) ||
                string.IsNullOrEmpty(txtAlmacenamiento.Text) ||
                string.IsNullOrEmpty(txtOS.Text) ||
                string.IsNullOrEmpty(txtPrecio.Text) ||
                string.IsNullOrEmpty(txtStock.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                //Si no falta nada, se pasan los datos a un objeto tipo Laptop
                nuevaLap.Marca = txtMarca.Text;
                nuevaLap.Modelo = txtModelo.Text;
                nuevaLap.FechaLanzamiento = int.Parse(txtFechaLanzamiento.Text);
                nuevaLap.Uso = cboUso.Text;
                nuevaLap.Color = txtColor.Text;
                nuevaLap.SizePantalla = txtPantalla.Text;
                nuevaLap.CPU = txtCPU.Text;
                nuevaLap.RAM = cboRAM.SelectedItem.ToString();
                nuevaLap.Graficos = txtGraficos.Text;
                nuevaLap.Almacenamiento = txtAlmacenamiento.Text;
                nuevaLap.OSInstalado = txtOS.Text;
                nuevaLap.Precio = double.Parse(txtPrecio.Text);
                nuevaLap.Stock = int.Parse(txtStock.Text);
            }
            //Query
            string query = @"INSERT INTO Laptops 
                (Marca, Modelo, FechaLanzamiento, Uso, Color, SizePantalla, CPU, RAM, Graficos, Almacenamiento, OSInstalado, Precio, Stock) 
                VALUES 
                (@marca, @modelo, @fechaLanzamiento, @uso, @color, @sizePantalla, @cpu, @ram, @graficos, @almacenamiento, @osInstalado, @precio, @stock)";

            //Conexión
            using (ConexionDB.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand(query, ConexionDB.ObtenerConexion());

                //Se guardan los datos del objeto en la base de datos
                cmd.Parameters.AddWithValue("@marca", nuevaLap.Marca);
                cmd.Parameters.AddWithValue("@modelo", nuevaLap.Modelo);
                cmd.Parameters.AddWithValue("@fechaLanzamiento", nuevaLap.FechaLanzamiento);
                cmd.Parameters.AddWithValue("@uso", nuevaLap.Uso);
                cmd.Parameters.AddWithValue("@color", nuevaLap.Color);
                cmd.Parameters.AddWithValue("@sizePantalla", nuevaLap.SizePantalla);
                cmd.Parameters.AddWithValue("@cpu", nuevaLap.CPU);
                cmd.Parameters.AddWithValue("@ram", nuevaLap.RAM);
                cmd.Parameters.AddWithValue("@graficos", nuevaLap.Graficos);
                cmd.Parameters.AddWithValue("@almacenamiento", nuevaLap.Almacenamiento);
                cmd.Parameters.AddWithValue("@osInstalado", nuevaLap.OSInstalado);
                cmd.Parameters.AddWithValue("@precio", nuevaLap.Precio);
                cmd.Parameters.AddWithValue("@stock", nuevaLap.Stock);

                int filasAfectadas = cmd.ExecuteNonQuery();
                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Laptop agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al agregar la laptop.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtMarca.Clear();
            txtModelo.Clear();
            txtFechaLanzamiento.Clear();
            cboUso.SelectedIndex = -1;
            txtColor.Clear();
            txtPantalla.Clear();
            txtCPU.Clear();
            cboRAM.SelectedIndex = -1;
            txtGraficos.Clear();
            txtAlmacenamiento.Clear();
            txtOS.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
        }
        private void dtpFechaLanz_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}