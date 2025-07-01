namespace Warehouse.ConsoleApp.Dtos
{
    public class PalletGroupDTO
    {
        public DateOnly ExpirationDate { get; set; }
        public List<PalleteReadDTO> Pallets { get; set; }
    }
}
