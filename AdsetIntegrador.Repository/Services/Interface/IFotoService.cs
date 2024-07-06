using AdsetIntegrador.DTO.Carro;
using AdsetIntegrador.DTO.Foto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdsetIntegrador.Repository.Services.Interface
{
    public interface IFotoService
    {
        Task<ReadFotoDto> Create(CreateFotoDto fotoDto);
        Task<bool> Delete(int id);
    }
}
