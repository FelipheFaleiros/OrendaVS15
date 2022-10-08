using Orenda.Models;
using System.Web.Mvc;

namespace Orenda.Controllers
{
    public class ProdutoController : Controller
    {
        [HttpGet]
        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Produtos cadastrar)
        {
            cadastrar.Cadastrar();
            return Content("TOP");
        }

        public ActionResult Relatorio()
        {
            return View(Produtos.RecuperarList());
        }

        [HttpGet]
        public ActionResult GetDados(int id)
        {
            return View("Cadastro", Produtos.GetProdutos(id));
        }

        [HttpPost]
        public ActionResult Put(Produtos cadastrar)
        {
            cadastrar.Put();
            return Content("TOP");
        }

    }
}