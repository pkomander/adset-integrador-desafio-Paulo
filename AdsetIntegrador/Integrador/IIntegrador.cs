using AdsetIntegrador.Models;

namespace AdsetIntegrador.Integrador
{
    public interface IIntegrador
    {
        Task<Carro> Create(Carro carroDto);
        Task<Carro> FindById(int id);
        Task<List<Carro>> FindAll();
        Task<Carro> Update(int id, Carro carroDto);
        Task<bool> Delete(int id);
    }
}
