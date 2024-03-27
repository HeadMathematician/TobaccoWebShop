using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using TobaccoWebShop.Enums;

namespace TobaccoWebShop.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public CategoryEnum Category { get; set; }
        [ValidateNever]  
        
        public string? Image { get; set; }
        
    }
}
