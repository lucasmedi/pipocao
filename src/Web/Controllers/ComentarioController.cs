using System;
using System.Web.Mvc;
using DAL.Repositories;
using Web.Models;
using WebMatrix.WebData;

namespace Web.Controllers
{
    [Authorize]
    public class ComentarioController : Controller
    {
        private IComentarioRepository repository;
        private IFilmeRepository repositoryF;

        public ComentarioController(IComentarioRepository repoC, IFilmeRepository repoF)
        {
            repository = repoC;
            repositoryF = repoF;
        }

        // GET: /Comentario/Details/5
        public ActionResult Details(int id)
        {
            if (id <= 0)
                return RedirectToAction("List", "Filme");

            return View(ComentarioViewModel.ToModel(repository.FindBy(id)));
        }

        // GET: /Comentario/Create
        public ActionResult Create(int filmeId)
        {
            var filme = repositoryF.FindBy(filmeId);

            if (filme == null)
                return RedirectToAction("Index", "Filme");

            var viewModel = new ComentarioViewModel()
            {
                Filme = filme,
                FilmeId = filme.Id
            };

            return View(viewModel);
        }

        // POST: /Comentario/Create
        [HttpPost]
        public ActionResult Create(int filmeId, ComentarioViewModel comentario)
        {
            try
            {
                comentario.UsuarioId = WebSecurity.CurrentUserId;
                comentario.Data = DateTime.Now;
                repository.Add(comentario);
            }
            catch
            {
                comentario.Filme = repositoryF.FindBy(filmeId);
                return View(comentario);
            }

            return RedirectToAction("Index", "Filme");
        }

        // GET: /Comentario/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var f = repository.FindBy(id);
                if (f.Usuario.Id == WebSecurity.CurrentUserId)
                    repository.Delete(id);
            }
            catch
            {

            }

            return RedirectToAction("Index", "Filme");
        }
    }
}