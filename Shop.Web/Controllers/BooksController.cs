using Newtonsoft.Json;
using Shop.Web.ASP.Repositories;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Shop.Web.Controllers
{
    public class BooksController : Controller
    {
        private readonly BooksRepository _repo;

        public BooksController()
        {
            _repo = new BooksRepository();
        }

        [HttpGet]
        public string GetAll(String searchString)
        {
            return JsonConvert.SerializeObject(_repo.GetAll(searchString).ToArray());
        }
        [HttpGet]
        public string GetOnlyAudiobooks(String searchString)
        {
            return JsonConvert.SerializeObject(_repo.GetAudiobooks(searchString).ToArray());
        }
        [HttpGet]
        public string GetOnlyEbooks(String searchString)
        {
            return JsonConvert.SerializeObject(_repo.GetEbooks(searchString).ToArray());
        }
        [HttpGet]
        public string GetNews(String searchString)
        {
            return JsonConvert.SerializeObject(_repo.GetNews(searchString).ToArray());
        }
        [HttpGet]
        public string GetPreviews(String searchString)
        {
            return JsonConvert.SerializeObject(_repo.GetPreviews(searchString).ToArray());
        }
        [HttpGet]
        public string GetSuperBargains(String searchString)
        {
            return JsonConvert.SerializeObject(_repo.GetSuperBargains(searchString).ToArray());
        }

        private static bool IsNotEmpty(string searchString)
        {
            return searchString != null || searchString == "";
        }
    }
}