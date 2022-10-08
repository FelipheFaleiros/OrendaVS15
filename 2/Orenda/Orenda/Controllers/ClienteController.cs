using Orenda.Models;
using System.Web.Mvc;

namespace Orenda.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        [HttpGet]        
        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Clientes cadastrar)
        {
            cadastrar.Cadastrar();
            return Content("TOP");
        }

        public ActionResult Relatorio()
        {
            return View(Clientes.RecuperarList());
            
        }

    }
}