using Microsoft.EntityFrameworkCore;
using MyFirstAspireApp.ApiService.Models;

namespace MyFirstAspireApp.ApiService.Data
{
    public class VegetablesShopContext : DbContext
    {
        public VegetablesShopContext(DbContextOptions<VegetablesShopContext> options): base(options) { }
        public DbSet<Vegetable> Vegetables => Set<Vegetable>();
    }
}
