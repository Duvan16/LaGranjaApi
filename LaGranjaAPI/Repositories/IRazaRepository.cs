using LaGranjaAPI.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace LaGranjaAPI.Repositories
{
    public interface IRazaRepository
    {
        Task<Raza> GetById(int id);
        Task<IQueryable<Raza>> Get();
        Task Create(Raza Raza);
        Task Update(Raza Raza);
        Task Delete(Raza Raza);
    }
}
