using Domain.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Data
{
    public class PaisAdoRepository : IPaisRepository
    {
        private readonly string _connectionString;

        public PaisAdoRepository(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("La cadena de conexión no puede estar vacía.", nameof(connectionString));

            _connectionString = connectionString;
        }

        public async Task<List<Pais>> GetAllAsync()
        {
            var paises = new List<Pais>();
            const string sql = "SELECT Id, Nombre FROM Paises ORDER BY Nombre";

            await using var conn = new SqlConnection(_connectionString);
            await using var cmd = new SqlCommand(sql, conn);

            await conn.OpenAsync();
            await using var reader = await cmd.ExecuteReaderAsync();

            int ordId = reader.GetOrdinal("Id");
            int ordNombre = reader.GetOrdinal("Nombre");

            while (await reader.ReadAsync())
            {
                int id = reader.GetInt32(ordId);
                string nombre = reader.GetString(ordNombre);
                paises.Add(new Pais(id, nombre));
            }

            return paises;
        }

        public async Task<Pais?> GetByIdAsync(int id)
        {
            const string sql = "SELECT Id, Nombre FROM Paises WHERE Id = @Id";

            await using var conn = new SqlConnection(_connectionString);
            await using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

            await conn.OpenAsync();
            await using var reader = await cmd.ExecuteReaderAsync();

            if (!await reader.ReadAsync())
                return null;

            int paisId = reader.GetInt32(reader.GetOrdinal("Id"));
            string nombre = reader.GetString(reader.GetOrdinal("Nombre"));
            return new Pais(paisId, nombre);
        }

        public async Task AddAsync(Pais pais)
        {
            const string sql = @"
                INSERT INTO Paises (Nombre)
                VALUES (@Nombre);
                SELECT CAST(SCOPE_IDENTITY() AS int);";

            await using var conn = new SqlConnection(_connectionString);
            await using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100).Value = pais.Nombre;

            await conn.OpenAsync();
            var result = await cmd.ExecuteScalarAsync();
            if (result != null && result != DBNull.Value)
            {
                pais.SetId(Convert.ToInt32(result));
            }
        }

        public async Task UpdateAsync(Pais pais)
        {
            const string sql = "UPDATE Paises SET Nombre = @Nombre WHERE Id = @Id";

            await using var conn = new SqlConnection(_connectionString);
            await using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = pais.Id;
            cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100).Value = pais.Nombre;

            await conn.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task DeleteAsync(Pais pais)
        {
            const string sql = "DELETE FROM Paises WHERE Id = @Id";

            await using var conn = new SqlConnection(_connectionString);
            await using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = pais.Id;

            await conn.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }
    }
}