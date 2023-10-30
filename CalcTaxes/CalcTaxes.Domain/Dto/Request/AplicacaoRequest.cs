using CalcTaxes.Domain.Enum;

namespace CalcTaxes.Domain.Dto.Request
{
    public class AplicacaoRequest
    {
        public decimal Valor { get; set; }  
        public DateTime Data { get; set; }
        public Guid ClienteId { get; set; }
        public TipoMovimentacao TipoMovimentacao { get; set; }
    }
}
