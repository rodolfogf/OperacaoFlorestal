using OperacaoFlorestal.Data;
using OperacaoFlorestal.Models;

namespace OperacaoFlorestal.Strategies
{
    public class ColetaDadosMaquinarioPesadoStrategy : IColetaDadosStrategy
    {
        public object ColetarDados(Maquinario maquinario, OperacaoFlorestalContext context)
        {
            if (maquinario is MaquinarioPesado mp)
            {
                var dado = new DadoBrutoMaquinario
                {
                    IdMaquinario = mp.Id,
                    CaminhoArquivo = $"/dados/maquinarios/{Guid.NewGuid()}.csv",
                    DataProcessamento = DateTime.Now,
                    TipoDado = "Geolocalizacao"
                };

                context.DadosBrutosMaquinario.Add(dado);
                context.SaveChanges();
                return dado;
            }
            throw new InvalidOperationException("Maquinário não é pesado");
        }
    }
}
