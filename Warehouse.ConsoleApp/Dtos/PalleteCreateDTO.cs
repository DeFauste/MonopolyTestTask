using System.ComponentModel.DataAnnotations;

namespace Warehouse.ConsoleApp.Dtos
{
    public class PalleteCreateDTO
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public double Depth { get; set; }
        public double Weight { get; set; } = 30;
    }
}
