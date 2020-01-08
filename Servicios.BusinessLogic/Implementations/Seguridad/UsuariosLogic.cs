using System;
using System.Collections.Generic;
using Servicios.BusinessLogic.Intefaces;
using Servicios.Common;
using Servicios.Models;
using Servicios.Models.Seguridad;
using Servicios.UnitOfWork;

namespace Servicios.BusinessLogic.Implementations
{
    public class UsuariosLogic : IUsuariosLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        public UsuariosLogic(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public bool Delete(Usuarios usuario) => _unitOfWork.Usuarios.Delete(usuario);

        public Usuarios Insert(Usuarios usuario)
        {

            usuario.Contrasena = Util.RandomString(8, true);
            usuario.CambiarContrasena = true;
            Email.sendMail(usuario.CorreoElectronico, usuario.Contrasena);

            usuario.FechaIngreso = DateTime.Now;
            usuario.UsuarioIngreso = "giank";

            var id = _unitOfWork.Usuarios.Insert(usuario);

            return _unitOfWork.Usuarios.GetById(id);
        }

        public bool Update(Usuarios usuario) => _unitOfWork.Usuarios.Update(usuario);
        

        public IEnumerable<ListaUsuarios> UsuariosListaPaginada(int pag, int filas) => _unitOfWork.Usuarios.UsuariosListaPaginada(pag, filas);

        public Usuarios ValidarUsuario(string correo, string contrasena) => _unitOfWork.Usuarios.ValidarUsuario(correo, contrasena);

        Usuarios IUsuariosLogic.GetById(int id) => _unitOfWork.Usuarios.GetById(id);
    }
}
