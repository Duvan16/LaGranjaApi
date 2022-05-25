using LaGranjaAPI.Data;
using LaGranjaAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace LaGranjaAPI.Repositories
{
    public class RazaRepository : IRazaRepository
    {
        private readonly ApplicationDbContext context;

        public RazaRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Raza> GetById(int id)
        {
            return await context.Razas.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<IQueryable<Raza>> Get()
        {
            var Razaes = await context.Razas.ToListAsync();
            return Razaes.AsQueryable();
        }

        public async Task Create(Raza Raza)
        {
            context.Add(Raza);
            await context.SaveChangesAsync();
        }

        public async Task Update(Raza Raza)
        {
            context.Razas.Update(Raza);
            await context.SaveChangesAsync();
        }

        public async Task Delete(Raza Raza)
        {
            context.Remove(Raza);
            await context.SaveChangesAsync();
        }
    }
}
