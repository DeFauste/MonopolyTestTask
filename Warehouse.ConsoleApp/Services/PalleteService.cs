using AutoMapper;
using Warehouse.ConsoleApp.Dtos;
using Warehouse.Database.InMemory.Entities;
using Warehouse.Database.InMemory.Repositories;

namespace Warehouse.ConsoleApp.Services
{
    public class PalleteService
    {
        private readonly IPalleteRepository _repository;
        private readonly IMapper _mapper;
        public PalleteService(IPalleteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Create(PalleteCreateDTO dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }
            var entity = _mapper.Map<PalletEntity>(dto);
            _repository.Create(entity);
            _repository.SaveChange();
        }
        public void DeleteById(int ID)
        {
            _repository.DeleteById(ID);
            _repository.SaveChange();
        }

        public IEnumerable<PalleteReadDTO> GetAll()
        {
            var listEnity = _repository.GetAll();
            var listDto = _mapper.Map<IEnumerable<PalleteReadDTO>>(listEnity);
            return listDto;
        }
        public void Update(int ID, PalleteCreateDTO dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }
            var entity = _repository.GetById(ID);

            if (entity == null)
            {
                throw new ArgumentException($"The pallet with this {ID} was not found");
            }
            var entityForUpdate = _mapper.Map<PalletEntity>(dto);
            _repository.Update(entity, entityForUpdate);
            _repository.SaveChange();
        }
        public IEnumerable<PalletGroupDTO> GroupPalletsByExpirationDate()
        {
            var pallete = GetAll();
            var groupePallete = pallete
               .GroupBy(p => p.ExpirationDate)
            .OrderBy(g => g.Key)
            .Select(g => new PalletGroupDTO
            {
                ExpirationDate = g.Key,
                Pallets = g.OrderBy(p => p.Weight).ToList()
            })
            .ToList();
            return groupePallete;
        }

        public IEnumerable<PalleteReadDTO> GetTopThreePalletsWithBigVolume()
        {
            var pallets = GetAll();

            var allBoxes = pallets
                .SelectMany(p => p.Boxes.Select(b => new
                {
                    Box = b,
                    PalleteId = p.ID,
                    b.ExpirationDate
                }));


            var topBoxesExpirationDate = allBoxes
                .GroupBy(x => x.PalleteId)
                .Select(g => g.OrderByDescending(x => x.ExpirationDate).First())
                .OrderByDescending(x => x.ExpirationDate)
                .Take(3)
                .Select(x => x.Box.PalleteId)
                .ToList();

            var topPallets = pallets
                .Where(p => topBoxesExpirationDate.Contains(p.ID))
                .OrderByDescending(x => x.Volume)
                .ToList();

            return topPallets;
        }
    }
}
