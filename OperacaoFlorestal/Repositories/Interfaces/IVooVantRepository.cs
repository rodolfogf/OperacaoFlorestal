using OperacaoFlorestal.Models;

namespace OperacaoFlorestal.Repositories.Interfaces
{
    public interface IVooVantRepository
    {
        Task<VooVant> AddAsync(VooVant vooVant);
        Task<VooVant?> UpdateAsync(VooVant vooVant);
        Task DeleteAsync(VooVant vooVant);
        Task<bool> ExistsByIdAsync(int id);
        Task<IEnumerable<VooVant>> GetAllAsync(int skip, int take);
        Task<VooVant?> GetByIdAsync(int id);
        Task<IEnumerable<VooVant?>> GetByIdEquipeAsync(int idEquipe);
        Task<IEnumerable<VooVant?>> GetByIdMaquinario(int idMaquinario);
        Task<int> CountAsync();
    }
}
