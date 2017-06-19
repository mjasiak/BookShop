using Shop.Data;
using Shop.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Common.Repositories
{
    public class AdditionsRepository
    {
        private readonly ShopContext _context;

        public AdditionsRepository()
        {
            _context = new ShopContext();
        }

        public IEnumerable<Carrier> GetCarriers()
        {
            return _context.Carriers.AsEnumerable();
        }
        public IEnumerable<Publisher> GetPublishers()
        {
            return _context.Publishers.AsEnumerable();
        }
        public IEnumerable<Edition> GetEditions()
        {
            return _context.Editions.AsEnumerable();
        }
        public IEnumerable<Cover> GetCovers()
        {
            return _context.Covers.AsEnumerable();
        }
    }
}