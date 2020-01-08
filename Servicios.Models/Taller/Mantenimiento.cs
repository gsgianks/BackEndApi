using System;
using System.Collections.Generic;
using System.Text;

namespace Servicios.Models.Taller
{
    public class Mantenimiento
    {
        public Int32 Id { get; set; }
        public Int32 IdHojaRecibimiento { get; set; }
        public Int32 IdMecanico { get; set; }
        public string Repuesto { get; set; }
        public string Descripcion { get; set; }
        public decimal? Monto { get; set; }
        public DateTime Fecha { get; set; }
    }
}
