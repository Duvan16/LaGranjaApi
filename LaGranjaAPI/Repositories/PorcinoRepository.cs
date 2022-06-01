using LaGranjaAPI.Data;
using LaGranjaAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace LaGranjaAPI.Repositories
{
    public class PorcinoRepository : IPorcinoRepository
    {
        private readonly ApplicationDbContext context;

        public PorcinoRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Porcino> GetById(int id)
        {
            return await context.Porcinos.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<IQueryable<Porcino>> Get()
        {
            var Porcinos = await context.Porcinos
                .Include(x => x.Raza)
                .Include(x => x.Alimentacion)
                .Include(x => x.Cliente).ToListAsync();
            return Porcinos.AsQueryable();
        }

        public async Task<IQueryable<Porcino>> Filter(Porcino Porcino)
        {

            var PorcinosQueryable = await context.Porcinos
                .Include(x => x.Raza)
                .Include(x => x.Alimentacion)
                .Include(x => x.Cliente).ToListAsync();

            if (Porcino.ClienteId != 0)
            {
                PorcinosQueryable = PorcinosQueryable
                    .Where(x => x.ClienteId == Porcino.ClienteId).ToList();
            }

            if (Porcino.RazaId != 0)
            {
                PorcinosQueryable = PorcinosQueryable
                    .Where(x => x.RazaId == Porcino.RazaId).ToList();
            }

            return PorcinosQueryable.AsQueryable();
        }


        public async Task Create(Porcino Porcino)
        {
            context.Add(Porcino);
            await context.SaveChangesAsync();
        }

        public async Task Update(Porcino Porcino)
        {
            context.Porcinos.Update(Porcino);
            await context.SaveChangesAsync();
        }

        public async Task Delete(Porcino Porcino)
        {
            context.Remove(Porcino);
            await context.SaveChangesAsync();
        }
    }
}
