using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace gestion_tech_culture
{
    internal class Venta
    {
        //Atributos
        public int Codigo { get; set; }
        public DateTime Fecha { get; set; }
        public int CodigoEmpleado { get; set; }
        public int CodigoLaptop { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioLaptop { get; set; }
        public decimal Total { get; set; }

        //Metodos

        //1. Calcular el total de la venta
        public decimal CalcularTotal()
        {
            this.Total = this.Cantidad * this.PrecioLaptop;
            return this.Total;
        }

        //2. Registrar la venta en la base de datos
        public bool RegistrarVenta()
        {
            string queryVenta = @"INSERT INTO HistorialVentas (Fecha, CodigoEmpleado, CodigoLaptop, Cantidad, PrecioLaptop, Total) 
                             VALUES (@fecha, @codEmp, @codLap, @cant, @precio, @total)";

            string queryStock = @"UPDATE Laptops SET Stock = Stock - @cant WHERE Codigo = @codLap";

            using (SqlConnection conx = ConexionDB.ObtenerConexion())
            {
                //Se usa una transacción para asegurarnos de que se ejecuten *ambas cosas o ninguna*
                SqlTransaction transaccion = conx.BeginTransaction();

                try
                {
                    //Guardar la venta en el historial
                    SqlCommand cmdVenta = new SqlCommand(queryVenta, conx, transaccion);
                    cmdVenta.Parameters.AddWithValue("@fecha", DateTime.Now);
                    cmdVenta.Parameters.AddWithValue("@codEmp", this.CodigoEmpleado);
                    cmdVenta.Parameters.AddWithValue("@codLap", this.CodigoLaptop);
                    cmdVenta.Parameters.AddWithValue("@cant", this.Cantidad);
                    cmdVenta.Parameters.AddWithValue("@precio", this.PrecioLaptop);
                    cmdVenta.Parameters.AddWithValue("@total", this.Total);
                    cmdVenta.ExecuteNonQuery();

                    //Descontar el stock de la laptop
                    SqlCommand cmdStock = new SqlCommand(queryStock, conx, transaccion);
                    cmdStock.Parameters.AddWithValue("@cant", this.Cantidad);
                    cmdStock.Parameters.AddWithValue("@codLap", this.CodigoLaptop);
                    cmdStock.ExecuteNonQuery();

                    //Confirmamos los cambios en SQL Server
                    transaccion.Commit();
                    return true;
                }
                catch
                {
                    //Si algo falla, deshace la operación y no se guarda la venta
                    transaccion.Rollback();
                    return false;
                }
            }
        }
    }
}
