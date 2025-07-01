using Warehouse.ConsoleApp.Dtos;

namespace Warehouse.ConsoleApp.Utils
{
    public static class BoxExtenstions
    {
        public static void CalculateDate(this BoxCreateDTO box, int daysBeforeExpiration)
        {
            if (box == null)
            {
                throw new ArgumentNullException(nameof(box));
            }
            if (box.ExpirationDate == null && box.ProductionDate == null)
            {
                throw new ArgumentException($"Specify the Expiration Date or Production Date");
            }
            if (box.ProductionDate != null && box.ExpirationDate == null)
            {
                var expirationDate = box.ProductionDate.Value.AddDays(daysBeforeExpiration);
                box.ExpirationDate = expirationDate;
            }
            if (box.ProductionDate == null && box.ExpirationDate != null)
            {
                var expirationDate = box.ExpirationDate.Value.AddDays(-daysBeforeExpiration);
                box.ProductionDate = expirationDate;
            }
        }
    }
}
