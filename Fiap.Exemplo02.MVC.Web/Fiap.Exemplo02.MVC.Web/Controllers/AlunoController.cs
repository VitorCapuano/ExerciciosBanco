using Fiap.Exemplo02.MVC.Web.Models;
using Fiap.Exemplo02.MVC.Web.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap.Exemplo02.MVC.Web.Controllers
{
    public class AlunoController : Controller
    {
        //private PortalContext _context = new PortalContext();
        ICollection<Aluno> lista;
        private UnitOfWork _unit = new UnitOfWork();


        #region GET

        [HttpGet]
        public ActionResult Cadastrar()
        {
            //Buscar todos os grupos cadastrados
            
            var lista = _unit.AlunoRepository.Listar();
            ViewBag.grupos = new SelectList(lista, "Id", "Nome");
            return View();
        }

        [HttpGet]
        public ActionResult Listar()
        {
            CarregarComboGrupos();
            //include-> busca o relacionamento(preenche o grupo que o aluno possui) ps tirar o virtual da classe
            //var lista = _context.Aluno.Include("Grupo).ToList();
            var lista = _unit.AlunoRepository.Listar();
            return View(lista);
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            //buscar objeto (aluno) no banco
            var aluno = _unit.AlunoRepository.BuscarPorId(id);
            //manda aluno para view
            return View(aluno);
        }

        [HttpGet]
        public ActionResult Buscar(String nomeBusca, int? idGrupo)//tem que ser o nome nomeBusca que esta na view listar
        {
            if (idGrupo == null)
            {
                lista = _unit.AlunoRepository.BuscarPor(a => a.Nome.Contains(nomeBusca));
            }
            else
            {
                lista = _unit.AlunoRepository.BuscarPor(a => a.Nome.Contains(nomeBusca) && a.GrupoId == idGrupo);
            }
            //Buscar o aluno no banco por nome
            CarregarComboGrupos();
            //retorna a lista para a View Listar
            return View("Listar", lista);
        }

        #endregion

        #region POST
        [HttpPost]
        public ActionResult Cadastrar(Aluno aluno)
        {
            _unit.AlunoRepository.Cadastrar(aluno);
            _unit.Salvar();
            TempData["msg"] = "Aluno cadastrado!";
            return RedirectToAction("Cadastrar");
        }    

        [HttpPost]
        public ActionResult Editar(Aluno aluno)
        {
            _unit.AlunoRepository.Alterar(aluno);
            
            TempData["msg"] = "Aluno Atualizado";
            return RedirectToAction("Listar");
        }

        [HttpPost]
        public ActionResult Excluir(int alunoId)
        {
            _unit.AlunoRepository.Remover(alunoId);
            _unit.Salvar();
            TempData["msg"] = "Aluno removido com sucesso";
            return RedirectToAction("Listar");
        }
        #endregion
        #region PRIVATE
        private void CarregarComboGrupos()
        {
            ViewBag.grupos = new SelectList(_unit.GrupoRepository.Listar(), "Id", "Nome");
        }
        #endregion

        #region Dispose
        //reescrevendo a função dispose do proprio controle e implementando com o disponivel da unitofwork
        protected override void Dispose(bool disposing)
        {
            _unit.Dispose();
            base.Dispose(disposing);    
        }
        #endregion

    }
}