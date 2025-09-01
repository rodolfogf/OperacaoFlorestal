using OperacaoFlorestal.Models;

namespace OperacaoFlorestal.Services.Interfaces
{
    public interface IMaquinarioService
    {
        Task<Maquinario> AddMaquinarioAsync(Maquinario maquinario);
        Task<Maquinario?> UpdateMaquinarioAsync(int id, Maquinario maquinario);
        Task DeleteMaquinarioAsync(int id);
        Task<bool> ExistsMaquinarioByIdAsync(int id);
        Task<IEnumerable<Maquinario>> GetAllMaquinarioAsync(int skip, int take);
        Task<Maquinario?> GetMaquinarioById(int id);
    }
}
