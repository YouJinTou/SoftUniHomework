using System;
using System.Collections.Generic;

namespace BookshopAPI.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int AuthorId { get; set; }
        public decimal Price { get; set; }
        public int Copies { get; set; }
        public int Edition { get; set; }
        public IEnumerable<string> Categories { get; set; }
        public int AgeRestriction { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}