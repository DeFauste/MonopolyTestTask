using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        public void Update(int ID , PalleteCreateDTO dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }
            var entity = _repository.GetById(ID);

            if(entity == null)
            {
                throw new ArgumentException($"The pallet with this {ID} was not found");
            }
            var entityForUpdate = _mapper.Map<PalletEntity>(dto);
            _repository.Update(entity, entityForUpdate);
            _repository.SaveChange();
        }
    }
}
