using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdsetIntegrador.Domain
{
    public class CarroFoto
    {
        [Key]
        [Required]
        public int CarroFotoId { get; set; }
        public int CarroId { get; set; }
        public virtual Carro Carro { get; set; }
        public int FotoId { get; set; }
        public virtual Foto Foto { get; set; }
    }
}
