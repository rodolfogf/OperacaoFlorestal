using NetTopologySuite.Geometries;

namespace OperacaoFlorestal.Models
{
    public class Maquinario
    {
        public int id { get; set; }
        public string? tipoMaquinario { get; set; }
        public string? modelo { get; set; }
        public StatusOperacional statusOperacional { get; set; }
        public DateTime dataAquisicao { get; set; }
        public Point? localizacaoAtual { get; set; }
    }
}
