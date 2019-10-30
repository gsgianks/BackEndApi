using Servicios.Models;
using Servicios.Models.Seguridad;
using System.Collections.Generic;

namespace Servicios.BusinessLogic.Intefaces
{
    public interface IMotocicletaLogic
    {
        IEnumerable<Motocicleta> GetList();
        Motocicleta GetById(int id);
        int Insert(Motocicleta usuario);
        bool Update(Motocicleta usuario);
        bool Delete(Motocicleta usuario);
    }
}
