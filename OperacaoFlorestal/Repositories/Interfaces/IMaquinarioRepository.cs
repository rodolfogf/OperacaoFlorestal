using OperacaoFlorestal.Models;
using System;

namespace OperacaoFlorestal.Repositories.Interfaces
{
    public interface IMaquinarioRepository
    {
        Task<Maquinario> AddAsync(Maquinario maquinario);
        Task<Maquinario?> UpdateAsync(Maquinario maquinario);
        Task DeleteAsync(Maquinario maquinario);
        Task<bool> ExistsByIdAsync(int id);
        Task<IEnumerable<Maquinario>> GetAllAsync(int skip, int take);
        Task<IEnumerable<Maquinario>> GetAllVantAsync(int skip, int take);
        Task<Maquinario?> GetByIdAsync(int id);
        Task<int> CountAsync();
    }   

}
