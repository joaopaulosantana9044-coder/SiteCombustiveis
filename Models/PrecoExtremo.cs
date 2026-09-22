namespace SiteCombustiveis.Models
{
    public class PrecoExtremo
    {
        public string Posto { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Combustivel { get; set; } = string.Empty;
        public decimal MenorPreco { get; set; }
        public decimal MaiorPreco { get; set; }
    }
}