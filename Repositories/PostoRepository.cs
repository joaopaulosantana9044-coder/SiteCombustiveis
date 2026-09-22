using MySql.Data.MySqlClient;
using SiteCombustiveis.Data;
using SiteCombustiveis.Models;
using Microsoft.Extensions.Configuration;

namespace SiteCombustiveis.Repositories
{
    public class PostoRepository
    {
        public PostoRepository(IConfiguration configuration)
        {
            _conexaoMySql = new ConexaoMySql(configuration);
        }
        private readonly ConexaoMySql _conexaoMySql;

        public List<Posto> ObterTodos()
        {
            var lista = new List<Posto>();
            using var conexao = _conexaoMySql.ObterConexao();
            conexao.Open();

            string sql = "SELECT id_posto, nome, bairro FROM posto ORDER BY nome;";

            using var comando = new MySqlCommand(sql, conexao);
            using var leitor = comando.ExecuteReader();
            while (leitor.Read())
            {
                lista.Add(new Posto
                {
                    IdPosto = leitor.GetInt32("id_posto"),
                    Nome = leitor.GetString("nome"),
                    Bairro = leitor.GetString("bairro")
                });
            }
            return lista;
        }
    }
}