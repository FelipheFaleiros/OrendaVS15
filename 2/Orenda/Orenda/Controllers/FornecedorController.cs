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
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Fornecedores cadastrar)
        {
            cadastrar.Cadastrar();
            return Content("TOP");
        }

        public ActionResult Relatorio()
        {
            return View(Fornecedores.RecuperarList());
        }
        
        public ActionResult Deletar(int id)
        {
            Fornecedores.Deletar(id);
            return Content("TOP");
        }
    }
}