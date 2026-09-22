namespace SiteCombustiveis.Models
{
    public class PrecoMedio
    {
        public string Posto { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Combustivel { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public int QuantidadeAmostras { get; set; }
    }
}