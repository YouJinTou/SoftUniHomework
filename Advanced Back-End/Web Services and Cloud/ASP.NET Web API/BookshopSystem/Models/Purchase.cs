using System;

namespace Bookshop.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string User { get; set; }
        public DateTime PurchaseDate { get; set; }
        public bool IsRecalled { get; set; }
    }
}
