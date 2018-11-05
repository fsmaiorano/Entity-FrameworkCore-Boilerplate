using System.Linq;
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
        public IActionResult Index()
        {
            var categorias = _contexto.Categorias.ToList();
            return View(categorias);
        }

        public IActionResult Editar(int id)
        {
            var categoria = _contexto.Categorias.FirstOrDefault(x => x.Id == id);
            return View("Salvar", categoria);
        }

        [HttpGet]
        public IActionResult Salvar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Salvar(Categoria categoria)
        {
            if (categoria.Id == 0)
            {
                _contexto.Categorias.Add(categoria);
            }
            else
            {
                var categoriaSelecionada = _contexto.Categorias.FirstOrDefault(x => x.Id == categoria.Id);
                categoriaSelecionada.Nome = categoria.Nome;
            }

            await _contexto.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}