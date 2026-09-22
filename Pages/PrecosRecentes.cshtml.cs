using Microsoft.AspNetCore.Mvc.RazorPages;
using SiteCombustiveis.Models;
using SiteCombustiveis.Repositories;
using Microsoft.Extensions.Configuration;

namespace SiteCombustiveis.Pages
{
    public class PrecosRecentesModel : PageModel
    {
        private readonly ColetaRepository _coletaRepository;

        public PrecosRecentesModel(IConfiguration configuration)
        {
            _coletaRepository = new ColetaRepository(configuration);
        }

        public List<Coleta> Coletas { get; set; } = new List<Coleta>();

        public void OnGet()
        {
            Coletas = _coletaRepository.ObterMaisRecentes();
        }
    }
}