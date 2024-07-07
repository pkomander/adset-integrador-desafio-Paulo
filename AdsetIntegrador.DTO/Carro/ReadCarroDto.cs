using AdsetIntegrador.Business.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdsetIntegrador.DTO.CarroFoto;
using Microsoft.AspNetCore.Http;

namespace AdsetIntegrador.DTO.Carro
{
    public class ReadCarroDto
    {
        public int CarroId { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Ano { get; set; }
        public string Placa { get; set; }
        public long? Km { get; set; }
        public string Cor { get; set; }
        public decimal Preco { get; set; }
        public bool ArCondicionado { get; set; }
        public bool Alarme { get; set; }
        public bool Airbag { get; set; }
        public bool FreioABS { get; set; }
        public List<ReadCarroFotoDto>? CarroFotos { get; set; }
        public List<IFormFile>? Imagens { get; set; }
    }
}
