using LaGranjaAPI.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace LaGranjaAPI.Repositories
{
    public interface IClienteRepository
    {
        Task<Cliente> GetById(int id);
        Task<IQueryable<Cliente>> Get();
        Task Create(Cliente Cliente);
        Task Update(Cliente Cliente);
        Task Delete(Cliente Cliente);
    }
}
