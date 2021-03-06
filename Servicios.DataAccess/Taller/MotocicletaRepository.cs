﻿using Dapper;
using Servicios.Models;
using Servicios.Models.Seguridad;
using Servicios.Models.Taller;
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

        public IEnumerable<ListaMotocicleta> ListaPaginadaMotocycleta(int pag, int filas, int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pPagina", pag);
            parameters.Add("@pFilas", filas);
            parameters.Add("@pIdUsuario", id);

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<ListaMotocicleta>("dbo.ListaPaginadaMotocicletas",
                                                    parameters,
                                                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
