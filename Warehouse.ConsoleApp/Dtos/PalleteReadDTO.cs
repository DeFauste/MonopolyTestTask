using Warehouse.Database.InMemory.Entities;

namespace Warehouse.ConsoleApp.Dtos
{
    public class PalleteReadDTO
    {
        public int ID { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Depth { get; set; }
        public double Weight { get; set; }
        public DateOnly ExpirationDate { get; set; }
        public List<BoxEntity> Boxes { get; set; }
        public override string ToString()
        {
            return $"ID: {ID}, Width: {Width}, Height: {Height}, Depth: {Depth}, Weight: {Weight}, ExpirationDate: {ExpirationDate}";
        }
    }
}
