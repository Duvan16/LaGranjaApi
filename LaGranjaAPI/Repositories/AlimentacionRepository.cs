using LaGranjaAPI.Data;
using LaGranjaAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaGranjaAPI.Repositories
{
    public class AlimentacionRepository : IAlimentacionRepository
    {
        private readonly ApplicationDbContext context;

        public AlimentacionRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Alimentacion> GetById(int id)
        {
            return await context.Alimentaciones.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<IQueryable<Alimentacion>> Get()
        {
            var alimentaciones = await context.Alimentaciones.ToListAsync();
            return alimentaciones.AsQueryable();
        }

        public async Task Create(Alimentacion Alimentacion)
        {
            context.Add(Alimentacion);
            await context.SaveChangesAsync();
        }

        public async Task Update(Alimentacion Alimentacion)
        {
            context.Alimentaciones.Update(Alimentacion);
            await context.SaveChangesAsync();
        }

        public async Task Delete(Alimentacion Alimentacion)
        {
            context.Remove(Alimentacion);
            await context.SaveChangesAsync();
        }

    }
}
