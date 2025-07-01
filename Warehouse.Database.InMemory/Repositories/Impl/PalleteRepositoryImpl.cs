using Microsoft.EntityFrameworkCore;
using Warehouse.Database.InMemory.Data;
using Warehouse.Database.InMemory.Entities;

namespace Warehouse.Database.InMemory.Repositories.Impl
{
    public class PalleteRepositoryImpl : IPalleteRepository
    {
        private readonly AppDbInMemoryContext _context;
        public PalleteRepositoryImpl(AppDbInMemoryContext context) 
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
            var pallets = _context.Pallets.AsNoTracking().ToList();
            foreach (var pallet in pallets)
            {
                var boxes = _context.Boxes.AsNoTracking().Where(b => b.PalleteId == pallet.ID).ToList();   
                pallet.Boxes = boxes;
            }
            return pallets;
        }

        public PalletEntity GetById(int ID)
        {
            var pallet = _context.Pallets
                .AsNoTracking()
                .FirstOrDefault(c => c.ID == ID);
            if(pallet != null)
            {
                pallet.Boxes = _context.Boxes.AsNoTracking().Where(b => b.PalleteId == pallet.ID).ToList();
            }
            return pallet;
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

            var pallete = _context.Pallets.FirstOrDefault(a => a.ID == entity.ID);
            if (pallete == null)
            {
                throw new AbandonedMutexException(nameof(pallete));
            }
            pallete.Width = data.Width;
            pallete.Height = data.Height;
            pallete.Depth = data.Depth;
            pallete.Weight = data.Weight;
            pallete.ExpirationDate = data.ExpirationDate;
        }
    }
}
