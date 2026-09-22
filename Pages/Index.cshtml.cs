using Microsoft.AspNetCore.Mvc.RazorPages;
using SiteCombustiveis.Models;
using SiteCombustiveis.Repositories;

namespace SiteCombustiveis.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ColetaRepository _coletaRepository;
        private readonly PostoRepository _postoRepository;
        private readonly CombustivelRepository _combustivelRepository;

        public IndexModel(IConfiguration configuration)
        {
            _coletaRepository = new ColetaRepository(configuration);
            _postoRepository = new PostoRepository(configuration);
            _combustivelRepository = new CombustivelRepository(configuration);
        }

        public List<PrecoExtremo> Extremos { get; set; } = new List<PrecoExtremo>();
        public List<PrecoMedio> Medios { get; set; } = new List<PrecoMedio>();
        public List<Coleta> Recentes { get; set; } = new List<Coleta>();

        public List<Posto> Postos { get; set; } = new List<Posto>();
        public List<Combustivel> Combustiveis { get; set; } = new List<Combustivel>();
        public List<Coleta> Evolucao { get; set; } = new List<Coleta>();

        public void OnGet(int? idPosto, int? idCombustivel)
        {
            Extremos = _coletaRepository.ObterExtremos();
            Medios = _coletaRepository.ObterMedias();
            Recentes = _coletaRepository.ObterMaisRecentes();

            Postos = _postoRepository.ObterTodos();
            Combustiveis = _combustivelRepository.ObterTodos();

            if (idPosto.HasValue && idCombustivel.HasValue)
            {
                Evolucao = _coletaRepository.ObterEvolucao(idPosto.Value, idCombustivel.Value);
            }
        }
    }
}