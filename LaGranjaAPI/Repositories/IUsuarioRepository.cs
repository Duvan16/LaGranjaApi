using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace LaGranjaAPI.Repositories
{
    public interface IUsuarioRepository
    {
        Task<IQueryable<IdentityUser>> Get();
    }
}
