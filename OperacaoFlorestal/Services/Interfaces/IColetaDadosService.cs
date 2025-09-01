namespace OperacaoFlorestal.Services.Interfaces
{
    public interface IColetaDadosService
    {
        Task<object> ColetarDadosAsync(int idMaquinario);
    }
}
