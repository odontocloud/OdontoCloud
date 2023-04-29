namespace OdontoCloud.Domain.Entities
{
    public class DetalheAtendimento
    {
        public DetalheAtendimento() { }

        public DetalheAtendimento(int id, int idAtendimento, int idItem, float quantidadeItem)
        {
            Id = id;
            IdAtendimento = idAtendimento;
            IdItem = idItem;
            QuantidadeItem = quantidadeItem;
        }

        public int Id { get; set; }
        public int IdAtendimento { get; set; }
        public int IdItem { get; set; }
        public float QuantidadeItem { get; set; }
    }
}
