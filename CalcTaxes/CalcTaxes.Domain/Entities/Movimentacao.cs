using CalcTaxes.Domain.Enum;

namespace CalcTaxes.Domain.Entities
{
    public class Movimentacao
    {
        public Guid Id { get; set; }
        public TipoMovimentacao tipoMovimentacao { get; set; }
        public DateTime data { get; set; }
        public decimal valor { get; set; }
        public Guid ClienteId { get; set; }
    }
}
