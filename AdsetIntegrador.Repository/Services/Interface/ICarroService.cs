using AdsetIntegrador.Domain;
using AdsetIntegrador.DTO.Carro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdsetIntegrador.Repository.Services.Interface
{
    public interface ICarroService
    {
        Task<ReadCarroDto> Create(CreateCarroDto carroDto);
        Task<ReadCarroDto> FindById(int? id);
        Task<List<ReadCarroDto>> FindAll();
        Task<List<ReadCarroDto>> FindFiltro(string? placa, string? marca, string? modelo, string? anoMin, string? anoMax, string? preco, string? foto, string? opcionais, string? cor);
        Task<ReadCarroDto> Update(int id, UpdateCarroDto personDto);
        Task<bool> Delete(int? id);
    }
}
