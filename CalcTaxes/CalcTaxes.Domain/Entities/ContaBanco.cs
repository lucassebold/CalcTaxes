using CalcTaxes.Domain.Dto.Request;

namespace CalcTaxes.Domain.Entities
{
    public class ContaBanco
    {
        public Guid Id { get; set; }
        public string Agencia { get; set; }
        public string Conta { get; set; }
        public decimal Saldo { get; set; }

        private readonly DbContext _dbContext;

        public ContaBanco(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AdicionaSaldo(decimal valor)
        {
            Saldo += valor;
        }

        public void RemoveSaldo(AplicacaoRequest aplicacaoRequest)
        {
            var queryUpdateSaldo = @"UPDATE cb
                                    SET c.saldo = @p0
                                    FROM ContaBanco cb
                                    INNER JOIN Cliente c
                                    ON cb.Id = c.contaId
                                    WHERE c.Id = @p1";

            _dbContext.Execute(queryUpdateSaldo, new { p0 = aplicacaoRequest.Valor, p1 = aplicacaoRequest.ClienteId });
        }
    }
}
