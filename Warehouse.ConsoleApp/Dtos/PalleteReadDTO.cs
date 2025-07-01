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
        public List<BoxReadDTO> Boxes { get; set; }
        public double Volume { get => CulcVolume(); }
        private double CulcVolume()
        {
            double result = 0;
            foreach (var box in Boxes)
            {
                result += box.Volume;
            }
            result += Width * Height * Depth;
            return result;
        }
        public override string ToString()
        {
            return $"ID: {ID}, Width: {Width}, Height: {Height}, Depth: {Depth}, Weight: {Weight}, ExpirationDate: {ExpirationDate}, Volume: {Volume}";
        }
    }
}
