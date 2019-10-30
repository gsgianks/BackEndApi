using Dapper;
using Servicios.Models;
using Servicios.Models.Seguridad;
using Servicios.Repositories;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Servicios.DataAccess
{
    public class UsuariosRepository : Repository<Usuarios>, IUsuariosRepository
    {
        public UsuariosRepository(string connectionString) : base(connectionString)
        {
        }

        public IEnumerable<ListaUsuarios> UsuariosListaPaginada(int pag, int filas)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pPagina", pag);
            parameters.Add("@pFilas", filas);

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<ListaUsuarios>("dbo.ListaPaginadaUsuarios",
                                                    parameters,
                                                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public Usuarios ValidarUsuario(string correo, string contrasena)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pCorreo", correo);
            parameters.Add("@pContasena", contrasena);

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.QueryFirstOrDefault<Usuarios>(
                    "dbo.PR_Validar_Usuario", parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
    }
}

