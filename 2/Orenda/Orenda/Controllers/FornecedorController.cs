using Orenda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Orenda.Controllers
{
    public class FornecedorController : Controller
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
        public ActionResult Cadastrar(Fornecedores cadastrar)
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
                return View(Fornecedores.RecuperarList());
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
                Fornecedores.Deletar(id);
                return Content("TOP");
            }
            else
            {
                Response.Redirect("/Login/Index");
                return null;
            }
        }

        [HttpGet]
        public ActionResult GetDados (int id)
        {
            if (Session["Autorizado"] != null)
            {
                return View("Edicao", Fornecedores.GetFornecedores(id));
            }
            else
            {
                Response.Redirect("/Login/Index");
                return null;
            }
        }

        [HttpPost]
        public ActionResult Put(Fornecedores cadastrar)
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