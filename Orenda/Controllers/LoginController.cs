using Orenda.Models;
using System.Web.Mvc;

namespace Orenda.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            if (Session["Erro"] != null)
                ViewBag.Erro = Session["Erro"].ToString();

            return View();
        }

        [HttpPost]
        public void ChecarLogin()
        {

            var usuario = new Usuarios();
            usuario.Email = Request["Email"];
            usuario.Senha = Request["Password"];

            if (usuario.Login())
            {
                Session["Autorizado"] = "OK";
                Session.Remove("Erro");
                Response.Redirect("/Home/Index");
            }
            else
            {
                Session["Erro"] = "Senha ou usúario inválidos";
                Response.Redirect("/Login/Index");
            }
        }

    }
}