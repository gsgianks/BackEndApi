using Servicios.Models;
using Servicios.Models.Base;
using Servicios.Models.Seguridad;
using System.Collections.Generic;

namespace Servicios.BusinessLogic.Intefaces
{
    public interface IUsuariosLogic
    {
        IEnumerable<ListaUsuarios> UsuariosListaPaginada(int pag, int filas);
        Usuarios ValidarUsuario(string cedula, string contrasena);
        ResponseModel<Usuarios> GetById(int id);
        ResponseModel<Usuarios> Insert(Usuarios usuario);
        ResultBaseModel Update(Usuarios usuario);
        ResultBaseModel Delete(Usuarios usuario);
        ResponseModel<Usuarios> GetList();
    }
}
