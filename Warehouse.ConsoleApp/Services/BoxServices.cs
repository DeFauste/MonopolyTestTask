using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.ConsoleApp.Dtos;
using Warehouse.ConsoleApp.Utils;
using Warehouse.Database.InMemory.Entities;
using Warehouse.Database.InMemory.Repositories;

namespace Warehouse.ConsoleApp.Services
{
    public class BoxServices
    {
        private readonly IBoxRepository _boxRepository;
        private readonly IPalleteRepository _palleteRepository;
        private readonly IMapper _mapper;
        public BoxServices(IBoxRepository boxRepository,IPalleteRepository palleteRepository, IMapper mapper)
        {
            _boxRepository = boxRepository;
            _palleteRepository = palleteRepository;
            _mapper = mapper;
        }

        public void Create(BoxCreateDTO boxDto, int daysBeforeExpiration = 100)
        {
            if (boxDto == null)
            {
                throw new ArgumentNullException(nameof(boxDto));
            }

            var entityPallete = _palleteRepository.GetById(boxDto.PalleteId);
            if (entityPallete == null)
            {
                throw new ArgumentException($"The pallete with this {boxDto.PalleteId} was not found");
            }
            if (!entityPallete.CheckCapacity(boxDto))
            {
                throw new ArgumentException($"A box ( {boxDto} ) is bigger than a pallet");
            }
            boxDto.CalculateDate(daysBeforeExpiration);

            entityPallete.Weight += boxDto.Weight;
            entityPallete.UpdatekExpirationDate(boxDto.ExpirationDate.Value);
            Console.WriteLine(entityPallete.ExpirationDate.Value);
            _palleteRepository.Update(entityPallete, entityPallete);
            _palleteRepository.SaveChange();

            var entity = _mapper.Map<BoxEntity>(boxDto);
            _boxRepository.Create(entity);
            _boxRepository.SaveChange();

        }
        public void DeleteById(int ID)
        {
            _boxRepository.DeleteById(ID);
            _boxRepository.SaveChange();
        }

        public IEnumerable<BoxReadDTO> GetAll()
        {
            var listEnity = _boxRepository.GetAll();
            var listDto = _mapper.Map<IEnumerable<BoxReadDTO>>(listEnity);
            return listDto;
        }

        public void Update(int ID, BoxCreateDTO dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            var entityBox = _boxRepository.GetById(ID);
            if (entityBox == null)
            {
                throw new ArgumentException($"The box with this {ID} was not found");
            }

            var entityPallete = _palleteRepository.GetById(ID);
            if (entityPallete == null)
            {
                throw new ArgumentException($"The pallete with this {ID} was not found");
            }

            var entityForUpdate = _mapper.Map<BoxEntity>(dto);
            _boxRepository.Update(entityBox, entityForUpdate);
            _boxRepository.SaveChange();
        }
    }
}
