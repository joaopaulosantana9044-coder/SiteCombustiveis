using MySql.Data.MySqlClient;
using SiteCombustiveis.Data;
using SiteCombustiveis.Models;
using Microsoft.Extensions.Configuration;

namespace SiteCombustiveis.Repositories
{
    public class CombustivelRepository
    {
        private readonly ConexaoMySql _conexaoMySql;

        public CombustivelRepository(IConfiguration configuration)
        {
            _conexaoMySql = new ConexaoMySql(configuration);
        }

        public List<Combustivel> ObterTodos()
        {
            var lista = new List<Combustivel>();
            using var conexao = _conexaoMySql.ObterConexao();
            conexao.Open();

            string sql = "SELECT id_combustivel, tipo FROM combustivel ORDER BY tipo;";

            using var comando = new MySqlCommand(sql, conexao);
            using var leitor = comando.ExecuteReader();
            while (leitor.Read())
            {
                lista.Add(new Combustivel
                {
                    IdCombustivel = leitor.GetInt32("id_combustivel"),
                    Tipo = leitor.GetString("tipo")
                });
            }
            return lista;
        }
    }
}