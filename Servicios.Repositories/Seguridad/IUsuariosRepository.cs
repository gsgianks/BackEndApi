using Servicios.Models;
using Servicios.Models.Seguridad;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicios.Repositories
{
    public interface IUsuariosRepository: IRepository<Usuarios>
    {
        IEnumerable<ListaUsuarios> UsuariosListaPaginada(int pag, int filas);
        Usuarios ValidarUsuario(string correo, string contrasena);
    }
}
