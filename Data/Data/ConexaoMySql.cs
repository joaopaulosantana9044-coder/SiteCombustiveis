using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace SiteCombustiveis.Data
{
    public class ConexaoMySql
    {
        private readonly string _connectionString;

        public ConexaoMySql(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Combustiveis")
                ?? throw new InvalidOperationException("Connection string 'Combustiveis' não encontrada.");
        }

        public MySqlConnection ObterConexao()
        {
            return new MySqlConnection(_connectionString);
        }
    }
}