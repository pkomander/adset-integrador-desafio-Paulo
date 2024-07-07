using AdsetIntegrador.Domain;
using AdsetIntegrador.DTO.Carro;
using AdsetIntegrador.DTO.CarroFoto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdsetIntegrador.Repository.Services.Interface
{
    public interface ICarroFotoService
    {
        Task<ReadCarroFotoDto> Create(CreateCarroFotoDto carroFotoDto);
        Task<List<CarroFoto>> Delete(int id);
    }
}
