using LaGranjaAPI.Data;
using LaGranjaAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace LaGranjaAPI.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext context;

        public ClienteRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Cliente> GetById(int id)
        {
            return await context.Clientes.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<IQueryable<Cliente>> Get()
        {
            var Clientees = await context.Clientes.ToListAsync();
            return Clientees.AsQueryable();
        }

        public async Task Create(Cliente Cliente)
        {
            context.Add(Cliente);
            await context.SaveChangesAsync();
        }

        public async Task Update(Cliente Cliente)
        {
            context.Clientes.Update(Cliente);
            await context.SaveChangesAsync();
        }

        public async Task Delete(Cliente Cliente)
        {
            context.Remove(Cliente);
            await context.SaveChangesAsync();
        }
    }
}
