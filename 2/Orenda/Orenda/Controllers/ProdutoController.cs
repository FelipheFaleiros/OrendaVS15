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

        public ActionResult Deletar(int id)
        {
            Produtos.Deletar(id);
            return Content("TOP");
        }
    }
}