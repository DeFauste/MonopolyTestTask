namespace Warehouse.ConsoleApp.Dtos
{
    public class BoxCreateDTO
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public double Depth { get; set; }
        public double Weight { get; set; }
        public DateOnly? ProductionDate { get; set; }
        public DateOnly? ExpirationDate { get; set; }
        public int PalleteId { get; set; }
    }
}
