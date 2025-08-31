using OperacaoFlorestal.Models;

namespace OperacaoFlorestal.Services.Interfaces
{
    public interface IVooVantService
    {
        Task<VooVant> AddVooVantAsync(VooVant vooVant);
        Task<VooVant?> UpdateVooVantAsync(int id, VooVant vooVant);
        Task DeleteVooVantAsync(int id);
        Task<bool> ExistsVooVantByIdAsync(int id);
        Task<IEnumerable<VooVant>> GetAllVooVantAsync(int skip, int take);
        Task<VooVant?> GetVooVantById(int id);
        Task<IEnumerable<VooVant?>> GetVooVantByIdEquipe(VooVant vooVant);
        Task<IEnumerable<VooVant?>> GetVooVantByIdMaquinario(VooVant vooVant);

    }
}
