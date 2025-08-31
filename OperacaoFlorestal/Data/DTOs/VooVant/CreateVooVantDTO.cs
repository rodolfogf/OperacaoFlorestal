namespace OperacaoFlorestal.Data.DTOs.VooVant
{
    public class CreateVooVantDTO
    {
        public int Id { get; set; }
        public int IdMaquinario { get; set; }
        public int IdEquipe { get; set; }
        public DateTime DataInicioVoo { get; set; }
        public DateTime DataFimVoo { get; set; }
        public string? CondicoesClimaticas { get; set; }
        public string? TipoVoo { get; set; }
    }

}
