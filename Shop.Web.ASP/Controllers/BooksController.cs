using Shop.Common.Repositories;
using System.Web.Mvc;

namespace Shop.Web.Controllers
{
    public class BooksController : Controller
    {
        private const string partialView = "Partials/BooksList";
        private readonly BooksRepository _repo;

        public BooksController()
        {
            _repo = new BooksRepository();
        }

        [HttpGet]
        public PartialViewResult GetAll(string searchString)
        {
            return PartialView(partialView, _repo.GetAll(searchString));
        }
        [HttpGet]
        public PartialViewResult GetAudiobooks(string searchString)
        {
            return PartialView(partialView, _repo.GetAudiobooks(searchString));
        }
        [HttpGet]
        public PartialViewResult GetEbooks(string searchString)
        {
            return PartialView(partialView, _repo.GetEbooks(searchString));
        }
        [HttpGet]
        public PartialViewResult GetNews(string searchString)
        {
            return PartialView(partialView, _repo.GetNews(searchString));
        }
        [HttpGet]
        public PartialViewResult GetPreviews(string searchString)
        {
            return PartialView(partialView, _repo.GetPreviews(searchString));
        }
        [HttpGet]
        public PartialViewResult GetSuperBargains(string searchString)
        {
            return PartialView(partialView, _repo.GetSuperBargains(searchString));
        }
    }
}