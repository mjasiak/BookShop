using Shop.Data;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Common.Repositories
{
    public class BooksRepository
    {
        private readonly ShopContext _context;

        public BooksRepository()
        {
            _context = new ShopContext();
        }

        public IEnumerable<Book> GetAll(String searchString)
        {
            if (IsNotEmpty(searchString))
                return _context.Books.Where(b => b.Author.Contains(searchString) || b.Name.Contains(searchString)).OrderBy(b => b.Name).AsEnumerable();
            else
                return _context.Books.OrderBy(b => b.Name).AsEnumerable();
        }

        public IEnumerable<Book> GetAudiobooks(String searchString)
        {
            if (IsNotEmpty(searchString))
                return _context.Books.Where(b => b.Type == 1 && (b.Author.Contains(searchString) || b.Name.Contains(searchString))).OrderBy(b => b.Name).AsEnumerable();
            else
                return _context.Books.Where(b => b.Type == 1).OrderBy(b => b.Name).AsEnumerable();
        }

        public IEnumerable<Book> GetEbooks(String searchString)
        {
            if (IsNotEmpty(searchString))
                return _context.Books.Where(b => b.Type == 2 && (b.Author.Contains(searchString) || b.Name.Contains(searchString))).OrderBy(b => b.Name).AsEnumerable();
            else
                return _context.Books.Where(b => b.Type == 2).OrderBy(b => b.Name).AsEnumerable();
        }

        public IEnumerable<Book> GetNews(String searchString)
        {
            var substractedDate = DateTime.Now.AddDays(-14);
            if (IsNotEmpty(searchString))
                return _context.Books.Where(b => (b.ReleaseDate <= DateTime.Now && b.ReleaseDate >= substractedDate) && (b.Author.Contains(searchString) || b.Name.Contains(searchString))).OrderBy(b => b.Name).AsEnumerable();
            else
                return _context.Books.Where(b => b.ReleaseDate <= DateTime.Now && b.ReleaseDate >= substractedDate).OrderBy(b => b.Name).AsEnumerable();
        }

        public IEnumerable<Book> GetPreviews(String searchString)
        {
            var addedDate = DateTime.Now.AddDays(14);
            if (IsNotEmpty(searchString))
                return _context.Books.Where(b => (b.ReleaseDate >= DateTime.Now && b.ReleaseDate <= addedDate) && (b.Author.Contains(searchString) || b.Name.Contains(searchString))).OrderBy(b => b.Name).AsEnumerable();
            else
                return _context.Books.Where(b => b.ReleaseDate >= DateTime.Now && b.ReleaseDate <= addedDate).OrderBy(b => b.Name).AsEnumerable();
        }

        public IEnumerable<Book> GetSuperBargains(String searchString)
        {
            if (IsNotEmpty(searchString))
                return _context.Books.Where(b => b.SuperBargain == true && (b.Author.Contains(searchString) || b.Name.Contains(searchString))).OrderBy(b => b.Name).AsEnumerable();
            else
                return _context.Books.Where(b => b.SuperBargain == true).OrderBy(b => b.Name).AsEnumerable();
        }

        public IEnumerable<Book> GetTitleContains(String searchString)
        {
            if (IsNotEmpty(searchString))
                return _context.Books.Where(b => b.Name.Contains(searchString)).OrderBy(b => b.ReleaseDate).AsEnumerable();
            else
                return null;
        }

        public IEnumerable<Book> GetThroughPublishers(String searchString)
        {
            if (IsNotEmpty(searchString))
                return _context.Books.Where(b => b.Publisher.Contains(searchString)).OrderBy(b => b.ReleaseDate).AsEnumerable();
            else
                return null;
        }

        private static bool IsNotEmpty(string searchString)
        {
            return searchString != null || searchString == "";
        }
    }
}