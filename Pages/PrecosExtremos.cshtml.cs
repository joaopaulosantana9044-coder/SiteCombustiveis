using Microsoft.AspNetCore.Mvc.RazorPages;
using SiteCombustiveis.Models;
using SiteCombustiveis.Repositories;
using Microsoft.Extensions.Configuration;

namespace SiteCombustiveis.Pages
{
    public class PrecosExtremosModel : PageModel
    {
        private readonly ColetaRepository _coletaRepository;

        public PrecosExtremosModel(IConfiguration configuration)
        {
            _coletaRepository = new ColetaRepository(configuration);
        }

        public List<PrecoExtremo> Precos { get; set; } = new List<PrecoExtremo>();

        public void OnGet()
        {
            Precos = _coletaRepository.ObterExtremos();
        }
    }
}