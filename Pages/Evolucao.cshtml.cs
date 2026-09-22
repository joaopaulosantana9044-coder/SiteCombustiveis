using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SiteCombustiveis.Models;
using SiteCombustiveis.Repositories;
using Microsoft.Extensions.Configuration;

namespace SiteCombustiveis.Pages
{
    public class EvolucaoModel : PageModel
    {
        private readonly ColetaRepository _coletaRepository;
        private readonly PostoRepository _postoRepository;
        private readonly CombustivelRepository _combustivelRepository;

        public EvolucaoModel(IConfiguration configuration)
        {
            _coletaRepository = new ColetaRepository(configuration);
            _postoRepository = new PostoRepository(configuration);
            _combustivelRepository = new CombustivelRepository(configuration);
        }

        public List<Posto> Postos { get; set; } = new List<Posto>();
        public List<Combustivel> Combustiveis { get; set; } = new List<Combustivel>();
        public List<Coleta> Resultado { get; set; } = new List<Coleta>();

        public void OnGet(int? idPosto, int? idCombustivel)
        {
            Postos = _postoRepository.ObterTodos();
            Combustiveis = _combustivelRepository.ObterTodos();

            if (idPosto.HasValue && idCombustivel.HasValue)
            {
                Resultado = _coletaRepository.ObterEvolucao(idPosto.Value, idCombustivel.Value);
            }
        }
    }
}