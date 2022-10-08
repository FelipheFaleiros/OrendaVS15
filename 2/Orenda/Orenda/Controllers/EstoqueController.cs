
using Orenda.Models;
using System.Web.Mvc;

namespace Orenda.Controllers
{
    public class EstoqueController : Controller
    {
        // GET: Cliente
        [HttpGet]
        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Estoques cadastrar)
        {
            cadastrar.Cadastrar();
            return Content("TOP");
        }

        public ActionResult Relatorio()
        {
            return View(Estoques.RecuperarList());

        }

        [HttpGet]
        public ActionResult GetDados(int id)
        {
            return View("Cadastro", Estoques.GetProdutos(id));
        }

        [HttpPost]
        public ActionResult Put(Estoques cadastrar)
        {
            cadastrar.Put();
            return Content("TOP");
        }

    }
}