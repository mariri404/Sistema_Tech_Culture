using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestion_tech_culture
{
    public class Empleado
    {
        //Atributos
        public int Codigo { get; set; }
        public string Contraseña { get; set; }
        public string NombreYApellido { get; set; }
        public string Cedula { get; set; }
        public string Correo { get; set; }
        public string Puesto { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaIngreso { get; set; }
        public decimal SueldoBase { get; set; }

        //Métodos 
        //1. Horas extras
        public decimal CalcularHorasExtras(int horasTrabajadas)
        {
            decimal valorHoraExtra = SueldoBase / 160; //-> 160 horas laborales al mes
            decimal totalHoraExtra = valorHoraExtra * horasTrabajadas;
            return totalHoraExtra;
        }

        //2. Seguro Médico (ARS)
        public decimal CalcularARS()
        {
            return SueldoBase * 0.0304m; //-> 3.04% 
        }

        //3. Fondo de Pensiones (AFP)
        public decimal CalcularAFP()
        {
            return SueldoBase * 0.0287m;//-> 2.87%
        }

        //4. Impuesto Sobre la Renta (ISR)
        public decimal CalcularISR()
        {
            decimal sueldoCotizable = SueldoBase - (CalcularARS() + CalcularAFP());

            //Escala impositiva de la DGII:
            if (sueldoCotizable <= 34685.00m)
            {
                return 0.00m; // Exento
            }
            else if (sueldoCotizable <= 52027.00m)
            {
                return (sueldoCotizable - 34685.00m) * 0.15m; // 15% del excedente
            }
            else if (sueldoCotizable <= 72260.00m)
            {
                return 2601.33m + ((sueldoCotizable - 52027.00m) * 0.20m); // 20%
            }
            else
            {
                return 6648.00m + ((sueldoCotizable - 72260.00m) * 0.25m); // 25%
            }
        }

        //5. Bonificación por Antigüedad (5% del sueldo base, si aplica)
        public decimal CalcularBonificacion()
        {
            bool aplicaBonificacion;
            if (FechaIngreso.Year < DateTime.Now.Year - 5)
            {
                aplicaBonificacion = true;
            }
            else
            {
                aplicaBonificacion = false;
            }
            return aplicaBonificacion ? (SueldoBase * 0.05m) : 0.00m;
        }

        //6. Sueldo total
        public decimal CalcularSueldoTotal(int horasTrabajadas)
        { 
            decimal ingresos = SueldoBase + CalcularHorasExtras(horasTrabajadas) + CalcularBonificacion();
            decimal deducciones = CalcularARS() + CalcularAFP() + CalcularISR();

            return ingresos - deducciones;
        }
    }
}
