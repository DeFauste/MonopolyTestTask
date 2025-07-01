using Warehouse.ConsoleApp.Dtos;
using Warehouse.ConsoleApp.Services;

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
            palleteService.Create(new PalleteCreateDTO { Width = 201, Height = 210, Depth = 10 });
        }
        private void CreateBoxes(BoxServices boxServices)
        {

            boxServices.Create(new BoxCreateDTO { Width = 5, Height = 5, Depth = 5, Weight = 3, ProductionDate = new DateOnly(2025, 01, 01), ExpirationDate = new DateOnly(2025, 01, 02), PalleteId = 1 });
            boxServices.Create(new BoxCreateDTO { Width = 5, Height = 5, Depth = 5, Weight = 5, ProductionDate = new DateOnly(2025, 06, 01), ExpirationDate = null, PalleteId = 1 });
            boxServices.Create(new BoxCreateDTO { Width = 5, Height = 5, Depth = 5, Weight = 3, ProductionDate = new DateOnly(2025, 04, 01), ExpirationDate = null, PalleteId = 1 });
            boxServices.Create(new BoxCreateDTO { Width = 5, Height = 5, Depth = 5, Weight = 3, ProductionDate = new DateOnly(2025, 03, 01), ExpirationDate = null, PalleteId = 1 });

            boxServices.Create(new BoxCreateDTO { Width = 5, Height = 5, Depth = 5, Weight = 23, ProductionDate = new DateOnly(2025, 01, 01), ExpirationDate = null, PalleteId = 2 });
            boxServices.Create(new BoxCreateDTO { Width = 5, Height = 5, Depth = 5, Weight = 3, ProductionDate = null, ExpirationDate = new DateOnly(2025, 01, 02), PalleteId = 2 });
            boxServices.Create(new BoxCreateDTO { Width = 5, Height = 5, Depth = 5, Weight = 23, ProductionDate = new DateOnly(2025, 07, 01), ExpirationDate = null, PalleteId = 2 });
            boxServices.Create(new BoxCreateDTO { Width = 5, Height = 5, Depth = 5, Weight = 3, ProductionDate = new DateOnly(2025, 02, 01), ExpirationDate = null, PalleteId = 2 });

            boxServices.Create(new BoxCreateDTO { Width = 5, Height = 5, Depth = 5, Weight = 1, ProductionDate = new DateOnly(2025, 02, 01), ExpirationDate = null, PalleteId = 3 });
            boxServices.Create(new BoxCreateDTO { Width = 5, Height = 5, Depth = 5, Weight = 1, ProductionDate = new DateOnly(2025, 02, 11), ExpirationDate = null, PalleteId = 3 });
            boxServices.Create(new BoxCreateDTO { Width = 5, Height = 5, Depth = 5, Weight = 1, ProductionDate = new DateOnly(2025, 04, 01), ExpirationDate = null, PalleteId = 3 });
            boxServices.Create(new BoxCreateDTO { Width = 5, Height = 5, Depth = 5, Weight = 1, ProductionDate = null, ExpirationDate = new DateOnly(2025, 08, 02), PalleteId = 3 });

            boxServices.Create(new BoxCreateDTO { Width = 5, Height = 5, Depth = 5, Weight = 1, ProductionDate = new DateOnly(2025, 07, 01), ExpirationDate = null, PalleteId = 4 });
            boxServices.Create(new BoxCreateDTO { Width = 5, Height = 5, Depth = 5, Weight = 1, ProductionDate = new DateOnly(2025, 02, 11), ExpirationDate = null, PalleteId = 4 });
            boxServices.Create(new BoxCreateDTO { Width = 5, Height = 5, Depth = 5, Weight = 1, ProductionDate = new DateOnly(2025, 10, 01), ExpirationDate = null, PalleteId = 4 });
            boxServices.Create(new BoxCreateDTO { Width = 5, Height = 5, Depth = 5, Weight = 1, ProductionDate = null, ExpirationDate = new DateOnly(2025, 08, 02), PalleteId = 4 });
        }
    }
}
