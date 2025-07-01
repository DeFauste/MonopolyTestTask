using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Database.InMemory.Entities;

namespace Warehouse.ConsoleApp.Dtos.Mapper
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile() 
        {
            //Source --> Target
            //Pallete
            CreateMap<PalletEntity, PalleteReadDTO>();
            CreateMap<PalleteCreateDTO, PalletEntity>();
            //Boxe
            CreateMap<BoxEntity, BoxReadDTO>();
            CreateMap<BoxCreateDTO, BoxEntity>();
        }
    }
}
