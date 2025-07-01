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

            var listPallete = palleteService.GetAll();
            foreach (var item in listPallete)
            {
                Console.WriteLine($"Pallete - {item.ID}");
                foreach (var p in item.Boxes)
                {
                    Console.WriteLine(p.ToString());
                }
            }


            var listBox = boxService.GetAll();
            foreach (var item in listBox)
            {
                Console.WriteLine(item);
            }

        }
    }
}