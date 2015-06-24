using System.Linq;
using System.Web.Mvc;
using DAL.Repositories;
using Web.Code;
using Web.Models;
using WebMatrix.WebData;

namespace Web.Controllers
{
    [Authorize]
    public class FilmeController : Controller
    {
        private IFilmeRepository repository;

        public FilmeController(IFilmeRepository repo)
        {
            repository = repo;
        }

        // GET: /Filme/
        public ActionResult Index()
        {
            var viewModel = new SearchViewModel
            {
                Result = repository.AllByUser(WebSecurity.CurrentUserId).OrderBy(o => o.Titulo).Select(o => FilmeViewModel.ToModel(o)).ToArray()
            };

            return View(viewModel);
        }

        // POST: /Filme/List/titulo
        [HttpPost]
        public ActionResult Index(string titulo)
        {
            var viewModel = new SearchViewModel();
            if (!string.IsNullOrEmpty(titulo))
                viewModel.Result = repository.FilterByUserAndTitle(WebSecurity.CurrentUserId, titulo).Select(o => FilmeViewModel.ToModel(o)).ToArray();
            else
                viewModel.Result = repository.AllByUser(WebSecurity.CurrentUserId).OrderBy(o => o.Titulo).Select(o => FilmeViewModel.ToModel(o)).ToArray();

            return View(viewModel);
        }

        // GET: /Filme/Details/5
        public ActionResult Details(int id)
        {
            var filme = repository.FindBy(o => o.Id == id && o.Usuario.Id == WebSecurity.CurrentUserId);
            if (filme != null)
            {
                return View(FilmeViewModel.ToModel(filme));
            }

            return RedirectToAction("Index");
        }

        // GET: /Filme/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Filme/Create
        [HttpPost]
        public ActionResult Create(FilmeViewModel filme)
        {
            try
            {
                filme.UsuarioId = WebSecurity.CurrentUserId;
                repository.Add(filme);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: /Filme/Edit/5
        public ActionResult Edit(int id)
        {
            var filme = repository.FindBy(o => o.Id == id && o.Usuario.Id == WebSecurity.CurrentUserId);
            if (filme != null)
            {
                return View(FilmeViewModel.ToModel(filme));
            }

            return RedirectToAction("Details", new { id });
        }

        // POST: /Filme/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FilmeViewModel filme)
        {
            try
            {
                var f = repository.FindBy(id);
                if (f.Usuario.Id == WebSecurity.CurrentUserId)
                {
                    FilmeViewModel.Parse(f, filme);
                    repository.Update(f);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: /Filme/Delete/5
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
                return RedirectToAction("Details", new { id });
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult GetMovies(string titulo)
        {
            var tmdbClient = new TmdbClient();
            var list = tmdbClient.GetMovies(titulo);

            return Json(list);
        }

        [HttpPost]
        public JsonResult GetMovie(int id)
        {
            var tmdbClient = new TmdbClient();
            var movie = tmdbClient.GetMovie(id);

            return Json(movie);
        }
    }
}