using OperacaoFlorestal.Models;
using OperacaoFlorestal.Repositories.Interfaces;
using OperacaoFlorestal.Services.Interfaces;

namespace OperacaoFlorestal.Services
{
    public class MaquinarioService : IMaquinarioService
    {
        private readonly IMaquinarioRepository _maquinarioRepository;

        public MaquinarioService(IMaquinarioRepository maquinarioRepository)
        {
            _maquinarioRepository ??= maquinarioRepository;
        }

        public async Task<Maquinario> AddMaquinarioAsync(Maquinario maquinario)
        {
            try
            {
                return await _maquinarioRepository.AddAsync(maquinario);
            }
            catch (Exception ex)
            {
                throw new HttpRequestException("Ocorreu um erro ao adicionar os dados de Maquinario.", ex);
            }
        }

        public async Task<Maquinario?> UpdateMaquinarioAsync(int id, Maquinario maquinario)
        {
            Maquinario? maquinarioExistente;

            if (id <= 0)
            {
                throw new ArgumentException("ID inválido");
            }

            if (maquinario == null || id != maquinario.Id)
            {
                throw new ArgumentNullException("Dados de Maquinario inválidos");
            }

            maquinarioExistente = await _maquinarioRepository.UpdateAsync(maquinario);

            if (maquinarioExistente == null)
            {
                throw new KeyNotFoundException($"Maquinario com ID {maquinario.Id} não encontrado.");
            }

            return maquinarioExistente;
        }

        public async Task DeleteMaquinarioAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID inválido");
            }

            var maquinario = await GetMaquinarioById(id);

            if (maquinario == null)
            {
                throw new KeyNotFoundException($"Maquinario com ID {id} não encontrado.");
            }

            try
            {
                await _maquinarioRepository.DeleteAsync(maquinario);
            }
            catch (Exception ex)
            {
                throw new HttpRequestException("Ocorreu um erro ao deletar os dados de Maquinario.", ex);
            }
        }

        public async Task<bool> ExistsMaquinarioByIdAsync(int id)
        {
            return await _maquinarioRepository.ExistsByIdAsync(id);
        }

        public async Task<IEnumerable<Maquinario>> GetAllMaquinarioAsync(int skip, int take)
        {
            if (skip < 0 || take <= 0)
            {
                throw new ArgumentException("Parâmetros de paginação inválidos");
            }

            try
            {
                return await _maquinarioRepository.GetAllAsync(skip, take);
            }
            catch (Exception ex)
            {
                throw new HttpRequestException("Ocorreu um erro ao obter os dados do maquinário.", ex);
            }
        }

        public async Task<Maquinario?> GetMaquinarioById(int id)
        {
            Maquinario? maquinario;

            try
            {
                maquinario = await _maquinarioRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new HttpRequestException("Ocorreu um erro ao obter os dados do maquinário.", ex);
            }

            if (maquinario == null)
            {
                throw new KeyNotFoundException($"Maquinario com ID {id} não encontrado.");
            }

            return maquinario;
        }
    }
}

