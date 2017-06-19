using Shop.Data.Models;
using System;
using System.Collections.Generic;

namespace Shop.Web.DTO
{
    [Serializable]
    public class AdditionsDTO
    {
        public IEnumerable<Carrier> Carriers { get; set; }
        public IEnumerable<Cover> Covers { get; set; }
        public IEnumerable<Publisher> Publishers { get; set; }
        public IEnumerable<Edition> Editions { get; set; }
    }
}