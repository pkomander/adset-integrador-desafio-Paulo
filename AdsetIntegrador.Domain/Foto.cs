using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdsetIntegrador.Domain
{
    public class Foto
    {
        [Key]
        [Required]
        public int FotoId { get; set; }
        public string Nome { get; set; }
        public List<CarroFoto>? CarroFotos { get; set; }
    }
}
