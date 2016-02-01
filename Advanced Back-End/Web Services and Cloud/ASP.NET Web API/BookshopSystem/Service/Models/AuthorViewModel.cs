using System.Collections.Generic;

namespace BookshopAPI.Models
{
    public class AuthorViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<string> Books { get; set; }
    }
}