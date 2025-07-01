using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Database.InMemory.Entities;

namespace Warehouse.Database.InMemory.Repositories
{
    public interface IPalleteRepository : IRepository<PalletEntity, int>
    {
    }
}
