using AdsetIntegrador.Domain;
using AdsetIntegrador.DTO.Carro;
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
    public class FotoRepository : IFotoService
    {
        private readonly IGenericService _genericService;
        private readonly Context _context;
        private readonly IMapper _mapper;

        public FotoRepository(IGenericService genericService, Context context, IMapper mapper)
        {
            _genericService = genericService;
            _context = context;
            _mapper = mapper;
        }

        public async Task<ReadFotoDto> Create(CreateFotoDto fotoDto)
        {
            try
            {
                var foto = _mapper.Map<Foto>(fotoDto);
                _genericService.Add<Foto>(foto);
                await _genericService.SaveChangesAsync();

                return _mapper.Map<ReadFotoDto>(foto);
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
                var foto = await _context.Fotos.FirstOrDefaultAsync(x => x.FotoId == id);

                if (foto == null)
                    return false;

                var fotos = await _context.carroFotos.Where(x => x.CarroId == foto.FotoId).ToListAsync();

                if (fotos.Any())
                    _genericService.DeleteRange<CarroFoto>(fotos.ToArray());

                _genericService.Delete<Foto>(foto);
                await _genericService.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
