using AdsetIntegrador.Domain;
using AdsetIntegrador.DTO.Carro;
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
    public class CarroRepository : ICarroService
    {
        private readonly IGenericService _genericService;
        private readonly Context _context;
        private readonly IMapper _mapper;

        public CarroRepository(Context context, IGenericService genericService, IMapper mapper)
        {
            _context = context;
            _genericService = genericService;
            _mapper = mapper;
        }

        public async Task<ReadCarroDto> Create(CreateCarroDto carroDto)
        {
            try
            {
                var carro = _mapper.Map<Carro>(carroDto);
                _genericService.Add<Carro>(carro);
                await _genericService.SaveChangesAsync();

                return _mapper.Map<ReadCarroDto>(carro);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ReadCarroDto>> FindAll()
        {
            try
            {
                var carros = await _context.Carros
                                            .Include(i => i.CarroFotos)
                                            .ThenInclude(i => i.Foto)
                                            .ToListAsync();

                return _mapper.Map<List<ReadCarroDto>>(carros);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ReadCarroDto> FindById(int? id)
        {
            try
            {
                var carro = await _context.Carros.Include(i => i.CarroFotos)
                                          .ThenInclude(i => i.Foto)
                                          .FirstOrDefaultAsync(x => x.CarroId == id);

                return _mapper.Map<ReadCarroDto>(carro);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ReadCarroDto> Update(int id, UpdateCarroDto carroDto)
        {
            try
            {
                var model = await _context.Carros.FirstOrDefaultAsync(x => x.CarroId == id);

                if (model == null)
                    return null;

                var carro = _mapper.Map(carroDto, model);

                _genericService.Update<Carro>(carro);
                await _genericService.SaveChangesAsync();

                return _mapper.Map<ReadCarroDto>(carro);
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
                var carro = await _context.Carros.FirstOrDefaultAsync(x => x.CarroId == id);

                if (carro == null)
                    return false;

                var fotos = await _context.carroFotos.Where(x => x.CarroId == carro.CarroId).ToListAsync();

                if (fotos.Any())
                    _genericService.DeleteRange<CarroFoto>(fotos.ToArray());

                _genericService.Delete<Carro>(carro);
                await _genericService.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ReadCarroDto>> FindFiltro(string? placa, string? marca, string? modelo, string? anoMin, string? anoMax, string? preco, string? foto, string? opcionais, string? cor)
        {
            try
            {
                var query = _context.Carros
                                .Include(i => i.CarroFotos)
                                .ThenInclude(i => i.Foto)
                                .AsQueryable();

                // Aplica filtros baseados nos parâmetros recebidos
                if (!string.IsNullOrEmpty(placa))
                {
                    query = query.Where(c => c.Placa.Contains(placa));
                }

                if (!string.IsNullOrEmpty(marca))
                {
                    query = query.Where(c => c.Marca == marca);
                }

                if (!string.IsNullOrEmpty(modelo))
                {
                    query = query.Where(c => c.Modelo == modelo);
                }

                if (!string.IsNullOrEmpty(anoMin))
                {
                    query = query.Where(c => c.Ano == anoMin);
                }

                if (!string.IsNullOrEmpty(anoMin))
                {
                    query = query.Where(c => c.Ano == anoMax);
                }

                if (!string.IsNullOrEmpty(preco))
                {
                    query = query.Where(c => c.Preco == Convert.ToDecimal(preco));
                }

                if (!string.IsNullOrEmpty(foto))
                {
                    query = query.Where(c => c.CarroFotos.Any());
                }

                if (!string.IsNullOrEmpty(opcionais) && opcionais == "Airbag")
                {
                    query = query.Where(c => c.Airbag == true);
                }

                if (!string.IsNullOrEmpty(opcionais) && opcionais == "Alarme")
                {
                    query = query.Where(c => c.Alarme == true);
                }

                if (!string.IsNullOrEmpty(opcionais) && opcionais == "ArCondicionado")
                {
                    query = query.Where(c => c.ArCondicionado == true);
                }

                if (!string.IsNullOrEmpty(opcionais) && opcionais == "FreioABS")
                {
                    query = query.Where(c => c.FreioABS == true);
                }

                if (!string.IsNullOrEmpty(cor))
                {
                    query = query.Where(c => c.Cor == cor);
                }

                var carrosFiltrados = await query.ToListAsync();

                return _mapper.Map<List<ReadCarroDto>>(carrosFiltrados);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
