namespace OdontoCloud.Infrastructure.DTOs.DetalheAtendimento
{
    public class DetalheAtendimentoReadDTO
    {
        public int Id { get; set; }
        public int IdAtendimento { get; set; }
        public int IdItem { get; set; }
        public float QuantidadeItem { get; set; }
    }
}
