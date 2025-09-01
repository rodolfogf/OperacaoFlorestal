using Microsoft.EntityFrameworkCore;
using OperacaoFlorestal.Data;
using OperacaoFlorestal.Models;
using OperacaoFlorestal.Services.Interfaces;
using OperacaoFlorestal.Strategies;

namespace OperacaoFlorestal.Services
{
    public class ColetaDadosService : IColetaDadosService
    {
        private readonly OperacaoFlorestalContext _context;

        public ColetaDadosService(OperacaoFlorestalContext context)
        {
            _context = context;
        }

        public async Task<object> ColetarDadosAsync(int idMaquinario)
        {
            var maquinario = await _context.Maquinarios
                .Include(m => m.Voos)
                .FirstOrDefaultAsync(m => m.Id == idMaquinario);

            if (maquinario == null)
                throw new KeyNotFoundException("Maquinário não encontrado");

            IColetaDadosStrategy strategy;

            if (maquinario is MaquinarioVANT)
                strategy = new ColetaDadosVantStrategy();
            else if (maquinario is MaquinarioPesado)
                strategy = new ColetaDadosMaquinarioPesadoStrategy();
            else
                throw new InvalidOperationException("Tipo de maquinário não suportado");

            return strategy.ColetarDados(maquinario, _context);
        }
    }
}
