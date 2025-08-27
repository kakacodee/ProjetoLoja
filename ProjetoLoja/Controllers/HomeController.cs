using Microsoft.AspNetCore.Mvc;
using ProjetoLoja.Models;
using ProjetoLoja.Repositorio;
using System.Diagnostics;

namespace ProjetoLoja.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ProdutoRepositorio _produtoRepositorio;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var produtos = await _produtoRepositorio.TodosProdutos();
            return View(produtos);  
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
