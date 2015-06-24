using System.Linq;
using System.Web.Mvc;
using DAL.Repositories;
using Web.Models;

namespace Web.Controllers
{
    public class RankingController : Controller
    {
        private IComentarioRepository repository;

        public RankingController(IComentarioRepository repo)
        {
            repository = repo;
        }

        // GET: /Ranking/
        public ActionResult Index()
        {
            var viewModel = new RankingViewModel
            {
                Result = repository.GetMostValuableMovies().Select(o => ComentarioViewModel.ToModel(o)).ToArray()
            };

            return View(viewModel);
        }
    }
}