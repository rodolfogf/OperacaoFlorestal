using System;
using OperacaoFlorestal.Data;
using OperacaoFlorestal.Models;

namespace OperacaoFlorestal.Strategies
{
    public class ColetaDadosVantStrategy : IColetaDadosStrategy
    {
        public object ColetarDados(Maquinario maquinario, OperacaoFlorestalContext context)
        {
            if (maquinario is MaquinarioVANT vant)
            {
                var dado = new DadoBrutoVant
                {
                    IdVoo = vant.Voos.First().Id,
                    CaminhoArquivo = $"/dados/vants/{Guid.NewGuid()}.laz",
                    DataProcessamento = DateTime.Now
                };

                context.DadosBrutosVant.Add(dado);
                context.SaveChanges();
                return dado;
            }

            throw new InvalidOperationException("Maquinário não é VANT");
        }

    }
}
