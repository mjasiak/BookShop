using Shop.Common.Repositories;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Shop.WebAPI.Controllers
{
    public class BooksController : ApiController
    {
        private readonly BooksRepository _repo;

        public BooksController()
        {
            _repo = new BooksRepository();
        }

        [HttpGet]
        public IEnumerable<Book> GetAllBooks()
        {
            return _repo.GetAll("").OrderBy(b => b.ReleaseDate);
        }
        [HttpGet]
        public IEnumerable<Book> GetSpecificBooksType(int type)
        {
            IEnumerable<Book> books;
            if (type == 1) books = _repo.GetAudiobooks("");
            else if (type == 2) books = _repo.GetEbooks("");
            else return null;

            return books.OrderBy(b => b.ReleaseDate);
        }
        [HttpGet]
        public IEnumerable<Book> GetPartOfTitle(String searchString)
        {
            return _repo.GetTitleContains(searchString);
        }
        [HttpGet]
        public IEnumerable<Book> GetBooksThroughPublishers(String searchString)
        {
            return _repo.GetThroughPublishers(searchString);
        }
    }

}
