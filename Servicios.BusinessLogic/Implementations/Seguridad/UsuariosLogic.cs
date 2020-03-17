using System;
using System.Collections.Generic;
using System.Linq;
using Servicios.BusinessLogic.Intefaces;
using Servicios.Common;
using Servicios.Models;
using Servicios.Models.Base;
using Servicios.Models.Seguridad;
using Servicios.UnitOfWork;

namespace Servicios.BusinessLogic.Implementations
{
    public class UsuariosLogic : IUsuariosLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        public UsuariosLogic(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public ResultBaseModel Delete(Usuarios usuario) {

            ResultBaseModel result = new ResultBaseModel();

            try {
                if (_unitOfWork.Usuarios.Delete(usuario)) {
                    result.Description = "Registro eliminado exitosamente";
                }
            }
            catch (Exception ex)
            {
                result.Code = 99;
                result.Description = "Error no controlado: " + ex.Message;
            }

            return result;
        }

        public ResponseModel<Usuarios> Insert(Usuarios usuario)
        {
            ResponseModel<Usuarios> result = new ResponseModel<Usuarios>();

            try {
                //Datos necesarios para la inserción.
                usuario.Contrasena = Util.RandomString(8, true);
                usuario.CambiarContrasena = true;
                usuario.FechaIngreso = DateTime.Now;
                usuario.UsuarioIngreso = "giank";

                //Insertar y recuperar el registro.
                var id = _unitOfWork.Usuarios.Insert(usuario);
                result.Items.Add(_unitOfWork.Usuarios.GetById(id));
                
                //Envio de contraseña por correo electrónico.
                Email.sendMail(usuario.CorreoElectronico, usuario.Contrasena);
            }
            catch (Exception ex) {
                result.Code = 99;
                result.Description = "Error no controlado: " + ex.Message;
            }

            return result;
        }

        public ResultBaseModel Update(Usuarios usuario)
        {

            ResultBaseModel result = new ResultBaseModel();

            try
            {
                if (_unitOfWork.Usuarios.Update(usuario))
                {
                    result.Description = "Registro actualizado exitosamente";
                }
            }
            catch (Exception ex)
            {
                result.Code = 99;
                result.Description = "Error no controlado: " + ex.Message;
            }

            return result;
        }

        public IEnumerable<ListaUsuarios> UsuariosListaPaginada(int pag, int filas) => _unitOfWork.Usuarios.UsuariosListaPaginada(pag, filas);

        public Usuarios ValidarUsuario(string correo, string contrasena) => _unitOfWork.Usuarios.ValidarUsuario(correo, contrasena);

        public ResponseModel<Usuarios> GetById(int id) {
            ResponseModel<Usuarios> result = new ResponseModel<Usuarios>();

            try
            {
                result.Items.Add(_unitOfWork.Usuarios.GetById(id));
            }
            catch (Exception ex)
            {
                result.Code = 99;
                result.Description = "Error no controlado: " + ex.Message;
            }

            return result;
        }

        public ResponseModel<Usuarios> GetList() {
            ResponseModel<Usuarios> result = new ResponseModel<Usuarios>();

            try
            {
               result.Items = _unitOfWork.Usuarios.GetList().ToList();
            }
            catch (Exception ex)
            {
                result.Code = 99;
                result.Description = "Error no controlado: " + ex.Message;
            }

            return result;

        }
    }
}
