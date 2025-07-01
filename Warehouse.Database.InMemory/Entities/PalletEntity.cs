using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse.Database.InMemory.Entities
{
    public class PalletEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Depth { get; set; }
        public double Weight { get; set; }
        public DateOnly? ExpirationDate { get; set; } = null;
        public List<BoxEntity> Boxes { get; set; } = new();

    }
}
