using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace Fiap.Exemplo04.Web.MVC.Tests.Controllers
{
    [EnableCors(origins:"*",headers:"*",methods:"*")]
    public class AlunoController : Controller
    {
        // GET: Aluno
        public ActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {

            return View();
        }

        
    }
}