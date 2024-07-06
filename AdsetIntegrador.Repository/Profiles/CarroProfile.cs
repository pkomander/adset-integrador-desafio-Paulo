using AdsetIntegrador.Domain;
using AdsetIntegrador.DTO.Carro;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdsetIntegrador.Repository.Profiles
{
    public class CarroProfile : Profile
    {
        public CarroProfile()
        {
            CreateMap<CreateCarroDto, Carro>();
            CreateMap<Carro, ReadCarroDto>();
            CreateMap<UpdateCarroDto, Carro>();
        }
    }
}
