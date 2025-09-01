using OperacaoFlorestal.Data;
using OperacaoFlorestal.Models;

namespace OperacaoFlorestal.Strategies
{
    public interface IColetaDadosStrategy
    {
        object ColetarDados(Maquinario maquinario, OperacaoFlorestalContext context);
    }
}
