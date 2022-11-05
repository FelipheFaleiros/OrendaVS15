using Orenda.Models;
using System.Web.Mvc;

namespace Orenda.Controllers
{
    public class ProdutoController : Controller
    {
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
        public ActionResult Cadastrar(Produtos cadastrar)
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
                return View(Produtos.RecuperarList());
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
                Produtos.Deletar(id);
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
                return View("Edicao", Produtos.GetProdutos(id));
            }
            else
            {
                Response.Redirect("/Login/Index");
                return null;
            }
        }

        [HttpPost]
        public ActionResult Put(Produtos cadastrar)
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