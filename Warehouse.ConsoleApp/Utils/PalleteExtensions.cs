using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.ConsoleApp.Dtos;
using Warehouse.Database.InMemory.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Warehouse.ConsoleApp.Utils
{
    public static class PalleteExtensions
    {
        public static bool CheckCapacity(this PalletEntity pallete, BoxCreateDTO boxDto)
        {
            if(pallete == null)
            {
                throw new ArgumentNullException(nameof(pallete));
            }
            if (boxDto == null)
            {
                throw new ArgumentNullException(nameof(boxDto));
            }


            if(pallete.Width < boxDto.Width || pallete.Depth < boxDto.Depth)
            {
               return false;
            }

            return true;
        }

        public static void UpdatekExpirationDate(this PalletEntity palletEntity, DateOnly dateExpiration)
        {
            if(palletEntity == null)
            {
                throw new ArgumentNullException(nameof(palletEntity));
            }
            if (palletEntity.ExpirationDate == null || dateExpiration < palletEntity.ExpirationDate)
            {
                palletEntity.ExpirationDate = dateExpiration;
            }
        }
    }
}
