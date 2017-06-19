using System;
using System.ComponentModel.DataAnnotations;

namespace Shop.Data.Models
{
    public class Carrier
    {
        [Key]
        public int CarrierId { get; set; }
        public String Name { get; set; }
    }
}
