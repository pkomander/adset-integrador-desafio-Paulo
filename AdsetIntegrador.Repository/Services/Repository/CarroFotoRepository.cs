using AdsetIntegrador.Domain;
using AdsetIntegrador.DTO.CarroFoto;
using AdsetIntegrador.DTO.Foto;
using AdsetIntegrador.Repository.Data;
using AdsetIntegrador.Repository.Services.Interface;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdsetIntegrador.Repository.Services.Repository
{
    public class CarroFotoRepository : ICarroFotoService
    {
        private readonly IGenericService _genericService;
        private readonly IFotoService _fotoService;
        private readonly Context _context;
        private readonly IMapper _mapper;

        public CarroFotoRepository(IGenericService genericService, Context context, IMapper mapper, IFotoService fotoService)
        {
            _genericService = genericService;
            _context = context;
            _mapper = mapper;
            _fotoService = fotoService;
        }

        public async Task<ReadCarroFotoDto> Create(CreateCarroFotoDto carroFotoDto)
        {
            try
            {
                var carroFoto = _mapper.Map<CarroFoto>(carroFotoDto);
                _genericService.Add<CarroFoto>(carroFoto);
                await _genericService.SaveChangesAsync();

                return _mapper.Map<ReadCarroFotoDto>(carroFoto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<CarroFoto>> Delete(int id)
        {
            try
            {
                var fotos = await _context.carroFotos.Where(x => x.CarroId == id).ToListAsync();

                foreach (var item in fotos)
                {
                    var filePath = Path.Combine("wwwroot/uploads", item.Foto.Nome).Replace("\\", "/").Replace(" ", string.Empty);

                    if (System.IO.File.Exists(filePath))
                    {
                        // Deleta o arquivo
                        System.IO.File.Delete(filePath);
                    }
                }

                if (fotos.Any())
                {
                    _genericService.DeleteRange<CarroFoto>(fotos.ToArray());
                    await _genericService.SaveChangesAsync();
                    return fotos;
                }

                return fotos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
