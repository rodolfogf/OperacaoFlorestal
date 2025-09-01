namespace OperacaoFlorestal.Models
{
    public class DadoBrutoVant
    {
        public int Id { get; set; }
        public int IdVoo { get; set; }
        public VooVant Voo { get; set; } = null!;
        public string CaminhoArquivo { get; set; } = string.Empty;
        public DateTime DataProcessamento { get; set; }
    }
}
