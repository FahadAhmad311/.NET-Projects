using Microsoft.EntityFrameworkCore;
using MyFirstAspireApp.ApiService.Data;
using MyFirstAspireApp.ApiService.Models;
namespace MyFirstAspireApp.ApiService.Services
{
    public class VegetableService : IVegetableService
    {
        private readonly VegetablesShopContext _context;

        public VegetableService(VegetablesShopContext context)
        {
            _context = context;
        }

        public async Task<List<Vegetable>> GetVegetables()
        {
            return await _context.Vegetables.ToListAsync();
        }

        public async Task<Vegetable?> GetVegetable(int id)
        {
            return await _context.Vegetables.FindAsync(id);
        }

        public async Task<Vegetable> CreateVegetable(Vegetable vegetable)
        {
            _context.Vegetables.Add(vegetable);
            await _context.SaveChangesAsync();
            return vegetable;
        }

        public async Task<bool> UpdateVegetable(int id, Vegetable vegetable)
        {
            var existingVegetable = await _context.Vegetables.FindAsync(id);
            if (existingVegetable == null) return false;
            existingVegetable.Name = vegetable.Name;
            existingVegetable.Price = vegetable.Price;
            existingVegetable.StockQuantity = vegetable.StockQuantity;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteVegetable(int id)
        {
            var existingVegetable = await _context.Vegetables.FindAsync(id);
            if (existingVegetable == null) return false;
            _context.Vegetables.Remove(existingVegetable);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
