//using AdsetIntegrador.Domain;
using AdsetIntegrador.Domain;
using AdsetIntegrador.DTO.Carro;
using AdsetIntegrador.DTO.CarroFoto;
using AdsetIntegrador.DTO.Foto;
using AdsetIntegrador.Models;
using AdsetIntegrador.Repository.Data;
using AdsetIntegrador.Repository.Services.Interface;


//using AdsetIntegrador.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace AdsetIntegrador.Controllers
{
    public class CarroController : Controller
    {
        private readonly ICarroService _carroService;
        private readonly IFotoService _fotoService;
        private readonly ICarroFotoService _carroFotoService;

        public CarroController(ICarroService carroService, ICarroFotoService carroFotoService, IFotoService fotoService)
        {
            _carroService = carroService;
            _carroFotoService = carroFotoService;
            _fotoService = fotoService;
        }
        public async Task<IActionResult> Index(string? placa, string? marca, string? modelo, string? anoMin, string? anoMax, string? preco, string? foto, string? opcionais, string? cor)
        {
            var carrosViewbag = await _carroService.FindAll();
            var carrosFiltro = await _carroService.FindFiltro(placa, marca, modelo, anoMin, anoMax, preco, foto, opcionais, cor);

            var total = carrosViewbag.Count();
            var totalComFotos = carrosViewbag.Count(carro => carro.CarroFotos != null && carro.CarroFotos.Count > 0 && carro.CarroFotos[0].Foto != null);
            var totalSemFotos = carrosViewbag.Count(carro => carro.CarroFotos.Count() == 0);

            ViewBag.CoresComuns = new List<string> { "Todos", "Preto", "Branco", "Cinza", "Prata", "Vermelho", "Azul", "Verde", "Amarelo" };
            ViewBag.AnoMin = new List<string> { "Todos", "2000", "2001", "2002", "2003", "2004", "2005", "2006", "2007", "2008", "2009", "2010", "2011", "2012", "2013", "2014", "2015", "2016",
                                                "2017", "2018", "2019", "2020", "2021", "2022", "2023", "2024" };
            ViewBag.AnoMax = new List<string> { "Todos", "2000", "2001", "2002", "2003", "2004", "2005", "2006", "2007", "2008", "2009", "2010", "2011", "2012", "2013", "2014", "2015", "2016",
                                                "2017", "2018", "2019", "2020", "2021", "2022", "2023", "2024" };
            ViewBag.Preco = new List<string> { "Todos", "10mil", "50mil", "50mil", "Prata", "90mil", "+90mil" };
            ViewBag.Fotos = new List<string> { "Todos", "Com Fotos", "Sem Fotos" };
            ViewBag.Opcionais = new List<string> { "Ar Condicionado", "Alarme", "Airbag", "Freio ABS" };
            ViewBag.Total = total.ToString("D3");
            ViewBag.TotalComFotos = totalComFotos.ToString("D3");
            ViewBag.TotalSemFotos = totalSemFotos.ToString("D3");

            return View(carrosFiltro);
        }

        // GET: Carroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carro = await _carroService.FindById(id);
            if (carro == null)
            {
                return NotFound();
            }

            return View(carro);
        }

        // GET: Carroes/Create
        public IActionResult Create()
        {
            ViewBag.CoresComuns = new List<string> {"Preto", "Branco", "Cinza", "Prata", "Vermelho", "Azul", "Verde", "Amarelo" };
            return View();
        }

        // POST: Carroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CarroId,Marca,Modelo,Ano,Placa,Km,Cor,Preco,ArCondicionado,Alarme,Airbag,FreioABS,Imagens")] CreateCarroDto model)
        {
            try
            {
                var carro = await _carroService.Create(model);

                // Manipulação de arquivos de imagem
                if (model.Imagens != null && model.Imagens.Count < 15)
                {
                    foreach (var imagem in model.Imagens)
                    {
                        if (imagem.Length > 0)
                        {
                            string imageName = $"{DateTime.UtcNow.ToString("yymmssfff")}{Path.GetExtension(imagem.FileName)}";
                            var filePath = Path.Combine("wwwroot/uploads", imageName).Replace("\\", "/").Replace(" ", string.Empty);

                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await imagem.CopyToAsync(stream);
                                var foto = new CreateFotoDto
                                {
                                    Nome = imageName
                                };
                                var addFoto = await _fotoService.Create(foto);

                                var carroFoto = new CreateCarroFotoDto
                                {
                                    CarroId = carro.CarroId,
                                    FotoId = addFoto.FotoId
                                };
                                var addCarroFoto = await _carroFotoService.Create(carroFoto);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return RedirectToAction("Index");
        }

        // GET: Carroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carro = await _carroService.FindById(id);
            if (carro == null)
            {
                return NotFound();
            }

            ViewBag.CoresComuns = new List<string> {"Preto", "Branco", "Cinza", "Prata", "Vermelho", "Azul", "Verde", "Amarelo" };

            return View(carro);
        }

        // POST: Carroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CarroId,Marca,Modelo,Ano,Placa,Km,Cor,Preco,ArCondicionado,Alarme,Airbag,FreioABS,Imagens")] UpdateCarroDto model)
        {
            try
            {
                if (model == null)
                    return NotFound();

                var retorno = await _carroService.Update(id, model);

                // Manipulação de arquivos de imagem
                if (model.Imagens != null && model.Imagens.Count < 15)
                {
                    int contador = 0;
                    foreach (var imagem in model.Imagens)
                    {
                        if (imagem.Length > 0)
                        {
                            //deleta todas as fotos
                            if (contador == 0)
                            {
                                var fotos = await _carroFotoService.Delete(retorno.CarroId);
                                foreach (var item in fotos)
                                {
                                    await _fotoService.Delete(item.FotoId);
                                }
                            }   

                            string imageName = $"{DateTime.UtcNow.ToString("yymmssfff")}{Path.GetExtension(imagem.FileName)}";
                            var filePath = Path.Combine("wwwroot/uploads", imageName).Replace("\\", "/").Replace(" ", string.Empty);

                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await imagem.CopyToAsync(stream);
                                var foto = new CreateFotoDto
                                {
                                    Nome = imageName
                                };
                                var addFoto = await _fotoService.Create(foto);

                                var carroFoto = new CreateCarroFotoDto
                                {
                                    CarroId = retorno.CarroId,
                                    FotoId = addFoto.FotoId
                                };
                                var addCarroFoto = await _carroFotoService.Create(carroFoto);
                            }
                        }
                        contador++;
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: Carroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var retorno = await _carroService.FindById(id);

                if (retorno == null)
                    return NotFound();

                return View(retorno);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // POST: Carroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buscaCarro = await _carroService.FindById(id);

            if (buscaCarro != null)
            {
                var fotos = await _carroFotoService.Delete(buscaCarro.CarroId);
                foreach (var item in fotos)
                {
                    await _fotoService.Delete(item.FotoId);
                }
            }

            var carro = await _carroService.Delete(id);
            if (carro == true)
            {
                await _carroService.Delete(id);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
