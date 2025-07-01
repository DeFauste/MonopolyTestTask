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
    public class BoxRepositoryImpl : IBoxRepository
    {
        private readonly AppDbContext _context;

        public BoxRepositoryImpl(AppDbContext context)
        {
            _context = context;
        }
        public void Create(BoxEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _context.Boxes.Add(entity);
        }

        public void DeleteById(int ID)
        {
            _context.Pallets
                .Where(p => p.ID == ID)
                .ExecuteDelete();
        }

        public IEnumerable<BoxEntity> GetAll()
        {
            return _context.Boxes.AsNoTracking().ToList();
        }

        public bool SaveChange()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Update(BoxEntity entity, BoxEntity data)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            _context.Boxes
                .Where(e => e.ID == entity.ID)
                .ExecuteUpdate(a => a
                .SetProperty(x => x.Width, data.Width)
                .SetProperty(x => x.Height, data.Height)
                .SetProperty(x => x.Depth, data.Depth)
                .SetProperty(x => x.Weight, data.Weight)
                .SetProperty(x => x.ProductionDate, data.ProductionDate)
                .SetProperty(x => x.ExpirationDate, data.ExpirationDate)
                );
        }
    }
}
