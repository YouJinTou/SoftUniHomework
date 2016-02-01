﻿using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Models
{
    public class Category
    {
        private ICollection<Product> products;

        public Category()
        {
            this.products = new HashSet<Product>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        public string Name { get; set; }

        public virtual ICollection<Product> Products
        {
            get { return this.products; }
            set { this.products = value; }
        }
    }
}
