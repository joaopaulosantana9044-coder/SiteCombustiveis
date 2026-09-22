namespace SiteCombustiveis.Models
{
    public class Posto
    {
        public int IdPosto { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Cnpj { get; set; }
        public string Logradouro { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
    }
}