using AdsetIntegrador.DTO.Carro;
using AdsetIntegrador.DTO.Foto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdsetIntegrador.DTO.CarroFoto
{
    public class UpdateCarroFotoDto
    {
        public int CarroId { get; set; }
        public virtual ReadCarroDto Carro { get; set; }
        public int FotoId { get; set; }
        public virtual ReadFotoDto Foto { get; set; }
    }
}
