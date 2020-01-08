using System;
using System.Collections.Generic;
using Servicios.BusinessLogic.Intefaces;
using Servicios.Common;
using Servicios.Models;
using Servicios.Models.Seguridad;
using Servicios.Models.Taller;
using Servicios.UnitOfWork;

namespace Servicios.BusinessLogic.Implementations
{
    public class MantenimientoLogic : IMantenimientoLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        public MantenimientoLogic(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public bool Delete(Mantenimiento Mantenimiento) => _unitOfWork.Mantenimientos.Delete(Mantenimiento);

        public int Insert(Mantenimiento Mantenimiento) => _unitOfWork.Mantenimientos.Insert(Mantenimiento);

        public bool Update(Mantenimiento usuario) => _unitOfWork.Mantenimientos.Update(usuario);

        public IEnumerable<Mantenimiento> GetList() => _unitOfWork.Mantenimientos.GetList();       

        Mantenimiento IMantenimientoLogic.GetById(int id) => _unitOfWork.Mantenimientos.GetById(id);

        //public IEnumerable<ListaMantenimiento> ListaPaginadaMotocycleta(int pag, int filas, int id) => _unitOfWork.Mantenimientos.ListaPaginadaMotocycleta(pag, filas, id);
    }
}
