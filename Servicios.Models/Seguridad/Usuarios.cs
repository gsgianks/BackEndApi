using System;
using System.Collections.Generic;
using System.Text;

namespace Servicios.Models
{
    public class Usuarios
    {
        public Int32 Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Identificacion { get; set; }
        public string CorreoElectronico { get; set; }
        public string Direccion { get; set; }
        public string TelefonoCelular { get; set; }
        public string Telefono { get; set; }
        public string Contrasena { get; set; }
        public Boolean CambiarContrasena { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string UsuarioIngreso { get; set; }
        public DateTime? FechaModifico { get; set; }
        public string UsuarioModifico { get; set; }
        public string Rol { get; set; }
        //public int TotalRecords { get; set; }
    }
}
