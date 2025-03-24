using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PruebaAplicativo.Models.DB
{
    public partial class Empleados
    {
        public decimal IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public decimal? Salario { get; set; }
        public string Departamento { get; set; }
        public DateTime? FechaIngreso { get; set; }
    }
}
