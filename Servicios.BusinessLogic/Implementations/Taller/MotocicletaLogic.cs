using System;
using System.Collections.Generic;
using Servicios.BusinessLogic.Intefaces;
using Servicios.Common;
using Servicios.Models;
using Servicios.Models.Seguridad;
using Servicios.UnitOfWork;

namespace Servicios.BusinessLogic.Implementations
{
    public class MotocicletaLogic : IMotocicletaLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        public MotocicletaLogic(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public bool Delete(Motocicleta motocicleta) => _unitOfWork.Motocicletas.Delete(motocicleta);

        public int Insert(Motocicleta motocicleta) => _unitOfWork.Motocicletas.Insert(motocicleta);

        public bool Update(Motocicleta usuario) => _unitOfWork.Motocicletas.Update(usuario);

        public IEnumerable<Motocicleta> GetList() => _unitOfWork.Motocicletas.GetList();       

        Motocicleta IMotocicletaLogic.GetById(int id) => _unitOfWork.Motocicletas.GetById(id);
    }
}
