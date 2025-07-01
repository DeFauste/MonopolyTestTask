using Warehouse.ConsoleApp.Dtos;
using Warehouse.ConsoleApp.Services;
using Warehouse.Database.InMemory.Data;
using Warehouse.Database.InMemory.Entities;
using Warehouse.Database.InMemory.Repositories;
using Warehouse.Database.InMemory.Repositories.Impl;

namespace Warehouse.ConsoleApp.Data
{
    public class PrepDb
    {
        public PrepDb(BoxServices boxServices, PalleteService palleteService)
        {
            SeedData(boxServices, palleteService);
        }
        private void SeedData(BoxServices boxServices, PalleteService palleteService)
        {
            CreatePalletes(palleteService);

            CreateBoxes(boxServices);

        }
        private void CreatePalletes(PalleteService palleteService)
        {
            palleteService.Create(new PalleteCreateDTO { Width = 100, Height = 100, Depth = 10 });
            palleteService.Create(new PalleteCreateDTO { Width = 120, Height = 120, Depth = 10 });
            palleteService.Create(new PalleteCreateDTO { Width = 200, Height = 200, Depth = 10 });
        }
        private void CreateBoxes(BoxServices boxServices)
        {
            var date = new DateOnly(2025,07,01);
            boxServices.Create(new BoxCreateDTO {Width = 5, Height = 5, Depth = 5, ProductionDate = date,ExpirationDate = date.AddDays(100), PalleteId = 1 });
            boxServices.Create(new BoxCreateDTO {Width = 5, Height = 5, Depth = 5, ProductionDate = date,ExpirationDate = date.AddDays(100), PalleteId = 2 });
            boxServices.Create(new BoxCreateDTO {Width = 5, Height = 5, Depth = 5, ProductionDate = null,ExpirationDate = date.AddDays(100), PalleteId = 3 });
        }
    }
}
