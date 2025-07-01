using Microsoft.EntityFrameworkCore;
using Warehouse.Database.InMemory.Data;
using Warehouse.Database.InMemory.Entities;

namespace Warehouse.Database.InMemory.Repositories.Impl
{
    public class BoxRepositoryImpl : IBoxRepository
    {
        private readonly AppDbInMemoryContext _context;

        public BoxRepositoryImpl(AppDbInMemoryContext context)
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

        public BoxEntity GetById(int ID)
        {
            return _context.Boxes
                .AsNoTracking()
                .FirstOrDefault(c => c.ID == ID);
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
            var boxe = _context.Boxes.FirstOrDefault(a => a.ID == entity.ID);
            if (boxe == null)
            {
                throw new AbandonedMutexException(nameof(boxe));
            }
            boxe.Width = data.Width;
            boxe.Height = data.Height;
            boxe.Depth = data.Depth;
            boxe.Weight = data.Weight;
            boxe.ProductionDate = data.ProductionDate;
            boxe.ExpirationDate = data.ExpirationDate;
        }
    }
}
