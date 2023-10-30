namespace CalcTaxes.Domain.Entities
{
    public class Cliente
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string DocumentoFederal { get; set; }
        public Guid ContaId { get; set; }
    }
}
