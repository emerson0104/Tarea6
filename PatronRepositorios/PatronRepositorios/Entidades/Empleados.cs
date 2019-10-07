using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronRepositorios.Entidades
{
   public class Empleados
    {
        [Key]
        public int EmpleadoID { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombres { get; set; }
        public string Direccion { get; set; }
        public string Telefonos { get; set; }
        public string Celular { get; set; }
        public string Cedula { get; set; }
        public decimal Sueldo { get; set; }
        public decimal Incentivo { get; set; }

        public Empleados()
        {
            EmpleadoID = 0;
            Fecha = DateTime.Now;
            Nombres = string.Empty;
            Direccion = string.Empty;
            Telefonos = string.Empty;
            Celular = string.Empty;
            Cedula = string.Empty;
            Sueldo = 0;
            Incentivo = 0;
        }
    }
}
