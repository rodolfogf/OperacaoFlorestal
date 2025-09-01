namespace OperacaoFlorestal.Models
{
    public class DadoBrutoMaquinario
    {
        public int Id { get; set; }
        public int IdMaquinario { get; set; }
        public Maquinario Maquinario { get; set; } = null!;
        public string CaminhoArquivo { get; set; } = string.Empty;
        public DateTime DataProcessamento { get; set; }
        public string TipoDado { get; set; } = "Geolocalizacao";
    }
}
