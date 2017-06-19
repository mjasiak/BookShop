using System;
using System.ComponentModel.DataAnnotations;

namespace Shop.Data.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [MaxLength(75)]
        public String Name { get; set; }

        [MaxLength(75)]
        public String Author { get; set; }
        [MaxLength(75)]
        public String Publisher { get; set; }

        public Decimal Price { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }
        public short Type { get; set; }

        public bool SuperBargain { get; set; }
    }
}
