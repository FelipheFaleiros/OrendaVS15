
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
            if (Session["Autorizado"] != null)
            {
                return View();
            }
            else
            {
                Response.Redirect("/Login/Index");
                return null;
            }
        }

        [HttpPost]
        public ActionResult Cadastrar(Estoques cadastrar)
        {
            if (Session["Autorizado"] != null)
            {
                cadastrar.Cadastrar();
                return Content("TOP");
            }
            else
            {
                Response.Redirect("/Login/Index");
                return null;
            }
        }

        public ActionResult Relatorio()
        {
            if (Session["Autorizado"] != null)
            {
                return View(Estoques.RecuperarList());
            }
            else
            {
                Response.Redirect("/Login/Index");
                return null;
            }
        }

        public ActionResult Deletar(int id)
        {
            if (Session["Autorizado"] != null)
            {
                Estoques.Deletar(id);
                return Content("TOP");
            }
            else
            {
                Response.Redirect("/Login/Index");
                return null;
            }
        }

        [HttpGet]
        public ActionResult GetDados(int id)
        {
            if (Session["Autorizado"] != null)
            {
                return View("Edicao", Estoques.GetEstoques(id));
            }
            else
            {
                Response.Redirect("/Login/Index");
                return null;
            }
        }

        [HttpPost]
        public ActionResult Put(Estoques cadastrar)
        {
            if (Session["Autorizado"] != null)
            {
                cadastrar.Put();
                return Content("TOP");
            }
            else
            {
                Response.Redirect("/Login/Index");
                return null;
            }
        }
    }
}