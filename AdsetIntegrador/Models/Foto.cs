namespace AdsetIntegrador.Models
{
    public class Foto
    {
        public int FotoId { get; set; }
        public string Nome { get; set; }
        public List<CarroFoto>? CarroFotos { get; set; }
    }
}
