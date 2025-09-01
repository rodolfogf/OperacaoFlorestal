using Microsoft.EntityFrameworkCore;
using OperacaoFlorestal.Data;
using OperacaoFlorestal.Models;
using OperacaoFlorestal.Repositories.Interfaces;

namespace OperacaoFlorestal.Repositories
{
    public class MaquinarioRepository : IMaquinarioRepository
    {
        private readonly OperacaoFlorestalContext _context;

        public MaquinarioRepository(OperacaoFlorestalContext context)
        {
            _context = context;
        }

        public async Task<Maquinario> AddAsync(Maquinario maquinario)
        {
            var result = await _context.Maquinarios.AddAsync(maquinario);

            await _context.SaveChangesAsync();

            return maquinario;
        }

        public async Task<Maquinario?> UpdateAsync(Maquinario maquinario)
        {
            if (!await ExistsByIdAsync(maquinario.Id))
            {
                return null;
            }

            _context.Maquinarios.Update(maquinario);

            await _context.SaveChangesAsync();
            return maquinario;
        }
        public async Task DeleteAsync(Maquinario maquinario)
        {
            _context.Maquinarios.Remove(maquinario);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            return await _context
                .Maquinarios.AnyAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Maquinario>> GetAllAsync(int skip, int take)
        {
            return await _context.Maquinarios
                .Include(m => m.Voos)
                .Skip(skip)
                .Take(take)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Maquinario?> GetByIdAsync(int id)
        {
            return await _context.Maquinarios
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Maquinario>> GetAllVantAsync(int skip, int take)
        {
            return await _context.Set<MaquinarioVANT>()
                .Include(m => m.Voos)
                .Skip(skip)
                .Take(take)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Maquinario>> GetAllPesadoAsync(int skip, int take)
        {
            return await _context.Set<MaquinarioPesado>()
                .Include(m => m.Voos)
                .Skip(skip)
                .Take(take)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<int> CountAsync()
        {
            return await _context.Maquinarios.CountAsync();
        }
    }
}
