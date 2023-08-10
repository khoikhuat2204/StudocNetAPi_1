using Microsoft.EntityFrameworkCore;
using StudocNetAPi_1.Models;

namespace StudocNetAPi_1.Repositories
{
    public class PokemonRepository : BaseRepository<Pokemon>
    {
        //public async Task<IQueryable<Pokemon>> GetPokemonsWithInclude()
        //{
        //    return _context.Set<Pokemon>()
        //        .Include(p => p.Reviews)
        //        .Include(p => p.PokemonCategories).ThenInclude(c => c.Category);
        //}

    }
}
