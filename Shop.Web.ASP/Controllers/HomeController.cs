using Shop.Common.Repositories;
using System.Web.Mvc;

namespace Shop.Web.ASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly BooksRepository _repo;

        public HomeController()
        {
            _repo = new BooksRepository();
        }

        public ActionResult Index()
        {
            return View(_repo.GetAll(""));
        }
    }
}