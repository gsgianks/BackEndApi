using Servicios.BusinessLogic.Intefaces;
using Servicios.Models;
using Servicios.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicios.BusinessLogic.Implementations
{
    public class TokenLogic : ITokenLogic
    {
        private IUnitOfWork _unitOfWork;
        public TokenLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Usuarios ValidateUser(string correo, string contrasena)
        {
            return _unitOfWork.Usuarios.ValidarUsuario(correo, contrasena);
        }
    }
}
