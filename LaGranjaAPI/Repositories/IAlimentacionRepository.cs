using LaGranjaAPI.DTOs;
using LaGranjaAPI.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaGranjaAPI.Repositories
{
    public interface IAlimentacionRepository
    {
        Task<Alimentacion> GetById(int id);
        Task<IQueryable<Alimentacion>> Get();
        Task Create(Alimentacion Alimentacion);
        Task Update(Alimentacion Alimentacion);
        Task Delete(Alimentacion Alimentacion);
    }
}
