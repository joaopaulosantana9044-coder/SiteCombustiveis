namespace SiteCombustiveis.Models
{
    public class Coleta
    {
        public int IdColeta { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataColeta { get; set; }
        public TimeSpan? HoraColeta { get; set; }

        // Dados do posto e do combustível relacionados //
        public string NomePosto { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string TipoCombustivel { get; set; } = string.Empty;
    }
}