using LaGranjaAPI.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace LaGranjaAPI.Repositories
{
    public interface IPorcinoRepository
    {
        Task<Porcino> GetById(int id);
        Task<IQueryable<Porcino>> Get();
        Task<IQueryable<Porcino>> Filter(Porcino Porcino);
        Task Create(Porcino Porcino);
        Task Update(Porcino Porcino);
        Task Delete(Porcino Porcino);
    }
}
