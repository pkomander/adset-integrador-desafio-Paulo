using AdsetIntegrador.Domain;
using AdsetIntegrador.DTO.Carro;
using AdsetIntegrador.DTO.Foto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdsetIntegrador.Repository.Profiles
{
    public class FotoProfile : Profile
    {
        public FotoProfile()
        {
            CreateMap<CreateFotoDto, Foto>();
            CreateMap<Foto, ReadFotoDto>();
            CreateMap<UpdateFotoDto, Foto>();
        }
    }
}
