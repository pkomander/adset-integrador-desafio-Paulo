using AdsetIntegrador.Domain;
using AdsetIntegrador.DTO.Carro;
using AdsetIntegrador.DTO.CarroFoto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdsetIntegrador.Repository.Profiles
{
    public class CarroFotoProfile : Profile
    {
        public CarroFotoProfile()
        {
            CreateMap<CreateCarroFotoDto, CarroFoto>();
            CreateMap<CarroFoto, ReadCarroFotoDto>();
            CreateMap<UpdateCarroFotoDto, CarroFoto>();
        }
    }
}
