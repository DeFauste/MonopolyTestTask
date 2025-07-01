using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse.Database.InMemory.Entities
{
    public class BoxEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Depth { get; set; }
        public double Weight { get; set; }
        public DateOnly ProductionDate { get; set; }
        public DateOnly ExpirationDate { get; set; }
        public int PalleteId { get; set; }
        public PalletEntity Pallete { get; set; }
    }
}
