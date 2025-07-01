using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Database.InMemory.Data;
using Warehouse.Database.InMemory.Entities;

namespace Warehouse.Database.InMemory.Repositories.Impl
{
    public class PalleteRepositoryImpl : IPalleteRepository
    {
        private readonly AppDbContext _context;
        public PalleteRepositoryImpl(AppDbContext context) 
        {
            _context = context;
        }
        public void Create(PalletEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _context.Pallets.Add(entity);
        }

        public void DeleteById(int ID)
        {
            _context.Boxes
                .Where(b => b.ID == ID)
                .ExecuteDelete();
        }

        public IEnumerable<PalletEntity> GetAll()
        {
            return _context.Pallets.AsNoTracking().ToList();
        }

        public bool SaveChange()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Update(PalletEntity entity, PalletEntity data)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            _context.Pallets
                .Where(e => e.ID == entity.ID)
                .ExecuteUpdate(a => a
                .SetProperty(x => x.Width, data.Width)
                .SetProperty(x => x.Height, data.Height)
                .SetProperty(x => x.Depth, data.Depth)
                .SetProperty(x => x.Weight, data.Weight)
                .SetProperty(x => x.ExpirationDate, data.ExpirationDate)
                );
        }
    }
}
