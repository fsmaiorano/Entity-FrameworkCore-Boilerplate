using System.Threading.Tasks;
using Dados;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Mvc.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ApplicationDbContext _contexto;

        public CategoriaController(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public IActionResult Salvar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Salvar(Categoria categoria)
        {
            _contexto.Categorias.Add(categoria);
            await _contexto.SaveChangesAsync();
            return View();
        }
    }
}