using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BookWorm.Api
{
    
    public class BookDto
    {
        public string Id { get; set; } 
        public string Title { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public string Author { get; set; }
        public int TotalItemsInCart { get; set; }

        public bool IsSaved { get; set; }
    }

    
}
