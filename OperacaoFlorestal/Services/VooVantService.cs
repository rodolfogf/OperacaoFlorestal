using OperacaoFlorestal.Models;
using OperacaoFlorestal.Repositories.Interfaces;
using OperacaoFlorestal.Services.Interfaces;

namespace OperacaoFlorestal.Services
{
    public class VooVantService : IVooVantService
    {
        private readonly IVooVantRepository _vooVantRepository;

        public VooVantService(IVooVantRepository vooVantRepository)
        {
            _vooVantRepository ??= vooVantRepository;
        }

        public async Task<VooVant> AddVooVantAsync(VooVant vooVant)
        {
            try
            {
                return await _vooVantRepository.AddAsync(vooVant);
            }
            catch (Exception ex)
            {
                throw new HttpRequestException("Ocorreu um erro ao adicionar os dados de VooVant.", ex);
            }
        }

        public async Task<VooVant?> UpdateVooVantAsync(int id, VooVant vooVant)
        {
            VooVant? vooVantExistente; 
            
            if (id <= 0)
            {
                throw new ArgumentException("ID inválido");
            }

            if(vooVant == null || id != vooVant.Id)
            {
                throw new ArgumentNullException("Dados de VooVant inválidos");
            }

            vooVantExistente = await _vooVantRepository.UpdateAsync(vooVant);
            
            if(vooVantExistente == null)
            {
                throw new KeyNotFoundException($"VooVant com ID {vooVant.Id} não encontrado.");
            }

            return vooVantExistente;
        }

        public async Task DeleteVooVantAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID inválido");
            }

            var vooVant = await GetVooVantById(id);

            if (vooVant == null)
            {
                throw new KeyNotFoundException($"VooVant com ID {id} não encontrado.");
            }

            try
            {
                await _vooVantRepository.DeleteAsync(vooVant);
            }
            catch (Exception ex)
            {
                throw new HttpRequestException("Ocorreu um erro ao deletar os dados de VooVant.", ex);
            }
        }

        public async Task<bool> ExistsVooVantByIdAsync(int id)
        {
           return await _vooVantRepository.ExistsByIdAsync(id);
        }

        public async Task<IEnumerable<VooVant>> GetAllVooVantAsync(int skip, int take)
        {
            if (skip < 0 || take <= 0)
            {
                throw new ArgumentException("Parâmetros de paginação inválidos");
            }

            try
            {
                return await _vooVantRepository.GetAllAsync(skip, take);
            }
            catch (Exception ex)
            {
                throw new HttpRequestException("Ocorreu um erro ao obter os dados de VooVant.", ex);
            }
        }

        public async Task<VooVant?> GetVooVantById(int id)
        {
            VooVant? vooVant;

            try
            {
                vooVant = await _vooVantRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new HttpRequestException("Ocorreu um erro ao obter os dados de VooVant.", ex);
            }

            if (vooVant == null)
            {
                throw new KeyNotFoundException($"VooVant com ID {id} não encontrado.");
            }

            return vooVant;

        }

        public async Task<IEnumerable<VooVant?>> GetVooVantByIdEquipe(VooVant vooVant)
        {
            IEnumerable<VooVant?> vooVants;

            try
            {
                vooVants = await _vooVantRepository.GetByIdEquipeAsync(vooVant.IdEquipe);
            }
            catch (Exception ex)
            {
                throw new HttpRequestException("Ocorreu um erro ao obter os dados de VooVant.", ex);
            }

            if (!vooVants.Any())
            {
                throw new KeyNotFoundException($"Não foram encontrados voos de Vant com idEquipe {vooVant.IdEquipe}");
            }

            return vooVants;
        }

        public async Task<IEnumerable<VooVant?>> GetVooVantByIdMaquinario(VooVant vooVant)
        {
            IEnumerable<VooVant?> vooVants;
            try
            {
                vooVants = await _vooVantRepository.GetByIdMaquinario(vooVant.IdMaquinario);
            }
            catch (Exception ex)
            {
                throw new HttpRequestException("Ocorreu um erro ao obter os dados de VooVant.", ex);
            }
            if (!vooVants.Any())
            {
                throw new KeyNotFoundException($"Não foram encontrados voos de Vant com idMaquinario {vooVant.IdMaquinario}");
            }
            return vooVants;
        }
    }
}
