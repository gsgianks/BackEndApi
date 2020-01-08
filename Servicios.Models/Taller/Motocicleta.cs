using Servicios.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicios.Models
{
    public class Motocicleta
    {
        public Int32 Id { get; set; }
        public String NumeroPlaca { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public String Ano { get; set; }
        public string SerieMarco { get; set; }
        public string SerieMotor { get; set; }
        public string Anotaciones { get; set; }
        public string ImagenPerfil { get; set; }
        public Int32 IdUsuario { get; set; }
        public Int16 IdPlan { get; set; }

    }
}
