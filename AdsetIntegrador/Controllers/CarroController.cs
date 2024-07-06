//using AdsetIntegrador.Domain;
using AdsetIntegrador.Domain;
using AdsetIntegrador.DTO.Carro;
using AdsetIntegrador.DTO.CarroFoto;
using AdsetIntegrador.DTO.Foto;
using AdsetIntegrador.Repository.Services.Interface;


//using AdsetIntegrador.Models;
using Microsoft.AspNetCore.Mvc;

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
            var totalSemFotos = carrosViewbag.Count(carro => carro.CarroFotos == null && carro.CarroFotos.Count == 0 && carro.CarroFotos[0].Foto == null);

            ViewBag.CoresComuns = new List<string> { "Preto", "Branco", "Cinza", "Prata", "Vermelho", "Azul", "Verde", "Amarelo" };
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
                            string imageName = $"{imagem.FileName}{DateTime.UtcNow.ToString("yymmssfff")}{Path.GetExtension(imagem.FileName)}";
                            var filePath = Path.Combine("wwwroot/uploads", imageName);

                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await imagem.CopyToAsync(stream);
                                var foto = new CreateFotoDto
                                {
                                    Nome = filePath
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
    }
}
