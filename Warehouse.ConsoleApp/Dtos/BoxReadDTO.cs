namespace Warehouse.ConsoleApp.Dtos
{
    public class BoxReadDTO
    {
        public int ID { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Depth { get; set; }
        public double Weight { get; set; }
        public DateOnly ProductionDate { get; set; }
        public DateOnly ExpirationDate { get; set; }
        public int PalleteId { get; set; }
        public double Volume { get => Width * Height * Depth; }

        public override string ToString()
        {
            return $"ID: {ID}, Width: {Width}, Height: {Height}, Depth: {Depth}, Weight: {Weight}, ProductionDate:  {ProductionDate}, ExpirationDate: {ExpirationDate}, PalleteId: {PalleteId}";
        }
    }
}
