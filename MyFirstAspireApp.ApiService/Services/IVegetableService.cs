using MyFirstAspireApp.ApiService.Models;

namespace MyFirstAspireApp.ApiService.Services
{
    public interface IVegetableService
    {
        Task<List<Vegetable>> GetVegetables();
        Task<Vegetable?> GetVegetable(int id);
        Task<Vegetable> CreateVegetable(Vegetable vegetable);
        Task<bool> UpdateVegetable(int id, Vegetable vegetable);
        Task<bool> DeleteVegetable(int id);
    }
}
