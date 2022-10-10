
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

        public ActionResult Deletar(int id)
        {
            Estoques.Deletar(id);
            return Content("TOP");
        }
    }
}