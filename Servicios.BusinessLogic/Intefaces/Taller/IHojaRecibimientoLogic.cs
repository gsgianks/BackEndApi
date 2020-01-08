using Servicios.Models;
using Servicios.Models.Seguridad;
using Servicios.Models.Taller;
using System.Collections.Generic;

namespace Servicios.BusinessLogic.Intefaces
{
    public interface IHojaRecibimientoLogic
    {
        IEnumerable<HojaRecibimiento> GetList();
        HojaRecibimiento GetById(int id);
        int Insert(HojaRecibimiento usuario);
        bool Update(HojaRecibimiento usuario);
        bool Delete(HojaRecibimiento usuario);
        //IEnumerable<ListaHojaRecibimiento> ListaPaginadaMotocycleta(int pag, int filas, int id);
    }
}
