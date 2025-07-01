using AutoMapper;
using Warehouse.ConsoleApp.Data;
using Warehouse.ConsoleApp.Dtos.Mapper;
using Warehouse.ConsoleApp.Services;
using Warehouse.Database.InMemory.Data;
using Warehouse.Database.InMemory.Repositories;
using Warehouse.Database.InMemory.Repositories.Impl;

internal class Program
{
    private static void Main(string[] args)
    {
        using (var db = new AppDbInMemoryContext())
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile(new AutoMapperProfile()));
            var mapper = new Mapper(config);

            IPalleteRepository palleteRepository = new PalleteRepositoryImpl(db);
            IBoxRepository boxRepository = new BoxRepositoryImpl(db);

            var boxService = new BoxServices(boxRepository, palleteRepository, mapper);
            var palleteService = new PalleteService(palleteRepository, mapper);

            var preparatoryDatabase = new PrepDb(boxService, palleteService);


            Console.WriteLine("Display groups of pallets sorted by Date\n");
            var groupesPallete = palleteService.GroupPalletsByExpirationDate();
            foreach (var groupe in groupesPallete)
            {
                Console.WriteLine($"Expiration Date:{groupe.ExpirationDate}");
                foreach (var pallete in groupe.Pallets)
                {
                    Console.WriteLine($"Pallete ( {pallete} )");
                }
                Console.WriteLine();
            }

            Console.WriteLine("--------------------------------------------------------");

            Console.WriteLine("Display 3 pallets that contain the boxes with the longest shelf life, sorted by increasing volume\n");
            var topThreePallets = palleteService.GetTopThreePalletsWithBigVolume();
            foreach (var pallets in topThreePallets)
            {
                Console.WriteLine(pallets);
            }


        }
    }
}