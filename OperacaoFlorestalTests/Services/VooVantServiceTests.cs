using Moq;
using NetTopologySuite.Geometries;
using OperacaoFlorestal.Models;
using OperacaoFlorestal.Repositories.Interfaces;
using OperacaoFlorestal.Services;
using OperacaoFlorestal.Services.Interfaces;

namespace OperacaoFlorestalTests.Services
{
    public class VooVantServiceTests
    {
        [Fact]
        public async Task DeveAdicionarVooVant_QuandoMaquinarioExisteEÉVANT()
        {
            // Arrange
            var vooVant = new VooVant
            {
                Id = 1
                ,IdEquipe = 5
                ,IdMaquinario = 10
                ,DataInicioVoo = new DateTime(2025,9,1,8,0,0)
                ,DataFimVoo = new DateTime(2025,9,1,9,0,0)
                ,CondicoesClimaticas = "Céu limpo"
                ,TipoVoo = "Monitoramento"
                ,DadosBrutos = new List<DadoBrutoVant>()
            };

            var maquinarioVant = new MaquinarioVANT
            {
                Id = 10
                ,Modelo = "DJI Phantom 4"
                ,StatusOperacional = StatusOperacional.Ativo
                ,DataAquisicao = new DateTime(2023,5,10)
                ,LocalizacaoAtual = new Point(-45.123,-19.456) { SRID = 4326 }
                ,TipoDrone = TipoDrone.AsaFixa
            };

            var mockMaquinarioService = new Mock<IMaquinarioService>();
            mockMaquinarioService
                .Setup(s => s.GetMaquinarioById(vooVant.IdMaquinario))
                .ReturnsAsync(maquinarioVant);

            var mockVooVantRepository = new Mock<IVooVantRepository>();
            mockVooVantRepository
                .Setup(r => r.AddAsync(vooVant))
                .ReturnsAsync(vooVant);

            var service = new VooVantService(
                mockVooVantRepository.Object
                ,mockMaquinarioService.Object
            );

            // Act
            var resultado = await service.AddVooVantAsync(vooVant);

            // Assert
            Assert.NotNull(resultado);

            Assert.Equal(
                vooVant.Id
                ,resultado.Id
            );

            Assert.Equal(
                vooVant.IdEquipe
                ,resultado.IdEquipe
            );

            Assert.Equal(
                vooVant.IdMaquinario
                ,resultado.IdMaquinario
            );

            Assert.Equal(
                vooVant.DataInicioVoo
                ,resultado.DataInicioVoo
            );

            Assert.Equal(
                vooVant.DataFimVoo
                ,resultado.DataFimVoo
            );

            Assert.Equal(
                "Céu limpo"
                ,resultado.CondicoesClimaticas
            );

            Assert.Equal(
                "Monitoramento"
                ,resultado.TipoVoo
            );

            Assert.Empty(resultado.DadosBrutos);

            mockMaquinarioService.Verify(
                s => s.GetMaquinarioById(vooVant.IdMaquinario)
                ,Times.Once
            );
            mockVooVantRepository.Verify(
                r => r.AddAsync(vooVant)
                ,Times.Once
            );
        }


        [Fact]
        public async Task DeveLancarKeyNotFoundException_SeMaquinarioNaoExistir()
        {
            // Arrange
            var vooVant = new VooVant
            {
                Id = 1
                ,IdMaquinario = 99// ID inexistente
                ,IdEquipe = 5
                ,DataInicioVoo = DateTime.Now
                ,DataFimVoo = DateTime.Now.AddHours(1)
                ,CondicoesClimaticas = "Nublado"
                ,TipoVoo = "Reconhecimento"
            };

            var mockMaquinarioService = new Mock<IMaquinarioService>();
            mockMaquinarioService
                .Setup(s => s.GetMaquinarioById(vooVant.IdMaquinario))
                .ReturnsAsync((Maquinario?)null); // Simula maquinário inexistente

            var mockVooVantRepository = new Mock<IVooVantRepository>();

            var service = new VooVantService(
                mockVooVantRepository.Object
                ,mockMaquinarioService.Object
            );

            // Act & Assert
            var excecao = await Assert.ThrowsAsync<KeyNotFoundException>(() => service.AddVooVantAsync(vooVant));
            Assert.Equal(
                $"Maquinario com ID {vooVant.IdMaquinario} não encontrado."
                ,excecao.Message
            );

            mockMaquinarioService.Verify(s => 
                s.GetMaquinarioById(vooVant.IdMaquinario)
                ,Times.Once
            );

            mockVooVantRepository.Verify(r => 
                r.AddAsync(It.IsAny<VooVant>())
                ,Times.Never
            );
        }

    }
}
