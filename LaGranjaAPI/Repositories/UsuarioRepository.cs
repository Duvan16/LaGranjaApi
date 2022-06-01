using LaGranjaAPI.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace LaGranjaAPI.Repositories
{
    public class UsuarioRepository: IUsuarioRepository  
    {
        private readonly ApplicationDbContext context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<IQueryable<IdentityUser>> Get()
        {
            var users = await context.Users.ToListAsync();
            return users.AsQueryable();
        }
    }
}
