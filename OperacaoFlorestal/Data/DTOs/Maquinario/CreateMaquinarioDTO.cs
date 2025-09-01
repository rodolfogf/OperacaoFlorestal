using NetTopologySuite.Geometries;
using OperacaoFlorestal.Models;

namespace OperacaoFlorestal.Data.DTOs.Maquinario
{
    public class CreateMaquinarioDTO
    {
        public int Id { get; set; }
        public string? TipoMaquinario { get; set; }
        public string? Modelo { get; set; }
        public StatusOperacional StatusOperacional { get; set; }
        public DateTime DataAquisicao { get; set; }
        public Point? LocalizacaoAtual { get; set; }
    }
}
