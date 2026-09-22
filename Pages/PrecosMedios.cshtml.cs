using Microsoft.AspNetCore.Mvc.RazorPages;
using SiteCombustiveis.Models;
using SiteCombustiveis.Repositories;
using Microsoft.Extensions.Configuration;

namespace SiteCombustiveis.Pages
{
    public class PrecosMediosModel : PageModel
    {
        private readonly ColetaRepository _coletaRepository;

        public PrecosMediosModel(IConfiguration configuration)
        {
            _coletaRepository = new ColetaRepository(configuration);
        }
        public List<PrecoMedio> Precos { get; set; } = new List<PrecoMedio>();

        public void OnGet()
        {
            Precos = _coletaRepository.ObterMedias();
        }
    }
}