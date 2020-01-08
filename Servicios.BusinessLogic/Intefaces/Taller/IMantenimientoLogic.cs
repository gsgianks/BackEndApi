using Servicios.Models;
using Servicios.Models.Seguridad;
using Servicios.Models.Taller;
using System.Collections.Generic;

namespace Servicios.BusinessLogic.Intefaces
{
    public interface IMantenimientoLogic
    {
        IEnumerable<Mantenimiento> GetList();
        Mantenimiento GetById(int id);
        int Insert(Mantenimiento usuario);
        bool Update(Mantenimiento usuario);
        bool Delete(Mantenimiento usuario);
        //IEnumerable<ListaMantenimiento> ListaPaginadaMotocycleta(int pag, int filas, int id);
    }
}
