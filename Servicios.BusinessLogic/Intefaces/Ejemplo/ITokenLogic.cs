using Servicios.Models;

namespace Servicios.BusinessLogic.Intefaces
{
    public interface ITokenLogic
    {
        Usuarios ValidateUser(string email, string password);
    }
}
