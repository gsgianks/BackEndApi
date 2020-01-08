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
    public class HojaRecibimientoLogic : IHojaRecibimientoLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        public HojaRecibimientoLogic(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public bool Delete(HojaRecibimiento dto) => _unitOfWork.HojasRecibimiento.Delete(dto);

        public int Insert(HojaRecibimiento dto)
        {
            dto.FechaIngreso = DateTime.Now;
            return _unitOfWork.HojasRecibimiento.Insert(dto);
        }

        public bool Update(HojaRecibimiento dto) => _unitOfWork.HojasRecibimiento.Update(dto);

        public IEnumerable<HojaRecibimiento> GetList() => _unitOfWork.HojasRecibimiento.GetList();

        HojaRecibimiento IHojaRecibimientoLogic.GetById(int id) => _unitOfWork.HojasRecibimiento.GetById(id);

        //public IEnumerable<ListaHojaRecibimiento> ListaPaginadaMotocycleta(int pag, int filas, int id) => _unitOfWork.HojaRecibimientos.ListaPaginadaMotocycleta(pag, filas, id);
    }
}
