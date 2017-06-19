using Shop.Data.Models;
using System.Data.Entity;

namespace Shop.Data
{
    public class ShopContext : DbContext
    {
        public ShopContext() : base("name=ShopContext") { }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Carrier> Carriers { get; set; }
        public virtual DbSet<Cover> Covers { get; set; }
        public virtual DbSet<Edition> Editions { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
    }
}
