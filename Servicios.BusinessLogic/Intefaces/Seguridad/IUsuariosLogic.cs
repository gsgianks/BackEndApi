using Servicios.Models;
using Servicios.Models.Seguridad;
using System.Collections.Generic;

namespace Servicios.BusinessLogic.Intefaces
{
    public interface IUsuariosLogic
    {
        IEnumerable<ListaUsuarios> UsuariosListaPaginada(int pag, int filas);
        Usuarios ValidarUsuario(string cedula, string contrasena);
        Usuarios GetById(int id);
        Usuarios Insert(Usuarios usuario);
        bool Update(Usuarios usuario);
        bool Delete(Usuarios usuario);
    }
}
