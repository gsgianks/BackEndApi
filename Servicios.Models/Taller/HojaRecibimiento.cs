using System;
using System.Collections.Generic;
using System.Text;

namespace Servicios.Models.Taller
{
    public class HojaRecibimiento
    {
        public Int32 Id { get; set; }
        public Int32 IdUsuario { get; set; }
        public Int32 IdMotocicleta { get; set; }
        public string TrabajoRealizar { get; set; }
        public string Observaciones { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public DateTime? FechaSalida { get; set; }
    }
}
