using Newtonsoft.Json;
using Shop.Common.Repositories;
using Shop.Web.DTO;
using System;
using System.Web.Mvc;

namespace Shop.Web.Controllers
{
    public class AdditionsController : Controller
    {
        private readonly AdditionsRepository _repo;

        public AdditionsController()
        {
            _repo = new AdditionsRepository();
        }

        [HttpGet]
        public string GetAdditions(String BookId) //Use BookId to reference Book with additions in future
        {
            return JsonConvert.SerializeObject(new AdditionsDTO
            {
                Carriers = _repo.GetCarriers(),
                Covers = _repo.GetCovers(),
                Publishers = _repo.GetPublishers(),
                Editions = _repo.GetEditions()
            });
        }
    }
}