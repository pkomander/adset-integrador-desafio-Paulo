using AdsetIntegrador.Models;

namespace AdsetIntegrador.Integrador
{
    public class Integrador : IIntegrador
    {
        public Task<Carro> Create(Carro carroDto)
        {
            throw new NotImplementedException();
        }

        public Task<List<Carro>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<Carro> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Carro> Update(int id, Carro carroDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
