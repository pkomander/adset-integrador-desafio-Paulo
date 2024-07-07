using AdsetIntegrador.Business.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using AdsetIntegrador.DTO.CarroFoto;

namespace AdsetIntegrador.DTO.Carro
{
    public class UpdateCarroDto
    {
        [Required(ErrorMessage = "O campo Marca é obrigatorio")]
        [MaxLength(50)]
        public string Marca { get; set; }
        [Required(ErrorMessage = "O campo Modelo é obrigatorio")]
        [MaxLength(50)]
        public string Modelo { get; set; }
        [Required(ErrorMessage = "O campo Ano é obrigatorio")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "O ano deve ter 4 dígitos.")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "O ano deve ter exatamente 4 dígitos.")]
        public string Ano { get; set; }
        [Required(ErrorMessage = "O campo Placa é obrigatorio")]
        [PlacaValidation]
        public string Placa { get; set; }
        public long? Km { get; set; }
        [Required(ErrorMessage = "O campo Cor é obrigatorio")]
        public string Cor { get; set; }
        [Required(ErrorMessage = "O campo Preço é obrigatorio")]
        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        public decimal Preco { get; set; }
        [DisplayName("Ar Condicionado")]
        public bool ArCondicionado { get; set; }
        [DisplayName("Alarme")]
        public bool Alarme { get; set; }
        [DisplayName("Airbag")]
        public bool Airbag { get; set; }
        [DisplayName("Freio ABS")]
        public bool FreioABS { get; set; }
        public List<UpdateCarroFotoDto>? CarroFotos { get; set; }
        public List<IFormFile>? Imagens { get; set; }
    }
}
