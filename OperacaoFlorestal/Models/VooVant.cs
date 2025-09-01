namespace OperacaoFlorestal.Models
{
    public class VooVant
    {
        public int Id { get; set; }
        public int IdEquipe { get; set; }
        public DateTime DataInicioVoo { get; set; }
        public DateTime DataFimVoo { get; set; }
        public string? CondicoesClimaticas { get; set; }
        public string? TipoVoo { get; set; }
        public int IdMaquinario { get; set; }
        public Maquinario? Maquinario { get; set; }
        public ICollection<DadoBrutoVant> DadosBrutos { get; set; } = new List<DadoBrutoVant>();
    }
}
