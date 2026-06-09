using Microsoft.EntityFrameworkCore;

namespace MyFirstAspireApp.ApiService.Models
{
    public class Vegetable
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        [Precision(18, 2)]
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
    }
}
