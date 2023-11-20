using Camioneros.Model;
using Dapper;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camioneros.Data.Repositorio
{
    public class RepositorioCamionero : InterfaceCamionero
    {
        private readonly MySQLConfiguration _connectionString;

        public RepositorioCamionero(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<bool> DeleteCamionero(Camionero camionero)
        {
            var db = dbConnection();
            var sql = @"DELETE FROM camionero WHERE id = @Id";

            var result = await db.ExecuteAsync(sql, new { Id = camionero.id});

            return result > 0;
        }

        public Task<IEnumerable<Camionero>> GetAllCamionero()
        {
            var db = dbConnection();
            var sql = @"SELECT id,Nombre,ApellidoPaterno,ApellidoMaterno,Edad,Fecha_Nacimiento,Genero,Estado_Civil,Cantidad_Hijo FROM camionero";

            return db.QueryAsync<Camionero>(sql, new {});
        }

        public async Task<Camionero> GetCamionero(int id)
        {
            var db = dbConnection();

            var sql = @" SELECT id,Nombre,ApellidoPaterno,ApellidoMaterno,Edad,
                      Fecha_Nacimiento,Genero,Estado_Civil,Cantidad_Hijo 
                      FROM camionero
                      WHERE id = @Id ";

            return await db.QueryFirstOrDefaultAsync<Camionero>(sql, new { Id = id });
        }

        public async Task<bool> InsertCamionero(Camionero camionero)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO camionero(Nombre,ApellidoPaterno,ApellidoMaterno,Edad,Fecha_Nacimiento,Genero,Estado_Civil,Cantidad_Hijo)
                      VALUES(@Nombre,@ApellidoPaterno,@ApellidoMaterno,@Edad,@Fecha_Nacimiento,@Genero,@Estado_Civil,@Cantidad_Hijo)";

            var result = await db.ExecuteAsync(sql, new
            {
                camionero.Nombre,
                camionero.ApellidoPaterno,
                camionero.ApellidoMaterno,
                camionero.Edad,
                camionero.Fecha_Nacimiento,
                camionero.Genero,
                camionero.Estado_Civil,
                camionero.Cantidad_Hijo
            });
            return result > 0;
        }

        public async Task<bool> UpdateCamionero(Camionero camionero)
        {
            var db = dbConnection();
            var sql = @"UPDATE camionero SETNombre=@Nombre,ApellidoPaterno=@ApellidoPaterno,ApellidoMaterno=@ApellidoMaterno,
                      Edad=@Edad,Fecha_Nacimiento=@Fecha_Nacimiento,
                      Genero=@Genero,Estado_Civil=@Estado_Civil,Cantidad_Hijo=@Cantidad_Hijo
                      WHERE id = @Id"
                      ;

            var result = await db.ExecuteAsync(sql, new
            {
                camionero.Nombre,
                camionero.ApellidoPaterno,
                camionero.ApellidoMaterno,
                camionero.Edad,
                camionero.Fecha_Nacimiento,
                camionero.Genero,
                camionero.Estado_Civil,
                camionero.Cantidad_Hijo
            });
            return result > 0;
        }
    }
}
