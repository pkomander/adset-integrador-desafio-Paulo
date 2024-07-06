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
        private readonly Context _context;
        private readonly IMapper _mapper;

        public CarroFotoRepository(IGenericService genericService, Context context, IMapper mapper)
        {
            _genericService = genericService;
            _context = context;
            _mapper = mapper;
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

        public async Task<bool> Delete(int id)
        {
            try
            {
                //var foto = await _context.Carros.FirstOrDefaultAsync(x => x.FotoId == id);

                //if (foto == null)
                //    return false;

                //var fotos = await _context.carroFotos.Where(x => x.CarroId == foto.FotoId).ToListAsync();

                //if (fotos.Any())
                //    _genericService.DeleteRange<CarroFoto>(fotos.ToArray());

                //_genericService.Delete<Foto>(foto);
                //await _genericService.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
