namespace OperacaoFlorestal.Data.DTOs.Coleta
{
    public class ReadColetaDadosDTO
    {
        public int Id { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public string CaminhoArquivo { get; set; } = string.Empty;
        public DateTime DataProcessamento { get; set; }
    }
}
