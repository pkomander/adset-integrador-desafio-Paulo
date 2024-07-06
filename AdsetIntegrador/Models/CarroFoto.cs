namespace AdsetIntegrador.Models
{
    public class CarroFoto
    {
        public int CarroFotoId { get; set; }
        public int CarroId { get; set; }
        public virtual Carro Carro { get; set; }
        public int FotoId { get; set; }
        public virtual Foto Foto { get; set; }
    }
}
