using Dapper;
using Servicios.Models;
using Servicios.Models.Seguridad;
using Servicios.Repositories;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Servicios.DataAccess
{
    public class MotocicletaRepository : Repository<Motocicleta>, IMotocicletaRepository
    {
        public MotocicletaRepository(string connectionString) : base(connectionString)
        {
        }
    }
}
