using MyFirstAspireApp.ApiService.Services;
using MyFirstAspireApp.ApiService.Models;
using System.Runtime.CompilerServices;

namespace MyFirstAspireApp.ApiService.Endpoints
{
    public static class VegetableEndpoints
    {
        public static void MapVegetableEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/vegetables").WithTags("Vegetables");

            group.MapGet("/", async (IVegetableService service) =>
            {
                var vegetables = await service.GetVegetables();
                return Results.Ok(vegetables);
            });

            group.MapGet("/{id:int}", async (int id, IVegetableService service) =>
            {
                var vegetable = await service.GetVegetable(id);
                return vegetable != null ? Results.Ok(vegetable) : Results.NotFound();
            });

            group.MapPost("/", async (Vegetable vegetable, IVegetableService service) =>
            {
                var createdVegetable = await service.CreateVegetable(vegetable);
                return Results.Created($"/api/vegetables/{createdVegetable.Id}", createdVegetable);
            });

            group.MapPut("/{id:int}", async (int id, Vegetable vegetable, IVegetableService service) =>
            {
                var updated = await service.UpdateVegetable(id, vegetable);
                return updated ? Results.NoContent() : Results.NotFound();
            });

            group.MapDelete("/{id:int}", async (int id, IVegetableService service) =>
            {
                var deleted = await service.DeleteVegetable(id);
                return deleted ? Results.NoContent() : Results.NotFound();
            });
        }
    }
}
