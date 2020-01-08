using Servicios.Models;
using Servicios.Models.Taller;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicios.Repositories
{
    public interface IMantenimientoRepository : IRepository<Mantenimiento>
    {
        //IEnumerable<ListaMotocicleta> ListaPaginadaMotocycleta(int pag, int filas, int id);
    }
}
