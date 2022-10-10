﻿
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

        [HttpGet]
        public ActionResult GetDados(int id)
        {
            return View("Edicao", Estoques.GetProdutos(id));
        }

        [HttpPost]
        public ActionResult Put(Estoques cadastrar)
        {
            cadastrar.Put();
            return Content("TOP");
        }
    }
}