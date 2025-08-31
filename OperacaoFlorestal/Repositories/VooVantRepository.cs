using Microsoft.EntityFrameworkCore;
using OperacaoFlorestal.Data;
using OperacaoFlorestal.Models;
using OperacaoFlorestal.Repositories.Interfaces;

namespace OperacaoFlorestal.Repositories
{
    public class VooVantRepository : IVooVantRepository
    {
        private readonly OperacaoFlorestalContext _context;

        public VooVantRepository(OperacaoFlorestalContext context)
        {
            _context = context;
        }

        public async Task<VooVant> AddAsync(VooVant vooVant)
        {
            var result = await _context.VooVants.AddAsync(vooVant);

            await _context.SaveChangesAsync();
            
            return vooVant;
        }

        public async Task<VooVant?> UpdateAsync(VooVant vooVant)
        {
            if (!await ExistsByIdAsync(vooVant.Id))
            {
                return null;
            }

            _context.VooVants.Update(vooVant);

            await _context.SaveChangesAsync();
            return vooVant;
        }
        public async Task DeleteAsync(VooVant vooVant)
        {
            _context.VooVants.Remove(vooVant);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            return await _context
                .VooVants.AnyAsync(v => v.Id == id);
        }

        public async Task<IEnumerable<VooVant>> GetAllAsync(int skip, int take)
        {
            return await _context.VooVants
                .Skip(skip)
                .Take(take)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<VooVant?> GetByIdAsync(int id)
        {
            return await _context.VooVants
                .AsNoTracking()
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<IEnumerable<VooVant?>> GetByIdEquipeAsync(int idEquipe)
        {
            return await _context.VooVants
                .Where(v => v.IdEquipe == idEquipe)
                .ToListAsync();
        }

        public async Task<IEnumerable<VooVant?>> GetByIdMaquinario(int idMaquinario)
        {
            return await _context.VooVants
                .Where(v => v.IdEquipe == idMaquinario)
                .ToListAsync();
        }

        public async Task<int> CountAsync()
        {
            return await _context.VooVants.CountAsync();
        }

    }
}
