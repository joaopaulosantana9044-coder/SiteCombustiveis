using MySql.Data.MySqlClient;
using SiteCombustiveis.Data;
using SiteCombustiveis.Models;
using Microsoft.Extensions.Configuration;

namespace SiteCombustiveis.Repositories
{
    public class ColetaRepository
    {
        private readonly ConexaoMySql _conexaoMySql;

        public ColetaRepository(IConfiguration configuration)
        {
            _conexaoMySql = new ConexaoMySql(configuration);
        }

        // Consulta I: menor e maior preço de cada combustível
        public List<PrecoExtremo> ObterExtremos()
        {
            var lista = new List<PrecoExtremo>();
            using var conexao = _conexaoMySql.ObterConexao();
            conexao.Open();

            string sql = @"
                SELECT p.nome AS posto, CONCAT(p.logradouro, ', ', p.numero) AS endereco,
                       p.bairro, c.tipo AS combustivel,
                       MIN(co.valor) AS menor_preco, MAX(co.valor) AS maior_preco
                FROM coleta co
                JOIN posto p ON p.id_posto = co.id_posto
                JOIN combustivel c ON c.id_combustivel = co.id_combustivel
                GROUP BY p.id_posto, c.id_combustivel;";

            using var comando = new MySqlCommand(sql, conexao);
            using var leitor = comando.ExecuteReader();
            while (leitor.Read())
            {
                lista.Add(new PrecoExtremo
                {
                    Posto = leitor.GetString("posto"),
                    Endereco = leitor.GetString("endereco"),
                    Bairro = leitor.GetString("bairro"),
                    Combustivel = leitor.GetString("combustivel"),
                    MenorPreco = leitor.GetDecimal("menor_preco"),
                    MaiorPreco = leitor.GetDecimal("maior_preco")
                });
            }
            return lista;
        }

        // Consulta II: média e quantidade de amostras por posto/combustível
        public List<PrecoMedio> ObterMedias()
        {
            var lista = new List<PrecoMedio>();
            using var conexao = _conexaoMySql.ObterConexao();
            conexao.Open();

            string sql = @"
                SELECT p.nome AS posto, p.bairro, c.tipo AS combustivel,
                       ROUND(AVG(co.valor), 3) AS preco_medio, COUNT(*) AS quantidade_amostras
                FROM coleta co
                JOIN posto p ON p.id_posto = co.id_posto
                JOIN combustivel c ON c.id_combustivel = co.id_combustivel
                GROUP BY p.id_posto, c.id_combustivel;";

            using var comando = new MySqlCommand(sql, conexao);
            using var leitor = comando.ExecuteReader();
            while (leitor.Read())
            {
                lista.Add(new PrecoMedio
                {
                    Posto = leitor.GetString("posto"),
                    Bairro = leitor.GetString("bairro"),
                    Combustivel = leitor.GetString("combustivel"),
                    Valor = leitor.GetDecimal("preco_medio"),
                    QuantidadeAmostras = leitor.GetInt32("quantidade_amostras")
                });
            }
            return lista;
        }

        // Consulta III: preço mais recente de cada posto/combustível
        public List<Coleta> ObterMaisRecentes()
        {
            var lista = new List<Coleta>();
            using var conexao = _conexaoMySql.ObterConexao();
            conexao.Open();

            string sql = @"
                SELECT p.nome AS posto, p.bairro, c.tipo AS combustivel, co.valor, co.data_coleta
                FROM coleta co
                JOIN posto p ON p.id_posto = co.id_posto
                JOIN combustivel c ON c.id_combustivel = co.id_combustivel
                WHERE co.data_coleta = (
                    SELECT MAX(co2.data_coleta) FROM coleta co2
                    WHERE co2.id_posto = co.id_posto AND co2.id_combustivel = co.id_combustivel
                );";

            using var comando = new MySqlCommand(sql, conexao);
            using var leitor = comando.ExecuteReader();
            while (leitor.Read())
            {
                lista.Add(new Coleta
                {
                    NomePosto = leitor.GetString("posto"),
                    Bairro = leitor.GetString("bairro"),
                    TipoCombustivel = leitor.GetString("combustivel"),
                    Valor = leitor.GetDecimal("valor"),
                    DataColeta = leitor.GetDateTime("data_coleta")
                });
            }
            return lista;
        }

        // Consulta IV: evolução do preço de um combustível específico em um posto específico
        public List<Coleta> ObterEvolucao(int idPosto, int idCombustivel)
        {
            var lista = new List<Coleta>();
            using var conexao = _conexaoMySql.ObterConexao();
            conexao.Open();

            string sql = @"
                SELECT p.nome AS posto, p.bairro, c.tipo AS combustivel, co.valor, co.data_coleta
                FROM coleta co
                JOIN posto p ON p.id_posto = co.id_posto
                JOIN combustivel c ON c.id_combustivel = co.id_combustivel
                WHERE co.id_posto = @idPosto AND co.id_combustivel = @idCombustivel
                ORDER BY co.data_coleta;";

            using var comando = new MySqlCommand(sql, conexao);
            comando.Parameters.AddWithValue("@idPosto", idPosto);
            comando.Parameters.AddWithValue("@idCombustivel", idCombustivel);

            using var leitor = comando.ExecuteReader();
            while (leitor.Read())
            {
                lista.Add(new Coleta
                {
                    NomePosto = leitor.GetString("posto"),
                    Bairro = leitor.GetString("bairro"),
                    TipoCombustivel = leitor.GetString("combustivel"),
                    Valor = leitor.GetDecimal("valor"),
                    DataColeta = leitor.GetDateTime("data_coleta")
                });
            }
            return lista;
        }
    }
}